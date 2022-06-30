using Microsoft.Reporting.WinForms;
using Senaka.data_sets;
using Senaka.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka
{
    public partial class RushOrderReport : Form
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        List<Data_order> FullRushList = new List<Data_order>();
        [Serializable]
        public class Data_order
        {
            public string List_date { get; set; }
            public string Order_numb { get; set; }
            public string FrameCut { get; set; }
            public string WdCl { get; set; }
            public string PntSP { get; set; }
            public string PntRe { get; set; }
            public string GLCut { get; set; }
            public string GLSealed { get; set; }
            public string CS { get; set; }
            public string SL { get; set; }
            public string SHP { get; set; }
            public string SU { get; set; }
            public string Status { get; set; }
            public List<string> ListIDs { get; set; }



        }
        public RushOrderReport()
        {
            InitializeComponent();
            dataGridViewRush.AutoGenerateColumns = false;
            this.ActiveControl = textBoxOrdNumber;

            Datelabel.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }

        public void GetData(string order)
        {

            List<string[]> data = DB.getFrameCuttingByOrderNumber(order);
            bool casement_complete = false;
            bool slider_complete = false;
            bool su_complete = false;
            bool shape_complete = false;
            bool wdcl_complete = false;
            bool pntsp_complete = false;
            bool pntre_complete = false;
            bool glsealed_complete = false;

            int casementqty = 0;
            int sliderqty = 0;
            int suty = 0;
            int shapeqty = 0;
            if (data.Count != 0)
            {
                List<string> ids = new List<string>();

                int TotalIds = 0, TotalDone = 0;
                Data_order RushElement = new Data_order();
                RushElement.Order_numb = order;
                RushElement.ListIDs = new List<string>();

                bool OrderExists = false;
                for (int i = 0; i < data.Count; i++)
                {
                    OrderExists = true;
                    if (Settings.Brickmould.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)) ||
                        Settings.Casing.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)) ||
                        Settings.Casement_Frame.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)) ||
                        Settings.Casement_Sash.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)) ||
                        Settings.Slider_Frame.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)) ||
                        Settings.Slider_sash.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)) ||
                        Settings.Small_Fix.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)) ||
                        Settings.Large_Fix.Any(type => type[2].Equals(data[i][8], StringComparison.InvariantCultureIgnoreCase)))
                    {
                        ids.Add(data[i][6]);


                        if (RushElement.Order_numb == data[i][10])
                        {
                            RushElement.ListIDs.Add(data[i][6]);

                        }


                    }
                }
                //second iteration
                List<string[]> ListDone = DB.getFrameClearing(ids);

                int Done = ListDone.Where(a => RushElement.ListIDs.Any(b => string.Compare(a[0], b, true) == 0)).Count();
                RushElement.WdCl = Done + "/" + RushElement.ListIDs.Count;
                if (Done == RushElement.ListIDs.Count) wdcl_complete = true;
                //glass report
                List<string[]> glassReport = DB.importGlassyOrderNumb(order);
                int GlassDone = 0;
                for (int i = 0; i < glassReport.Count; i++)
                {
                    OrderExists = true;
                    if (glassReport[i][(int)GLASS.COMPLETE] != "" && glassReport[i][(int)GLASS.COMPLETE] != null)
                        GlassDone += Int32.Parse(glassReport[i][(int)GLASS.COMPLETE]);
                }

                RushElement.GLSealed = GlassDone + "/" + glassReport.Count;
                if (GlassDone == glassReport.Count) glsealed_complete = true;
                //production report
                string casement_info = null;
                string slider_info = null;
                string shape_info = null;
                string su_info = null;
                List<string[]> productionReport_data, windowsassembly_data = new List<string[]>(), glassreport_data;
                string[] sliders = Settings.Slider.Select(x => x[2]).ToArray();

                string[] casements = Settings.Casement.Select(x => x[2]).ToArray();

                string[] sus = Settings.SU.Select(x => x[2]).ToArray();

                string[] shapes = Settings.Shape.Select(x => x[2]).ToArray();
                productionReport_data = DB.importProductionReport(order);
                string status = "";

                if (productionReport_data.Count != 0)
                {
                    OrderExists = true;
                    List<string> order_numbers = productionReport_data.Select(x => x[3]).ToList();
                    List<string[]> IDS_total = DB.importFramereportbyIDs(order_numbers);
                    List<string[]> glass_report_total = DB.importGlassReportByOrders(order_numbers, sus);
                    List<string> casement_ids_total = new List<string>(), slider_ids_total = new List<string>(), glass_ids_total = new List<string>(), shape_ids_total = new List<string>();
                  
                    foreach (string[] report in productionReport_data)
                    {
                        string order_number = report[3].Substring(0, 5);
                        string casement = report[4];
                        string slider = report[5];
                        string shape = report[6];
                        string su = report[7];
                        if (casement != "0")
                        {
                            List<string> list = new List<string>(casements);

                            List<string[]> IDS = IDS_total.Where(x => (x[0].Contains(order_number)) && list.Any(a => a == x[4])).ToList();


                            foreach (var entry in IDS)
                            {
                                casement_ids_total.Add(entry[0]);
                            }
                        }
                        if (slider != "0")
                        {
                            List<string> list = new List<string>(sliders);

                            List<string[]> IDS = IDS_total.Where(x => (x[0].Contains(order_number)) && list.Any(a => a == x[4])).ToList();

                            foreach (var entry in IDS)
                            {
                                slider_ids_total.Add(entry[0]);
                            }


                        }
                        if (su != "0")
                        {
                            glassreport_data = glass_report_total.Where(x => x[1] == order_number).ToList();

                            foreach (var entry in glassreport_data)
                            {
                                glass_ids_total.Add(entry[0]);
                            }
                        }
                        if (shape != "0")
                        {
                            List<string> list = new List<string>(shapes);

                            List<string[]> IDS = IDS_total.Where(x => (x[0].Contains(order_number)) && list.Any(a => a == x[4])).ToList();

                            foreach (var entry in IDS)
                            {
                                shape_ids_total.Add(entry[0]);
                            }
                        }

                    }
                    List<string[]> windows_assembly_casement_total = DB.importWindowsAssemblyByIds(casement_ids_total);
                    List<string[]> windows_assembly_shape_total = DB.importWindowsAssemblyByIds(shape_ids_total);
                    List<string[]> windows_assembly_slider_total = DB.importWindowsAssemblyByIds(slider_ids_total);

                    List<string[]> igsorting_total = DB.importIgSorting(glass_ids_total);
                   
                    foreach (string[] report in productionReport_data)
                    {

                        string casement = report[4];
                        string slider = report[5];
                        string shape = report[6];
                        string su = report[7];
                        double information;



                        string description = null;

                       



                        string order_number = report[3].Substring(0, 5);


                        //qty for casements
                        if (casement != "0")
                        {
                            List<string> list = new List<string>(casements);
                            //  List<string[]> IDS = DB.importFramereportbyIDandType(order_number, list);
                            List<string[]> IDS = IDS_total.Where(x => (x[0].Contains(order_number)) && list.Any(a => a == x[4])).ToList();

                            List<string> casement_ids = new List<string>();
                            foreach (var entry in IDS)
                            {
                                casement_ids.Add(entry[0]);
                            }

                            if (windows_assembly_casement_total != null)
                                casementqty = windows_assembly_casement_total.Where(x => casement_ids.Any(a => a == x[0])).ToList().Count;
                            casement_info = casementqty + "/" + casement;

                        }

                        if (casementqty == Int32.Parse(casement)) casement_complete = true;
                        //qty for slider
                        if (slider != "0")
                        {
                            List<string> list = new List<string>(sliders);
                            //   List<string[]> IDS = DB.importFramereportbyIDandType(order_number, list);
                            List<string[]> IDS = IDS_total.Where(x => (x[0].Contains(order_number)) && list.Any(a => a == x[4])).ToList();
                            List<string> slider_ids = new List<string>();
                            foreach (var entry in IDS)
                            {
                                slider_ids.Add(entry[0]);
                            }
                            //  List<string[]> windows_assembly_table = DB.importWindowsAssemblyByIds(slider_ids);
                            if (windows_assembly_slider_total != null)
                                sliderqty = windows_assembly_slider_total.Where(x => slider_ids.Any(a => a == x[0])).ToList().Count;
                            slider_info = sliderqty + "/" + slider;

                        }

                        if (sliderqty == Int32.Parse(slider))
                            slider_complete = true;
                        //qty for su
                        if (su != "0")
                        {
                            glassreport_data = glass_report_total.Where(x => x[1] == order_number).ToList();
                            List<string> glass_ids = new List<string>();
                            foreach (var entry in glassreport_data)
                            {
                                glass_ids.Add(entry[0]);
                            }
                            if (glassreport_data.Count != 0)
                                windowsassembly_data = igsorting_total.Where(x => glass_ids.Any(a => a == x[0])).ToList();
                            if (windowsassembly_data != null)
                                suty = windowsassembly_data.Count;
                            su_info = suty + "/" + su;

                        }
                        if (suty == Int32.Parse(su))
                            su_complete = true;
                        //qty for shape
                        if (shape != "0")
                        {
                            List<string> list = new List<string>(shapes);
                            //     List<string[]> IDS = DB.importFramereportbyIDandType(order_number, list);
                            List<string[]> IDS = IDS_total.Where(x => (x[0].Contains(order_number)) && list.Any(a => a == x[4])).ToList();
                            List<string> shape_ids = new List<string>();
                            foreach (var entry in IDS)
                            {
                                shape_ids.Add(entry[0]);
                            }
                            List<string[]> windows_assembly_table = windows_assembly_shape_total.Where(x => shape_ids.Any(a => a == x[0])).ToList();
                            if (windows_assembly_table != null)
                                shapeqty = windows_assembly_table.Count;
                            shape_info = shapeqty + "/" + shape;
                            // line_numbers = new List<string>();
                        }


                        if (shapeqty == Int32.Parse(shape)) shape_complete = true;



                    }
                }
                RushElement.CS = casement_info;
                RushElement.SHP = shape_info;
                RushElement.SL = slider_info;
                RushElement.SU = su_info;
               

                //paint shipping
                int colorShipping_Done = 0, colorReceiving_Done = 0;
                List<string[]> ColorShipping = DB.importColourShippingByIds(RushElement.ListIDs);
                if (ColorShipping != null)
                    colorShipping_Done = ColorShipping.Count;
                List<string[]> ColorReceiving = DB.importColourReceivingByIds(RushElement.ListIDs);
                if (ColorReceiving != null)
                    colorReceiving_Done = ColorReceiving.Count;
                RushElement.PntSP = colorShipping_Done + "/" + RushElement.ListIDs.Count;
                if (colorShipping_Done == RushElement.ListIDs.Count) pntsp_complete = true;
                
                RushElement.PntRe = colorReceiving_Done + "/" + RushElement.ListIDs.Count;
                if (colorReceiving_Done == RushElement.ListIDs.Count) pntre_complete = true;
                string[] orderSummary = DB.fetchRow("ordersummary", "ORDER#", order);
                if (orderSummary != null)
                {
                    OrderExists = true;
                    RushElement.List_date = orderSummary[72];
                }
                RushElement.FrameCut = data[0][21];
                string[] glassreport = DB.fetchRow("glassreport", "order", order);
                if (glassreport != null)
                {
                    OrderExists = true;
                    RushElement.GLCut = glassreport[1];
                }

                if (casement_complete && slider_complete && su_complete && shape_complete && wdcl_complete && pntsp_complete && pntre_complete && glsealed_complete) status = "COMPLETE";
                else if (casementqty != 0 || sliderqty != 0 || shapeqty != 0 || suty != 0 || Done != 0 || colorShipping_Done != 0 || colorReceiving_Done != 0 || GlassDone != 0) status = "IN PROGRESS";
                else status = "NOT READY";
                RushElement.Status = status;
                if (OrderExists == true)
                {
                    FullRushList.Add(RushElement);
                    (dataGridViewRush.BindingContext[FullRushList] as CurrencyManager).Refresh();
                    dataGridViewRush.DataSource = FullRushList;
                    ColorStatus();
                }
                else
                {
                    MessageBox.Show("Order number doesn't exist!", "ERROR");
                }
                textBoxOrdNumber.Text = "";
            }
            else
            {
                MessageBox.Show("Order number doesn't exist!", "Error");
                textBoxOrdNumber.Text = "";
            }


        }

        private void textBoxOrdNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string data = textBoxOrdNumber.Text;
                if (data != "")
                {
                    GetData(data);
                }
            }
        }
        public void ColorStatus()
        {
            for (int i = 0; i < dataGridViewRush.Rows.Count; i++)
            {
                if (dataGridViewRush.Rows[i].Cells[12].Value.ToString() == "COMPLETE") dataGridViewRush.Rows[i].Cells[12].Style.BackColor = Color.Lime;
                else if (dataGridViewRush.Rows[i].Cells[12].Value.ToString() == "IN PROGRESS") dataGridViewRush.Rows[i].Cells[12].Style.BackColor = Color.Gold;
                else dataGridViewRush.Rows[i].Cells[12].Style.BackColor = Color.OrangeRed;
            }
        }
        private void RushOrderReport_FormClosing(object sender, FormClosingEventArgs e)
        {

            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void dataGridViewRush_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewRush.Columns["Delete"].Index && e.RowIndex >= 0)
            {

                FullRushList.RemoveAt(e.RowIndex);
                (dataGridViewRush.BindingContext[FullRushList] as CurrencyManager).Refresh();
                dataGridViewRush.DataSource = FullRushList;
                ColorStatus();
            }
        }

        private void Printbutton_Click(object sender, EventArgs e)
        {
            int rowCount = 0;
            rowCount = FullRushList.Count;
            if (rowCount == 0)
            {

                DialogResult result = MessageBox.Show("There is no element in the table. Are you sure you want to print?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return;
            }
            ReportDataSource rds = new ReportDataSource();
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            RushOrderDataSet data_Order = new RushOrderDataSet();
            string path = "";


            rowCount = FullRushList.Count;

            path = Path.Combine(Environment.CurrentDirectory, @"reports\RushOrderReport.rdlc");
            for (int i = 0; i < rowCount; i++)
            {

                data_Order.Tables[0].Rows.Add(FullRushList[i].List_date, FullRushList[i].Order_numb, FullRushList[i].FrameCut, FullRushList[i].WdCl, FullRushList[i].PntSP, FullRushList[i].PntRe, FullRushList[i].GLCut,
                    FullRushList[i].GLSealed, FullRushList[i].CS, FullRushList[i].SL, FullRushList[i].SHP, FullRushList[i].SU, FullRushList[i].Status);


            }
            rds.Value = data_Order.Tables[0];
            reportParameters.Add(new ReportParameter("FooterParameter", "Printed by " + Settings.user.Username + " " + DateTime.Now.ToString()));
            reportParameters.Add(new ReportParameter("DateParameter", Datelabel.Text));
            reportParameters.Add(new ReportParameter("PickUpDateParameter", dateTimePickUp.Value.ToString("yyyy-MM-dd")));



            LocalReport report = new LocalReport();
            report.ReportPath = path;



            report.DataSources.Add(rds);

            report.SetParameters(reportParameters);
            rds.Name = "DataSet1";




            report.DataSources.Add(rds);
            Export(report);
            Print_page();
        }
        private Stream CreateStream(string name,
  string fileNameExtension, Encoding encoding,
  string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        private void Export(LocalReport report)
        {

            string deviceInfo =
         @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>11in</PageWidth>
                <PageHeight>8.5in</PageHeight>
                <MarginTop>0.5in</MarginTop>
                <MarginLeft>0.5in</MarginLeft>
                <MarginRight>0.5in</MarginRight>
                <MarginBottom>0.5in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);


            foreach (Stream stream in m_streams)
                stream.Position = 0;


        }

        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print_page()
        {
            m_currentPageIndex = 0;
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Landscape = true;

            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);

                PrintDialog printDlg = new PrintDialog();

                printDoc.DocumentName = "Print Document";
                printDlg.Document = printDoc;
                printDlg.AllowSelection = true;
                printDlg.AllowSomePages = true;
                //Call ShowDialog  
                if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
            }
        }

        private void textBoxOrdNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Datelabel_Click(object sender, EventArgs e)
        {

        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            string file;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Bin files (*.bin)|*.bin";
            saveFileDialog1.Title = "Save the list";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                Stream s = File.Open(saveFileDialog1.FileName, FileMode.Create);
                BinaryFormatter b = new BinaryFormatter();
                List<Data_order> data = new List<Data_order>();
                foreach (var a in FullRushList) //bsAirplanes is the bindingsource object
                {
                    data.Add((Data_order)a);
                }
                b.Serialize(s, data);
                s.Close();
            }
        }

        private void Openbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
          
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Bin files (*.bin)|*.bin";
           
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FullRushList.Clear();
                Stream s = File.OpenRead(openFileDialog.FileName);
                BinaryFormatter b = new BinaryFormatter();
                List<Data_order> data = (List<Data_order>)b.Deserialize(s);
                foreach (Data_order a in data)
                {
                    FullRushList.Add(a);
                }
                s.Close();
                (dataGridViewRush.BindingContext[FullRushList] as CurrencyManager).Refresh();
                dataGridViewRush.DataSource = FullRushList;
                ColorStatus();
            }
          
        }
    }
}
