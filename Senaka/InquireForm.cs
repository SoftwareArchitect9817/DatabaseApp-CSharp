using Senaka.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka
{
    public partial class InquireForm : Form
    {
        string _Type;

        public InquireForm(List<string[]> data, string type, bool close = true)
        {
            InitializeComponent();
            if (close)
                this.FormClosing += new FormClosingEventHandler(InquireForm_FormClosing);
            _Type = type;

            Set(data, type, close);
        }
        public void Set(List<string[]> data, string type, bool close = true)
        {
            if (data != null)
            {
                List<string[]> data_done = new List<string[]>();
                List<string> frame_ids = new List<string>();
                List<string> names = new List<string>();
                if (!(type == "windowsAssembly"))
                    foreach (var element in data)

                        frame_ids.Add(element[5]);

                if (type == "frameClearing")
                {
                    List<string[]> FrameClearing_prefix_date = new List<string[]>();

                    dataInquire.Columns.Add("machine_id", "Machine Id");
                    dataInquire.Columns.Add("status", "Status");
                    data_done = DB.importFrameClearingByIds(frame_ids);

                    foreach (var element in data_done)
                    {
                        names.Add(element[3]);
                    }

                    if (names.Count != 0)
                        FrameClearing_prefix_date = DB.importFrameClearingPrefixByNames(names);

                    foreach (var element in data)
                    {
                        string name = "", date = "", machine_id = "", time = "", status = "NOT READY";
                        var match = data_done.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));
                        if (match != null)
                        {
                            status = "COMPLETE";
                            name = match[3];
                            date = match[1].Substring(0, 10);
                            time = match[2];
                            string[] match_prefix = null;
                            if (FrameClearing_prefix_date != null)
                                match_prefix = FrameClearing_prefix_date.FirstOrDefault(stringToCheck => stringToCheck[3].Contains(name));
                            if (match_prefix != null)
                                machine_id = match_prefix[4];
                        }

                        dataInquire.Rows.Add(element[18], element[11], element[12], element[7], element[5], element[16], element[17], element[19], date, time, name, machine_id, status);

                    }
                    for (int i = 0; i < dataInquire.Rows.Count - 1; i++)
                    {
                        if (dataInquire.Rows[i].Cells["status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["status"].Style.BackColor = Color.Lime;
                        else dataInquire.Rows[i].Cells["status"].Style.BackColor = Color.OrangeRed;

                    }

                }
                else if (type == "windowsAssembly")
                {
                    foreach (var element in data)
                    {
                        frame_ids.Add(element[0]);

                    }

                    dataInquire.Columns.Remove("ordnumb");
                    dataInquire.Columns.Remove("windowType");
                    dataInquire.Columns.Remove("size");
                    dataInquire.Columns.Remove("Material");
                    dataInquire.Columns.Remove("frameId");
                    dataInquire.Columns.Remove("colourIn");
                    dataInquire.Columns.Remove("colourOut");
                    dataInquire.Columns.Remove("rubberColour");
                    dataInquire.Columns.Remove("date");
                    dataInquire.Columns.Remove("time");
                    dataInquire.Columns.Remove("name");
                    dataInquire.Columns.Add("line", "LINE #1");
                    dataInquire.Columns.Add("qty", "QTY");
                    dataInquire.Columns.Add("width", "WIDTH");
                    dataInquire.Columns.Add("height", "HEIGHT");
                    dataInquire.Columns.Add("windowType", "W.TYPE");
                    dataInquire.Columns.Add("scanQty", "SCAN QUANTITY ");
                    dataInquire.Columns.Add("date", "DATE");
                    dataInquire.Columns.Add("time", "TIME");
                    dataInquire.Columns.Add("name", "NAME");
                    dataInquire.Columns.Add("status", "STATUS");

                    if (frame_ids.Count != 0)
                        data_done = DB.importWindowsAssemblyByIds(frame_ids);

                    foreach (var element in data)
                    {
                        string name = "", date = "", time = "", status = "";
                        int scanQty = 0;
                        for (int i = 0; i < data_done.Count; i++)
                            if (data_done[i][0] == element[0])
                            {
                                name = data_done[i][3];
                                date = data_done[i][1].Substring(0, 10);
                                time = data_done[i][2];
                                scanQty++;
                            }
                        if (scanQty.Equals(Int32.Parse(element[1]))) status = "COMPLETE"; else if (!scanQty.Equals(0)) status = "PROGRESSING"; else if (scanQty.Equals(0)) status = "NOT READY";

                        dataInquire.Rows.Add(element[0], element[1], element[2], element[3], element[4], scanQty, date, time, name, status);
                    }
                    for (int i = 0; i < dataInquire.Rows.Count - 1; i++)
                    {
                        if (dataInquire.Rows[i].Cells["status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["status"].Style.BackColor = Color.Lime;
                        else if (dataInquire.Rows[i].Cells["status"].Value.ToString() == "PROGRESSING")
                            dataInquire.Rows[i].Cells["status"].Style.BackColor = Color.Gold;
                        else if (dataInquire.Rows[i].Cells["status"].Value.ToString() == "NOT READY")
                            dataInquire.Rows[i].Cells["status"].Style.BackColor = Color.OrangeRed;

                    }
                }
                else if (type == "Colour")
                {
                    List<string[]> data_done_shipping = new List<string[]>(), data_done_receiving = new List<string[]>(), ColourShipping_prefix_date = new List<string[]>();
                    dataInquire.Columns.Remove("date");
                    dataInquire.Columns.Remove("time");
                    dataInquire.Columns.Remove("name");
                    dataInquire.Columns.Add("company", "Company");
                    dataInquire.Columns.Add("shipping_date", "Shipping Date");
                    dataInquire.Columns.Add("shipping_name", "Name");
                    dataInquire.Columns.Add("shipping_time", "Shipping Time");
                    dataInquire.Columns.Add("shipping_status", "Shipping Status");
                    dataInquire.Columns.Add("receiving_date", "Receiving Date");
                    dataInquire.Columns.Add("receiving_name", "Name");
                    dataInquire.Columns.Add("receiving_time", "Receiving Time");
                    dataInquire.Columns.Add("receiving_status", "Receiving Status");

                    if (frame_ids.Count != 0)
                    {
                        data_done_shipping = DB.importColourShippingByIds(frame_ids);
                        data_done_receiving = DB.importColourReceivingByIds(frame_ids);
                    }
                    foreach (var element in data_done_shipping)
                    {
                        names.Add(element[3]);
                    }

                    if (names.Count != 0)
                        ColourShipping_prefix_date = DB.importcolourShippingPrefixByNames(names);

                    foreach (var element in data)
                    {
                        string shipping_name = "", receiving_date = "", receiving_name = "", shipping_date = "", company = "", shipping_time = "", receiving_time = "", shipping_status = "NOT READY", receiving_status = "NOT READY";
                        var match_shipping = data_done_shipping.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));

                        var match_receiving = data_done_receiving.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));
                        if (match_shipping != null)
                        {
                            var match_shipping_prefix = ColourShipping_prefix_date.FirstOrDefault(stringToCheck => stringToCheck[4].Contains(match_shipping[3]));
                            if (match_shipping_prefix != null)

                            company = match_shipping_prefix[2];
                            shipping_name = match_shipping[3];
                            shipping_date = match_shipping[1].Substring(0, 10);
                            shipping_time = match_shipping[2];
                            shipping_status = "COMPLETE";
                        }
                        if (match_receiving != null)
                        {
                            receiving_name = match_receiving[3];
                            receiving_date = match_receiving[1].Substring(0, 10);
                            receiving_time = match_receiving[2];
                            receiving_status = "COMPLETE";
                        }

                        dataInquire.Rows.Add(element[18], element[11], element[12], element[7], element[5], element[16], element[17], element[19], company, shipping_date, shipping_name, shipping_time, shipping_status, receiving_date, receiving_name, receiving_time, receiving_status);
                    }
                    for (int i = 0; i < dataInquire.Rows.Count - 1; i++)
                    {
                        if (dataInquire.Rows[i].Cells["shipping_status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["shipping_status"].Style.BackColor = Color.Lime;
                        else dataInquire.Rows[i].Cells["shipping_status"].Style.BackColor = Color.OrangeRed;

                        if (dataInquire.Rows[i].Cells["receiving_status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["receiving_status"].Style.BackColor = Color.Lime;
                        else dataInquire.Rows[i].Cells["receiving_status"].Style.BackColor = Color.OrangeRed;

                    }
                }
                else if (type == "CasementHardware")
                {
                    List<string[]> casement_frame_types = DB.fetchRows("frame_types", "type", "Casement Frame");
                    dataInquire.Columns.Add("status", "STATUS");
                    if (frame_ids.Count != 0)
                        data_done = DB.importCasementHardwareByIds(frame_ids);
                    foreach (var element in data)
                    {
                        if (casement_frame_types.Any(frame_type => frame_type[2].Equals(element[7], StringComparison.InvariantCultureIgnoreCase)))
                        {
                            string name = "", date = "", time = "", status = "NOT READY";
                            var match = data_done.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));
                            if (match != null)
                            {
                                status = "COMPLETE";
                                name = match[3];
                                date = match[1].Substring(0, 10);
                                time = match[2];
                            }

                            dataInquire.Rows.Add(element[18], element[11], element[12], element[7], element[5], element[16], element[17], element[19], date, time, name, status);
                        }
                    }
                    for (int i = 0; i < dataInquire.Rows.Count - 1; i++)
                    {
                        if (dataInquire.Rows[i].Cells["status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["status"].Style.BackColor = Color.Lime;
                        else dataInquire.Rows[i].Cells["status"].Style.BackColor = Color.OrangeRed;

                    }
                }
                else if (type == "ColourShipping")
                {
                    List<string[]> data_done_shipping = new List<string[]>(), ColourShipping_prefix_date = new List<string[]>();
                    dataInquire.Columns.Remove("date");
                    dataInquire.Columns.Remove("time");
                    dataInquire.Columns.Remove("name");
                    dataInquire.Columns.Add("company", "Company");
                    dataInquire.Columns.Add("shipping_date", "Shipping Date");
                    dataInquire.Columns.Add("shipping_name", "Name");
                    dataInquire.Columns.Add("shipping_time", "Shipping Time");
                    dataInquire.Columns.Add("shipping_status", "Shipping Status");
                   

                    if (frame_ids.Count != 0)
                    {
                        data_done_shipping = DB.importColourShippingByIds(frame_ids);
                       
                    }
                    foreach (var element in data_done_shipping)
                    {
                        names.Add(element[3]);
                    }

                    if (names.Count != 0)
                        ColourShipping_prefix_date = DB.importcolourShippingPrefixByNames(names);

                    foreach (var element in data)
                    {
                        string shipping_name = "", shipping_date = "", company = "", shipping_time = "", shipping_status = "NOT READY";
                        var match_shipping = data_done_shipping.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));

                        if (match_shipping != null)
                        {
                            var match_shipping_prefix = ColourShipping_prefix_date.FirstOrDefault(stringToCheck => stringToCheck[4].Contains(match_shipping[3]));
                            if (match_shipping_prefix != null)

                                company = match_shipping_prefix[2];
                            shipping_name = match_shipping[3];
                            shipping_date = match_shipping[1].Substring(0, 8);
                            shipping_time = match_shipping[2];
                            shipping_status = "COMPLETE";
                        }
                       

                        dataInquire.Rows.Add(element[18], element[11], element[12], element[7], element[5], element[16], element[17], element[19], company, shipping_date, shipping_name, shipping_time, shipping_status);
                    }
                    for (int i = 0; i < dataInquire.Rows.Count - 1; i++)
                    {
                        if (dataInquire.Rows[i].Cells["shipping_status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["shipping_status"].Style.BackColor = Color.Lime;
                        else dataInquire.Rows[i].Cells["shipping_status"].Style.BackColor = Color.OrangeRed;

                    }
                }
                else if (type == "VinylFrameShipping")
                {
                    List<string[]> data_done_shipping = new List<string[]>(), VinylShipping_prefix_date = new List<string[]>();
                    dataInquire.Columns.Remove("date");
                    dataInquire.Columns.Remove("time");
                    dataInquire.Columns.Remove("name");
                    dataInquire.Columns.Add("shipping_date", "Shipping Date");
                    dataInquire.Columns.Add("shipping_name", "Name");
                    dataInquire.Columns.Add("shipping_time", "Shipping Time");
                    dataInquire.Columns.Add("shipping_status", "Shipping Status");


                    if (frame_ids.Count != 0)
                    {
                        data_done_shipping = DB.importVinylproFrameShippingByIds(frame_ids);

                    }
                    foreach (var element in data_done_shipping)
                    {
                        names.Add(element[4]);
                    }

                    if (names.Count != 0)
                        VinylShipping_prefix_date = DB.importVinylProFrameShippingPrefixByNames(names);

                    foreach (var element in data)
                    {
                        string shipping_name = "", receiving_name = "", shipping_date = "", shipping_time = "", shipping_status = "NOT READY";
                        var match_shipping = data_done_shipping.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));

                        if (match_shipping != null)
                        {
                            var match_shipping_prefix = VinylShipping_prefix_date.FirstOrDefault(stringToCheck => stringToCheck[3].Contains(match_shipping[4]));
                            if (match_shipping_prefix != null)

                            shipping_name = match_shipping[4];
                            shipping_date = match_shipping[2].Substring(0, 9);
                            shipping_time = match_shipping[3];
                            shipping_status = "COMPLETE";
                        }


                        dataInquire.Rows.Add(element[18], element[11], element[12], element[7], element[5], element[16], element[17], element[19], shipping_date, shipping_name, shipping_time, shipping_status, receiving_name);
                    }
                    for (int i = 0; i < dataInquire.Rows.Count - 1; i++)
                    {
                        if (dataInquire.Rows[i].Cells["shipping_status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["shipping_status"].Style.BackColor = Color.Lime;
                        else dataInquire.Rows[i].Cells["shipping_status"].Style.BackColor = Color.OrangeRed;

                    }
                }
                else if (type == "ColourReceiving")
                {
                    List<string[]> data_done_receiving = new List<string[]>(), ColourReceiving_prefix_date = new List<string[]>();
                    dataInquire.Columns.Remove("date");
                    dataInquire.Columns.Remove("time");
                    dataInquire.Columns.Remove("name");
                    dataInquire.Columns.Add("company", "Company");
                    dataInquire.Columns.Add("receiving_date", "Receiving Date");
                    dataInquire.Columns.Add("receiving_name", "Name");
                    dataInquire.Columns.Add("receiving_time", "Receiving Time");
                    dataInquire.Columns.Add("receiving_status", "Receiving Status");


                    if (frame_ids.Count != 0)
                    {
                        data_done_receiving = DB.importColourReceivingByIds(frame_ids);

                    }
                    foreach (var element in data_done_receiving)
                    {
                        names.Add(element[3]);
                    }

                    if (names.Count != 0)
                        ColourReceiving_prefix_date = DB.importcolourReceivingPrefixByNames(names);

                    foreach (var element in data)
                    {
                        string receiving_date = "", receiving_name = "", company = "", receiving_time = "", receiving_status = "NOT READY";
                        var match_receiving = data_done_receiving.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));

                        if (match_receiving != null)
                        {
                            var match_receiving_prefix = ColourReceiving_prefix_date.FirstOrDefault(stringToCheck => stringToCheck[4].Contains(match_receiving[3]));
                            if (match_receiving_prefix != null)

                                company = match_receiving_prefix[2];
                            receiving_name = match_receiving[3];
                            receiving_date = match_receiving[1].Substring(0, 8);
                            receiving_time = match_receiving[2];
                            receiving_status = "COMPLETE";
                        }


                        dataInquire.Rows.Add(element[18], element[11], element[12], element[7], element[5], element[16], element[17], element[19], company, receiving_date, receiving_name, receiving_time, receiving_status);
                    }
                    for (int i = 0; i < dataInquire.Rows.Count - 1; i++)
                    {
                        if (dataInquire.Rows[i].Cells["receiving_status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["receiving_status"].Style.BackColor = Color.Lime;
                        else dataInquire.Rows[i].Cells["receiving_status"].Style.BackColor = Color.OrangeRed;

                    }
                }
                else if (type == "VinylFrameReceiving")
                {
                    List<string[]> data_done_receiving = new List<string[]>(), VinylReceiving_prefix_date = new List<string[]>();
                    dataInquire.Columns.Remove("date");
                    dataInquire.Columns.Remove("time");
                    dataInquire.Columns.Remove("name");
                    dataInquire.Columns.Add("receiving_date", "Receiving Date");
                    dataInquire.Columns.Add("receiving_name", "Name");
                    dataInquire.Columns.Add("receiving_time", "Receiving Time");
                    dataInquire.Columns.Add("receiving_status", "Receiving Status");


                    if (frame_ids.Count != 0)
                    {
                        data_done_receiving = DB.importVinylproFrameReceivingByIds(frame_ids);

                    }
                    foreach (var element in data_done_receiving)
                    {
                        names.Add(element[4]);
                    }

                    if (names.Count != 0)
                        VinylReceiving_prefix_date = DB.importVinylProFrameReceivingPrefixByNames(names);

                    foreach (var element in data)
                    {
                        string receiving_date = "", receiving_name = "", receiving_time = "", receiving_status = "NOT READY";
                        var match_receiving = data_done_receiving.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));

                        if (match_receiving != null)
                        {
                            var match_receiving_prefix = VinylReceiving_prefix_date.FirstOrDefault(stringToCheck => stringToCheck[3].Contains(match_receiving[4]));
                            if (match_receiving_prefix != null)

                            receiving_name = match_receiving[4];
                            receiving_date = match_receiving[2].Substring(0, 9);
                            receiving_time = match_receiving[3];
                            receiving_status = "COMPLETE";
                        }


                        dataInquire.Rows.Add(element[18], element[11], element[12], element[7], element[5], element[16], element[17], element[19],  receiving_date, receiving_name, receiving_time, receiving_status);
                    }
                    for (int i = 0; i < dataInquire.Rows.Count - 1; i++)
                    {
                        if (dataInquire.Rows[i].Cells["receiving_status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["receiving_status"].Style.BackColor = Color.Lime;
                        else dataInquire.Rows[i].Cells["receiving_status"].Style.BackColor = Color.OrangeRed;

                    }
                }
            }
        }
        public void Update(List<string[]> data, string type, bool close = true)
        {
            if (data != null)
            {
                List<string[]> data_done = new List<string[]>();
                List<string> frame_ids = new List<string>();
                List<string> names = new List<string>();
                if (!(type == "windowsAssembly"))
                    foreach (var element in data)
                        frame_ids.Add(element[5]);

                if (type == "frameClearing")
                {
                    List<string[]> FrameClearing_prefix_date = new List<string[]>();
                    data_done = DB.importFrameClearingByIds(frame_ids);
                    foreach (var element in data_done)
                    {
                        names.Add(element[3]);
                    }

                    if (names.Count != 0)
                        FrameClearing_prefix_date = DB.importFrameClearingPrefixByNames(names);

                    foreach (var element in data)
                    {
                        string name = "", date = "", machine_id = "", time = "", status = "NOT READY";
                        var match = data_done.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));
                        if (match != null)
                        {
                            status = "COMPLETE";
                            name = match[3];
                            date = match[1].Substring(0, 10);
                            time = match[2];
                            string[] match_prefix = null;
                            if (FrameClearing_prefix_date != null)
                                match_prefix = FrameClearing_prefix_date.FirstOrDefault(stringToCheck => stringToCheck[3].Contains(name));
                            if (match_prefix != null)
                                machine_id = match_prefix[4];
                        }

                        dataInquire.Rows.Add(element[18], element[11], element[12], element[7], element[5], element[16], element[17], element[19], date, time, name, machine_id, status);

                    }
                    for (int i = 0; i < dataInquire.Rows.Count - 1; i++)
                    {
                        if (dataInquire.Rows[i].Cells["status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["status"].Style.BackColor = Color.Lime;
                        else dataInquire.Rows[i].Cells["status"].Style.BackColor = Color.OrangeRed;
                    }

                }
                else if (type == "windowsAssembly")
                {
                    foreach (var element in data)
                        frame_ids.Add(element[0]);

                    if (frame_ids.Count != 0)
                        data_done = DB.importWindowsAssemblyByIds(frame_ids);

                    foreach (var element in data)
                    {
                        string name = "", date = "", time = "", status = "";
                        int scanQty = 0;
                        for (int i = 0; i < data_done.Count; i++)
                            if (data_done[i][0] == element[0])
                            {
                                name = data_done[i][3];
                                date = data_done[i][1].Substring(0, 10);
                                time = data_done[i][2];
                                scanQty++;
                            }
                        if (scanQty.Equals(Int32.Parse(element[1]))) status = "COMPLETE"; else if (!scanQty.Equals(0)) status = "PROGRESSING"; else if (scanQty.Equals(0)) status = "NOT READY";

                        dataInquire.Rows.Add(element[0], element[1], element[2], element[3], element[4], scanQty, date, time, name, status);
                    }
                    for (int i = 0; i < dataInquire.Rows.Count - 1; i++)
                    {
                        if (dataInquire.Rows[i].Cells["status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["status"].Style.BackColor = Color.Lime;
                        else if (dataInquire.Rows[i].Cells["status"].Value.ToString() == "PROGRESSING")
                            dataInquire.Rows[i].Cells["status"].Style.BackColor = Color.Gold;
                        else if (dataInquire.Rows[i].Cells["status"].Value.ToString() == "NOT READY")
                            dataInquire.Rows[i].Cells["status"].Style.BackColor = Color.OrangeRed;

                    }
                }
                else if (type == "Colour")
                {

                    List<string[]> data_done_shipping = new List<string[]>(), data_done_receiving = new List<string[]>(), ColourShipping_prefix_date = new List<string[]>();

                    if (frame_ids.Count != 0)
                    {
                        data_done_shipping = DB.importColourShippingByIds(frame_ids);
                        data_done_receiving = DB.importColourReceivingByIds(frame_ids);
                    }

                    foreach (var element in data_done_shipping)
                    {
                        names.Add(element[3]);
                    }

                    if (names.Count != 0)
                        ColourShipping_prefix_date = DB.importcolourShippingPrefixByNames(names);

                    foreach (var element in data)
                    {
                        string shipping_name = "", receiving_date = "", receiving_name = "", shipping_date = "", company = "", shipping_time = "", receiving_time = "", shipping_status = "NOT READY", receiving_status = "NOT READY";
                        var match_shipping = data_done_shipping.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));

                        var match_receiving = data_done_receiving.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));
                        if (match_shipping != null)
                        {
                            var match_shipping_prefix = ColourShipping_prefix_date.FirstOrDefault(stringToCheck => stringToCheck[4].Contains(match_shipping[3]));
                            if (match_shipping_prefix != null)

                            company = match_shipping_prefix[2];
                            shipping_name = match_shipping[3];
                            shipping_date = match_shipping[1].Substring(0, 10);
                            shipping_time = match_shipping[2];
                            shipping_status = "COMPLETE";
                        }

                        if (match_receiving != null)
                        {
                            receiving_name = match_receiving[3];
                            receiving_date = match_receiving[1].Substring(0, 10);
                            receiving_time = match_receiving[2];
                            receiving_status = "COMPLETE";
                        }

                        dataInquire.Rows.Add(element[18], element[11], element[12], element[7], element[5], element[16], element[17], element[19], company, shipping_date, shipping_name, shipping_time, shipping_status, receiving_date, receiving_name, receiving_time, receiving_status);
                    }
                    for (int i = 0; i < dataInquire.Rows.Count - 1; i++)
                    {
                        if (dataInquire.Rows[i].Cells["shipping_status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["shipping_status"].Style.BackColor = Color.Lime;
                        else dataInquire.Rows[i].Cells["shipping_status"].Style.BackColor = Color.OrangeRed;

                        if (dataInquire.Rows[i].Cells["receiving_status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["receiving_status"].Style.BackColor = Color.Lime;
                        else dataInquire.Rows[i].Cells["receiving_status"].Style.BackColor = Color.OrangeRed;

                    }
                }
                else if (type == "CasementHardware")
                {
                    List<string[]> casement_frame_types = DB.fetchRows("frame_types", "type", "Casement Frame");

                    if (frame_ids.Count != 0)
                        data_done = DB.importCasementHardwareByIds(frame_ids);

                    foreach (var element in data)
                    {
                        if (casement_frame_types.Any(frame_type => frame_type[2].Equals(element[7], StringComparison.InvariantCultureIgnoreCase)))
                        {
                            string name = "", date = "", time = "", status = "NOT READY";
                            var match = data_done.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));
                            if (match != null)
                            {
                                status = "COMPLETE";
                                name = match[3];
                                date = match[1].Substring(0, 10);
                                time = match[2];
                            }

                            dataInquire.Rows.Add(element[18], element[11], element[12], element[7], element[5], element[16], element[17], element[19], date, time, name, status);
                        }
                    }
                    for (int i = 0; i < dataInquire.Rows.Count - 1; i++)
                    {
                        if (dataInquire.Rows[i].Cells["status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["status"].Style.BackColor = Color.Lime;
                        else dataInquire.Rows[i].Cells["status"].Style.BackColor = Color.OrangeRed;

                    }
                }
                else if (type == "ColourShipping")
                {
                    List<string[]> data_done_shipping = new List<string[]>(), ColourShipping_prefix_date = new List<string[]>();
                  

                    if (frame_ids.Count != 0)
                    {
                        data_done_shipping = DB.importColourShippingByIds(frame_ids);

                    }
                    foreach (var element in data_done_shipping)
                    {
                        names.Add(element[3]);
                    }

                    if (names.Count != 0)
                        ColourShipping_prefix_date = DB.importcolourShippingPrefixByNames(names);

                    foreach (var element in data)
                    {
                        string shipping_name = "", receiving_date = "", receiving_name = "", shipping_date = "", company = "", shipping_time = "", receiving_time = "", shipping_status = "NOT READY", receiving_status = "NOT READY";
                        var match_shipping = data_done_shipping.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));

                        if (match_shipping != null)
                        {
                            var match_shipping_prefix = ColourShipping_prefix_date.FirstOrDefault(stringToCheck => stringToCheck[4].Contains(match_shipping[3]));
                            if (match_shipping_prefix != null)

                                company = match_shipping_prefix[2];
                            shipping_name = match_shipping[3];
                            shipping_date = match_shipping[1].Substring(0, 8);
                            shipping_time = match_shipping[2];
                            shipping_status = "COMPLETE";
                        }


                        dataInquire.Rows.Add(element[18], element[11], element[12], element[7], element[5], element[16], element[17], element[19], company, shipping_date, shipping_name, shipping_time, shipping_status, receiving_date, receiving_name, receiving_time, receiving_status);
                    }
                    for (int i = 0; i < dataInquire.Rows.Count - 1; i++)
                    {
                        if (dataInquire.Rows[i].Cells["shipping_status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["shipping_status"].Style.BackColor = Color.Lime;
                        else dataInquire.Rows[i].Cells["shipping_status"].Style.BackColor = Color.OrangeRed;

                    }
                }
                else if (type == "VinylFrameShipping")
                {
                    List<string[]> data_done_shipping = new List<string[]>(), VinylShipping_prefix_date = new List<string[]>();
                  
                    if (frame_ids.Count != 0)
                    {
                        data_done_shipping = DB.importVinylproFrameShippingByIds(frame_ids);

                    }
                    foreach (var element in data_done_shipping)
                    {
                        names.Add(element[4]);
                    }

                    if (names.Count != 0)
                        VinylShipping_prefix_date = DB.importVinylProFrameShippingPrefixByNames(names);

                    foreach (var element in data)
                    {
                        string shipping_name = "", receiving_date = "", receiving_name = "", shipping_date = "", shipping_time = "", receiving_time = "", shipping_status = "NOT READY", receiving_status = "NOT READY";
                        var match_shipping = data_done_shipping.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));

                        if (match_shipping != null)
                        {
                            var match_shipping_prefix = VinylShipping_prefix_date.FirstOrDefault(stringToCheck => stringToCheck[4].Contains(match_shipping[3]));
                            if (match_shipping_prefix != null)

                            shipping_name = match_shipping[4];
                            shipping_date = match_shipping[2].Substring(0, 8);
                            shipping_time = match_shipping[3];
                            shipping_status = "COMPLETE";
                        }


                        dataInquire.Rows.Add(element[18], element[11], element[12], element[7], element[5], element[16], element[17], element[19], shipping_date, shipping_name, shipping_time, shipping_status, receiving_date, receiving_name, receiving_time, receiving_status);
                    }
                    for (int i = 0; i < dataInquire.Rows.Count - 1; i++)
                    {
                        if (dataInquire.Rows[i].Cells["shipping_status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["shipping_status"].Style.BackColor = Color.Lime;
                        else dataInquire.Rows[i].Cells["shipping_status"].Style.BackColor = Color.OrangeRed;

                    }
                }
                else if (type == "ColourReceiving")
                {
                    List<string[]> data_done_receiving = new List<string[]>(), ColourReceiving_prefix_date = new List<string[]>();
                  
                    if (frame_ids.Count != 0)
                    {
                        data_done_receiving = DB.importColourReceivingByIds(frame_ids);

                    }
                    foreach (var element in data_done_receiving)
                    {
                        names.Add(element[3]);
                    }

                    if (names.Count != 0)
                        ColourReceiving_prefix_date = DB.importcolourReceivingPrefixByNames(names);

                    foreach (var element in data)
                    {
                        string receiving_date = "", receiving_name = "", company = "", receiving_time = "", receiving_status = "NOT READY";
                        var match_receiving = data_done_receiving.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));

                        if (match_receiving != null)
                        {
                            var match_receiving_prefix = ColourReceiving_prefix_date.FirstOrDefault(stringToCheck => stringToCheck[4].Contains(match_receiving[3]));
                            if (match_receiving_prefix != null)

                            company = match_receiving_prefix[2];
                            receiving_name = match_receiving[3];
                            receiving_date = match_receiving[1].Substring(0, 8);
                            receiving_time = match_receiving[2];
                            receiving_status = "COMPLETE";
                        }


                        dataInquire.Rows.Add(element[18], element[11], element[12], element[7], element[5], element[16], element[17], element[19], company, receiving_date, receiving_name, receiving_time, receiving_status);
                    }
                    for (int i = 0; i < dataInquire.Rows.Count - 1; i++)
                    {
                        if (dataInquire.Rows[i].Cells["receiving_status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["receiving_status"].Style.BackColor = Color.Lime;
                        else dataInquire.Rows[i].Cells["receiving_status"].Style.BackColor = Color.OrangeRed;

                    }
                }
                else if (type == "VinylFrameReceiving")
                {
                    List<string[]> data_done_receiving = new List<string[]>(), VinylReceiving_prefix_date = new List<string[]>();
                  
                    if (frame_ids.Count != 0)
                    {
                        data_done_receiving = DB.importVinylproFrameReceivingByIds(frame_ids);

                    }
                    foreach (var element in data_done_receiving)
                    {
                        names.Add(element[4]);
                    }

                    if (names.Count != 0)
                        VinylReceiving_prefix_date = DB.importVinylProFrameReceivingPrefixByNames(names);

                    foreach (var element in data)
                    {
                        string receiving_date = "", receiving_name = "", receiving_time = "", receiving_status = "NOT READY";
                        var match_receiving = data_done_receiving.FirstOrDefault(stringToCheck => stringToCheck.Contains(element[5]));

                        if (match_receiving != null)
                        {
                            var match_receiving_prefix = VinylReceiving_prefix_date.FirstOrDefault(stringToCheck => stringToCheck[3].Contains(match_receiving[4]));
                            if (match_receiving_prefix != null)

                                receiving_name = match_receiving[4];
                            receiving_date = match_receiving[2].Substring(0, 8);
                            receiving_time = match_receiving[3];
                            receiving_status = "COMPLETE";
                        }


                        dataInquire.Rows.Add(element[18], element[11], element[12], element[7], element[5], element[16], element[17], element[19], receiving_date, receiving_name, receiving_time, receiving_status);
                    }
                    for (int i = 0; i < dataInquire.Rows.Count - 1; i++)
                    {
                        if (dataInquire.Rows[i].Cells["receiving_status"].Value.ToString() == "COMPLETE")
                            dataInquire.Rows[i].Cells["receiving_status"].Style.BackColor = Color.Lime;
                        else dataInquire.Rows[i].Cells["receiving_status"].Style.BackColor = Color.OrangeRed;

                    }
                }
            }
        }
        private void InquireForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

            string order_number = textBoxOrdNumber.Text;
            List<string[]> data = new List<string[]>();
            switch (_Type)
            {
                case "frameClearing":
                    data = DB.fetchRows("framescutting", "J", order_number, false);
                    if (data.Count == 0)
                    {
                        MessageBox.Show("Invalid Order Number!", "Error");
                        return;
                    }

                    foreach (var element in Settings.Casing)
                        data.RemoveAll(x => x[7] == element[2]);
                    break;

                case "windowsAssembly":
                    data = DB.importFrameReportbyLine(order_number);
                    if (data.Count == 0)
                    {
                        MessageBox.Show("Invalid Order Number!", "Error");
                        return;
                    }
                    break;

                case "Colour":
                    data = DB.fetchRows("framescutting", "J", order_number, false);
                    if (data.Count == 0)
                    {
                        MessageBox.Show("Invalid Order Number!", "Error");
                        return;
                    }
                    foreach (var element in Settings.Casing)
                        data.RemoveAll(x => x[7] == element[2]);
                    break;

                case "CasementHardware":
                    data = DB.fetchRows("framescutting", "J", order_number, false);
                    if (data.Count == 0)
                    {
                        MessageBox.Show("Invalid Order Number!", "Error");
                        return;
                    }
                    break;
                case "ColourShipping":
                    data = DB.fetchRows("framescutting", "J", order_number, false);
                    if (data.Count == 0)
                    {
                        MessageBox.Show("Invalid Order Number!", "Error");
                        return;
                    }
                    break;
                case "VinylFrameShipping":
                    data = DB.fetchRows("framescutting", "J", order_number, false);
                    if (data.Count == 0)
                    {
                        MessageBox.Show("Invalid Order Number!", "Error");
                        return;
                    }
                    break;
                case "ColourReceiving":
                    data = DB.fetchRows("framescutting", "J", order_number, false);
                    if (data.Count == 0)
                    {
                        MessageBox.Show("Invalid Order Number!", "Error");
                        return;
                    }
                    break;
                case "VinylFrameReceiving":
                    data = DB.fetchRows("framescutting", "J", order_number, false);
                    if (data.Count == 0)
                    {
                        MessageBox.Show("Invalid Order Number!", "Error");
                        return;
                    }
                    break;
            }
            dataInquire.Rows.Clear();
            Update(data, _Type);
        }
    }
}
