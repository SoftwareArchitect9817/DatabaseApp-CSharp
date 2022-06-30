using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

using System.Data;

namespace Senaka.lib
{
    public enum GLASS
    {
        ORDER_DATE = 0,
        LIST_DATE,
        SEALED_UNIT_ID,
        OT,
        WINDOW_TYPE,
        LINE_1,
        LINE_2,
        LINE_3,
        GRILLS,
        SPACER,
        DEALER,
        GLASS_COMMENT,
        TAG,
        ZONES,
        U_VALUE,
        SOLAR_HEAT_GAIN,
        VISUAL_TRASMITTANCE,
        ENERGY_RATING,
        GLASS_TYPE,
        ORDER,
        WIDTH,
        HEIGHT,
        QTY,
        DESCRIPTION,
        NOTE_1,
        NOTE_2,
        RACK_ID,
        COMPLETE,
        SHIPPING
    }
    public enum IG_SORTING
    {
        ID = 0, SEALED_UNIT_ID, DATE, TIME, NAME, RACK_ID
    }
    public enum IG_SHIPPING
    {
        ID = 0, SEALED_UNIT_ID, DATE, TIME, NAME, RACK_ID
    }
    public enum PREFIX
    {
        ID = 0, PREFIX, DEPARTMENT, NAME, NOTE
    }
    public enum SETTINGS
    {
        ID = 0, USER, KEY_NAME, KEY_VALUE
    }
    public enum TYPES
    {
        ID = 0, TYPE, VALUE
    }
    public static class DB
    {
        private static MySqlConnection connection;
        static List<string[]> settingsTable = new List<string[]>();
        //Initialize values	
        public static void initialize(string server, string database, string username, string password)
        {
            server = "127.0.0.1"; database = "u370015874_test"; username = "root"; password = "";
            string connectionString;
            connectionString = "SERVER='" + server + "';" + "DATABASE='" + database + "';"
                + "UID='" + username + "';" + "PASSWORD='" + password + "';SSL Mode=None";
            connection = new MySqlConnection(connectionString);
        }

