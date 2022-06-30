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
    public partial class SearchResult : Form
    {
        public class Data_order
        {
            public Data_order( string customer_name, string customer_po, string order_number, string order_date, string order_due_date, string description, string glass_prod_date, string completed, string note, string frame_send_cut, string complete, string paint_company, string send_date, string received_date, string windows_assembled)
            {

                Order_numb = order_number;
                Customer_Po = customer_po;
                Customer_Name = customer_name;
                Order_Date = order_date;
                Order_Due_Date = order_due_date;
                Description = description;
                Glass_Prod_Date = glass_prod_date;
                Completed = completed;
                Note = note;
                Frame_Send_Cut = frame_send_cut;
                Complete = complete;
                Paint_Company = paint_company;
                Send_Date = send_date;
                Received_Date = received_date;
                Windows_Assembled = windows_assembled;
             
            }
         
            public string Order_numb { get; set; }
            public string Customer_Po { get; set; }
            public string Customer_Name { get; set; }
            public string Order_Date { get; set; }
            public string Order_Due_Date { get; set; }
            public string Description { get; set; }
            public string Glass_Prod_Date { get; set; }
            public string Completed { get; set; }
            public string Note { get; set; }
            public string Frame_Send_Cut { get; set; }
            public string Complete { get; set; }
            public string Paint_Company { get; set; }
            public string Send_Date { get; set; }
            public string Received_Date { get; set; }
            public string Windows_Assembled { get; set; }

        }

        public SearchResult(List<string[]> production_data, int completed, int windows, string paint_company , string send_date , string received_date, string frame_send ,int complete_c_w_c, List<string[]> work_data=null)
        {
            InitializeComponent();
            List<Data_order> data_list = new List<Data_order>();
            if (Settings.user.Username != "admin")
            {
                if (!Settings.user.Permissions_Search.Contains("Received Date")) tableLayoutPanel2.RowStyles[13].Height = 0;
                if (!Settings.user.Permissions_Search.Contains("Send Date")) tableLayoutPanel2.RowStyles[12].Height = 0;
                if (!Settings.user.Permissions_Search.Contains("Complete CUT/ WELD/ CLEAR")) tableLayoutPanel2.RowStyles[10].Height = 0;
                if (!Settings.user.Permissions_Search.Contains("WINDOWS ASSEMBLED")) tableLayoutPanel2.RowStyles[14].Height = 0;
                if (!Settings.user.Permissions_Search.Contains("Paint Company")) tableLayoutPanel2.RowStyles[11].Height = 0;
                if (!Settings.user.Permissions_Search.Contains("Frame Send To Cut")) tableLayoutPanel2.RowStyles[9].Height = 0;
                if (!Settings.user.Permissions_Search.Contains("Note")) tableLayoutPanel2.RowStyles[8].Height = 0;
                if (!Settings.user.Permissions_Search.Contains("Completed")) tableLayoutPanel2.RowStyles[7].Height = 0;
                if (!Settings.user.Permissions_Search.Contains("Glass Production Date")) tableLayoutPanel2.RowStyles[6].Height = 0;
                if (!Settings.user.Permissions_Search.Contains("Description")) tableLayoutPanel2.RowStyles[5].Height = 0;
                if (!Settings.user.Permissions_Search.Contains("Order Due Date")) tableLayoutPanel2.RowStyles[4].Height = 0;
                if (!Settings.user.Permissions_Search.Contains("Order Date")) tableLayoutPanel2.RowStyles[3].Height = 0;
                if (!Settings.user.Permissions_Search.Contains("Customer Name")) tableLayoutPanel2.RowStyles[2].Height = 0;
                if (!Settings.user.Permissions_Search.Contains("Customer Po")) tableLayoutPanel2.RowStyles[1].Height = 0;
                if (!Settings.user.Permissions_Search.Contains("Order number")) tableLayoutPanel2.RowStyles[0].Height = 0;




            }
            if (production_data.Count != 0)
            {
               
                if (work_data.Count != 0)
                {
                  
                    dataCustomerName.Text = production_data[0][9];
                    dataCustomerPo.Text = work_data[0][1];
                    DataOrderNumber.Text = production_data[0][2];
                    DataOrderDate.Text = work_data[0][4];
                    DataOrderDueDate.Text = work_data[0][5];
                    DataDescriptions.Text = production_data[0][10] + " - " + production_data[0][1];
                    DataGlassProductionDate.Text = production_data[0][0];
                    DataCompleted.Text = completed.ToString();
                    DataNote.Text = production_data[0][11];
                    DataFrameSendCut.Text = frame_send.ToString();
                    DataCompleteCWC.Text = complete_c_w_c.ToString();
                    DataPaintCompany.Text = paint_company;
                    DataSendDate.Text = send_date;
                    DataReceivedDate.Text = received_date;
                    DataWindowsAssembled.Text = windows.ToString();

                }
                else
                {

                    dataCustomerName.Text = production_data[0][9];
                   
                    DataOrderNumber.Text = production_data[0][2];
                
                    DataDescriptions.Text = production_data[0][10] + " - " + production_data[0][1];
                    DataGlassProductionDate.Text = production_data[0][0];
                    DataCompleted.Text = completed.ToString();
                    DataNote.Text = production_data[0][11];
                    DataFrameSendCut.Text = frame_send.ToString();
                    DataCompleteCWC.Text = complete_c_w_c.ToString();
                    DataPaintCompany.Text = paint_company;
                    DataSendDate.Text = send_date;
                    DataReceivedDate.Text = received_date;
                    DataWindowsAssembled.Text = windows.ToString();

                }

            }
        }

        private void SearchResult_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }
    }
}
