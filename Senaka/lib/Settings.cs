using DeviceId;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka.lib
{
    static class Settings
    {
        private static string deviceID;

        public static DateTime[] Selected_Date;
        public static string Shutdown_Time;
        public static string Upload_From;
        public static string Upload_To;
        public static string Log_Path;

        public static int Rack_Size_16;
        public static int Rack_Size_8;
        public static List<string[]> Window_Type;
        public static List<string[]> Slider;
        public static List<string[]> Casement;
        public static List<string[]> SU;
        public static List<string[]> Shape;
        public static List<string[]> SU_History;
        public static List<string[]> SU_Shipping;
        public static Data_user user;
        public static List<string[]> IG_Sorting_Prefix_Table;
        public static int IG_Sorting_Error_Time;
        public static int IG_Sorting_Scan_Interval;

        public static int IG_Sorting_Scanned_Total;
        public static List<KeyValuePair<string, int>> IG_Sorting_Scanned;
        public static string IG_Sorting_Last_Scanned_Order;

        public static List<string[]> IG_Shipping_Prefix_Table;
        public static int IG_Shipping_Error_Time;
        public static List<string[]> Windows_Assembly_Prefix_Table;
        public static int Windows_Assembly_Error_Time;

        public static List<string[]> Frame_Clearing_Scanned;
        public static List<string[]> Frame_Clearing_Prefix_Table;
        public static int Frame_Clearing_Error_Time;
        public static int Frame_Clearing_Scan_Interval;

        public static List<string[]> Casement_Hardware_Scanned;
        public static List<string[]> Casement_Hardware_Prefix_Table;
        public static int Casement_Hardware_Error_Time;
        public static int Casement_Hardware_Scan_Interval;



        public static List<string[]> Colour_Shipping_Prefix_Table;
        public static int Colour_Shipping_Error_Time;

        public static List<string[]> Colour_Receiving_Prefix_Table;
        public static int Colour_Receiving_Error_Time;

        public static List<string[]> Brickmould;
        public static List<string[]> Casing;
        public static List<string[]> Casement_Frame;
        public static List<string[]> Casement_Sash;
        public static List<string[]> Slider_Frame;
        public static List<string[]> Slider_sash;
        public static List<string[]> Small_Fix;
        public static List<string[]> Large_Fix;
        public static List<string[]> Frame_Types;

        public static string sender_email;
        public static string sender_pass;

        public static List<string[]> OceanviewPatioDoors_fields;
        public static int OceanviewPatioDoors_days;

        public static List<string[]> VistaPatioDoors_fields;
        public static int VistaPatioDoors_days;

        public static string WindowsAssemblyHide;
        public static int WindowsAssemblyHideTime;
        public static int WindowsAssemblyUpdateTime;

        public static List<string[]> HourThermalGlass_Unit_fields;
        public static int HourThermalGlass_Unit_days;
        public static List<string[]> HourThermalGlass_Sheets_fields;
        public static int HourThermalGlass_Sheets_days;
        public static List<string[]> HourThermalGlass_CutToSize_fields;
        public static int HourThermalGlass_CutToSize_days;

        public static int Woodbridge_StockSheets_days;
        public static List<string[]> Woodbridge_StockSheets_fields;

        public static int Woodbridge_CutToSize_days;
        public static List<string[]> Woodbridge_CutToSize_fields;

        public static string NAAutoSelectOceanView;
        public static string NAAutoSelectVista;

        public static List<string[]> Receiving_Emails_Table;

        public static string EmailSubjectVista;
        public static string EmailSubjectVista_boolean;
        public static string EmailMessageVista;
        public static string EmailMessageVista_boolean;
        public static string EmailSignatureVista;
        public static string EmailSignatureVista_boolean;

        public static string EmailSubject24Hour;
        public static string EmailSubject24Hour_boolean;
        public static string EmailMessage24Hour;
        public static string EmailMessage24Hour_boolean;
        public static string EmailSignature24Hour;
        public static string EmailSignature24Hour_boolean;

        public static string EmailSubjectOceanview;
        public static string EmailSubjectOceanview_boolean;
        public static string EmailMessageOceanview;
        public static string EmailMessageOceanview_boolean;
        public static string EmailSignatureOceanview;
        public static string EmailSignatureOceanview_boolean;

        public static string EmailSubjectWoodbridge;
        public static string EmailSubjectWoodbridge_boolean;
        public static string EmailMessageWoodbridge;
        public static string EmailMessageWoodbridge_boolean;
        public static string EmailSignatureWoodbridge;
        public static string EmailSignatureWoodbridge_boolean;

        public static int OceanviewPatioDoors_Custom_Limit;
        public static int VistaPatioDoors_Custom_Limit;
        public static string CloseAppBoolean;
        public static List<string[]> TaskBoardEmail_list;
        public static List<Data_TaskBoard> TaskBoardData = new List<Data_TaskBoard>();
        public static List<string[]> Windows_Shipping_Prefix_Table;
        public static List<string[]> Frame_Assembly_Prefix_Table;
        public static string CountSashFrame_boolean;
        public static List<string[]> Windows_Wrapping_Prefix_Table;
        public static string WindowsWrappingHide;
        public static int WindowsWrappingHideTime;
        public static int WindowsWrappingUpdateTime;
        public static List<string[]> PatioDoors_Receiving_Prefix_Table;
        public static List<string[]> PatioDoors_Shipping_Prefix_Table;
        public static string PatioDoors_Shipping_Obligatory_Order_boolean;

        public static List<string[]> GlassRecut_Prefix_Table;
        public static string GlassRecut_Obligatory_Name_boolean;
        public static string GlassRecut_Obligatory_Reason_boolean;

        //Booking
        public static List<string[]> Window_Casement;
        public static List<string[]> Window_Dummy;
        public static List<string[]> Window_Fix;
        public static List<string[]> Window_Sdwind;
        public static List<string[]> Window_Shape;
        public static List<string[]> Window_Slider;
        public static List<string[]> Window_SU;
        public static List<string[]> Window_SUSHP;
        public static List<string[]> Window_Types;
        public static List<string[]> Book_Slider_Frame;
        public static List<string[]> Book_Slider_Sash;
        public static List<string[]> Book_Slider;
        public static string BookWindowType;
        public static string BookDueDate;
        public static string BookPswdTime;
        public static string BookDueDate_Message;
        public static string BookListDate_Message;
        public static string BookListDueDate;
        public static string BookCheckPassword;
        public static string BookPassword;
        public static string BookDateFilterType;
        public static string BookDateFilter;

        //Frame&Colour Receiving and Shipping
        public static List<string[]> VinylPro_Frame_Receiving_Prefix_Table;
        public static List<string[]> VinylPro_Frame_Shipping_Prefix_Table;
        public static List<string[]> DVCoatex_Color_Receiving_Prefix_Table;
        public static List<string[]> DVCoatex_Color_Shipping_Prefix_Table;
        public static List<string[]> ExpressCoating_Color_Receiving_Prefix_Table;
        public static List<string[]> ExpressCoating_Color_Shipping_Prefix_Table;
        public static int VinylPro_Frame_Receiving_Error_Time;
        public static int VinylPro_Frame_Shipping_Error_Time;
        public static int DVCoatex_Color_Receiving_Error_Time;
        public static int DVCoatex_Color_Shipping_Error_Time;
        public static int ExpressCoating_Color_Receiving_Error_Time;
        public static int ExpressCoating_Color_Shipping_Error_Time;

        //Frame Recut File Naming
        public static List<string[]> Frame_Recut_File_Naming_Table;
        public static string Frame_Recut_Obligatory_Name_boolean;
        public static string Frame_Recut_Obligatory_Reason_boolean;

        //Production Cut
      
        public static List<string[]> Production_Cut_SlotSize_Table;

        //Paint Comapnies
        public static List<string[]> Paint_Companies_Table;
        public static List<string> CompaniesList;
        public static List<string[]> UsedColorsList, NotUsedColorsList, TotalColorsList;
        public static List<string[]> Paint_Companies1_Table;

        //Production Frame Types
        public static List<string[]> Production_Types;
        public static List<string[]> Production_Casement;
        public static List<string[]> Production_LargeFix;
        public static List<string[]> Production_SmallFix;
        public static List<string[]> Production_DHFrame;
        public static List<string[]> Production_SHFrame;
        public static List<string[]> Production_SmallSash1;
        public static List<string[]> Production_SmallSash2;

        //Text Notification
        public static List<string[]> Notification_Dealers;
        public static bool Notification_Consider_Tag;
        public static bool Notification_Active_Password;
        public static string Notification_Password;
        public static string Notification_Upper_Message;
        public static string Notification_Down_Message;
        public static string TrueDialog_APIURL;
        public static string TrueDialog_AccountId;
        public static string TrueDialog_KEY;
        public static string TrueDialog_SECRET;
        public static string TrueDialog_CampaignId;

        //Shape PDF
        public static string ShapePDF_Path;

        //Shipping Report
        public static List<string[]> Shipping_Report_Dealers;

        public static void initSettings()
        {
            // Optimize
            Rack_Size_16 = Convert.ToInt32(DB.getSettings("rack_size_16", "40"));
            Rack_Size_8 = Convert.ToInt32(DB.getSettings("rack_size_8", "40"));
            string[] sliders = new string[] { "DES", "DESLO", "DS", "SH", "SHO", "SLO", "SS", "TRS", "V-A", "V-AO", "V-B", "V-BLO", "V-LCS", "V-SH", "V-SHO", "V-SLO", "V-SS", "V-SSO" };
            Slider = DB.getWindowType("SLIDER", sliders);
            string[] casements = new string[] { "AW-V", "B-AW", "B-F", "CS-L", "CS-R", "V-C", "V-F", "V-SF" };
            Casement = DB.getWindowType("CASEMENT", casements);
            string[] sus = new string[] { "SU", "SU1", "SUSHP" };
            SU = DB.getWindowType("SU", sus);
            string[] shapes = new string[] { "BSHAPE", "SHAPE", "SHP-SH" };
            Shape = DB.getWindowType("SHAPE", shapes);
            Window_Type = new List<string[]>()
                { getTypeValue(Slider), getTypeValue(Casement), getTypeValue(SU), getTypeValue(Shape) };
            SU_History = DB.getSUHistory();
            SU_Shipping = DB.getSUShipping();

            // General
            DateTime today = DateTime.Now;
            Selected_Date = new DateTime[] { today, today };
            Selected_Date[0] = Convert.ToDateTime(DB.getSettings("list_start_date", today.ToString("yyyy-MM-dd")));
            Selected_Date[1] = Convert.ToDateTime(DB.getSettings("list_end_date", today.ToString("yyyy-MM-dd")));

            deviceID = new DeviceIdBuilder()
                .AddMachineName()
                .AddMacAddress()
                .AddProcessorId()
                .AddMotherboardSerialNumber()
                .ToString();
            CloseAppBoolean = DB.getSettings("closeappboolean", "False", deviceID);
            Shutdown_Time = DB.getSettings("shutdown", "23:00", deviceID);
            Upload_From = DB.getSettings("upload_from", "C:\\uploadFiles".Replace("\\", "\\\\"), deviceID).Replace("\\\\", "\\");
            if (Upload_From != "" && !Directory.Exists(Upload_From))
            {
                try
                {
                    Directory.CreateDirectory(Upload_From);
                }
                catch (Exception e)
                {
                    Upload_From = "C:\\uploadFiles";
                    DB.saveSetting("upload_from", Upload_From.Replace("\\", "\\\\"), deviceID);
                }
            }
            Upload_To = DB.getSettings("upload_to", "C:\\uploads".Replace("\\", "\\\\"), deviceID).Replace("\\\\", "\\");
            if (Upload_To != "" && !Directory.Exists(Upload_To))
            {
                try
                {
                    Directory.CreateDirectory(Upload_To);
                }
                catch (Exception e)
                {
                    Upload_To = "C:\\uploads";
                    DB.saveSetting("upload_to", Upload_To.Replace("\\", "\\\\"), deviceID);
                }
            }
            Log_Path = DB.getSettings("log_path", Path.GetDirectoryName(Application.ExecutablePath).Replace("\\", "\\\\") + "\\\\Logs", deviceID).Replace("\\\\", "\\");
            if (Log_Path != "" && !Directory.Exists(Log_Path))
            {
                try
                {
                    Directory.CreateDirectory(Log_Path);
                }
                catch (Exception e)
                {
                    Log_Path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Logs";
                    DB.saveSetting("log_path", Log_Path.Replace("\\", "\\\\"));
                }
            }

            // IG Sorting
            IG_Sorting_Prefix_Table = DB.getIGSortingPrefix();
            IG_Sorting_Error_Time = Convert.ToInt32(DB.getSettings("ig_sorting_error_time", "5", deviceID));
            IG_Sorting_Scan_Interval = Convert.ToInt32(DB.getSettings("ig_sorting_scan_interval", "30", deviceID));

            IG_Sorting_Scanned_Total = 0;
            IG_Sorting_Scanned = new List<KeyValuePair<string, int>>();
            IG_Sorting_Last_Scanned_Order = "";

            // IG Shipping
            IG_Shipping_Prefix_Table = DB.getIGShippingPrefix();
            IG_Shipping_Error_Time = Convert.ToInt32(DB.getSettings("ig_shipping_error_time", "5", deviceID));
            // Windows Assembly
            Windows_Assembly_Prefix_Table = DB.getWindowsAssemblyPrefix();
            Windows_Assembly_Error_Time = Convert.ToInt32(DB.getSettings("windows_assembly_error_time", "5", deviceID));

            // Frame Clearing
            Frame_Clearing_Prefix_Table = DB.getFrameClearingPrefix();
            Frame_Clearing_Error_Time = Convert.ToInt32(DB.getSettings("frame_clearing_error_time", "5", deviceID));
            Frame_Clearing_Scan_Interval = Convert.ToInt32(DB.getSettings("frame_clearing_scan_interval", "30", deviceID));
            Frame_Clearing_Scanned = new List<string[]>();

            // Frame Clearing
            Casement_Hardware_Prefix_Table = DB.getCasementHardwarePrefix();
            Casement_Hardware_Error_Time = Convert.ToInt32(DB.getSettings("casement_hardware_error_time", "5", deviceID));
            Casement_Hardware_Scan_Interval = Convert.ToInt32(DB.getSettings("casement_hardware_scan_interval", "30", deviceID));
            Casement_Hardware_Scanned = new List<string[]>();

            // Frame Types
            List<string[]> frm_types = DB.getFrameTypes();
            Brickmould = frm_types.Where(x => x[1] == "Brickmould").ToList();

            Casing = frm_types.Where(x => x[1] == "Casing").ToList();

            Casement_Frame = frm_types.Where(x => x[1] == "Casement Frame").ToList();

            Casement_Sash = frm_types.Where(x => x[1] == "Casement Sash").ToList();

            Slider_Frame = frm_types.Where(x => x[1] == "Slider Frame").ToList();

            Slider_sash = frm_types.Where(x => x[1] == "Slider sash").ToList();

            Small_Fix = frm_types.Where(x => x[1] == "Small Fix").ToList();

            Large_Fix = frm_types.Where(x => x[1] == "Large Fix").ToList();
            Frame_Types = new List<string[]>()
                { getTypeValue(Brickmould), getTypeValue(Casing), getTypeValue(Casement_Frame), getTypeValue(Casement_Sash), getTypeValue(Slider_Frame), getTypeValue(Slider_sash), getTypeValue(Small_Fix), getTypeValue(Large_Fix) };

            // Colour Shipping
            Colour_Shipping_Prefix_Table = DB.getColourShippingPrefix();
            Colour_Shipping_Error_Time = Convert.ToInt32(DB.getSettings("colour_shipping_error_time", "5", deviceID));

            // Colour Receiving
            Colour_Receiving_Prefix_Table = DB.getColourReceivingPrefix();
            Colour_Receiving_Error_Time = Convert.ToInt32(DB.getSettings("colour_receiving_error_time", "5", deviceID));

            //email
            Receiving_Emails_Table = DB.getEmails();
            sender_email = "production.vinylpro@gmail.com";
            sender_pass = "vinylpro3350";
            EmailMessageVista = DB.getSettings("emailmessagevista", "", deviceID);
            EmailMessageVista_boolean = DB.getSettings("emailmessagevista_boolean", "False", deviceID);

            EmailSignatureVista = DB.getSettings("emailsignaturevista", "", deviceID);
            EmailSignatureVista_boolean = DB.getSettings("emailsignaturevista_boolean", "False", deviceID);

            EmailSubjectVista = DB.getSettings("emailsubjectvista", "", deviceID);
            EmailSubjectVista_boolean = DB.getSettings("emailsubjectvista_boolean", "False", deviceID);

            EmailMessage24Hour = DB.getSettings("emailmessage24hour", "", deviceID);
            EmailMessage24Hour_boolean = DB.getSettings("emailmessage24hour_boolean", "False", deviceID);

            EmailSignature24Hour = DB.getSettings("emailsignature24hour", "", deviceID);
            EmailSignature24Hour_boolean = DB.getSettings("emailsignature24hour_boolean", "False", deviceID);

            EmailSubject24Hour = DB.getSettings("emailsubject24hour", "", deviceID);
            EmailSubject24Hour_boolean = DB.getSettings("emailsubject24hour_boolean", "False", deviceID);

            EmailMessageOceanview = DB.getSettings("emailmessageoceanview", "", deviceID);
            EmailMessageOceanview_boolean = DB.getSettings("emailmessageoceanview_boolean", "False", deviceID);

            EmailSignatureOceanview = DB.getSettings("emailsignatureoceanview", "", deviceID);
            EmailSignatureOceanview_boolean = DB.getSettings("emailsignatureoceanview_boolean", "False", deviceID);

            EmailSubjectOceanview = DB.getSettings("emailsubjectoceanview", "", deviceID);
            EmailSubjectOceanview_boolean = DB.getSettings("emailsubjectoceanview_boolean", "False", deviceID);

            EmailMessageWoodbridge = DB.getSettings("emailmessagewoodbridge", "", deviceID);
            EmailMessageWoodbridge_boolean = DB.getSettings("emailmessagewoodbridge_boolean", "False", deviceID);

            EmailSignatureWoodbridge = DB.getSettings("emailsignaturewoodbridge", "", deviceID);
            EmailSignatureWoodbridge_boolean = DB.getSettings("emailsignaturewoodbridge_boolean", "False", deviceID);

            EmailSubjectWoodbridge = DB.getSettings("emailsubjectwoodbridge", "", deviceID);
            EmailSubjectWoodbridge_boolean = DB.getSettings("emailsubjectwoodbridge_boolean", "False", deviceID);

            // OceanviewPatioDoors
            OceanviewPatioDoors_fields = DB.getOceanviewPatioDoorsFields();
            OceanviewPatioDoors_days = Convert.ToInt32(DB.getSettings("oceanviewPatioDoors_days", "14", deviceID));
            NAAutoSelectOceanView = DB.getSettings("na_select_oceanview", "False", deviceID);
            OceanviewPatioDoors_Custom_Limit = Convert.ToInt32(DB.getSettings("oceanviewPatioDoors_custom_limit", "3", deviceID));

            // Vista
            VistaPatioDoors_fields = DB.getVistaPatioDoorsFields();
            VistaPatioDoors_days = Convert.ToInt32(DB.getSettings("vistaPatioDoors_days", "14", deviceID));
            NAAutoSelectVista = DB.getSettings("na_select_vista", "False", deviceID);
            VistaPatioDoors_Custom_Limit = Convert.ToInt32(DB.getSettings("vistaPatioDoors_custom_limit", "3", deviceID));


            // Windows Assebly Hide

            WindowsAssemblyHide = DB.getSettings("windowsAssemblyHide", "false", deviceID);
            WindowsAssemblyHideTime = Convert.ToInt32(DB.getSettings("windowsAssemblyHideTime", "1", deviceID));
            WindowsAssemblyUpdateTime = Convert.ToInt32(DB.getSettings("windowsAssemblyUpdateTime", "1", deviceID));

            // 24 hour thermal glass

            HourThermalGlass_CutToSize_days = Convert.ToInt32(DB.getSettings("hourThermalGlass_CutToSize_days", "14", deviceID));
            HourThermalGlass_CutToSize_fields = DB.get24HourThermalGlassCutToSizeFields();

            HourThermalGlass_Sheets_days = Convert.ToInt32(DB.getSettings("hourThermalGlass_Sheets_days", "14", deviceID));
            HourThermalGlass_Sheets_fields = DB.get24HourThermalGlassSheetsFields();

            HourThermalGlass_Unit_days = Convert.ToInt32(DB.getSettings("hourThermalGlass_Unit_days", "14", deviceID));
            HourThermalGlass_Unit_fields = DB.get24HourThermalGlassUnitFields();

            Woodbridge_StockSheets_days = Convert.ToInt32(DB.getSettings("woodbridge_StockSheets_days", "14", deviceID));
            Woodbridge_StockSheets_fields = DB.getWoodbridgeSheetsfields();

            Woodbridge_CutToSize_days = Convert.ToInt32(DB.getSettings("woodbridge_CutToSize_days", "14", deviceID));
            Woodbridge_CutToSize_fields = DB.getWoodbridgeCutToSizefields();

            //task board email
            TaskBoardEmail_list = DB.getTaskBoardEmail();


            // Windows Shipping
            Windows_Shipping_Prefix_Table = DB.getWindowsShippingPrefix();


            CountSashFrame_boolean = WindowsAssemblyHide = DB.getSettings("countSashFrame", "false", deviceID);

            //Frame Assembly
            Frame_Assembly_Prefix_Table = DB.getFrameAssemblyPrefix();

            // Windows Wrapping
            Windows_Wrapping_Prefix_Table = DB.getWindowsWrappingPrefix();
            // Windows Wrapping Hide

            WindowsWrappingHide = DB.getSettings("windowsWrappingHide", "false", deviceID);
            WindowsWrappingHideTime = Convert.ToInt32(DB.getSettings("windowsWrappingHideTime", "10", deviceID));
            WindowsWrappingUpdateTime = Convert.ToInt32(DB.getSettings("windowsWrappingUpdateTime", "10", deviceID));

            //Patio doors Receiving
            PatioDoors_Receiving_Prefix_Table = DB.getPatioDoorsReceivingPrefix();


            //Patio doors Shipping
            PatioDoors_Shipping_Prefix_Table = DB.getPatioDoorsShippingPrefix();
            PatioDoors_Shipping_Obligatory_Order_boolean  = DB.getSettings("patioDoors_shipping_obligatory_order_boolean", "false", deviceID);

            // Glass Recut
          
            GlassRecut_Obligatory_Name_boolean = DB.getSettings("glassRecut_obligatory_name_boolean", "false", deviceID);
            GlassRecut_Obligatory_Reason_boolean = DB.getSettings("glassRecut_obligatory_reason_boolean", "false", deviceID);
       

            //Booking
            List<string[]> window_types = DB.getWindowTypes();
            Window_Casement = window_types.Where(x => x[1] == "CASEMENT").ToList();
            Window_Dummy = window_types.Where(x => x[1] == "DUMMY").ToList();
            Window_Fix = window_types.Where(x => x[1] == "FIX").ToList();
            Window_Sdwind = window_types.Where(x => x[1] == "SDWIND").ToList();
            Window_Shape = window_types.Where(x => x[1] == "SHAPE").ToList();
            Window_Slider = window_types.Where(x => x[1] == "SLIDER").ToList();
            Window_SU = window_types.Where(x => x[1] == "SU").ToList();
            Window_SUSHP = window_types.Where(x => x[1] == "SUSHP").ToList();
        
            BookDueDate = DB.getSettings("book_due_date", "0", deviceID);
            BookListDueDate = DB.getSettings("list_due_date", "0", deviceID);
            BookDueDate_Message = DB.getSettings("book_due_date_message", "", deviceID);
            BookListDate_Message = DB.getSettings("book_list_date_message", "", deviceID);
            BookCheckPassword = DB.getSettings("book_check_password", "false", deviceID);
            BookPassword= DB.getSettings("book_password", "", deviceID);
            BookPswdTime = DB.getSettings("book_time", "0", deviceID);
            BookDateFilterType = DB.getSettings("book_date_filter_type", "ORDER DATE", deviceID);
            BookDateFilter = DB.getSettings("book_date_filter", "", deviceID);

            //Booking Slider Types
            List<string[]> book_frame_types = DB.getBookingSliderTypes();
            Book_Slider_Frame= book_frame_types.Where(x => x[1] == "FRAME").ToList();
            Book_Slider_Sash = book_frame_types.Where(x => x[1] == "SASH").ToList();

            //Frame&Colour Receiving and Shipping
            VinylPro_Frame_Receiving_Prefix_Table = DB.getReceivingShippingPrefix("VinylProFrameReceiving_prefix");
            VinylPro_Frame_Shipping_Prefix_Table = DB.getReceivingShippingPrefix("VinylProFrameShipping_prefix");
            DVCoatex_Color_Receiving_Prefix_Table = DB.getReceivingShippingPrefix("DVCoatexColorReceiving_prefix");
            DVCoatex_Color_Shipping_Prefix_Table = DB.getReceivingShippingPrefix("DVCoatexColorShipping_prefix");
            ExpressCoating_Color_Receiving_Prefix_Table = DB.getReceivingShippingPrefix("ExpressCoatingColorReceiving_prefix");
            ExpressCoating_Color_Shipping_Prefix_Table = DB.getReceivingShippingPrefix("ExpressCoatingColourShipping_prefix");

           VinylPro_Frame_Receiving_Error_Time = Convert.ToInt32(DB.getSettings("vinylPro_frame_receiving_error_time", "5", deviceID));
            VinylPro_Frame_Shipping_Error_Time = Convert.ToInt32(DB.getSettings("vinylPro_frame_shipping_error_time", "5", deviceID));
            DVCoatex_Color_Receiving_Error_Time = Convert.ToInt32(DB.getSettings("dVCoatex_color_receiving_error_time", "5", deviceID));
            DVCoatex_Color_Shipping_Error_Time = Convert.ToInt32(DB.getSettings("dVCoatex_color_shipping_error_time", "5", deviceID));
            ExpressCoating_Color_Receiving_Error_Time = Convert.ToInt32(DB.getSettings("expressCoating_color_receiving_error_time", "5", deviceID));
            ExpressCoating_Color_Shipping_Error_Time = Convert.ToInt32(DB.getSettings("expressCoating_color_shipping_error_time", "5", deviceID));

            //Frame Recut
            Frame_Recut_File_Naming_Table = DB.getFrameRecutNaming();
            Frame_Recut_Obligatory_Name_boolean = DB.getSettings("frameRecut_obligatory_name_boolean", "false", deviceID);
            Frame_Recut_Obligatory_Reason_boolean = DB.getSettings("frameRecut_obligatory_reason_boolean", "false", deviceID);
          
            //Production Cut
            Production_Cut_SlotSize_Table = DB.getProductionCutSlotSizeTable();

            //Paint Comapnies
            Paint_Companies_Table = DB.getPaintCompanies();
            TotalColorsList = DB.getOrderSummaryColors();
            CompaniesList = Paint_Companies_Table.Select(x => x[0]).Distinct().ToList();
            UsedColorsList = Paint_Companies_Table.Select(x => new string[] { x[1], x[2] }).Distinct().ToList();
            NotUsedColorsList = TotalColorsList.Where(p => !UsedColorsList.Any(l => p.SequenceEqual(l))).ToList();
            Paint_Companies1_Table = DB.getPaintCompanies1();

            //Production Frame Types
            List<string[]> production_frame_types = DB.getProductionSliderTypes();
            Production_Casement = production_frame_types.Where(x => x[1] == "CASEMENT").ToList();
            Production_LargeFix = production_frame_types.Where(x => x[1] == "LARGE FIX").ToList();
            Production_SmallFix = production_frame_types.Where(x => x[1] == "SMALL FIX").ToList();
            Production_DHFrame = production_frame_types.Where(x => x[1] == "DH Frame").ToList();
            Production_SHFrame = production_frame_types.Where(x => x[1] == "SH Frame").ToList();
            Production_SmallSash1 = production_frame_types.Where(x => x[1] == "Small Sash 1").ToList();
            Production_SmallSash2 = production_frame_types.Where(x => x[1] == "Small Sash 2").ToList();

            //Notification
            Notification_Dealers = DB.getNotificationSettings();
            Notification_Consider_Tag = DB.getSettings("notification_consider_tag", "0") == "1";
            Notification_Active_Password = DB.getSettings("notification_active_password", "0") == "1";
            Notification_Password = DB.getSettings("notification_password", "");
            Notification_Upper_Message = DB.getSettings("notification_upper_message", "");
            Notification_Down_Message = DB.getSettings("notification_down_message", "");
            TrueDialog_APIURL = DB.getSettings("notification_truedialog_api_url", "https://api.truedialog.com/api/v2.1/");
            TrueDialog_AccountId = DB.getSettings("notification_truedialog_account_id", "18035");
            TrueDialog_KEY = DB.getSettings("notification_truedialog_key", "417efbf4f9f34469ab09ced7f95f6454");
            TrueDialog_SECRET = DB.getSettings("notification_truedialog_secret", "w}5SW6r_?Y3z");
            TrueDialog_CampaignId = DB.getSettings("notification_truedialog_campagin_id", "114683");

            //Shape PDF
            ShapePDF_Path = DB.getSettings("shape_pdf_path", "C:\\pdfs".Replace("\\", "\\\\"), deviceID).Replace("\\\\", "\\");
            if (ShapePDF_Path != "" && !Directory.Exists(ShapePDF_Path))
            {
                try
                {
                    Directory.CreateDirectory(ShapePDF_Path);
                }
                catch (Exception e)
                {
                    ShapePDF_Path = "C:\\pdfs";
                }
            }

            //Shippping Report
            Shipping_Report_Dealers = DB.getShippingReportSettings();
        }

        public static string[] getTypeValue(List<string[]> list)
        {
            List<string> data = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                data.Add(list[i][(int)TYPES.VALUE]);
            }
            return data.ToArray();
        }

        public static void saveSetting()
        {
            // Optimize
            DB.saveSetting("rack_size_16", Rack_Size_16.ToString());
            DB.saveSetting("rack_size_8", Rack_Size_8.ToString());
            DB.saveWindowType("SLIDER", Slider);
            DB.saveWindowType("CASEMENT", Casement);
            DB.saveWindowType("SU", SU);
            DB.saveWindowType("SHAPE", Shape);

            // General
            DB.saveSetting("list_start_date", Selected_Date[0].ToString("yyyy-MM-dd"));
            DB.saveSetting("list_end_date", Selected_Date[1].ToString("yyyy-MM-dd"));
            DB.saveSetting("shutdown", Shutdown_Time, deviceID);
            DB.saveSetting("upload_from", Upload_From.Replace("\\", "\\\\"), deviceID);
            DB.saveSetting("upload_to", Upload_To.Replace("\\", "\\\\"), deviceID);
            DB.saveSetting("log_path", Log_Path.Replace("\\", "\\\\"), deviceID);
            DB.saveSetting("closeappboolean", CloseAppBoolean, deviceID);
            // IG Sorting
            DB.saveIGSortingPrefix(IG_Sorting_Prefix_Table);
            DB.saveSetting("ig_sorting_error_time", IG_Sorting_Error_Time.ToString(), deviceID);
            DB.saveSetting("ig_sorting_scan_interval", IG_Sorting_Scan_Interval.ToString(), deviceID);

            // IG Shipping
            DB.saveIGShippingPrefix(IG_Shipping_Prefix_Table);
            DB.saveSetting("ig_shipping_error_time", IG_Shipping_Error_Time.ToString(), deviceID);
            // Windows Assembly
            DB.saveWindowsAssemblyPrefix(Windows_Assembly_Prefix_Table);
            DB.saveSetting("windows_assembly_error_time", Windows_Assembly_Error_Time.ToString(), deviceID);

            // Frame Clearing
            DB.saveFrameClearing(Frame_Clearing_Prefix_Table);
            DB.saveSetting("frame_clearing_error_time", Frame_Clearing_Error_Time.ToString(), deviceID);
            DB.saveSetting("frame_clearing_scan_interval", Frame_Clearing_Scan_Interval.ToString(), deviceID);

            // Frame Types
            DB.saveFrameTypes("Brickmould", Brickmould);
            DB.saveFrameTypes("Casing", Casing);
            DB.saveFrameTypes("Casement Frame", Casement_Frame);
            DB.saveFrameTypes("Casement Sash", Casement_Sash);
            DB.saveFrameTypes("Slider Frame", Slider_Frame);
            DB.saveFrameTypes("Slider sash", Slider_sash);
            DB.saveFrameTypes("Small Fix", Small_Fix);
            DB.saveFrameTypes("Large Fix", Large_Fix);

            // Casement Hardware
            DB.saveCasementHardware(Casement_Hardware_Prefix_Table);
            DB.saveSetting("casement_hardware_error_time", Casement_Hardware_Error_Time.ToString(), deviceID);
            DB.saveSetting("casement_hardware_scan_interval", Casement_Hardware_Scan_Interval.ToString(), deviceID);

            // Colour Shipping
            DB.saveColourShippingPrefix(Colour_Shipping_Prefix_Table);
            DB.saveSetting("colour_shipping_error_time", Colour_Shipping_Error_Time.ToString(), deviceID);

            // Colour Receiving
            DB.saveColourReceivingPrefix(Colour_Receiving_Prefix_Table);
            DB.saveSetting("colour_receiving_error_time", Colour_Receiving_Error_Time.ToString(), deviceID);

            //email
            DB.saveEmails(Receiving_Emails_Table);
            DB.saveSetting("emailmessagevista", EmailMessageVista.ToString(), deviceID);
            DB.saveSetting("emailmessagevista_boolean", EmailMessageVista_boolean.ToString(), deviceID);

            DB.saveSetting("emailsignaturevista", EmailSignatureVista.ToString(), deviceID);
            DB.saveSetting("emailsignaturevista_boolean", EmailSignatureVista_boolean.ToString(), deviceID);

            DB.saveSetting("emailsubjectvista", EmailSubjectVista.ToString(), deviceID);
            DB.saveSetting("emailsubjectvista_boolean", EmailSubjectVista_boolean.ToString(), deviceID);

            DB.saveSetting("emailmessage24hour", EmailMessage24Hour.ToString(), deviceID);
            DB.saveSetting("emailmessage24hour_boolean", EmailMessage24Hour_boolean.ToString(), deviceID);

            DB.saveSetting("emailsignature24hour", EmailSignature24Hour.ToString(), deviceID);
            DB.saveSetting("emailsignature24hour_boolean", EmailSignature24Hour_boolean.ToString(), deviceID);

            DB.saveSetting("emailsubject24hour", EmailSubject24Hour.ToString(), deviceID);
            DB.saveSetting("emailsubject24hour_boolean", EmailSubject24Hour_boolean.ToString(), deviceID);

            DB.saveSetting("emailmessageoceanview", EmailMessageOceanview.ToString(), deviceID);
            DB.saveSetting("emailmessageoceanview_boolean", EmailMessageOceanview_boolean.ToString(), deviceID);

            DB.saveSetting("emailsignatureoceanview", EmailSignatureOceanview.ToString(), deviceID);
            DB.saveSetting("emailsignatureoceanview_boolean", EmailSignatureOceanview_boolean.ToString(), deviceID);

            DB.saveSetting("emailsubjectoceanview", EmailSubjectOceanview.ToString(), deviceID);
            DB.saveSetting("emailsubjectoceanview_boolean", EmailSubjectOceanview_boolean.ToString(), deviceID);

            DB.saveSetting("emailmessagewoodbridge", EmailMessageWoodbridge.ToString(), deviceID);
            DB.saveSetting("emailmessagewoodbridge_boolean", EmailMessageWoodbridge_boolean.ToString(), deviceID);

            DB.saveSetting("emailsignaturewoodbridge", EmailSignatureWoodbridge.ToString(), deviceID);
            DB.saveSetting("emailsignaturewoodbridge_boolean", EmailSignatureWoodbridge_boolean.ToString(), deviceID);

            DB.saveSetting("emailsubjectwoodbridge", EmailSubjectWoodbridge.ToString(), deviceID);
            DB.saveSetting("emailsubjectwoodbridge_boolean", EmailSubjectWoodbridge_boolean.ToString(), deviceID);



            // OceanviewPatioDoors
            DB.saveOceanviewPatioDoorsFields(OceanviewPatioDoors_fields);
            DB.saveSetting("oceanviewPatioDoors_days", OceanviewPatioDoors_days.ToString(), deviceID);
            DB.saveSetting("na_select_oceanview", NAAutoSelectOceanView.ToString(), deviceID);
            DB.saveSetting("oceanviewPatioDoors_custom_limit", OceanviewPatioDoors_Custom_Limit.ToString(), deviceID);

            // VistaPatioDoors
            DB.saveVistaPatioDoorsFields(VistaPatioDoors_fields);
            DB.saveSetting("vistaPatioDoors_days", VistaPatioDoors_days.ToString(), deviceID);
            DB.saveSetting("vistaPatioDoors_custom_limit", VistaPatioDoors_Custom_Limit.ToString(), deviceID);

            // Windows Assebly Hide

            DB.saveSetting("windowsAssemblyHide", WindowsAssemblyHide.ToString(), deviceID);
            DB.saveSetting("windowsAssemblyHideTime", WindowsAssemblyHideTime.ToString(), deviceID);
            DB.saveSetting("windowsAssemblyUpdateTime", WindowsAssemblyUpdateTime.ToString(), deviceID);
            DB.saveSetting("na_select_vista", NAAutoSelectVista.ToString(), deviceID);


            // 24 hour thermal glass
            DB.save24HourThermalGlassUnitFields(HourThermalGlass_Unit_fields);
            DB.saveSetting("hourThermalGlass_Unit_days", HourThermalGlass_Unit_days.ToString(), deviceID);

            DB.save24HourThermalGlassSheetsFields(HourThermalGlass_Sheets_fields);
            DB.saveSetting("hourThermalGlass_Sheets_days", HourThermalGlass_Sheets_days.ToString(), deviceID);

            DB.save24HourThermalGlassCutToSizeFields(HourThermalGlass_CutToSize_fields);
            DB.saveSetting("hourThermalGlass_CutToSize_days", HourThermalGlass_CutToSize_days.ToString(), deviceID);


            // woodbridge
            DB.saveWoodbridgeCutToSizefields(Woodbridge_CutToSize_fields);
            DB.saveSetting("woodbridge_CutToSize_days", Woodbridge_CutToSize_days.ToString(), deviceID);

            DB.saveWoodbridgeSheetsfields(Woodbridge_StockSheets_fields);
            DB.saveSetting("woodbridge_StockSheets_days", Woodbridge_StockSheets_days.ToString(), deviceID);

            //task board email
            DB.saveTaskBoardEmail(TaskBoardEmail_list);

            // Windows Shipping
            DB.saveWindowsShippingPrefix(Windows_Shipping_Prefix_Table);

            // Frame Assembly
            DB.saveFrameAssemblyPrefix(Frame_Assembly_Prefix_Table);

            DB.saveSetting("countSashFrame", CountSashFrame_boolean, deviceID);


            // Windows Wrapping
            DB.saveWindowsWrappingPrefix(Windows_Wrapping_Prefix_Table);
            DB.saveSetting("windowsWrappingHide", WindowsWrappingHide.ToString(), deviceID);
            DB.saveSetting("windowsWrappingHideTime", WindowsWrappingHideTime.ToString(), deviceID);
            DB.saveSetting("windowsWrappingUpdateTime", WindowsWrappingUpdateTime.ToString(), deviceID);
            //Patio doors Receiving
            DB.savePatioDoorsReceivingPrefix(PatioDoors_Receiving_Prefix_Table);

            //Patio doors Shipping
            DB.savePatioDoorsShippingPrefix(PatioDoors_Shipping_Prefix_Table);
            DB.saveSetting("patioDoors_shipping_obligatory_order_boolean", PatioDoors_Shipping_Obligatory_Order_boolean.ToString(), deviceID);

            // Glass Recut
           
            DB.saveSetting("glassRecut_obligatory_name_boolean", GlassRecut_Obligatory_Name_boolean.ToString(), deviceID);
            DB.saveSetting("glassRecut_obligatory_reason_boolean", GlassRecut_Obligatory_Reason_boolean.ToString(), deviceID);
            
            //Booking

            DB.saveWindowTypes(Window_Types);
            
            DB.saveSetting("book_due_date", BookDueDate.ToString(), deviceID);
            DB.saveSetting("list_due_date", BookListDueDate.ToString(), deviceID);
            DB.saveSetting("book_due_date_message", BookDueDate_Message.ToString(), deviceID);
            DB.saveSetting("book_list_date_message", BookListDate_Message.ToString(), deviceID);
            DB.saveSetting("book_check_password", BookCheckPassword.ToString(), deviceID);
            DB.saveSetting("book_password", BookPassword.ToString(), deviceID);
            DB.saveSetting("book_time", BookPswdTime.ToString(), deviceID);
            DB.saveSetting("book_date_filter_type", BookDateFilterType, deviceID);
            DB.saveSetting("book_date_filter", BookDateFilter, deviceID);

            //Booking Slider Types
            DB.saveWBookingSliderTypes(Book_Slider);

            //Frame&Colour Receiving and Shipping
            DB.saveReceivingShippingPrefix("VinylProFrameReceiving_prefix",VinylPro_Frame_Receiving_Prefix_Table);
            DB.saveReceivingShippingPrefix("VinylProFrameShipping_prefix", VinylPro_Frame_Shipping_Prefix_Table);
            DB.saveReceivingShippingPrefix("DVCoatexColorReceiving_prefix", DVCoatex_Color_Receiving_Prefix_Table);
            DB.saveReceivingShippingPrefix("DVCoatexColorShipping_prefix", DVCoatex_Color_Shipping_Prefix_Table);
            DB.saveReceivingShippingPrefix("ExpressCoatingColorReceiving_prefix", ExpressCoating_Color_Receiving_Prefix_Table);
            DB.saveReceivingShippingPrefix("ExpressCoatingColourShipping_prefix", ExpressCoating_Color_Shipping_Prefix_Table);

            DB.saveSetting("vinylPro_frame_receiving_error_time", VinylPro_Frame_Receiving_Error_Time.ToString(), deviceID);
            DB.saveSetting("vinylPro_frame_shipping_error_time", VinylPro_Frame_Shipping_Error_Time.ToString(), deviceID);
            DB.saveSetting("dVCoatex_color_receiving_error_time", DVCoatex_Color_Receiving_Error_Time.ToString(), deviceID);
            DB.saveSetting("dVCoatex_color_shipping_error_time", DVCoatex_Color_Shipping_Error_Time.ToString(), deviceID);
            DB.saveSetting("expressCoating_color_receiving_error_time", ExpressCoating_Color_Receiving_Error_Time.ToString(), deviceID);
            DB.saveSetting("expressCoating_color_shipping_error_time", ExpressCoating_Color_Shipping_Error_Time.ToString(), deviceID);

            //Frame Recut
            DB.saveFrameRecutNaming(Frame_Recut_File_Naming_Table);
            DB.saveSetting("frameRecut_obligatory_name_boolean", Frame_Recut_Obligatory_Name_boolean.ToString(), deviceID);
            DB.saveSetting("frameRecut_obligatory_reason_boolean", Frame_Recut_Obligatory_Reason_boolean.ToString(), deviceID);
            
            //Production Cut
            DB.saveProductionCutSlotSizeTable(Production_Cut_SlotSize_Table);

            //Production Frame Types
            DB.saveProductionFrameTypes(Production_Types);

            //Paint Companies
            DB.savePaintCompaniesTable(Paint_Companies_Table);
            DB.savePaintCompanies1Table(Paint_Companies1_Table);

            //Notification
            DB.saveNotificationSettings(Notification_Dealers);
            DB.saveSetting("notification_consider_tag", Notification_Consider_Tag ? "1" : "0");
            DB.saveSetting("notification_active_password", Notification_Active_Password ? "1" : "0");
            DB.saveSetting("notification_password", Notification_Password);
            DB.saveSetting("notification_upper_message", Notification_Upper_Message);
            DB.saveSetting("notification_down_message", Notification_Down_Message);
            DB.saveSetting("notification_truedialog_api_url", TrueDialog_APIURL);
            DB.saveSetting("notification_truedialog_account_id", TrueDialog_AccountId);
            DB.saveSetting("notification_truedialog_key", TrueDialog_KEY);
            DB.saveSetting("notification_truedialog_secret", TrueDialog_SECRET);
            DB.saveSetting("notification_truedialog_campagin_id", TrueDialog_CampaignId);

            //Shape PDF
            DB.saveSetting("shape_pdf_path", ShapePDF_Path.Replace("\\", "\\\\"), deviceID);

            //Shipping Report
            DB.saveShippingReportSettings(Shipping_Report_Dealers);
        }

        public static void saveSUHistory(List<string[]> su_history)
        {
            SU_History = su_history;
            DB.saveSUHistory(SU_History);
        }

        public static void saveSUShipping(List<string[]> su_shipping)
        {
            SU_Shipping = su_shipping;
            DB.saveSUShipping(SU_Shipping);
        }
    }
}