        //open connection to database	
        private static bool openDB()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show("Error: MySQL server error!");
                        break;
                }
                return false;
            }
        }

        //Close connection	
        private static bool closeDB()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private static int excuteSQL(string query)
        {
            int result = 1;
            if (connection.State == ConnectionState.Open || openDB() == true)
            {
                result = 0;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                if (cmd.ExecuteNonQuery() != 1) result = 1;
                closeDB();
            }
            return result;
        }

        private static string[] fetchRow(string query, bool id = true)
        {
            string[] result = null;
            if (connection.State == ConnectionState.Open || openDB() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows)
                {
                    List<string> row = new List<string>();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (!id && i == 0) continue;
                        if (dataReader.IsDBNull(i)) row.Add(null);
                        else row.Add(dataReader.GetString(i));
                    }
                    result = row.ToArray();
                }
                dataReader.Close();
                closeDB();
            }
            return result;
        }

        public static string[] fetchRow(string table, string field, string value, bool id = true)
        {
            string query = "SELECT * FROM `" + table + "` WHERE `" + field + "` = '" + value + "'";
            return fetchRow(query, id);
        }

        private static string[] fetchOrCreate(string table, string field, string value, string target_field, int target_index, string default_value = "")
        {
            string[] row = null;
            string query;
            if ((row = fetchRow(table, field, value)) != null)
            {
                if (row[target_index] == "" && default_value != "")
                {
                    row[target_index] = default_value;
                    query = "UPDATE `" + table + "` SET `" + target_field + "` = '" + default_value +
                        "' WHERE `" + field + "` = '" + value + "'";
                    excuteSQL(query);
                }
            }
            else
            {
                query = "INSERT INTO `" + table + "` (`" + field + "`, `" + target_field + "`) " +
                    "VALUES ('" + value + "', '" + default_value + "')";
                excuteSQL(query);
                row = fetchRow(table, field, value);
            }
            return row;
        }

        private static List<string[]> fetchRows(string query, bool id = true)
        {
            List<string[]> list = new List<string[]>();
            if (connection.State == ConnectionState.Open || openDB() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    List<string> record = new List<string>();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (!id && i == 0) continue;
                        if (dataReader.IsDBNull(i)) record.Add(null);
                        else record.Add(dataReader.GetString(i));
                    }
                    list.Add(record.ToArray());
                }
                dataReader.Close();
                closeDB();
            }
            return list;
        }

        public static List<string[]> fetchRows(string table, string field, string value, bool id = true)
        {
            string query = "SELECT * FROM `" + table + "` WHERE `" + field + "` = '" + value + "'";
            return fetchRows(query, id);
        }

        public static List<string[]> fetchRows(string table, string field, string[] values, bool id = true)
        {
            string query = "SELECT * FROM `" + table + "` WHERE `" + field + "` IN ('" + string.Join("','", values) + "')";
            return fetchRows(query, id);
        }

        public static List<string[]> fetchRows(string table, string field, List<string> values, bool id = true)
        {
            string query = "SELECT * FROM `" + table + "` WHERE `" + field + "` IN ('" + string.Join("','", values) + "')";
            return fetchRows(query, id);
        }

        public static List<string[]> fetchRows(string table, string field, string value, string[] orderBy, bool id = true)
        {
            string query = "SELECT * FROM `" + table + "` WHERE `" + field + "` = '" + value + "' ORDER BY `" + orderBy[0] + "` " + orderBy[1];
            return fetchRows(query, id);
        }

        public static List<string[]> fetchAllRows(string table, bool id = true)
        {
            string query = "SELECT * FROM `" + table + "`";
            return fetchRows(query, id);
        }

        public static int deleteRows(string table, string field, string value)
        {
            string query = "DELETE FROM `" + table + "` WHERE `" + field + "` = '" + value + "'";
            return excuteSQL(query);
        }

        public static int deleteRows(string table, string field, string[] values)
        {
            string query = "SELECT * FROM `" + table + "` WHERE `" + field + "` IN ('" + string.Join("','", values) + "')";
            return excuteSQL(query);
        }

        public static int deleteRows(string table, string field, List<string> values)
        {
            string query = "DELETE FROM `" + table + "` WHERE `" + field + "` IN ('" + string.Join("','", values) + "')";
            return excuteSQL(query);
        }

        public static void updateRow(string table, string field, string key, string target_field, string value)
        {
            string query = "UPDATE `" + table + "` SET `" + target_field + "` = '" + value + "' WHERE `" + field + "` = '" + key + "'";
            excuteSQL(query);
        }

        private static string[] dateRangeToStringArray(DateTime[] date)
        {
            int diff = (date[1] - date[0]).Days + 1, i = 0;
            string[] parameters = new string[diff * 5];
            for (DateTime day = date[0]; day.CompareTo(date[1]) <= 0; day = day.AddDays(1))
            {
                parameters[i * 5] = day.ToString("dd-MMM-yy");
                parameters[i * 5 + 1] = day.ToString("d-MMM-yy");
                parameters[i * 5 + 2] = day.ToString("dd MMMM yyyy");
                parameters[i * 5 + 3] = day.ToString("d MMMM yyyy");
                parameters[i * 5 + 4] = day.ToString("yyyyMMdd");
                i++;
            }
            return parameters;
        }

        public static List<string[]> importGlassByListDate(DateTime? date)
        {
            string query = null;
            if (date != null)
            {
                query = "SELECT * FROM `glassreport` WHERE (`list_date` = '" + date.Value.ToString("dd-MMM-yy") + "' OR `list_date` = '" + date.Value.ToString("d-MMM-y") +
                    "' OR `list_date` = '" + date.Value.ToString("dd MMMM yyyy") + "' OR `list_date` = '" + date.Value.ToString("d MMMM yyyy") + "') And (`rack_id` IS NULL OR `rack_id`='')";
            }
            return fetchRows(query, false);
        }

        public static List<string[]> importFrameReport(string order)
        {
            string query = null;
            if (order != null && order.Length > 0)
            {
                query = "SELECT `QTY`,`LINE #1` FROM `framereport` WHERE `LINE #1` LIKE '%" + order + "%'";
                //  query = "SELECT `QTY`,`LINE #1` FROM `framereport` WHERE `LINE #1` LIKE '%" + order + "%' AND  (`W.TYPE` = '" + string.Join("' OR `W.TYPE` = '", type) + "')";
                // formatted = String.Format(query, String.Join(",`", type));
                //query = "SELECT * FROM `framereport` WHERE ('W.Type = '"+ type+") AND ('LINE #1' LIKE %" + order+"%)";
            }
            return fetchRows(query, false);
        }

        public static List<string[]> importFrameReportbyLine(string order)
        {
            string query = null;
            if (order != null && order.Length > 0)
            {
                query = "SELECT * FROM `framereport` WHERE `LINE #1` LIKE '%" + order + "%'";
            }
            return fetchRows(query, false);
        }

        public static List<string[]> importGlassReportByOrder(string[] order)
        {
            if (order != null && order.Length > 0)
            {
                return fetchRows("glassreport", "order", order);
            }
            return null;
        }

        public static List<string[]> importFrameClearingByIds(List<string> ids)
        {
            string query = null;
            if (ids != null && ids.Count > 0)
            {
                query = "SELECT * FROM `FrameClearing` WHERE `Id`  IN ('" + string.Join("' , '", ids) + "')";
                return fetchRows(query, true);
            }
            return null;

        }

        public static List<string[]> importFrameClearingPrefixByNames(List<string> names)
        {
            string query = null;
            if (names != null && names.Count > 0)
            {
                query = "SELECT * FROM `FrameClearing_prefix` WHERE `name` IN ('" + string.Join("' , '", names) + "')";
            }
            return fetchRows(query, true);
        }

        public static List<string[]> importcolourShippingPrefixByNames(List<string> names)
        {
            string query = null;
            if (names != null && names.Count > 0)
            {
                query = "SELECT * FROM `ColourShipping_prefix` WHERE `name`  IN ('" + string.Join("' , '", names) + "')";
            }
            return fetchRows(query, true);
        }

        public static List<string[]> importWindowsAssemblyByIds(List<string> ids)
        {
            string query = null;
            if (ids != null && ids.Count > 0)
            {
                query = "SELECT * FROM `windowsassembly` WHERE `Line_number` IN ('" + string.Join("' , '", ids) + "') ";
                return fetchRows(query, true);
            }
            return null;
        }

        public static List<string[]> importCasementHardwareByIds(List<string> ids)
        {
            string query = null;
            if (ids != null && ids.Count > 0)
            {
                query = "SELECT * FROM `CasementHardware` WHERE `Id`  IN ('" + string.Join("' , '", ids) + "') ";
            }
            return fetchRows(query, true);
        }

        public static List<string[]> importColourReceivingByIds(List<string> ids)
        {
            string query = null;
            if (ids != null && ids.Count > 0)
            {
                query = "SELECT * FROM `ColourReceiving` WHERE `Id`  IN ('" + string.Join("' , '", ids) + "')";
                return fetchRows(query, true);
            }
            return null;
        }

        public static List<string[]> importColourShippingByIds(List<string> ids)
        {
            string query = null;
            if (ids != null && ids.Count > 0)
            {
                query = "SELECT `Id`, DATE_FORMAT(Date,'%Y-%m-%d'),`Time`,`Name` FROM `ColourShipping` WHERE `Id`  IN ('" + string.Join("' , '", ids) + "')";
                return fetchRows(query, true);
            }
            return null;
        }

        public static List<string[]> LogIn(string username, string password)
        {
            string query = null;
            if (username != null && password != null)
            {
                query = "SELECT * FROM `Accounts` WHERE (`Username` = '" + username + "' AND `Password` = '" + password + "') ";
            }
            return fetchRows(query, true);
        }

        public static List<string[]> importAccounts()
        {
            string query = null;
            query = "SELECT * FROM `Accounts`";
            return fetchRows(query, true);
        }

        public static List<string[]> importAccountByUserNameandId(string username, int id)
        {
            string query = null;
            query = "SELECT * FROM `Accounts` WHERE (`Username` = '" + username + "') AND (`id` != '" + id + "') ";
            return fetchRows(query, false);
        }

        public static List<string[]> importAccountByUserName(string username)
        {
            string query = null;
            query = "SELECT * FROM `Accounts` WHERE (`Username` = '" + username + "')";
            return fetchRows(query, false);
        }

        public static List<string[]> importGlassReportByOrderAndType(string order, string[] type)
        {
            string query = null;
            if (order != null && order.Length > 0)
            {
                query = "SELECT `list_date`, `sealed_unit_id` FROM `glassreport` WHERE (`order` = '" + order + "') AND  (`window_type` = 'Window_Type_" + string.Join("' OR `window_type` = 'Window_Type_", type) + "')";
            }
            return fetchRows(query, false);
        }

        public static List<string[]> importIgSorting(List<string> unit_ids)
        {
            string query = null;
            if (unit_ids != null && unit_ids.Count > 0)
            {
                query = "SELECT * FROM `ig_sorting` WHERE `sealed_unit_id`  IN ('" + string.Join("' , '", unit_ids) + "')";
                return fetchRows(query, false);
            }
            return null;
        }

        public static List<string[]> importGlassByOrder(string[] order)
        {
            string query = null;
            if (order != null && order.Length > 0)
            {
                query = "SELECT * FROM `glassreport` WHERE `order`  IN ('" + string.Join("' , '", order) + "') AND (`rack_id` IS NULL OR `rack_id`='')";
            }
            return fetchRows(query, false);
        }

        public static List<string[]> importWindowsAssembly(string line_number)
        {
            string query = null;
            if (line_number != null && line_number.Length > 0)
            {
                query = "SELECT * FROM `windowsassembly` WHERE (`Line_number` = '" + line_number + "') ";
            }
            return fetchRows(query, false);
        }

        public static List<string[]> importProductionReport(string order_numb)
        {
            string query = null;
            if (order_numb != null)
            {
                query = "SELECT * FROM `productionreport` WHERE (`ORDER` = '" + order_numb + "') ";
            }
            return fetchRows(query, true);
        }

        public static List<string[]> importWorkOrderbyPO(string po)
        {
            string query = null;
            if (po != null)
            {
                query = "SELECT * FROM `workorder` WHERE (`PO` = '" + po + "') ";
            }
            return fetchRows(query, false);
        }

        public static List<string[]> importWorkOrderbyOrderNumb(string order_numb)
        {
            string query = null;
            if (order_numb != null)
            {
                query = "SELECT * FROM `workorder` WHERE (`ORDER #` = '" + order_numb + "') ";
            }
            return fetchRows(query, false);
        }

        public static List<string[]> importGlassyOrderNumb(string order_numb)
        {
            string query = null;
            if (order_numb != null)
            {
                query = "SELECT * FROM `glassreport` WHERE (`order` = '" + order_numb + "') ";
            }
            return fetchRows(query, false);
        }

        public static List<string[]> importWindowsAssemblyByListLine(List<string> line_numbers)
        {
            string query = null;
            if (line_numbers != null && line_numbers.Count > 0)
            {
                query = "SELECT `Line_number` FROM `windowsassembly` WHERE `Line_number` IN ('" + string.Join("' , '", line_numbers) + "')";
                return fetchRows(query, false);
            }
            else return null;
        }

        public static List<string[]> getFrameClearing(List<string> numbers)
        {
            string query = null;
            if (numbers != null)
            {
                query = "SELECT * FROM `FrameClearing` WHERE `Id` IN ('" + string.Join("' , '", numbers) + "')";
                return fetchRows(query, true);
            }
            else return null;
        }

        public static List<string[]> getColourShippingDelivered(List<string> numbers)
        {
            string query = null;
            if (numbers != null)
            {
                query = "SELECT * FROM `ColourShipping` WHERE `Id` IN ('" + string.Join("' , '", numbers) + "')";
                return fetchRows(query, true);
            }
            else return null;
        }

        public static int updateGlassByListDate(DateTime? date, string sealed_unit_id, string rack_id)
        {
            int result = 1;
            if (date != null)
            {
                string query = "UPDATE `glassreport` SET `rack_id` = '" + rack_id + "' WHERE (`list_date` = '" + date.Value.ToString("dd-MMM-yy") + "' OR `list_date` = '" + date.Value.ToString("d-MMM-y") +
                    "' OR `list_date` = '" + date.Value.ToString("dd MMMM yyyy") + "' OR `list_date` = '" + date.Value.ToString("d MMMM yyyy") + "') AND `sealed_unit_id` = '" + sealed_unit_id + "'";
                result = excuteSQL(query);
            }
            return result;
        }

        public static int updateGlassByBatch(string batch, string sealed_unit_id, string rack_id)
        {
            int result = 1;
            if (batch != null && batch.Length > 0)
            {
                string query = "UPDATE `glassreport` SET  `rack_id` = '" + rack_id + "' WHERE (`note2` = '"+ batch + "') AND `sealed_unit_id` = '" + sealed_unit_id + "'";
                result = excuteSQL(query);
            }
            return result;
        }

        public static int updateGlassByOrder(int i, string[] order, string sealed_unit_id, string rack_id)
        {
            int result = 1;
            if (order != null && order.Length > 0)
            {
                string query = "UPDATE `glassreport` SET  `rack_id` = '" + rack_id + "' WHERE (`order` = '" + string.Join("' OR `order` = '", order) + "') AND `sealed_unit_id` = '" + sealed_unit_id + "'";
                result = excuteSQL(query);
            }
            return result;
        }

        public static int saveOptimizeGlass(string[] record, string rack_id)
        {
            int result = 1;
            if (fetchRow("glassreport", "sealed_unit_id", record[(int)GLASS.SEALED_UNIT_ID]) == null)
            {
                string query = "INSERT INTO `glassreport` (`order_date`, `list_date`, `sealed_unit_id`, `ot`, `window_type`, `line1`, `line2`, `line3`, `grills`, `spacer`, `dealer`, `glass_comment`, `tag`, `zones`, `u_value`, `solar_heat_gain`, `visual_trasmittance`, `energy_rating`, `glass_type`, `order`, `width`, `height`, `qty`, `description`, `note1`, `note2`, `rack_id`) " +
                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '" + rack_id + "')";
                query = string.Format(query, record).Replace("\\", "\\\\");
                result = excuteSQL(query);
            }
            return result;
        }

        public static string[] importOptimizedGlass(string field, string value, bool id = true)
        {
            string query = "SELECT * FROM `glassreport` WHERE `" + field + "` = '" + value + "' AND `rack_id` IS NOT NULL";
            return fetchRow(query, id);
        }

        public static void completeGlassBySealedUnit(string sealed_unit_id)
        {
            string query = "UPDATE `glassreport` SET `complete` = 1 WHERE `sealed_unit_id` = '" + sealed_unit_id + "'";
            excuteSQL(query);
        }

        public static void shippingCompleteGlassBySealedUnit(string sealed_unit_id)
        {
            string query = "UPDATE `glassreport` SET `shipping` = 1 WHERE `sealed_unit_id` = '" + sealed_unit_id + "'";
            excuteSQL(query);
        }

        public static List<string[]> importGlassByListDate(DateTime[] date, string key = null, string value = null)
        {
            string query = null;
            if (date.Length > 0)
            {
                string[] parameters = dateRangeToStringArray(date);
                string additional = "";
                if (key != null && value != null)
                {
                    additional = " AND `" + key + "` = '" + value + "'";
                }
                query = "SELECT * FROM `glassreport` WHERE `list_date`  IN ('" + string.Join("' , '", parameters) + "')";
            }
            return fetchRows(query, false);
        }

        public static List<string[]> importGlassReportByListDate(DateTime[] date, string key = null, string value = null)
        {
            string query = null;
            if (date.Length > 0)
            {
                string[] parameters = dateRangeToStringArray(date);
                string additional = "";
                if (key != null && value != null)
                {
                    additional = " AND `" + key + "` = '" + value + "'";
                }
                query = "SELECT * FROM `glassreport` WHERE `list_date` IN ('" + string.Join("' , '", parameters) + "')";
            }
            return fetchRows(query, false);
        }

        public static List<string[]> importGlassByOrderDate(DateTime[] date)
        {
            string query = null;
            if (date.Length > 0)
            {
                string[] parameters = dateRangeToStringArray(date);
                query = "SELECT * FROM `glassreport` WHERE `order_date`  IN ('" + string.Join("' , '", parameters) + "')";
            }
            return fetchRows(query, false);
        }

        public static List<string[]> importGlassByRushOrder(DateTime[] date)
        {
            string query = null;
            if (date.Length > 0)
            {
                string[] parameters = dateRangeToStringArray(date);
                query = "SELECT * FROM `glassreport` WHERE `order_date` IN ('" + string.Join("' , '", parameters) + "') And `description` = 'RUSH'";
            }
            return fetchRows(query, false);
        }

        public static List<string[]> importIncompleteOrdersGlass()
        {
            string query = "SELECT * FROM `glassreport` WHERE `order` IN (SELECT `order` FROM `glassreport` WHERE `complete`='0' GROUP BY `order`)";
            return fetchRows(query, false);
        }

        public static int saveIGSortingData(string sealed_unit_id, string date, string time, string name)
        {
            string query = "INSERT INTO `ig_sorting` (`sealed_unit_id`, `date`, `time`, `name`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}')";
            query = string.Format(query, sealed_unit_id, date, time, name);
            int result = excuteSQL(query);
            return result;
        }

        public static int saveFrameClearingData(string id, string date, string time, string name)
        {
            string query = "INSERT INTO `FrameClearing` (`id`, `date`, `time`, `name`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}')";
            query = string.Format(query, id, date, time, name);
            int result = excuteSQL(query);
            return result;
        }

        public static int saveColourShippingData(string id, string date, string time, string name, string batch_number)
        {
            string query = "INSERT INTO `ColourShipping` (`id`, `date`, `time`, `name`, `batch_number`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
            query = string.Format(query, id, date, time, name, batch_number);
            int result = excuteSQL(query);
            return result;
        }

        public static int saveColourReceivingData(string id, string date, string time, string name, string batch_number)
        {
            string query = "INSERT INTO `ColourReceiving` (`id`, `date`, `time`, `name`,`batch_number`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
            query = string.Format(query, id, date, time, name,batch_number);
            int result = excuteSQL(query);
            return result;
        }

        public static int saveCasementHardwareData(string id, string date, string time, string name)
        {
            string query = "INSERT INTO `CasementHardware` (`id`, `date`, `time`, `name`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}')";
            query = string.Format(query, id, date, time, name);
            int result = excuteSQL(query);
            return result;
        }

        public static int saveIGShippingData(string sealed_unit_id, string date, string time, string name)
        {
            string query = "INSERT INTO `ig_shipping` (`sealed_unit_id`, `date`, `time`, `name`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}')";
            query = string.Format(query, sealed_unit_id, date, time, name);
            int result = excuteSQL(query);
            return result;
        }

        public static int saveWindowsAssemblyData(string Line_number, string date, string time, string name)
        {
            string query = "INSERT INTO `windowsassembly` (`Line_number`, `Date`, `Time`, `Name`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}')";
            query = string.Format(query, Line_number, date, time, name);
            int result = excuteSQL(query);
            return result;
        }

        public static List<string[]> getWindowType(string category, string[] default_value = null)
        {
            string query = "SELECT * FROM `types` WHERE `type` = '" + category + "'";
            List<string[]> types = fetchRows(query);
            if (types.Count == 0 && default_value != null)
            {
                foreach (string value in default_value)
                {
                    query = "INSERT INTO `types` (`type`, `value`) VALUES ('" + category + "', '" + value + "')";
                    excuteSQL(query);
                }
                query = "SELECT * FROM `types` WHERE `type` = '" + category + "'";
                types = fetchRows(query);
            }
            return types;
        }

        public static List<string[]> getFrameTypes()
        {
            string query = "SELECT * FROM `frame_types`";
            List<string[]> types = fetchRows(query);
            return types;
        }

        public static void saveWindowType(string category, List<string[]> value)
        {
            string query = "DELETE FROM `types` WHERE `type` = '" + category + "'";
            excuteSQL(query);
            query = "INSERT INTO `types` (`id`, `type`, `value`) VALUE ";
            foreach (string[] data in value)
            {
                query += string.Format(" ('{0}', '{1}', '{2}'),", data);
            }
            query = query.Remove(query.Length - 1);
            excuteSQL(query);
        }

        public static void saveFrameTypes(string category, List<string[]> value)
        {
            string query = "DELETE FROM `frame_types` WHERE `type` = '" + category + "'";
            excuteSQL(query);
            query = "INSERT INTO `frame_types` (`id`, `type`, `value`) VALUE ";
            foreach (string[] data in value)
            {
                query += string.Format(" ('{0}', '{1}', '{2}'),", data);
            }
            query = query.Remove(query.Length - 1);
            excuteSQL(query);
        }

        public static List<string[]> getSUHistory()
        {
            string query = "SELECT * FROM `su_history`";
            return fetchRows(query);
        }

        public static void saveSUHistory(List<string[]> value)
        {
            string query = "DELETE FROM `su_history`";
            excuteSQL(query);
            foreach (string[] data in value)
            {
                query = string.Format("INSERT INTO `su_history` (`letter`, `count`, `category`) VALUE" +
                    " ('{0}', '{1}', '{2}')", data);
                excuteSQL(query);
            }
        }

        public static void addSUShipping(string rack_id, int category, int qty)
        {
            string query = string.Format("INSERT INTO `su_shipping` (`rack_id`, `category`, `qty`) " +
                "VALUE ('{0}', '{1}', '{2}')", rack_id, category, qty);
            excuteSQL(query);
        }

        public static List<string[]> getSUShipping()
        {
            string query = "SELECT * FROM `su_shipping`";
            return fetchRows(query);
        }

        public static void saveSUShipping(List<string[]> value)
        {
            string query = "DELETE FROM `su_shipping`";
            excuteSQL(query);
            int index = 0;
            if (value.Count != 0)
            {
                query = "INSERT INTO `su_shipping` (`id`, `rack_id`, `category`, `qty`) VALUE ";
                foreach (string[] data in value)
                {
                    index++;
                    query += string.Format(" ('{0}', '{1}', '{2}', {3}),", index, data);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static string getSettings(string key, string default_value, string user = "common")
        {
            if (settingsTable.Count == 0)
            {
                settingsTable = fetchAllRows("settings");
            }
            string[] result = settingsTable.FindLast(x => x[1] == user && x[2] == key);
            if (result != null) return result[(int)SETTINGS.KEY_VALUE];
            return default_value;
        }

        public static void saveSetting(string key, string value, string user = "common")
        {
            string query = "";
            if (settingsTable.FindLast(x => x[1] == user && x[2] == key) != null)
            {
                query = "UPDATE `settings` SET `key_value` = '" + value + "' WHERE `user` = '" + user + "' AND `key_name` = '" + key + "'";
            }
            else
            {
                query = "INSERT INTO `settings` (`user`, `key_name`, `key_value`) VALUES ('" + user + "', '" + key + "', '" + value + "')";
                settingsTable.Add(new string[] { user, key, value });
            }
            excuteSQL(query);
        }

        public static List<string[]> getIGSortingPrefix()
        {
            string query = "SELECT * FROM `prefix`";
            return fetchRows(query);
        }

        public static List<string[]> getProductioReportLeftOrderSummary(string start, string end)
        {
            string query = null;
            if (end == null)
            {
                query = "SELECT `productionreport`.*, `ordersummary`.`ORDER#` FROM `ordersummary` LEFT JOIN `productionreport` ON `productionreport`.`ORDER` = `ordersummary`.`ORDER#` WHERE `ordersummary`.`LIST DATE` = '" + start + "'";
            }
            else
            {
                query = "SELECT `productionreport`.*, `ordersummary`.`ORDER#` FROM `ordersummary` LEFT JOIN `productionreport` ON `productionreport`.`ORDER` = `ordersummary`.`ORDER#` WHERE STR_TO_DATE(`ordersummary`.`LIST DATE`, '%Y %m %d') BETWEEN STR_TO_DATE('" + start + "', '%d %M %Y') AND STR_TO_DATE('" + end + "', '%d %M %Y')";
            }
            return fetchRows(query);
        }

        public static List<string[]> getFrameCutting(DateTime[] dates)
        {
            string query = null;
            if (dates != null)
            {
                query = "SELECT * FROM `framescutting` WHERE STR_TO_DATE(`U`, '%Y%m%d') BETWEEN STR_TO_DATE('" + dates[0].ToString("dd M yyyy") + "', '%d %m %Y') AND STR_TO_DATE('" + dates[1].ToString("dd M yyyy") + "', '%d %m %Y')";
            }
            return fetchRows(query);
        }

        public static List<string[]> getGlassByDates(DateTime[] dates)
        {
            string query = null;
            if (dates != null)
            {
                string[] parameters = dateRangeToStringArray(dates);
                query = "SELECT * FROM `glassreport`  WHERE `list_date` IN ('" + string.Join("' , '", parameters) + "')";
            }
            return fetchRows(query);
        }
        
        public static List<string[]> getFrameCuttingByNumbs(List<string> numbers)
        {
            List<string> partial_numbers = new List<string>();
            List<string[]> result = new List<string[]>();
            string query = null;
            if (numbers != null)
            {
                query = "SELECT * FROM `framescutting` WHERE `F` IN ('" + string.Join("','", numbers) + "')";
                result = fetchRows(query);
            }
            return result;
        }

        public static List<string[]> getFrameCuttingByOrder(List<string> numbers)
        {
            string query = null;
            if (numbers != null)
            {
                query = "SELECT * FROM `framescutting` WHERE `J` IN ('" + string.Join("','", numbers) + "')";
            }
            return fetchRows(query);
        }

        public static List<string[]> getFrameCuttingByOrderNumber(string number)
        {
            string query = null;
            if (number != null)
            {
                query = "SELECT * FROM `framescutting` WHERE `J` = '" + number + "'";
            }
            return fetchRows(query);
        }

        public static List<string[]> getFrameClearingByIds(List<string> Ids)
        {
            string query = null;
            if (Ids != null)
            {
                query = "SELECT * FROM `FrameClearing` WHERE `Id`  IN ('" + string.Join("' , '", Ids) + "')";
            }
            return fetchRows(query);
        }

        public static string[] getColourShippingByIds(List<string> Ids)
        {
            string query = null;
            if (Ids != null)
            {
                query = "SELECT * FROM `ColourShipping` WHERE `Id` IN ('" + string.Join("' , '", Ids) + "')";
            }
            return fetchRow(query);
        }

        public static string[] getColourShippingPrefix(string name)
        {
            string query = null;
            if (name != null)
            {
                query = "SELECT * FROM `ColourShipping_prefix` WHERE (`name` = '" + name + "')";
            }
            return fetchRow(query);
        }

        public static string[] getColourReceivingByIds(List<string> Ids)
        {
            string query = null;
            if (Ids != null)
            {
                query = "SELECT * FROM `ColourReceiving` WHERE `Id` IN ('" + string.Join("' , '", Ids) + "')";
            }
            return fetchRow(query);
        }

        public static List<string[]> getFrameClearingByDate(DateTime date)
        {
            string query = null;
            if (date != null)
            {
                query = "SELECT * FROM `FrameClearing` WHERE STR_TO_DATE(`Date`, '%Y-%m-%d') = STR_TO_DATE('" + date.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            return fetchRows(query);
        }

        public static void saveIGSortingPrefix(List<string[]> data)
        {
            string query = "DELETE FROM `prefix`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `prefix` (`id`, `prefix`, `department`, `name`, `note`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}', '{3}', '{4}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static int insertAccount(string[] data)
        {
            string query = string.Format("INSERT INTO `Accounts` (`First Name`, `Last Name`, `Username`, `Password`, `Email 1`, `Email 2`, `Phone`, `Permissions_search`,`GlassReport_Delete`,`FrameReport_Delete`) " +
                "VALUE ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", data);
            int result = excuteSQL(query);
            return result;
        }

        public static int UpdateAccount(string[] data)
        {
            string query = string.Format("UPDATE `Accounts` SET `First Name`='" + data[1] + "', `Last Name`='" + data[2] + "', `Username`='" + data[3] + "', `Password`='" + data[4] + "', `Email 1`='" + data[5] + "', `Email 2`='" + data[6] + "', `Phone`='" + data[7] + "', `Permissions_search`='" + data[8] + "', `Permissions_menu`='" + data[9] + "', `GlassReport_Delete`='" + data[10] + "', `FrameReport_Delete`='" + data[11] + "' " +
                "WHERE `id` = '" + data[0] + "'");
            int result = excuteSQL(query);
            return result;
        }

        public static int DeleteAccount(string user)
        {
            string query = string.Format("DELETE FROM `Accounts` WHERE `Username` = '" + user + "'");
            int result = excuteSQL(query);
            return result;
        }

        public static List<string[]> getIGShippingPrefix()
        {
            string query = "SELECT * FROM `ig_shipping_prefix`";
            return fetchRows(query);
        }

        public static void saveIGShippingPrefix(List<string[]> data)
        {
            string query = "DELETE FROM `ig_shipping_prefix`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `ig_shipping_prefix` (`id`, `prefix`, `department`, `name`, `note`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}', '{3}', '{4}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static List<string[]> getWindowsAssemblyPrefix()
        {
            string query = "SELECT * FROM `WindowsAssembly_prefix`";
            return fetchRows(query);
        }

        public static List<string[]> getColourShippingPrefix()
        {
            string query = "SELECT * FROM `ColourShipping_prefix`";
            return fetchRows(query);
        }

        public static List<string[]> getColourReceivingPrefix()
        {
            string query = "SELECT * FROM `ColourReceiving_prefix`";
            return fetchRows(query);
        }

        public static List<string[]> getFrameClearingPrefix()
        {
            string query = "SELECT * FROM `FrameClearing_prefix`";
            return fetchRows(query);
        }

        public static List<string[]> getCasementHardwarePrefix()
        {
            string query = "SELECT * FROM `CasementHardware_prefix`";
            return fetchRows(query);
        }

        public static void saveWindowsAssemblyPrefix(List<string[]> data)
        {
            string query = "DELETE FROM `WindowsAssembly_prefix`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `WindowsAssembly_prefix` (`id`, `prefix`, `department`, `name`, `note`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}', '{3}', '{4}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static void saveColourShippingPrefix(List<string[]> data)
        {
            string query = "DELETE FROM `ColourShipping_prefix`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `ColourShipping_prefix` (`id`, `prefix`, `company`, `batch_number`, `name`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}', '{3}', '{4}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static void saveColourReceivingPrefix(List<string[]> data)
        {
            string query = "DELETE FROM `ColourReceiving_prefix`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `ColourReceiving_prefix` (`id`, `prefix`, `name`, `batch_number`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}', '{3}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static void saveFrameClearing(List<string[]> data)
        {
            string query = "DELETE FROM `FrameClearing_prefix`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `FrameClearing_prefix` (`id`, `prefix`, `department`, `name`, `machine_id`, `note`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static void saveCasementHardware(List<string[]> data)
        {
            string query = "DELETE FROM `CasementHardware_prefix`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `CasementHardware_prefix` (`id`, `prefix`, `department`, `name`,  `note`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}', '{3}', '{4}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static List<string[]> getWindowsAssemblybyNameDate(DateTime start, string name, string type, DateTime end = new DateTime())
        {
            string query;
            if (type == "date")
            {
                query = "SELECT `Line_number`, DATE_FORMAT(Date,'%Y-%m-%d'),`Time`,`Name` FROM `windowsassembly` WHERE `Name` = '" + name + "' AND `Date`= '" + start.ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                query = "SELECT `Line_number`, DATE_FORMAT(Date,'%Y-%m-%d'),`Time`,`Name` FROM `windowsassembly` WHERE `Name` = '" + name + "' AND STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            return fetchRows(query);
        }

        public static List<string[]> getFrameClearingByDates(DateTime start, DateTime end)
        {
            string query = null;
            if (start != null && end != null)
            {
                query = "SELECT `Id`, DATE_FORMAT(Date,'%Y-%m-%d'),`Time`,`Name` FROM `FrameClearing` WHERE  STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            return fetchRows(query);
        }

        public static List<string[]> getCasementHardwareByDates(DateTime start, DateTime end)
        {
            string query = null;
            if (start != null && end != null)
            {
                query = "SELECT `Id`, DATE_FORMAT(Date,'%Y-%m-%d'),`Time`,`Name` FROM `CasementHardware` WHERE  STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            return fetchRows(query);
        }

        public static List<string[]> getColourShippingbyBatch(string batch)
        {
            string query = "SELECT * FROM `ColourShipping`";
            if (batch != "" && batch != null)
            {
                query = "SELECT * FROM `ColourShipping` WHERE `batch_number` = '" + batch + "' ";
            }
            return fetchRows(query);
        }

        public static List<string[]> getColourShippingbyBatchDate(DateTime start, DateTime end, string batch)
        {
            string query = "SELECT * FROM `ColourShipping`";
            if (batch != "" && batch != null)
            {
                query = "SELECT * FROM `ColourShipping` WHERE `batch_number` = '" + batch + "' AND STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            else
            {
                query = "SELECT * FROM `ColourShipping` WHERE  STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            return fetchRows(query);
        }

        public static List<string[]> getColourReceivingbyBatch(string batch)
        {
            string query = "";
            if (batch != "" && batch != null)
            {
                query = "SELECT * FROM `ColourReceiving` WHERE `batch_number` = '" + batch + "'";
            }
            return fetchRows(query);
        }

        public static List<string[]> getColourReceivingbyBatchDate(DateTime start, DateTime end, string batch)
        {
            string query = "SELECT * FROM `ColourReceiving`";
            if (batch != "" && batch != null)
            {
                query = "SELECT * FROM `ColourReceiving` WHERE `batch_number` = '" + batch + "' AND STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            else query = "SELECT * FROM `ColourReceiving` WHERE  STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            return fetchRows(query);
        }

        public static List<string[]> getOceanviewPatioDoorsFields()
        {
            string query = "SELECT * FROM `OceanviewPatioDoors_fields`";
            return fetchRows(query);
        }

        public static List<string[]> getVistaPatioDoorsFields()
        {
            string query = "SELECT * FROM `VistaPatioDoors_fields`";
            return fetchRows(query);
        }

        public static void saveOceanviewPatioDoorsFields(List<string[]> data)
        {
            string query = "DELETE FROM `OceanviewPatioDoors_fields`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `OceanviewPatioDoors_fields` (`id`, `Category`, `Value`) VALUE ";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static void saveVistaPatioDoorsFields(List<string[]> data)
        {
            string query = "DELETE FROM `VistaPatioDoors_fields`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `VistaPatioDoors_fields` (`id`, `Category`, `Value`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static string[] getLastOceanviewPatioDoors()
        {
            string query = "SELECT `Id`, DATE_FORMAT(`Created Date`,'%Y-%m-%d'),`Door number` FROM `OceanviewPatioDoors` ORDER BY ID DESC LIMIT 1";
            return fetchRow(query);
        }

        public static string[] getLastVistaPatioDoors()
        {
            string query = "SELECT `Id`, DATE_FORMAT(`Created Date`,'%Y-%m-%d'),`Door number` FROM `VistaPatioDoors` ORDER BY ID DESC LIMIT 1";
            return fetchRow(query);
        }

        public static string[] getLastVistaPatioDoorsStock()
        {
            string query = "SELECT `Id`, DATE_FORMAT(`Created Date`,'%Y-%m-%d'),`Reference number` FROM `VistaPatioDoors` WHERE `Type`='stock' ORDER BY ID DESC LIMIT 1";
            return fetchRow(query);
        }

        public static string[] getLastWoodbirdgeSheets()
        {
            string query = "SELECT `Id`, DATE_FORMAT(`Created Date`,'%Y-%m-%d'),`Reference number` FROM `Woodbridge` WHERE `type`='sheets' ORDER BY ID DESC LIMIT 1";
            return fetchRow(query);
        }

        public static string[] getLastOceanviewDoorsStock()
        {
            string query = "SELECT `Id`, DATE_FORMAT(`Created Date`,'%Y-%m-%d'),`Reference number` FROM `OceanviewPatioDoors` WHERE `Type`='stock' ORDER BY ID DESC LIMIT 1";
            return fetchRow(query);
        }

        public static int saveOceanviewPatioDoors(List<string[]> data)
        {
            string query;
            int result = 1;
            if (data.Count > 0)
            {
                query = "INSERT INTO `OceanviewPatioDoors` (`Date`,`Created Date`,`Size`,`Qty`,`Date Required`,`Order number`,`Door number`,`Colour`,`AssmebledView`,`Grills`,`Internal Blinds`,`Elite Lock`,`Euro Lock`,`New Euro Lock`,`Security Options`,`Pacific Series`,`Note`,`Tag`,`Type` ,`Reference number`,`Company`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}'),", item);
                }
                query = query.Remove(query.Length - 1);
                result = excuteSQL(query);
            }
            return (result);
        }

        public static int saveVistaPatioDoors(List<string[]> data)
        {
            string query;
            int result = 1;
            if (data.Count > 0)
            {
                query = "INSERT INTO `VistaPatioDoors` (`Date`,`Created Date`,`Door Size`,`Qty`,`Date Required`,`Order number`,`Door number`,`KNOCKED DOWN`,`ASSEMBLED`,`FINISHES`,`GLAZING OPTIONS`,`MINI BLINDS`,`GRILLS`,`INTERIOR EXTENTIONS`,`BRICKMOULD`,`VINYL PACKAGE`,`SILL EXTENTION`,`NAILING FIN`,`DRYWALL RETURN`,`LOCKING HARDWARE`,`SERIES`,`SECONDARY HARDWARE`,`Transom Size`,`Sidelite Size`,`LUXURY PACKAGES`,`Note`,`Tag`,`Type` ,`Reference number`,`Company`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}')", item);
                    result = excuteSQL(query);
                }
            }
            return (result);
        }

        public static List<string[]> importigshippingByIds(List<string> ids)
        {
            string query = null;
            if (ids != null && ids.Count > 0)
            {
                query = "SELECT * FROM `ig_shipping` WHERE `sealed_unit_id`  IN ('" + string.Join("' , '", ids) + "')";
            }
            return fetchRows(query, true);
        }

        public static List<string[]> importFramereportbyIDandType(string order, List<string> type)
        {
            string query = null;
            if (order != null && order.Length > 0)
            {
                query = "SELECT * FROM `framereport` WHERE `LINE #1` LIKE '%" + order + "%' AND `W.TYPE`  IN ('" + string.Join("' , '", type) + "') ";
            }
            return fetchRows(query, false);
        }

        public static List<string[]> importFramereportbyIDs(List<string> orders)
        {
            string query = null;
            if (orders != null && orders.Count > 0)
            {
                query = "SELECT * FROM `framereport` WHERE `LINE #1` LIKE'%" + string.Join("%' OR `LINE #1` LIKE '%", orders) + "%'";
                return fetchRows(query, false);
            }
            return null;
        }

        public static List<string[]> get24HourThermalGlassUnitFields()
        {
            string query = "SELECT * FROM `24HourThermalGlass_Unit_fields`";
            return fetchRows(query);
        }

        public static List<string[]> get24HourThermalGlassSheetsFields()
        {
            string query = "SELECT * FROM `24HourThermalGlass_Sheets_fields`";
            return fetchRows(query);
        }

        public static List<string[]> get24HourThermalGlassCutToSizeFields()
        {
            string query = "SELECT * FROM `24HourThermalGlass_CutToSize_fields`";
            return fetchRows(query);
        }

        public static void save24HourThermalGlassUnitFields(List<string[]> data)
        {
            string query = "DELETE FROM `24HourThermalGlass_Unit_fields`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `24HourThermalGlass_Unit_fields` (`id`, `Category`, `Value`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format("('{0}', '{1}', '{2}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static void save24HourThermalGlassSheetsFields(List<string[]> data)
        {
            string query = "DELETE FROM `24HourThermalGlass_Sheets_fields`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `24HourThermalGlass_Sheets_fields` (`id`, `Category`, `Value`) Value";
                foreach (var item in data)
                {
                    query += string.Format("('{0}', '{1}', '{2}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static void save24HourThermalGlassCutToSizeFields(List<string[]> data)
        {
            string query = "DELETE FROM `24HourThermalGlass_CutToSize_fields`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `24HourThermalGlass_CutToSize_fields` (`id`, `Category`, `Value`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format("('{0}', '{1}', '{2}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static string[] getLastHourThermalGlass()
        {
            string query = "SELECT `Id`, DATE_FORMAT(`Created Date`,'%Y-%m-%d'),`ID number` FROM `24HourThermalGlass` ORDER BY ID DESC LIMIT 1";
            return fetchRow(query);
        }

        public static int save24HourThermalGlass(List<string[]> data)
        {
            string query;
            int result = 1;
            if (data.Count > 0)
            {
                query = "INSERT INTO `24HourThermalGlass` (`Date`,`Created Date`,`Type`,`LineNumber`,`Date Required`,`Order number`,`ID number`,`Width`,`Height`,`Qty`,`OT`,`Spacer`,`MIL`,`GRILL`,`Argon gas`,`GlassType`,`Note`,`Tag`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
            return (result);
        }

        public static List<string[]> getWoodbridgeCutToSizefields()
        {
            string query = "SELECT * FROM `Woodbridge_CutToSize_fields`";
            return fetchRows(query);
        }

        public static List<string[]> getWoodbridgeSheetsfields()
        {
            string query = "SELECT * FROM `Woodbridge_Sheets_fields`";
            return fetchRows(query);
        }

        public static void saveWoodbridgeCutToSizefields(List<string[]> data)
        {
            string query = "DELETE FROM `Woodbridge_CutToSize_fields`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `Woodbridge_CutToSize_fields` (`id`, `Category`, `Value`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static void saveWoodbridgeSheetsfields(List<string[]> data)
        {
            string query = "DELETE FROM `Woodbridge_Sheets_fields`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `Woodbridge_Sheets_fields` (`id`, `Category`, `Value`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static string[] getLastHourWoodbridger()
        {
            string query = "SELECT `Id`, DATE_FORMAT(`Created Date`,'%Y-%m-%d'),`ID number` FROM `Woodbridge` ORDER BY ID DESC LIMIT 1";
            return fetchRow(query);
        }

        public static int saveWoodbridge(List<string[]> data)
        {
            string query;
            int result = 1;
            if (data.Count > 0)
            {
                query = "INSERT INTO `Woodbridge` (`Date`,`Created Date`,`Type`,`Date Required`,`Order number`,`ID number`,`Width`,`Height`,`Qty`,`MIL`,`GlassType`,`Note`,`Tag`,`Reference number`) VALUE ";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}'),", item);
                }
                query = query.Remove(query.Length - 1);
                result = excuteSQL(query);
            }
            return (result);
        }

        public static List<string[]> getEmails()
        {
            string query = "SELECT * FROM `email_settings`";
            return fetchRows(query);
        }

        public static void saveEmails(List<string[]> data)
        {
            string query = "DELETE FROM `email_settings`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `email_settings` (`id`, `address`, `Order_type`) VALUE ";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static List<string[]> getTaskBoardEmail()
        {
            string query = "SELECT * FROM `TaskBoard_email`";
            return fetchRows(query);
        }

        public static void saveTaskBoardEmail(List<string[]> data)
        {
            string query = "DELETE FROM `TaskBoard_email`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `TaskBoard_email` (`id`, `address`, `name`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static int InsertTaskBoard(Data_TaskBoard data_TaskBoard)
        {
            string query = "INSERT INTO `TaskBoard` (`Ord_numb`,`DateTime`,`Description`,`Frame`,`Color`,`Glass`,`Windows_assembly`,`Wrapping`,`Shipping`,`P`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')";
            query = string.Format(query, data_TaskBoard.Ord_numb, data_TaskBoard.DateTime, data_TaskBoard.Description, data_TaskBoard.Frame, data_TaskBoard.Color, data_TaskBoard.Glass, data_TaskBoard.Windows_assembly, data_TaskBoard.Wrapping, data_TaskBoard.Shipping, data_TaskBoard.P);
            fetchRow(query);
            query = "SELECT * FROM `TaskBoard` ORDER BY ID DESC LIMIT 1";
            string[] result = fetchRow(query);
            return result == null ? 0 : Int32.Parse(result[0]);
        }

        public static List<Data_TaskBoard> getTaskBoard()
        {
            List<Data_TaskBoard> data_TaskBoards = new List<Data_TaskBoard>();
            string query = "SELECT * FROM `TaskBoard`";
            List<string[]> result = fetchRows(query);
            foreach (var entry in result)
            {
                data_TaskBoards.Add(new Data_TaskBoard(Int32.Parse(entry[0]), entry[2], entry[1], entry[3], Int32.Parse(entry[4]), Int32.Parse(entry[5]), Int32.Parse(entry[6]), Int32.Parse(entry[7]), 3, 3, Double.Parse(entry[10])));
            }
            return data_TaskBoards;
        }

        public static int getLastTaskBoard()
        {
            string query = "SELECT * FROM `TaskBoard` ORDER BY ID DESC LIMIT 1";
            string[] result = fetchRow(query);
            return result == null ? 0 : Int32.Parse(result[0]);
        }

        public static void DeleteTaskBoard(int id)
        {
            string query = "DELETE FROM `TaskBoard` WHERE `id` = '" + id + "'";
            excuteSQL(query);
        }

        public static void UpdateTaskBoard(int id, string order, string datetime, string description, int frame, int color, int glass, int windows_assembly, int wrapping, int shipping, double p)
        {
            string query = "UPDATE `TaskBoard` SET `Ord_numb` ='" + order + "', `DateTime`='" + datetime + "', `Description`='" + description + "', `Frame`='" + frame + "', `Color`='" + color + "', `Glass`='" + glass + "', `Windows_assembly`='" + windows_assembly + "', `Wrapping`='" + wrapping + "', `Shipping`='" + shipping + "', `P`='" + p + "'" +
                " WHERE `id` = '" + id + "'";
            excuteSQL(query);
        }

        public static List<string[]> getWindowsShippingPrefix()
        {
            string query = "SELECT * FROM `WindowsShipping_prefix`";
            return fetchRows(query);
        }

        public static void saveWindowsShippingPrefix(List<string[]> data)
        {
            string query = "DELETE FROM `WindowsShipping_prefix`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `WindowsShipping_prefix` (`id`, `prefix`, `name`, `note`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}', '{3}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static List<string[]> getFrameCuttingByOrderType(List<string> type, string order)
        {
            string query = null;
            if (type != null)
            {
                query = "SELECT * FROM `framescutting` WHERE `H`  IN ('" + string.Join("' , '", type) + "') AND `J` ='" + order + "'";
            }
            return fetchRows(query);
        }

        public static int saveWindowsShippingData(string Line_number, string date, string time, string name, string order, string window, string pdoor, string casing, string reference)
        {
            string query = "INSERT INTO `WindowsShipping` (`Line_number`, `Date`, `Time`, `Name`,`Order`, `Window`, `P.door`, `Casing`, `Reference`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')";
            query = string.Format(query, Line_number, date, time, name, order, window, pdoor, casing, reference);
            int result = excuteSQL(query);
            return result;
        }

        public static string[] getLastWindowsShippingData(string line_number)
        {
            string query = "SELECT * FROM `WindowsShipping` WHERE `Line_number`='" + line_number + "' ORDER BY ID DESC LIMIT 1";
            return fetchRow(query);
        }

        public static List<string[]> importGlassByDate(DateTime[] date, string type)
        {
            string query = null;
            if (date.Length > 0)
            {
                string[] parameters = dateRangeToStringArray(date);
                if (type == "order")
                {
                    query = "SELECT * FROM `glassreport` WHERE `order_date` IN ('" + string.Join("' , '", parameters) + "')";
                }
                else if (type == "list")
                {
                    query = "SELECT * FROM `glassreport` WHERE `list_date` IN ('" + string.Join("' , '", parameters) + "')";
                }
            }
            return fetchRows(query, false);
        }

        public static List<string[]> getFrameCuttingByIdAndType(string id)
        {
            string query = "SELECT * FROM `framescutting` WHERE `H`  ='Case Sash' AND `J`='" + id + "'";
            List<string[]> result = fetchRows(query, false);
            return result;
        }

        public static List<string[]> importGlassReportByOrders(List<string> orders, string[] type)
        {
            if (orders != null && orders.Count > 0)
            {
                string query = "SELECT `list_date`, `sealed_unit_id`, `order` FROM `glassreport` WHERE `order` IN ('" + string.Join("','", orders) + " ') AND  (`window_type` = 'Window_Type_" + string.Join("' OR `window_type` = 'Window_Type_", type) + "')";
                return fetchRows(query, false);
            }
            return null;
        }

        public static List<string[]> getFrameAssemblyPrefix()
        {
            string query = "SELECT * FROM `FrameAssembly_prefix`";
            return fetchRows(query);
        }

        public static void saveFrameAssemblyPrefix(List<string[]> data)
        {
            string query = "DELETE FROM `FrameAssembly_prefix`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `FrameAssembly_prefix` (`id`, `prefix`,`name`, `note`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}', '{3}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static int saveFrameAssemblyData(string Line_number, string date, string time, string name)
        {
            string query = "INSERT INTO `FrameAssembly` (`Line_id`, `Date`, `Time`, `Name`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}')";
            query = string.Format(query, Line_number, date, time, name);
            int result = excuteSQL(query);
            return result;
        }

        public static List<string[]> importFrameAssemblyAssemblyByIds(List<string> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                string query = "SELECT * FROM `FrameAssembly` WHERE `Line_Id` IN ('" + string.Join("' , '", ids) + "') ";
                return fetchRows(query, true);
            }
            return null;
        }

        public static List<string[]> getWindowsWrappingPrefix()
        {
            string query = "SELECT * FROM `WindowsWrapping_prefix`";
            return fetchRows(query);
        }

        public static void saveWindowsWrappingPrefix(List<string[]> data)
        {
            string query = "DELETE FROM `WindowsWrapping_prefix`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `WindowsWrapping_prefix` (`id`, `prefix`, `name`, `note`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}', '{3}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);

            }
        }

        public static string[] getLastWindowsWrappingData(string line_number)
        {
            string query = "SELECT * FROM `WindowsWrapping` WHERE `Line_number`='" + line_number + "' ORDER BY ID DESC LIMIT 1";
            return fetchRow(query);
        }

        public static int saveWindowsWrappingData(string Line_number, string date, string time, string name, string order, string window, string reference)
        {
            string query = "INSERT INTO `WindowsWrapping` (`Line_number`, `Date`, `Time`, `Name`,`Order`, `Window`, `Reference`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')";
            query = string.Format(query, Line_number, date, time, name, order, window, reference);
            int result = excuteSQL(query);
            return result;
        }

        public static List<string[]> getPatioDoorsReceivingPrefix()
        {
            string query = "SELECT * FROM `PatioDoorsReceiving_prefix`";
            return fetchRows(query);
        }

        public static void savePatioDoorsReceivingPrefix(List<string[]> data)
        {
            string query = "DELETE FROM `PatioDoorsReceiving_prefix`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `PatioDoorsReceiving_prefix` (`id`, `prefix`, `gate`, `note`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}', '{3}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static int savePatioDoorsReceivingData(string Door_number, string date, string time, string gate, string name)
        {
            string query = "INSERT INTO `PatioDoorsReceiving` (`Door_number`, `Date`, `Time`, `Gate`,`Name`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
            query = string.Format(query, Door_number, date, time, gate, name);
            int result = excuteSQL(query);
            return result;
        }

        public static List<string[]> importPatioDoorsReceivingByIds(List<string> ids)
        {
            string query = null;
            if (ids != null && ids.Count > 0)
            {
                query = "SELECT * FROM `PatioDoorsReceiving` WHERE `Door_number` IN ('" + string.Join("' , '", ids) + "') ";
                return fetchRows(query, true);
            }
            return null;
        }

        public static List<string[]> getPatioDoorsShippingPrefix()
        {
            string query = "SELECT * FROM `PatioDoorsShipping_prefix`";
            return fetchRows(query);
        }

        public static void savePatioDoorsShippingPrefix(List<string[]> data)
        {
            string query = "DELETE FROM `PatioDoorsShipping_prefix`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `PatioDoorsShipping_prefix` (`id`, `prefix`, `name`, `note`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}', '{3}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static string[] getVistaDoorByDoorOrderNumb(string door_number, string order_number)
        {
            string query = "SELECT * FROM `VistaPatioDoors` WHERE `Door number`='" + door_number + "' AND `Order number`='" + order_number + "'";
            return fetchRow(query);
        }

        public static string[] getOceanviewDoorByDoorOrderNumb(string door_number, string order_number)
        {
            string query = "SELECT * FROM `OceanviewPatioDoors` WHERE `Door number`='" + door_number + "' AND `Order number`='" + order_number + "'";
            return fetchRow(query);
        }

        public static int savePatioDoorsShippingData(string Door_number, string date, string time, string name)
        {
            string query = "INSERT INTO `PatioDoorsShipping` (`Door_number`, `Date`, `Time`,`Name`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}')";
            query = string.Format(query, Door_number, date, time, name);
            int result = excuteSQL(query);
            return result;
        }

        public static List<string[]> importPatioDoorsShippingByIds(List<string> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                string query = "SELECT * FROM `PatioDoorsShipping` WHERE `Door_number` IN ('" + string.Join("' , '", ids) + "') ";
                return fetchRows(query, true);
            }
            return null;
        }

        public static List<string[]> importColourReceivingByIDs(List<string> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                string query = "SELECT * FROM `ColourReceiving` WHERE `Id` IN ('" + string.Join("' , '", ids) + "')";
                return fetchRows(query, true);
            }
            return null;
        }
        
        public static List<string[]> getGlassReportByTTO(string ot, string order_number, string type)
        {
            string query = "SELECT * FROM `glassreport` WHERE `ot`='" + ot + "' AND `glass_type`='" + type + "' AND `order`='" + order_number + "'";
            return fetchRows(query);
        }

        public static int saveGlassRecutData(string su_id, string date, string time, string order, string name, string reason)
        {
            string query = "INSERT INTO `GlassRecut` (`sealed_unit_id`, `Date`, `Time`,`Order_number`, `Name`,`Reason`,`Status`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')";
            query = string.Format(query, su_id, date, time,order, name, reason,"Incomplete");
            int result = excuteSQL(query);
            return result;
        }

        public static List<string[]> getGlassRecut()
        {
            string query = "SELECT * FROM `GlassRecut` WHERE `Removed`!='1'";
            return fetchRows(query, false);
        }

        public static List<string[]> importGlassBySU(string[] su_ids)
        {
            if (su_ids != null && su_ids.Length > 0)
            {
                return fetchRows("glassreport", "sealed_unit_id", su_ids, false);
            }
            return null;
        }

        public static List<string[]> getNotBookedOrderSummary(string date_filter_type, string date_filter)
        {
            string query = "SELECT * FROM `ordersummary` WHERE `LIST DATE` = ''";
            if (date_filter != null && date_filter != "")
            {
                query += " AND `" + date_filter_type + "` >= '" + date_filter.Replace("-", "") + "'";
            }
            return fetchRows(query);
        }

        public static List<string[]> getBookedOrderSummary(string date, string location = null)
        {
            string query = "SELECT * FROM `ordersummary` WHERE STR_TO_DATE(`LIST DATE`, '%Y%m%d') = STR_TO_DATE('" + date + "', '%Y%m%d')";
            if (location != null)
            {
                query += " AND `EX_COL1` = '" + location + "';";
            }
            return fetchRows(query);
        }

        public static List<string[]> getWindowTypes()
        {
            string query = "SELECT * FROM `booking_window_type`";
            List<string[]> types = fetchRows(query);
            return types;
        }

        public static void saveWindowTypes(List<string[]> value)
        {
            string query = "DELETE FROM `booking_window_type`";
            excuteSQL(query);
            query = "INSERT INTO `booking_window_type` (`id`, `type`, `value`) VALUE ";
            foreach (string[] data in value)
            {
                query += string.Format(" ('{0}', '{1}', '{2}'),", data);
            }
            query = query.Remove(query.Length - 1);
            excuteSQL(query);
        }

        public static DataTable GetTableSchema(string table)
        {
            DataTable schema = null;
            if (connection.State == ConnectionState.Open || openDB() == true)
            {
                using (var schemaCommand = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM "+ table, connection))
                {
                    using (var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly))
                    {
                        schema = reader.GetSchemaTable();
                    }
                }
                closeDB();
            }
            return schema;
        }

        public static int BookOrderSummary(string id, string date, string location)
        {
            string query = "UPDATE `ordersummary` SET `LIST DATE` = '" + date + "', `EX_COL1` = '" + location + "' WHERE `id` = '" + id + "'";
            return excuteSQL(query);
        }

        public static int BookOrderSummaryByOrder(string order, string date)
        {
            string query = "UPDATE `ordersummary` SET `LIST DATE` = '" + date + "' WHERE `ORDER#` = '" + order + "'";// ORDER BY id ASC LIMIT 1
            return excuteSQL(query);
        }

        public static int BookOrderSummaryByOrder(List<string> orders, string date)
        {
            string query = "UPDATE `ordersummary` SET `LIST DATE` = '" + date + "' WHERE `ORDER#` IN ('" + string.Join("','", orders) + "')";// ORDER BY id ASC LIMIT 1
            return excuteSQL(query);
        }

        public static int UpdateOrderSummaryStatus(string order, string status)
        {
            string query = "UPDATE `ordersummary` SET `STATUS` = '" + status + "' WHERE `ORDER#` = '" + order + "'";// ORDER BY id ASC LIMIT 1
            return excuteSQL(query);
        }

        public static int UpdateOrderSummaryStatus(List<string> orders, string status)
        {
            string query = "UPDATE `ordersummary` SET `STATUS` = '" + status + "' WHERE `ORDER#` IN ('" + string.Join("','", orders) + "')";// ORDER BY id ASC LIMIT 1
            return excuteSQL(query);
        }

        public static string[] getOrderSummaryBYNumber(string order)
        {
            string query = "SELECT * FROM `ordersummary` WHERE `ORDER#`='" + order + "'";
            return fetchRow(query);
        }

        public static List<string[]> getOrderSummaryByDueDate(DateTime date1, DateTime date2)
        {
            string query = "SELECT * FROM `ordersummary` WHERE `DUE DATE` between '"+ date1.ToString("yyyyMMdd") + "' and '" + date2.ToString("yyyyMMdd") + "' AND `LIST DATE`=''";
            return fetchRows(query);
        }

        public static List<string[]> getBookingSliderTypes()
        {
            string query = "SELECT * FROM `booking_slider_type`";
            List<string[]> types = fetchRows(query);
            return types;
        }

        public static void saveWBookingSliderTypes(List<string[]> value)
        {
            string query = "DELETE FROM `booking_slider_type`";
            excuteSQL(query);
            query = "INSERT INTO `booking_slider_type` (`id`, `type`, `value`, `multiplicator`) VALUE ";
            foreach (string[] data in value)
            {
                query += string.Format(" ('{0}', '{1}', '{2}', '{3}'),", data);
            }
            query = query.Remove(query.Length - 1);
            excuteSQL(query);
        }

        public static int RemoveFromGlassRecut(string su_id)
        {
            string query = "UPDATE `GlassRecut` SET `Removed` = '1' WHERE `sealed_unit_id` = '" + su_id + "' AND `Removed` = '0' ORDER BY id DESC LIMIT 1;";
            return excuteSQL(query);
        }

        public static int UpdateGlassRecut(string su_id)
        {
            string query = "UPDATE `GlassRecut` SET `Status` = 'Complete' WHERE `sealed_unit_id` = '" + su_id + "' ORDER BY id DESC LIMIT 1;";
            return excuteSQL(query);
        }

        public static int UpdateDealerGlassReport(string id)
        {
            string query = "UPDATE `glassreport` SET `dealer` = 'RE CUT' WHERE `id` = '" + id + "' ORDER BY id DESC LIMIT 1;";
            return excuteSQL(query);
        }

        public static List<string[]> getReceivingShippingPrefix(string table_name)
        {
            string query = "SELECT * FROM `" + table_name + "`";
            return fetchRows(query);
        }

        public static void saveReceivingShippingPrefix(string table_name, List<string[]> data)
        {
            string query = "DELETE FROM `" + table_name + "`";
            excuteSQL(query);
            if (data.Count > 0)
            {
                query = "INSERT INTO `" + table_name + "` (`id`, `prefix`, `company`, `name`) VALUE";
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}', '{3}'),", item);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static int saveDVCoatexColorShippingData(string line, string date, string time, string name, string batch_number)
        {
            string query = "INSERT INTO `DVCoatexColorShipping` (`line`, `date`, `time`, `name`,`batch_number`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
            query = string.Format(query, line, date, time, name, batch_number);
            int result = excuteSQL(query);
            return result;
        }

        public static int saveDVCoatexColorReceivingData(string line, string date, string time, string name, string batch_number)
        {
            string query = "INSERT INTO `DVCoatexColorReceiving` (`line`, `date`, `time`, `name`,`batch_number`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
            query = string.Format(query, line, date, time, name, batch_number);
            int result = excuteSQL(query);
            return result;
        }

        public static int saveExpressCoatingColorShippingData(string line, string date, string time, string name, string batch_number)
        {
            string query = "INSERT INTO `ExpressCoatingColourShipping` (`line`, `date`, `time`, `name`,`batch_number`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
            query = string.Format(query, line, date, time, name, batch_number);
            int result = excuteSQL(query);
            return result;
        }

        public static int saveExpressCoatingColorReceivingData(string line, string date, string time, string name, string batch_number)
        {
            string query = "INSERT INTO `ExpressCoatingColorReceiving` (`line`, `date`, `time`, `name`,`batch_number`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
            query = string.Format(query, line, date, time, name, batch_number);
            int result = excuteSQL(query);
            return result;
        }

        public static int saveVinylProFrameShippingData(string line, string date, string time, string name, string batch_number)
        {
            string query = "INSERT INTO `VinylProFrameShipping` (`line`, `date`, `time`, `name`,`batch_number`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
            query = string.Format(query, line, date, time, name, batch_number);
            int result = excuteSQL(query);
            return result;
        }

        public static int saveVinylProFrameReceivingData(string line, string date, string time, string name, string batch_number)
        {
            string query = "INSERT INTO `VinylProFrameReceiving` (`line`, `date`, `time`, `name`,`batch_number`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
            query = string.Format(query, line, date, time, name, batch_number);
            int result = excuteSQL(query);
            return result;
        }

        public static List<string[]> getFramesCuttingByOrdersWID(List<string> numbers)
        {
            string query = null;
            if (numbers != null)
            {
                query = "SELECT * FROM `framescutting` WHERE `J` IN ('" + string.Join("','", numbers) + "')";
            }
            //else string query = "SELECT * FROM `productionreport` WHERE `LIST_DATE` = '" + sealed_unit_id + "'";
            return fetchRows(query, false);
        }

        public static List<string[]> getDVCoatexColorReceivingbyBatch(string batch)
        {
            if (batch != "" && batch != null)
            {
                string query = "SELECT * FROM `DVCoatexColorReceiving` WHERE `batch_number` = '" + batch + "'";
                return fetchRows(query);
            }
            return null;
        }

        public static List<string[]> getDVCoatexColorReceivingbyBatchDate(DateTime start, DateTime end, string batch)
        {
            string query;
            if (batch != "" && batch != null)
            {
                query = "SELECT * FROM `DVCoatexColorReceiving` WHERE `batch_number` = '" + batch + "' AND STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            else
            {
                query = "SELECT * FROM `DVCoatexColorReceiving` WHERE  STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            return fetchRows(query);
        }

        public static List<string[]> importDVCoatexColorReceivingByIds(List<string> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                string query = "SELECT * FROM `DVCoatexColorReceiving` WHERE `Line` IN ('" + string.Join("' , '", ids) + "')";
                return fetchRows(query, true);
            }
            return null;
        }

        public static List<string[]> getExpressCoatingColorReceivingbyBatch(string batch)
        {
            if (batch != "" && batch != null)
            {
                string query = "SELECT * FROM `ExpressCoatingColorReceiving` WHERE `batch_number` = '" + batch + "'";
                return fetchRows(query);
            }
            return null;
        }

        public static List<string[]> getExpressCoatingColorReceivingbyBatchDate(DateTime start, DateTime end, string batch)
        {
            string query;
            if (batch != "" && batch != null)
            {
                query = "SELECT * FROM `ExpressCoatingColorReceiving` WHERE `batch_number` = '" + batch + "' AND STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            else
            {
                query = "SELECT * FROM `ExpressCoatingColorReceiving` WHERE  STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            return fetchRows(query);
        }

        public static List<string[]> importExpressCoatingColorReceivingByIds(List<string> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                string query = "SELECT * FROM `ExpressCoatingColorReceiving` WHERE `Line`  IN ('" + string.Join("' , '", ids) + "')";
                return fetchRows(query, true);
            }
            return null;
        }

        public static List<string[]> getVinylproFrameReceivingbyBatch(string batch)
        {
            if (batch != "" && batch != null)
            {
                string query = "SELECT * FROM `VinylProFrameReceiving` WHERE `batch_number` = '" + batch + "'";
                return fetchRows(query);
            }
            return null;
        }

        public static List<string[]> getVinylproFrameReceivingbyBatchDate(DateTime start, DateTime end, string batch)
        {
            string query;
            if (batch != "" && batch != null)
            {
                query = "SELECT * FROM `VinylProFrameReceiving` WHERE `batch_number` = '" + batch + "' AND STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            else
            {
                query = "SELECT * FROM `VinylProFrameReceiving` WHERE  STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            return fetchRows(query);
        }

        public static List<string[]> importVinylproFrameReceivingByIds(List<string> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                string query = "SELECT * FROM `VinylProFrameReceiving` WHERE `Line` IN ('" + string.Join("' , '", ids) + "')";
                return fetchRows(query, true);
            }
            return null;
        }

        public static List<string[]> importVinylproFrameShippingByIds(List<string> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                string query = "SELECT * FROM `VinylProFrameShipping` WHERE `Line` IN ('" + string.Join("' , '", ids) + "')";
                return fetchRows(query, true);
            }
            return null;
        }

        public static List<string[]> importExpressCoatingColorShippingByIds(List<string> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                string query = "SELECT * FROM `ExpressCoatingColourShipping` WHERE `Line`  IN ('" + string.Join("' , '", ids) + "')";
                return fetchRows(query, true);
            }
            return null;
        }

        public static List<string[]> importDVCoatexColorShippingByIds(List<string> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                string query = "SELECT * FROM `DVCoatexColorShipping` WHERE `Line` IN ('" + string.Join("' , '", ids) + "')";
                return fetchRows(query, true);
            }
            return null;
        }

        public static List<string[]> getDVCoatexColorShippingbyBatch(string batch)
        {
            string query = "SELECT * FROM `DVCoatexColorShipping`";
            if (batch != "" && batch != null)
            {
                query = "SELECT * FROM `DVCoatexColorShipping` WHERE `batch_number` = '" + batch + "' ";
            }
            return fetchRows(query);
        }

        public static List<string[]> getDVCoatexColorShippingbyBatchDate(DateTime start, DateTime end, string batch)
        {
            string query;
            if (batch != "" && batch != null)
            {
                query = "SELECT * FROM `DVCoatexColorShipping` WHERE `batch_number` = '" + batch + "' AND STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            else
            {
                query = "SELECT * FROM `DVCoatexColorShipping` WHERE  STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            return fetchRows(query);
        }

        public static List<string[]> getExpressCoatingColourShippingbyBatch(string batch)
        {
            string query = "SELECT * FROM `ExpressCoatingColourShipping`";
            if (batch != "" && batch != null)
            {
                query = "SELECT * FROM `ExpressCoatingColourShipping` WHERE `batch_number` = '" + batch + "' ";
            }
            return fetchRows(query);
        }

        public static List<string[]> getExpressCoatingColourShippingbyBatchDate(DateTime start, DateTime end, string batch)
        {
            string query;
            if (batch != "" && batch != null)
            {
                query = "SELECT * FROM `ExpressCoatingColourShipping` WHERE `batch_number` = '" + batch + "' AND STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            else
            {
                query = "SELECT * FROM `ExpressCoatingColourShipping` WHERE  STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            return fetchRows(query);
        }

        public static List<string[]> getVinylProFrameShippingbyBatch(string batch)
        {
            string query = "SELECT * FROM `VinylProFrameShipping`";
            if (batch != "" && batch != null)
            {
                query = "SELECT * FROM `VinylProFrameShipping` WHERE `batch_number` = '" + batch + "' ";
            }
            return fetchRows(query);
        }

        public static List<string[]> getVinylProFrameShippingbyBatchDate(DateTime start, DateTime end, string batch)
        {
            string query;
            if (batch != "" && batch != null)
            {
                query = "SELECT * FROM `VinylProFrameShipping` WHERE `batch_number` = '" + batch + "' AND STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            else
            {
                query = "SELECT * FROM `VinylProFrameShipping` WHERE STR_TO_DATE(`Date`, '%Y-%m-%d') BETWEEN STR_TO_DATE('" + start.ToString("yyyy-MM-dd") + "', '%Y-%m-%d') AND STR_TO_DATE('" + end.ToString("yyyy-MM-dd") + "', '%Y-%m-%d')";
            }
            return fetchRows(query);
        }

        public static List<string[]> importDVCoatexColorShippingPrefixByNames(List<string> names)
        {
            if (names != null && names.Count > 0)
            {
                string query = "SELECT * FROM `DVCoatexColorShipping_prefix` WHERE `name` IN ('" + string.Join("' , '", names) + "')";
                return fetchRows(query, true);
            }
            return null;
        }

        public static List<string[]> importVinylProFrameShippingPrefixByNames(List<string> names)
        {
            if (names != null && names.Count > 0)
            {
                string query = "SELECT * FROM `VinylProFrameShipping_prefix` WHERE `name` IN ('" + string.Join("' , '", names) + "')";
                return fetchRows(query, true);
            }
            return null;
        }

        public static List<string[]> importExpressCoatingColourShippingPrefixByNames(List<string> names)
        {
            if (names != null && names.Count > 0)
            {
                string query = "SELECT * FROM `ExpressCoatingColourShipping_prefix` WHERE `name` IN ('" + string.Join("' , '", names) + "')";
                return fetchRows(query, true);
            }
            return null;
        }

        public static List<string[]> importWindowsAssemblybyOrder(List<string> orders)
        {
            if (orders != null && orders.Count > 0)
            {
                string query = "SELECT * FROM `windowsassembly` WHERE `Line_number` Like '%" + string.Join("%' OR `Line_number`  Like '%", orders) + "%'";
                return fetchRows(query, true);
            }
            return null;
        }

        public static void insertControls(List<Tuple<string,string, string>> controls)
        {
            string query = "INSERT INTO `Controls` (`ControlId`, `ControlName`, `ControlParent`) VALUE ";
            foreach (Tuple<string, string, string> data in controls)
            {
                query += string.Format(" ('{0}', '{1}', '{2}'),", data.Item1,data.Item2, data.Item3);
            }
            query = query.Remove(query.Length - 1);
            excuteSQL(query);
        }

        public static List<string[]> getControls()
        {
            string query = "SELECT * FROM `Controls`";
            return fetchRows(query, true);
        }
       
        public static string[] getUserId(string userName)
        {
            string query = "SELECT * FROM `Accounts` WHERE `Username` = '"+ userName+"'";
            return fetchRow(query, true);
        }

        public static void insertControlsToUser(string id,List<int> ControlIds )
        {
            string query = "DELETE FROM `ControlsToUser` where `UserId` = '" + id+"'";
            excuteSQL(query);
            query = "INSERT INTO `ControlsToUser` (`UserId`, `ControlId`) VALUE ";
            foreach (int data in ControlIds)
            {
                query += string.Format(" ('{0}', '{1}'),", id, data);
            }
            query = query.Remove(query.Length - 1);
            excuteSQL(query);
        }

        public static List<string[]> getControlsToUser(string userId)
        {
            string query = "SELECT * FROM `ControlsToUser` WHERE `UserId` = '" + userId + "'";
            return fetchRows(query, true);
        }

        public static string[] getGlassRecutCounting()
        {
            string query = "SELECT * FROM `GlassRecut_Counting` WHERE `Date` = '" +DateTime.Today.ToString("yyyy-MM-dd") + "'";
            return fetchRow(query, true);
        }

        public static void updateGlassRecutCounting(int count)
        {
            string query = "UPDATE `GlassRecut_Counting` SET `Count` = "+count+" WHERE `Date` = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' ";
            excuteSQL(query);
        }

        public static void insertGlassRecutCounting()
        {
            string query = "INSERT INTO `GlassRecut_Counting` (`Date`, `Count`) VALUE('" + DateTime.Today.ToString("yyyy-MM-dd") + "', 1)";
            excuteSQL(query);
        }

        public static List<string[]> getWindowsWrappingData(DateTime dateTime)
        {
            string query = "SELECT `Order`, Count(`Line_number`)FROM `WindowsWrapping` " +
                "WHERE `Date`>='" + dateTime.Date.ToString("yyyy-MM-dd") + "' AND `Time`>='" + dateTime.TimeOfDay.ToString() + "' OR `Date`>='" + dateTime.Date.AddDays(1).ToString("yyyy-MM-dd") + "' GROUP BY `WindowsWrapping`.`Order`";
            return fetchRows(query, true);
        }

        public static List<string[]> getWindowsAssemblyData(DateTime dateTime)
        {
            string query = "SELECT `Line_number` FROM `windowsassembly` " +
                "WHERE `Date`>='" + dateTime.Date.ToString("yyyy-MM-dd") + "' AND `Time`>='" + dateTime.TimeOfDay.ToString() + "' OR `Date`>='" + dateTime.Date.AddDays(1).ToString("yyyy-MM-dd") + "'";
            return fetchRows(query, true);
        }

        public static List<string[]> getWorkOrderData(List<string> orders)
        {
            string query = "SELECT `ORDER #`, SUM(`QTY`),`DEALER` FROM `workorder` " +
                "WHERE `ORDER #` IN ('" + string.Join("' , '", orders) + "') GROUP BY `ORDER #`";
            return fetchRows(query, true);
        }

        public static List<string[]> getFrameReportDataDone(List<string> line_numbers)
        {
            string query = "SELECT LEFT(`LINE #1`, 5), COUNT(`LINE #1`), `types`.`type` FROM `framereport` " +
                "LEFT JOIN `types` ON `W.TYPE`= `types`.`value` " +
                "WHERE `framereport`.`LINE #1` IN ('" + string.Join("' , '", line_numbers) + "') GROUP BY(LEFT(`LINE #1`, 5)),  `types`.`type`";
            return fetchRows(query, true);
        }

        public static List<string[]> getFrameReportDataTotal(List<string> orders)
        {
            string query = "SELECT LEFT(`LINE #1`, 5), SUM(`QTY`), `types`.`type` FROM `framereport` " +
                "LEFT JOIN `types` ON `W.TYPE`= `types`.`value` " +
                "WHERE LEFT(`LINE #1`, 5) IN ('" + string.Join("' , '", orders) + "') GROUP BY(LEFT(`LINE #1`, 5)),  `types`.`type`";
            return fetchRows(query, true);
        }

        public static List<string[]> getFrameRecutNaming()
        {
            string query = "SELECT * FROM `FrameRecut_Naming`";
            return fetchRows(query);
        }
      
        public static void saveFrameRecutNaming(List<string[]> value)
        {
            string query = "DELETE FROM `FrameRecut_Naming`";
            excuteSQL(query);
            query = "INSERT INTO `FrameRecut_Naming` (`id`, `File_name`, `ColumnH`, `First_letter`,`Profile_Code`,`UCS4590`,`SCS4545`) VALUE ";
            foreach (string[] data in value)
            {
                query += string.Format(" ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}'),", data);
            }
            query = query.Remove(query.Length - 1);
            excuteSQL(query);
        }
      
        public static int saveFrameRecutData(string su_id, string date, string time, string order, string name, string reason)
        {
            string query = "INSERT INTO `FrameRecut` (`Order_id`, `Date`, `Time`,`Order_number`, `Name`,`Reason`,`Status`) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')";
            query = string.Format(query, su_id, date, time, order, name, reason, "Incomplete");
            int result = excuteSQL(query);
            return result;
        }

        public static string[] getFrameRecutCounting()
        {
            string query = "SELECT * FROM `FrameRecut_Counting` WHERE `Date` = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
            return fetchRow(query, true);
        }

        public static void updateFrameRecutCounting(int count)
        {
            string query = "UPDATE `FrameRecut_Counting` SET `Count` = " + count + " WHERE `Date` = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' ";
            excuteSQL(query);
        }

        public static void insertFrameRecutCounting()
        {
            string query = "INSERT INTO `FrameRecut_Counting` (`Date`, `Count`) VALUE('" + DateTime.Today.ToString("yyyy-MM-dd") + "', 1)";
            excuteSQL(query);
        }

        public static List<string[]> getOrderSummaryByListDateComapny(DateTime date1, DateTime date2, List<string[]> colors)
        {
            string query = "SELECT `ordersummary`.*, `ProductionCutList`.`Date` FROM `ordersummary` " +
                "LEFT JOIN `ProductionCutList` on `ordersummary`.`ORDER#` = `ProductionCutList`.`Order_Number` " +
                "WHERE `LIST DATE` between '" + date1.ToString("yyyyMMdd") + "' and '" + date2.ToString("yyyyMMdd") + "' AND `LIST DATE`!='' AND ";
            foreach (string[] data in colors)
            {
                query += string.Format(" (`COLOUR IN` = '{0}' AND `COLOUR OUT` = '{1}') OR", data);
            }
            query = query.Remove(query.Length - 2);
            return fetchRows(query);
        }

        public static string[] getOrderSummaryLeftProductionCutList(string order)
        {
            string query = "SELECT `ordersummary`.*, `ProductionCutList`.`Date` FROM `ordersummary` " +
                "LEFT JOIN `ProductionCutList` on `ordersummary`.`ORDER#` = `ProductionCutList`.`Order_Number` " +
                "WHERE `ordersummary`.`ORDER#` ='" + order+ "' AND NOT(`COLOUR IN`='WHT' AND `COLOUR OUT`='WHT')";
            return fetchRow(query);
        }

        public static int insertIntoProductionCutList(List<string[]> data)
        {
            string query = "INSERT INTO `ProductionCutList` (`Order_Number`,`Date`) VALUES ";
            int result = 1;
            if (data.Count > 0)
            {
                foreach (var item in data)
                {
                    query += string.Format(" ('{0}', '{1}'),", item);
                }
                query = query.Remove(query.Length - 1);
                result = excuteSQL(query);
            }
            return (result);
        }

        public static List<string[]> getCompanyFromWorkOrder(List<string> orders)
        {
            string query = "SELECT `ORDER #`, `DEALER` FROM `workorder` WHERE `ORDER #` IN ('" + string.Join("' , '", orders) + "')";
            return fetchRows(query, true);
        }

        public static void deleteIgSorting(string su_id)
        {
            string query = "DELETE FROM `ig_sorting` Where `sealed_unit_id` ='" + su_id+ "' LIMIT 1";
            excuteSQL(query);
        }

        public static void deleteFrameClearing(string line_id)
        {
            string query = "DELETE FROM `FrameClearing` Where `Id` ='" + line_id + "'";
            excuteSQL(query);
        }

        public static void deleteVinylProFrameShipping(string line_id)
        {
            string query = "DELETE FROM `VinylProFrameShipping` Where `Line` ='" + line_id + "'";
            excuteSQL(query);
        }

        public static void deleteColourShipping(string line_id)
        {
            string query = "DELETE FROM `ColourShipping` Where `Id` ='" + line_id + "'";
            excuteSQL(query);
        }

        public static void deleteCasementHardware(string line_id)
        {
            string query = "DELETE FROM `CasementHardware` Where `Id` ='" + line_id + "'";
            excuteSQL(query);
        }

        public static void deleteColourReceiving(string line_id)
        {
            string query = "DELETE FROM `ColourReceiving` Where `Id` ='" + line_id + "'";
            excuteSQL(query);
        }

        public static void deleteFrameAssembly(string line_id)
        {
            string query = "DELETE FROM `FrameAssembly` Where `Line_Id` ='" + line_id + "'";
            excuteSQL(query);
        }

        public static void deleteDVCoatexColorShipping(string line_id)
        {
            string query = "DELETE FROM `DVCoatexColorShipping` Where `Line` ='" + line_id + "'";
            excuteSQL(query);
        }

        public static void deleteDVCoatexColorReceiving(string line_id)
        {
            string query = "DELETE FROM `DVCoatexColorReceiving` Where `Line` ='" + line_id + "'";
            excuteSQL(query);
        }

        public static void deleteExpressCoatingColourShipping(string line_id)
        {
            string query = "DELETE FROM `ExpressCoatingColourShipping` Where `Line` ='" + line_id + "'";
            excuteSQL(query);
        }

        public static void deleteExpressCoatingColorReceiving(string line_id)
        {
            string query = "DELETE FROM `ExpressCoatingColorReceiving` Where `Line` ='" + line_id + "'";
            excuteSQL(query);
        }

        public static void deleteVinylProFrameReceiving(string line_id)
        {
            string query = "DELETE FROM `VinylProFrameReceiving` Where `Line` ='" + line_id + "'";
            excuteSQL(query);
        }

        public static int UpdateFrameRecut(string order_id)
        {
            string query = "UPDATE `FrameRecut` SET `Status` = 'Complete' WHERE `Order_id` = '" + order_id + "' ORDER BY id DESC LIMIT 1;";
            return excuteSQL(query);
        }

        public static List<string[]> getIncompleteGlassRecut(string su_id)
        {
            string query = "SELECT * FROM `GlassRecut` WHERE `sealed_unit_id`='"+su_id+ "' AND `Status` = 'Incomplete'";
            return fetchRows(query, false);
        }

        public static List<string[]> getIncompleteFrameRecut(string order_id)
        {
            string query = "SELECT * FROM `FrameRecut` WHERE `Order_id`='" + order_id + "' AND `Status` = 'Incomplete'";
            return fetchRows(query, false);
        }

        public static List<string[]> getFrameRecut()
        {
            string query = "SELECT * FROM `FrameRecut` WHERE `Removed`!='1'";
            return fetchRows(query, false);
        }

        public static int RemoveFromFrameRecut(string order_id)
        {
            string query = "UPDATE `FrameRecut` SET `Removed` = '1' " +
                "WHERE `Order_id` = '" + order_id + "' AND `Removed` = '0' ORDER BY id DESC LIMIT 1;";
            return excuteSQL(query);
        }

        public static List<string[]> getFrameReportCount(string start, string end)
        {
            string query = null;
            if (end == null)
            {
                query = "SELECT framereport.`LINE #1`, framereport.`W.TYPE` FROM `windowsassembly` " +
                    "LEFT JOIN framereport ON framereport.`LINE #1` = windowsassembly.Line_number " +
                    "WHERE `DATE` = '" + start + "'";
            }
            else
            {
                query = "SELECT framereport.`LINE #1`, framereport.`W.TYPE` FROM `windowsassembly` " +
                    "LEFT JOIN framereport ON framereport.`LINE #1` = windowsassembly.Line_number " +
                    "WHERE `DATE` BETWEEN '" + start + "' AND '" + end + "'";
            }
            return fetchRows(query);
        }

        public static List<string[]> getOrderByDates(DateTime[] dates)
        {
            string query = null;
            if (dates != null)
            {
                string[] parameters = dateRangeToStringArray(dates);
                query = "SELECT `ORDER#`, `COLOUR IN`, `COLOUR OUT`, `EX_COL1`, `EX_COL2`, `COMPANY` FROM `ordersummary` " +
                    "WHERE `LIST DATE` IN ('" + string.Join("' , '", parameters) + "')";
            }
            return fetchRows(query);
        }

        public static void savePaintSchedule(List<string[]> data)
        {
            string query = "";
            foreach (var row in data)
            {
                query += string.Format("UPDATE `ordersummary` SET `EX_COL2` = '{1}' WHERE `ORDER#` = '{0}';", row);
            }
            if (query != "") excuteSQL(query);
        }
       
        public static List<string[]> getColorFrameShipping(List<string> orders)
        {
            string query = null;
            if (orders != null)
            {
                query = "SELECT `F`, `H`,`J`, `Q`, `R`,  `ColourShipping`.`Id` FROM `framescutting` " +
                    "LEFT JOIN `ColourShipping` ON `ColourShipping`.`Id` = `framescutting`.`F` " +
                    "WHERE `J` IN ('" + string.Join("' , '", orders) + "') GROUP BY F  ";
            }
            return fetchRows(query);
        }

        public static List<string[]> getVinylProShipping(List<string> orders)
        {
            string query = null;
            if (orders != null)
            {
                query = "SELECT `F`, `H`,`J`, `Q`, `R`, `VinylProFrameShipping`.`Id` FROM `framescutting` " +
                    "LEFT JOIN `VinylProFrameShipping` ON `VinylProFrameShipping`.`Line` = `framescutting`.`F` " +
                    "WHERE `J` IN ('" + string.Join("' , '", orders) + "') GROUP BY F  ";
            }
            return fetchRows(query);
        }

        public static List<string[]> getColorFrameReceiving(List<string> orders)
        {
            string query = null;
            if (orders != null)
            {
                query = "SELECT `F`, `H`,`J`, `Q`, `R`,  `ColourReceiving`.`Id` FROM `framescutting` " +
                    "LEFT JOIN `ColourReceiving` ON `ColourReceiving`.`Id` = `framescutting`.`F` " +
                    "WHERE `J` IN ('" + string.Join("' , '", orders) + "') GROUP BY F  ";
            }
            return fetchRows(query);
        }

        public static List<string[]> getVinylProReceiving(List<string> orders)
        {
            string query = null;
            if (orders != null)
            {
                query = "SELECT `F`, `H`,`J`, `Q`, `R`, `VinylProFrameReceiving`.`Id` FROM `framescutting` " +
                    "LEFT JOIN `VinylProFrameReceiving` ON `VinylProFrameReceiving`.`Line` = `framescutting`.`F` " +
                    "WHERE `J` IN ('" + string.Join("' , '", orders) + "') GROUP BY F  ";
            }
            return fetchRows(query);
        }

        public static List<string[]> importcolourReceivingPrefixByNames(List<string> names)
        {
            string query = null;
            if (names != null && names.Count > 0)
            {
                query = "SELECT * FROM `ColourReceiving_prefix` WHERE `name` IN ('" + string.Join("' , '", names) + "')";
            }
            return fetchRows(query, true);
        }

        public static List<string[]> importVinylProFrameReceivingPrefixByNames(List<string> names)
        {
            string query = null;
            if (names != null && names.Count > 0)
            {
                query = "SELECT * FROM `VinylProFrameReceiving_prefix` WHERE `name` IN ('" + string.Join("' , '", names) + "')";
            }
            return fetchRows(query, true);
        }

        public static List<string[]> getOrderListDate(List<string> orders)
        {
            if (orders != null && orders.Count > 0)
            { 
                string query = "SELECT `ORDER#`, `LIST DATE` FROM `ordersummary` WHERE `ORDER#` IN ('" + string.Join("' , '", orders) + "')";
                return fetchRows(query);
            }
            return null;
        }

        public static List<string[]> getVinylShippingReceivingDate(List<string> orders)
        {
            string query = null;
            if (orders != null)
            {
                query = "SELECT `J`, MAX(`VinylProFrameShipping`.`Date`), MAX(`VinylProFrameReceiving`.`Date`) FROM `framescutting` " +
                    "LEFT JOIN VinylProFrameShipping ON VinylProFrameShipping.Line = `F` " +
                    "LEFT JOIN VinylProFrameReceiving ON VinylProFrameReceiving.Line = `F` " +
                    "WHERE `J` IN ('" + string.Join("' , '", orders) + "') GROUP BY F  ";
            }
            return fetchRows(query);
        }

        public static List<string[]> getIgSortingByDate(string start, string end)
        {
            string query = null;
            if (end == null)
            {
                query = "SELECT `sealed_unit_id` FROM `ig_sorting` " +
                     "WHERE `date` = '" + start + "'";
            }
            else
            {
                query = "SELECT `sealed_unit_id` FROM `ig_sorting` " +
                     " WHERE `date` BETWEEN '" + start + "' AND '" + end + "'";
            }
            return fetchRows(query);
        }

        public static List<string[]> getSUGlassReport(List<string> orders)
        {
            string query = null;
            if (orders != null)
            {
                query = "SELECT  `glassreport`.`sealed_unit_id`, `glassreport`.`order`  FROM `glassreport` " +
                    "LEFT JOIN `types` ON `glassreport`.`window_type` = CONCAT('Window_Type_', `types`.`value`) " +
                    "WHERE `types`.`type` = 'SU' AND `sealed_unit_id` IN ('" + string.Join("' , '", orders) + "')";
            }
            return fetchRows(query);
        }

        public static List<string[]> getProductionCutSlotSizeTable()
        {
            return fetchAllRows("ProductionCut_SlotSize");
        }

        public static void saveProductionCutSlotSizeTable(List<string[]> value)
        {
            if (value.Count != 0)
            {
                string query = "DELETE FROM `ProductionCut_SlotSize`";
                excuteSQL(query);
                query = "INSERT INTO `ProductionCut_SlotSize` (`id`, `ColumnH`, `SlotSize`) VALUE ";
                foreach (string[] data in value)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}'),", data);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static List<string[]> getOrderSummaryColors()
        {
            string query = "SELECT `COLOUR IN`, `COLOUR OUT` FROM `ordersummary` GROUP BY `COLOUR IN`, `COLOUR OUT`";
            return fetchRows(query);
        }

        public static List<string[]> getPaintCompanies()
        {
            string query = "SELECT `Name`, `ColorIn`, `ColorOut` FROM `PaintCompanies`";
            return fetchRows(query);
        }

        public static void savePaintCompaniesTable(List<string[]> value)
        {
            string query = "DELETE FROM `PaintCompanies`";
            excuteSQL(query);
            query = "INSERT INTO `PaintCompanies` (`Name`, `ColorIn`, `ColorOut`) VALUE ";
            foreach (string[] data in value)
            {
                query += string.Format(" ('{0}', '{1}', '{2}'),", data);
            }
            query = query.Remove(query.Length - 1);
            excuteSQL(query);
        }

        public static List<string[]> getPaintCompanies1()
        {
            string query = "SELECT * FROM `PaintCompanies1`";
            return fetchRows(query);
        }

        public static void savePaintCompanies1Table(List<string[]> value)
        {
            string query = "DELETE FROM `PaintCompanies1`";
            excuteSQL(query);
            query = "INSERT INTO `PaintCompanies1` (`id`, `Name`) VALUE ";
            foreach (string[] data in value)
            {
                query += string.Format(" ('{0}', '{1}'),", data);
            }
            query = query.Remove(query.Length - 1);
            excuteSQL(query);
        }

        public static List<string[]> getProductionSliderTypes()
        {
            return fetchAllRows("production_frame_type");
        }

        public static void saveProductionFrameTypes(List<string[]> value)
        {
            if (value.Count != 0)
            {
                string query = "DELETE FROM `production_frame_type`";
                excuteSQL(query);
                query = "INSERT INTO `production_frame_type` (`id`, `type`, `value`) VALUE ";
                foreach (string[] data in value)
                {
                    query += string.Format(" ('{0}', '{1}', '{2}'),", data);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static List<string[]> getIgSortingCount(List<string> suIds)
        {
            string query = null;
            if (suIds != null)
            {
                query = "SELECT `sealed_unit_id`, COUNT(`sealed_unit_id`) FROM `ig_sorting`" +
                    " WHERE `sealed_unit_id` IN ('" + string.Join("' , '", suIds) + "') GROUP BY `sealed_unit_id`";
                return fetchRows(query);
            }
            return null;
        }

        public static List<string[]> importGlassByBatch(string batch_number)
        {
            string query = null;
            if (batch_number != null)
            {
                query = "SELECT * FROM `glassreport` WHERE `note2` = '"+batch_number+"'";
            }
            return fetchRows(query, false);
        }

        public static List<string[]> getGlassLeftOrderSummaryByDate(DateTime[] date, string type)
        {
            string query = null;
            if (date.Length > 0)
            {
                string[] parameters = dateRangeToStringArray(date);
                if (type == "order")
                {
                    query = "SELECT `glassreport`.*, `ordersummary`.`ORDER#` FROM `ordersummary` " +
                        "LEFT JOIN `glassreport` ON `glassreport`.`order` = `ordersummary`.`ORDER#` " +
                        "WHERE `ordersummary`.`ORDER DATE`  IN ('" + string.Join("' , '", parameters) + "')";
                }
                if (type == "list")
                {
                    query = "SELECT`glassreport`.*, `ordersummary`.`ORDER#` FROM `ordersummary` " +
                        "LEFT JOIN `glassreport` ON `glassreport`.`order` = `ordersummary`.`ORDER#` " +
                        "WHERE `ordersummary`.`LIST DATE`  IN ('" + string.Join("' , '", parameters) + "')";
                }
                return fetchRows(query, false);
            }
            return null;
        }

        public static List<string[]> importWindowsShippingByLines(List<string> lines)
        {
            string query = null;
            if (lines != null && lines.Count > 0)
            {
                query = "SELECT * FROM `WindowsShipping` WHERE `Line_number` IN ('" + string.Join("','", lines) + " ')";
            }
            return fetchRows(query, false);
        }

        public static List<string[]> importWorkOrderByLines(List<string> lines)
        {
            string query = null;
            if (lines != null && lines.Count > 0)
            {
                query = "SELECT * FROM `workorder` WHERE `LINE #1` IN ('" + string.Join("','", lines) + "')";
            }
            return fetchRows(query, false);
        }

        public static List<string[]> getNotificationSettings()
        {
            return fetchAllRows("notification_settings", false);
        }

        public static void saveNotificationSettings(List<string[]> value)
        {
            if (value.Count != 0)
            {
                string query = "DELETE FROM `notification_settings`";
                excuteSQL(query);
                query = "INSERT INTO `notification_settings` (`id`, `dealer`, `tag`, `phone`) VALUE ";
                int i = 1;
                foreach (string[] data in value)
                {
                    query += string.Format(" ('" + i++ + "', '{0}', '{1}', '{2}'),", data);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static List<string[]> getShippingReportSettings()
        {
            return fetchAllRows("shipping_report_settings", false);
        }

        public static void saveShippingReportSettings(List<string[]> value)
        {
            if (value.Count != 0)
            {
                string query = "DELETE FROM `shipping_report_settings`";
                excuteSQL(query);
                query = "INSERT INTO `shipping_report_settings` (`id`, `dealer`, `email`) VALUE ";
                int i = 1;
                foreach (string[] data in value)
                {
                    query += string.Format(" ('" + i++ + "', '{0}', '{1}'),", data);
                }
                query = query.Remove(query.Length - 1);
                excuteSQL(query);
            }
        }

        public static List<string[]> getWorkOrderDealers()
        {
            string query = "SELECT `DEALER` FROM `workorder` GROUP BY `DEALER` ORDER BY `DEALER`";
            return fetchRows(query);
        }

        public static List<string[]> getWorkOrderDataGroupByOrder(string[] orders)
        {
            string query = "SELECT * FROM `workorder` WHERE `ORDER #` IN ('" + string.Join("','", orders) + "') GROUP BY `ORDER #`";
            return fetchRows(query);
        }

        public static List<string[]> getWindowsShippingByDate(DateTime[] dates)
        {
            string query = "SELECT `b`.`DEALER`, `a`.`Order`, `a`.`Number`, `b`.`QUANTITY`, `a`.`Name` "
                + "FROM (SELECT `Order`, `Name`, `Date`, COUNT(`id`) as Number FROM `WindowsShipping` GROUP BY `Order`) AS a "
                + "JOIN (SELECT `ORDER #`, `DEALER`, SUM(`QTY`) as QUANTITY FROM `workorder` GROUP BY `ORDER #`) AS b ON `a`.`Order` = `b`.`ORDER #` "
                + "WHERE `a`.`Date` BETWEEN '" + dates[0].ToString("yyyy-MM-dd") + "' AND '" + dates[1].ToString("yyyy-MM-dd") + "' "
                + "ORDER BY `b`.`DEALER`, `a`.`Order`;";
            return fetchRows(query);
        }

        public static List<string[]> getWindowsAssemblyByDate(DateTime[] dates)
        {
            string query = "SELECT `Date`, COUNT(`Line_number`) as Total FROM `windowsassembly` "
                + "WHERE `Date` BETWEEN '" + dates[0].ToString("yyyy-MM-dd") + "' AND '" + dates[1].ToString("yyyy-MM-dd") + "' "
                + "GROUP BY `Date` ORDER BY `Date`;";
            return fetchRows(query);
        }

        public static List<string[]> getReferenceFromWindowsShipping()
        {
            string query = "SELECT `Reference` FROM `WindowsShipping` GROUP BY `Reference` ORDER BY `Reference`";
            return fetchRows(query);
        }

        public static List<string[]> getShippingReportByBatchDate(DateTime[] dates, string batch)
        {
            string query = "SELECT `a`.`Order`, `a`.`WQTY`, `a`.`PQTY`, `a`.`CQTY`, `b`.`WINDOW DESCRIPTION` "
                + "FROM(SELECT `Order`, SUM(`Window`) AS WQTY, SUM(`P.door`) AS PQTY, SUM(`Casing`) AS CQTY, `Date`, `Reference` FROM `WindowsShipping` GROUP BY `Order`) AS a "
                + "JOIN(SELECT `ORDER #`, `WINDOW DESCRIPTION` FROM `workorder` GROUP BY `ORDER #`) AS b "
                + "ON `a`.`Order` = `b`.`ORDER #` "
                + "WHERE `a`.`Date` BETWEEN '" + dates[0].ToString("yyyy-MM-dd") + "' AND '" + dates[1].ToString("yyyy-MM-dd") + "' AND `a`.`Reference`='" + batch + "';";
            return fetchRows(query);
        }

        public static string[] getShippingReportAdditionalInfo(string company, string batch)
        {
            string query = "SELECT * FROM `shipping_report_additional_info` "
                + "WHERE `company`='" + company + "' AND `batch_number`='" + batch + "';";
            return fetchRow(query, false);
        }

        public static void saveShippingReportAdditionalInfo(string[] data, bool create)
        {
            string query;
            if (create)
            {
                query = string.Format("INSERT INTO `shipping_report_additional_info` "
                    + "(`company`, `batch_number`, `truck_arrived_date`, `truck_arrived_time`, `truck_left_date`, `truck_left_time`, `trailer_license`, `trailer_serial`, `loading_start_date`, `loading_start_time`, `loading_finish_date`, `loading_finish_time`, `loading_people`, `company_people`, `comment`, `shipper_name`) "
                    + "VALUE ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}');", data);
            }
            else
            {
                query = string.Format("UPDATE `shipping_report_additional_info` "
                    + "SET `truck_arrived_date`='{2}', `truck_arrived_time`='{3}', `truck_left_date`='{4}', `truck_left_time`='{5}', `trailer_license`='{6}', `trailer_serial`='{7}', `loading_start_date`='{8}', `loading_start_time`='{9}', `loading_finish_date`='{10}', `loading_finish_time`='{11}', `loading_people`='{12}', `company_people`='{13}', `comment`='{14}', `shipper_name`='{15}'"
                    + "WHERE `company`='{0}' AND `batch_number`='{1};", data);
            }
            excuteSQL(query);
        }
    }
}