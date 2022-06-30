using Senaka.component;
using Senaka.lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace Senaka
{
    public partial class SettingForm : Form
    {
        private bool is_saved = true;
        private bool is_cancel = false;

        Timer thread = new Timer();
        ProgressDialog progress = new ProgressDialog();

        public SettingForm(int tab)
        {
            InitializeComponent();

            MinimumSize = new Size(600, 400);
            setMainTabControl.SelectTab(tab);

            thread.Interval = 1;
            thread.Tick += Loading_Tick;
            thread.Start();

            progress.Show();
        }

        private void Loading_Tick(object sender, EventArgs e)
        {
            thread.Stop();
            thread.Tick -= Loading_Tick;

            List<string[]> dealers = DB.getWorkOrderDealers();
            foreach (var dealer in dealers)
            {
                ((DataGridViewComboBoxColumn)dataGridViewTextNotification.Columns[0]).Items.Add(dealer[0]);
                ((DataGridViewComboBoxColumn)dataGridViewShippingReport.Columns[0]).Items.Add(dealer[0]);
            }

            initForm();
            checkBoxCountTogether.Text = "Count frame and\r\n sash together";

            progress.Hide();
        }

        private async void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!is_cancel)
            {
                if (!is_saved)
                {
                    DialogResult confirm = MessageBox.Show("Data is not saved yet.\n Will you save changed setting?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (confirm.Equals(DialogResult.Yes))
                    {
                        await saveSetting();
                        return;
                    }
                    else if (confirm.Equals(DialogResult.Cancel))
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            new MainForm().Show();
        }

        private void initForm()
        {
            int i;
            // General Setting
            string[] shutdown_time = Settings.Shutdown_Time.Split(':');
            setGeneralShutdownHour.Value = Convert.ToInt16(shutdown_time[0]);
            setGeneralShutdownMin.Value = Convert.ToInt16(shutdown_time[1]);
            if (Settings.Selected_Date != null)
            {
                string start_date = Settings.Selected_Date[0].ToString("yyyy-MM-dd");
                string end_date = Settings.Selected_Date[1].ToString("yyyy-MM-dd");
                if (start_date != end_date) setGeneralLblSelectedDate.Text = start_date + " - " + end_date;
                else setGeneralLblSelectedDate.Text = start_date;
            }
            setGeneralUploadFrom.Text = Settings.Upload_From;
            setGeneralUploadTo.Text = Settings.Upload_To;
            setGeneralUploadLog.Text = Settings.Log_Path;

            // Optimize
            setOptRackSize16.Value = Convert.ToInt16(Settings.Rack_Size_16);
            setOptRackSize8.Value = Convert.ToInt16(Settings.Rack_Size_8);
            setOptSliderTable.Rows.Clear();
            for (i = 0; i < Settings.Slider.Count; i++)
            {
                setOptSliderTable.Rows.Add(Settings.Slider[i]);
            }
            setOptCaseTable.Rows.Clear();
            for (i = 0; i < Settings.Casement.Count; i++)
            {
                setOptCaseTable.Rows.Add(Settings.Casement[i]);
            }
            setOptSUTable.Rows.Clear();
            for (i = 0; i < Settings.SU.Count; i++)
            {
                setOptSUTable.Rows.Add(Settings.SU[i]);
            }
            setOptShapeTable.Rows.Clear();
            for (i = 0; i < Settings.Shape.Count; i++)
            {
                setOptShapeTable.Rows.Add(Settings.Shape[i]);
            }

            // IG Sorting Setting
            setISortPrefixTable.Rows.Clear();
            foreach (string[] item in Settings.IG_Sorting_Prefix_Table)
            {
                setISortPrefixTable.Rows.Add(item[0], item[1], item[2], item[3], item[4]);
            }
            setISortErrorTime.Value = Settings.IG_Sorting_Error_Time;
            setISortIntervalTime.Value = Settings.IG_Sorting_Scan_Interval;

            // IG Shipping Setting
            setIShippingPrefixTable.Rows.Clear();
            foreach (string[] item in Settings.IG_Shipping_Prefix_Table)
            {
                setIShippingPrefixTable.Rows.Add(item[0], item[1], item[2], item[3], item[4]);
            }
            setIShippingErrorTime.Value = Settings.IG_Shipping_Error_Time;

            // Windows Assembly
            setIWindowsAssemblyPrefixTable.Rows.Clear();
            foreach (string[] item in Settings.Windows_Assembly_Prefix_Table)
            {
                setIWindowsAssemblyPrefixTable.Rows.Add(item[0], item[1], item[2], item[3], item[4]);
            }
            setIWindowsAssemblyErrorTime.Value = Settings.Windows_Assembly_Error_Time;
            // Frame Clearing
            setFrameClearingPrefixTable.Rows.Clear();
            foreach (string[] item in Settings.Frame_Clearing_Prefix_Table)
            {
                setFrameClearingPrefixTable.Rows.Add(item[0], item[1], item[2], item[3], item[4], item[5]);
            }
            setFrameClearingErrorTime.Value = Settings.Frame_Clearing_Error_Time;
            setFrameClearingScanInterval.Value = Settings.Frame_Clearing_Scan_Interval;

            // Frame Types

            setBrickmouldTable.Rows.Clear();
            for (i = 0; i < Settings.Brickmould.Count; i++)
            {
                setBrickmouldTable.Rows.Add(Settings.Brickmould[i]);
            }
            setCasingTable.Rows.Clear();
            for (i = 0; i < Settings.Casing.Count; i++)
            {
                setCasingTable.Rows.Add(Settings.Casing[i]);
            }
            setCasementFrameTable.Rows.Clear();
            for (i = 0; i < Settings.Casement_Frame.Count; i++)
            {
                setCasementFrameTable.Rows.Add(Settings.Casement_Frame[i]);
            }
            setCasementSashTable.Rows.Clear();
            for (i = 0; i < Settings.Casement_Sash.Count; i++)
            {
                setCasementSashTable.Rows.Add(Settings.Casement_Sash[i]);
            }
            setSliderFrameTable.Rows.Clear();
            for (i = 0; i < Settings.Slider_Frame.Count; i++)
            {
                setSliderFrameTable.Rows.Add(Settings.Slider_Frame[i]);
            }
            setSliderSashTable.Rows.Clear();
            for (i = 0; i < Settings.Slider_sash.Count; i++)
            {
                setSliderSashTable.Rows.Add(Settings.Slider_sash[i]);
            }
            setSmallFixTable.Rows.Clear();
            for (i = 0; i < Settings.Small_Fix.Count; i++)
            {
                setSmallFixTable.Rows.Add(Settings.Small_Fix[i]);
            }
            setLargeFixTable.Rows.Clear();
            for (i = 0; i < Settings.Large_Fix.Count; i++)
            {
                setLargeFixTable.Rows.Add(Settings.Large_Fix[i]);
            }
            // Casement Hardware
            setCasementHardwarePrefixTable.Rows.Clear();
            foreach (string[] item in Settings.Casement_Hardware_Prefix_Table)
            {
                setCasementHardwarePrefixTable.Rows.Add(item[0], item[1], item[2], item[3], item[4]);
            }
            setCasementHardwareErrorTime.Value = Settings.Casement_Hardware_Error_Time;
            setCasementHardwareScanInterval.Value = Settings.Casement_Hardware_Scan_Interval;


            // Colour Shipping
            setColourShippingPrefixTable.Rows.Clear();
            foreach (string[] item in Settings.Colour_Shipping_Prefix_Table)
            {
                setColourShippingPrefixTable.Rows.Add(item[0], item[1], item[2], item[3], item[4]);
            }
            setColourShippingErrorTime.Value = Settings.Colour_Shipping_Error_Time;

            // Colour Receiving
            setColourDeliveredPrefixTable.Rows.Clear();
            foreach (string[] item in Settings.Colour_Receiving_Prefix_Table)
            {
                setColourDeliveredPrefixTable.Rows.Add(item[0], item[1], item[2], item[3]);
            }
            setColourReceivingErrorTime.Value = Settings.Colour_Receiving_Error_Time;

            //email
            EmaildataGridView.Rows.Clear();
            foreach (string[] item in Settings.Receiving_Emails_Table)
            {
                bool woodbridge = false, hourthermalglass = false, oceanview = false, vista = false, colourShippingReport = false, colourReceivingReport = false, ig_sorting = false, glass_recut = false, frame_recut = false, frame_clearing = false, vinyl_pro_frame_receiving = false;
                if (item[2].Contains("24Hour Thermal Glass")) hourthermalglass = true;
                if (item[2].Contains("Oceanview Patio Doors")) oceanview = true;
                if (item[2].Contains("Vista Patio Doors")) vista = true;
                if (item[2].Contains("Woodbridge")) woodbridge = true;
                if (item[2].Contains("Colour Shipping Report")) colourShippingReport = true;
                if (item[2].Contains("Colour Receiving Report")) colourReceivingReport = true;
                if (item[2].Contains("IG-Sorting")) ig_sorting = true;
                if (item[2].Contains("GlassRecut")) glass_recut = true;
                if (item[2].Contains("FrameRecut")) frame_recut = true;
                if (item[2].Contains("FrameClearing")) frame_clearing = true;
                if (item[2].Contains("VinylProFrameReceiving")) vinyl_pro_frame_receiving = true;
                EmaildataGridView.Rows.Add(item[0], item[1], hourthermalglass, oceanview, vista, woodbridge, colourShippingReport, colourReceivingReport, glass_recut, ig_sorting, frame_recut, frame_clearing, vinyl_pro_frame_receiving);
            }

            textBoxEmailMessageVista.Text = Settings.EmailMessageVista;
            textBoxEmailSignatureVista.Text = Settings.EmailSignatureVista;
            textBoxEmailSubjectVista.Text = Settings.EmailSubjectVista;
            if (Settings.EmailMessageVista_boolean == "True") checkBoxEmailMessageVista.Checked = true;
            if (Settings.EmailSignatureVista_boolean == "True") checkBoxEmailSignatureVista.Checked = true;
            if (Settings.EmailSubjectVista_boolean == "True") checkBoxEmailSubjectVista.Checked = true;

            textBoxEmailMessageWoodbridge.Text = Settings.EmailMessageWoodbridge;
            textBoxEmailSignatureWoodbridge.Text = Settings.EmailSignatureWoodbridge;
            textBoxEmailSubjectWoodbridge.Text = Settings.EmailSubjectWoodbridge;
            if (Settings.EmailMessageWoodbridge_boolean == "True") checkBoxEmailMessageWoodbridge.Checked = true;
            if (Settings.EmailSignatureWoodbridge_boolean == "True") checkBoxEmailSignatureWoodbridge.Checked = true;
            if (Settings.EmailSubjectWoodbridge_boolean == "True") checkBoxEmailSubjectWoodbridge.Checked = true;

            textBoxEmailMessage24Hour.Text = Settings.EmailMessage24Hour;
            textBoxEmailSignature24Hour.Text = Settings.EmailSignature24Hour;
            textBoxEmailSubject24Hour.Text = Settings.EmailSubject24Hour;
            if (Settings.EmailMessage24Hour_boolean == "True") checkBoxEmailMessage24Hour.Checked = true;
            if (Settings.EmailSignature24Hour_boolean == "True") checkBoxEmailSignature24Hour.Checked = true;
            if (Settings.EmailSubject24Hour_boolean == "True") checkBoxEmailSubject24Hour.Checked = true;

            textBoxEmailMessageOceanview.Text = Settings.EmailMessageOceanview;
            textBoxEmailSignatureOceanview.Text = Settings.EmailSignatureOceanview;
            textBoxEmailSubjectOceanview.Text = Settings.EmailSubjectOceanview;
            if (Settings.EmailMessageOceanview_boolean == "True") checkBoxEmailMessageOceanview.Checked = true;
            if (Settings.EmailSignatureOceanview_boolean == "True") checkBoxEmailSignatureOceanview.Checked = true;
            if (Settings.EmailSubjectOceanview_boolean == "True") checkBoxEmailSubjectOceanview.Checked = true;

            is_saved = true;
            setBtnSave.Enabled = false;

            // OceanviewPatioDoors
            OceanviewPatioDoorsData.Rows.Clear();
            foreach (string[] item in Settings.OceanviewPatioDoors_fields)
            {
                OceanviewPatioDoorsData.Rows.Add(item[0], item[1], item[2]);
            }

            OceanviewPatioDoorsDays.Text = Settings.OceanviewPatioDoors_days.ToString();
            textBoxOceanviewLimit.Text = Settings.OceanviewPatioDoors_Custom_Limit.ToString();

            // VistaDoors
            VistaPatioDoorsData.Rows.Clear();
            foreach (string[] item in Settings.VistaPatioDoors_fields)
            {
                VistaPatioDoorsData.Rows.Add(item[0], item[1], item[2]);
            }

            VistaPatioDoorsDays.Text = Settings.VistaPatioDoors_days.ToString();
            textBoxVistaLimit.Text = Settings.VistaPatioDoors_Custom_Limit.ToString();

            // Windows Assembly Hide

            textBoxWindowsAssemblyHideTime.Text = Settings.WindowsAssemblyHideTime.ToString();
            if (Settings.WindowsAssemblyHide == "True")
            {
                labelHideTime.Visible = true;
                textBoxWindowsAssemblyHideTime.Visible = true;
                checkBoxWindowsAssemblyHide.Checked = true;
            }
            else
            {
                labelHideTime.Visible = false;
                textBoxWindowsAssemblyHideTime.Visible = false;
                checkBoxWindowsAssemblyHide.Checked = false;
            }
            textBoxWindowsAssemblyUpdateTime.Text = Settings.WindowsAssemblyUpdateTime.ToString();
            //   // 24 hour thermal glass
            HourThermalGlass_CutToSizeData.Rows.Clear();
            foreach (string[] item in Settings.HourThermalGlass_CutToSize_fields)
            {
                HourThermalGlass_CutToSizeData.Rows.Add(item[0], item[1], item[2]);
            }
            HourThermalGlass_CutToSizeRequiredDays.Text = Settings.HourThermalGlass_CutToSize_days.ToString();

            HourThermalGlass_SheetsData.Rows.Clear();
            foreach (string[] item in Settings.HourThermalGlass_Sheets_fields)
            {
                HourThermalGlass_SheetsData.Rows.Add(item[0], item[1], item[2]);
            }
            HourThermalGlass_SheetsRequiredDays.Text = Settings.HourThermalGlass_Sheets_days.ToString();

            HourThermalGlass_UnitData.Rows.Clear();
            foreach (string[] item in Settings.HourThermalGlass_Unit_fields)
            {
                HourThermalGlass_UnitData.Rows.Add(item[0], item[1], item[2]);
            }
            HourThermalGlass_UnitRequiredDays.Text = Settings.HourThermalGlass_Unit_days.ToString();

            //  woodbridge
            dataGridViewWBCutToSize.Rows.Clear();
            foreach (string[] item in Settings.Woodbridge_CutToSize_fields)
            {
                dataGridViewWBCutToSize.Rows.Add(item[0], item[1], item[2]);
            }
            textBoxWBCutToSizeRequiredDays.Text = Settings.Woodbridge_CutToSize_days.ToString();

            dataGridViewWBStockSheet.Rows.Clear();
            foreach (string[] item in Settings.Woodbridge_StockSheets_fields)
            {
                dataGridViewWBStockSheet.Rows.Add(item[0], item[1], item[2]);
            }
            HourThermalGlass_SheetsRequiredDays.Text = Settings.Woodbridge_StockSheets_days.ToString();

            if (Settings.NAAutoSelectOceanView == "True")
                NAcheckBoxOceanView.Checked = true;
            else NAcheckBoxOceanView.Checked = false;

            if (Settings.NAAutoSelectVista == "True")
                NAcheckBoxVista.Checked = true;
            else NAcheckBoxVista.Checked = false;

            if (Settings.CloseAppBoolean == "True")
                checkBoxCloseTime.Checked = true;
            else checkBoxCloseTime.Checked = false;

            //task board email
            dataGridViewTaskBoardEmail.Rows.Clear();
            foreach (string[] item in Settings.TaskBoardEmail_list)
            {
                dataGridViewTaskBoardEmail.Rows.Add(item[0], item[1], item[2]);
            }

            // Windows Shipping
            setWindowsShippingPrefixTable.Rows.Clear();
            foreach (string[] item in Settings.Windows_Shipping_Prefix_Table)
            {
                setWindowsShippingPrefixTable.Rows.Add(item[0], item[1], item[2], item[3]);
            }

            //Frame Assembly
            setFrameAssemblyPrefixTable.Rows.Clear();
            foreach (string[] item in Settings.Frame_Assembly_Prefix_Table)
            {
                setFrameAssemblyPrefixTable.Rows.Add(item[0], item[1], item[2], item[3]);
            }

            // Windows Wrapping
            setWindowsWrappingPrefixTable.Rows.Clear();
            foreach (string[] item in Settings.Windows_Wrapping_Prefix_Table)
            {
                setWindowsWrappingPrefixTable.Rows.Add(item[0], item[1], item[2], item[3]);
            }

            textBoxWindowsWrappingHideTime.Text = Settings.WindowsWrappingHideTime.ToString();
            if (Settings.WindowsAssemblyHide == "True")
            {
                textBoxWindowsWrappingHideTime.Visible = true;
                checkBoxWindowsWrappingHide.Checked = true;
            }
            else
            {
                textBoxWindowsWrappingHideTime.Visible = false;
                checkBoxWindowsWrappingHide.Checked = false;
            }
            textBoxWindowsWrappingUpdateTime.Text = Settings.WindowsWrappingUpdateTime.ToString();
            //Patio doors Receiving
            setPatioDoorReceivingPrefixTable.Rows.Clear();
            foreach (string[] item in Settings.PatioDoors_Receiving_Prefix_Table)
            {
                setPatioDoorReceivingPrefixTable.Rows.Add(item[0], item[1], item[2], item[3]);
            }


            //Patio doors Shipping
            setPatioDoorShippingPrefixTable.Rows.Clear();
            foreach (string[] item in Settings.PatioDoors_Shipping_Prefix_Table)
            {
                setPatioDoorShippingPrefixTable.Rows.Add(item[0], item[1], item[2], item[3]);
            }
            if (Settings.PatioDoors_Shipping_Obligatory_Order_boolean == "True") checkBoxPatioDoorReceivingOrder.Checked = true;

            //Glass recut

            if (Settings.GlassRecut_Obligatory_Name_boolean == "True") checkBoxGlassRecutMandatoryName.Checked = true;
            if (Settings.GlassRecut_Obligatory_Reason_boolean == "True") checkBoxGlassRecutMandatoryReason.Checked = true;
            textBoxGlassRecutPath.Text = Properties.Settings.Default.GlassRecutPath;

            //Booking
            // Frame Types

            dataGridViewBookingCasement.Rows.Clear();
            for (i = 0; i < Settings.Window_Casement.Count; i++)
            {
                dataGridViewBookingCasement.Rows.Add(Settings.Window_Casement[i]);
            }
            dataGridViewBookingDUMMY.Rows.Clear();
            for (i = 0; i < Settings.Window_Dummy.Count; i++)
            {
                dataGridViewBookingDUMMY.Rows.Add(Settings.Window_Dummy[i]);
            }
            dataGridViewBookingFix.Rows.Clear();
            for (i = 0; i < Settings.Window_Fix.Count; i++)
            {
                dataGridViewBookingFix.Rows.Add(Settings.Window_Fix[i]);
            }
            dataGridViewBookingSDWIND.Rows.Clear();
            for (i = 0; i < Settings.Window_Sdwind.Count; i++)
            {
                dataGridViewBookingSDWIND.Rows.Add(Settings.Window_Sdwind[i]);
            }
            dataGridViewBookingShape.Rows.Clear();
            for (i = 0; i < Settings.Window_Shape.Count; i++)
            {
                dataGridViewBookingShape.Rows.Add(Settings.Window_Shape[i]);
            }
            dataGridViewBookingSlider.Rows.Clear();
            for (i = 0; i < Settings.Window_Slider.Count; i++)
            {
                dataGridViewBookingSlider.Rows.Add(Settings.Window_Slider[i]);
            }
            dataGridViewBookingSU.Rows.Clear();
            for (i = 0; i < Settings.Window_SU.Count; i++)
            {
                dataGridViewBookingSU.Rows.Add(Settings.Window_SU[i]);
            }
            dataGridViewBookingSUSHP.Rows.Clear();
            for (i = 0; i < Settings.Window_SUSHP.Count; i++)
            {
                dataGridViewBookingSUSHP.Rows.Add(Settings.Window_SUSHP[i]);
            }
            textBoxBookDueDate.Text = Settings.BookDueDate;
            textBoxBookDueDateMessage.Text = Settings.BookDueDate_Message;
            textBoxBookListDateMessage.Text = Settings.BookListDate_Message;
            textBoxBookListDueDate.Text = Settings.BookListDueDate;
            if (Settings.BookCheckPassword == "True") checkBoxBookingPassword.Checked = true;
            textBoxPswdTime.Text = Settings.BookPswdTime;
            textBoxBookingPassword.Text = Settings.BookPassword;
            if (Settings.BookDateFilterType == "ORDER DATE")
            {
                RadioOrderDateFilter.Checked = true;
            }
            else
            {
                RadioDueDateFilter.Checked = true;
            }
            textBoxDateFilter.Text = Settings.BookDateFilter;


            //Booking Slider Types
            dataGridViewBookingFrame.Rows.Clear();
            for (i = 0; i < Settings.Book_Slider_Frame.Count; i++)
            {
                dataGridViewBookingFrame.Rows.Add(Settings.Book_Slider_Frame[i]);
            }
            dataGridViewBookingSash.Rows.Clear();
            for (i = 0; i < Settings.Book_Slider_Sash.Count; i++)
            {
                dataGridViewBookingSash.Rows.Add(Settings.Book_Slider_Sash[i]);
            }

            if (Settings.CountSashFrame_boolean == "True") checkBoxCountTogether.Checked = true;

            //Frame&Colour Receiving and Shipping
            setVinylProFrameReceivingPrefixTable.Rows.Clear();
            for (i = 0; i < Settings.VinylPro_Frame_Receiving_Prefix_Table.Count; i++)
            {
                setVinylProFrameReceivingPrefixTable.Rows.Add(Settings.VinylPro_Frame_Receiving_Prefix_Table[i]);
            }
            setVinylProFrameShippingPrefixTable.Rows.Clear();
            for (i = 0; i < Settings.VinylPro_Frame_Shipping_Prefix_Table.Count; i++)
            {
                setVinylProFrameShippingPrefixTable.Rows.Add(Settings.VinylPro_Frame_Shipping_Prefix_Table[i]);
            }
            setDVCoatexColorReceivingPrefixTable.Rows.Clear();
            for (i = 0; i < Settings.DVCoatex_Color_Receiving_Prefix_Table.Count; i++)
            {
                setDVCoatexColorReceivingPrefixTable.Rows.Add(Settings.DVCoatex_Color_Receiving_Prefix_Table[i]);
            }
            setDVCotexColorShippingPrefixTable.Rows.Clear();
            for (i = 0; i < Settings.DVCoatex_Color_Shipping_Prefix_Table.Count; i++)
            {
                setDVCotexColorShippingPrefixTable.Rows.Add(Settings.DVCoatex_Color_Shipping_Prefix_Table[i]);
            }
            setExpressCoatingColorReceivingPrefixTable.Rows.Clear();
            for (i = 0; i < Settings.ExpressCoating_Color_Receiving_Prefix_Table.Count; i++)
            {
                setExpressCoatingColorReceivingPrefixTable.Rows.Add(Settings.ExpressCoating_Color_Receiving_Prefix_Table[i]);
            }
            setExpressCoatingColourShippingPrefixTable.Rows.Clear();
            for (i = 0; i < Settings.ExpressCoating_Color_Shipping_Prefix_Table.Count; i++)
            {
                setExpressCoatingColourShippingPrefixTable.Rows.Add(Settings.ExpressCoating_Color_Shipping_Prefix_Table[i]);
            }

            setVinylProFrameReceivingErrorTime.Value = Settings.VinylPro_Frame_Receiving_Error_Time;
            setVinylProFrameShippingErrorTime.Value = Settings.VinylPro_Frame_Shipping_Error_Time;
            setDVCoatexColorReceivingErrorTime.Value = Settings.DVCoatex_Color_Receiving_Error_Time;
            setDVCoatexColorShippingErrorTime.Value = Settings.DVCoatex_Color_Shipping_Error_Time;
            setExpressCoatingColorReceivingErrorTime.Value = Settings.ExpressCoating_Color_Receiving_Error_Time;
            setExpressCoatingColorShippingErrorTime.Value = Settings.ExpressCoating_Color_Shipping_Error_Time;

            //Frame Recut 
            setFrameRecutFileNamingTable.Rows.Clear();
            for (i = 0; i < Settings.Frame_Recut_File_Naming_Table.Count; i++)
            {
                setFrameRecutFileNamingTable.Rows.Add(Settings.Frame_Recut_File_Naming_Table[i]);
            }

            if (Settings.Frame_Recut_Obligatory_Name_boolean == "True") checkBoxFrameRecutMandatoryName.Checked = true;
            if (Settings.Frame_Recut_Obligatory_Reason_boolean == "True") checkBoxFrameRecutMandatoryReason.Checked = true;
            textBoxFrameRecutPath.Text = Properties.Settings.Default.FrameRecutPath;

            //Production Cut
            textBoxProductionCutPath.Text = Properties.Settings.Default.ProductionCutPath;
            dataGridViewSlotSize.Rows.Clear();
            for (i = 0; i < Settings.Production_Cut_SlotSize_Table.Count; i++)
            {
                dataGridViewSlotSize.Rows.Add(Settings.Production_Cut_SlotSize_Table[i]);
            }

            //Paint Comapanies
            dataGridViewPaintCompanies.Rows.Clear();
            for (i = 0; i < Settings.CompaniesList.Count; i++)
            {
                dataGridViewPaintCompanies.Rows.Add(Settings.CompaniesList[i]);
            }
            dataGridViewPaintCompanies1.Rows.Clear();
            for (i = 0; i < Settings.Paint_Companies1_Table.Count; i++)
            {
                dataGridViewPaintCompanies1.Rows.Add(Settings.Paint_Companies1_Table[i][1]);
            }

            //Production Frame Types
            dataGridViewProductionCasement.Rows.Clear();
            for (i = 0; i < Settings.Production_Casement.Count; i++)
            {
                dataGridViewProductionCasement.Rows.Add(Settings.Production_Casement[i]);
            }
            dataGridViewProductionLFix.Rows.Clear();
            for (i = 0; i < Settings.Production_LargeFix.Count; i++)
            {
                dataGridViewProductionLFix.Rows.Add(Settings.Production_LargeFix[i]);
            }
            dataGridViewProductionSFix.Rows.Clear();
            for (i = 0; i < Settings.Production_SmallFix.Count; i++)
            {
                dataGridViewProductionSFix.Rows.Add(Settings.Production_SmallFix[i]);
            }
            dataGridViewProductionDH.Rows.Clear();
            for (i = 0; i < Settings.Production_DHFrame.Count; i++)
            {
                dataGridViewProductionDH.Rows.Add(Settings.Production_DHFrame[i]);
            }
            dataGridViewProductionSH.Rows.Clear();
            for (i = 0; i < Settings.Production_SHFrame.Count; i++)
            {
                dataGridViewProductionSH.Rows.Add(Settings.Production_SHFrame[i]);
            }
            dataGridViewProductionSSash1.Rows.Clear();
            for (i = 0; i < Settings.Production_SmallSash1.Count; i++)
            {
                dataGridViewProductionSSash1.Rows.Add(Settings.Production_SmallSash1[i]);
            }
            dataGridViewProductionSSash2.Rows.Clear();
            for (i = 0; i < Settings.Production_SmallSash2.Count; i++)
            {
                dataGridViewProductionSSash2.Rows.Add(Settings.Production_SmallSash2[i]);
            }

            //Text Notification
            for (i = 0; i < Settings.Notification_Dealers.Count; i++)
            {
                dataGridViewTextNotification.Rows.Add(Settings.Notification_Dealers[i]);
            }
            checkBoxNotificationConsiderTag.Checked = Settings.Notification_Consider_Tag;
            checkBoxNotificationActivePassword.Checked = Settings.Notification_Active_Password;
            textBoxNotificationPassword.Text = Settings.Notification_Password;
            if (Settings.Notification_Upper_Message != "")
            {
                textBoxNotificationUpperMessage.Text = Settings.Notification_Upper_Message;
            }
            if (Settings.Notification_Down_Message != "")
            {
                textBoxNotificationDownMessage.Text = Settings.Notification_Down_Message;
            }
            textBoxNotificationTrueDialogAPIURL.Text = Settings.TrueDialog_APIURL;
            textBoxNotificationTrueDialogAccountID.Text = Settings.TrueDialog_AccountId;
            textBoxNotificationTrueDialogKEY.Text = Settings.TrueDialog_KEY;
            textBoxNotificationTrueDialogSECRET.Text = Settings.TrueDialog_SECRET;
            textBoxNotificationTrueDialogCampaignID.Text = Settings.TrueDialog_CampaignId;

            //Shape PDF
            textBoxShapePDFBrowse.Text = Settings.ShapePDF_Path;

            //Shipping Report
            for (i = 0; i < Settings.Shipping_Report_Dealers.Count; i++)
            {
                dataGridViewShippingReport.Rows.Add(Settings.Shipping_Report_Dealers[i]);
            }
        }

        private async void setBtnSave_Click(object sender, EventArgs e)
        {
            await saveSetting();
        }

        private List<string[]> getDataFromDGView(DataGridView DGView, out bool error)
        {
            error = false;
            List<string[]> data = new List<string[]>();
            foreach (DataGridViewRow row in DGView.Rows)
            {
                if (row.IsNewRow) continue;
                List<string> item = new List<string>();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    item.Add((cell.Value == null) ? "" : cell.Value.ToString());
                }
                if (DGView.Equals(setISortPrefixTable) && (item[(int)PREFIX.PREFIX] == "" || item[(int)PREFIX.NAME] == ""))
                {
                    row.ErrorText = "Prefix and Name cannot be empty";
                    error = true;
                }
                else if ((DGView.Equals(setOptSliderTable) || DGView.Equals(setOptCaseTable) ||
                    DGView.Equals(setOptSUTable) || DGView.Equals(setOptShapeTable)) && (item[(int)TYPES.VALUE] == ""))
                {
                    row.ErrorText = "Name cannot be empty";
                    error = true;
                }
                else if (DGView.Equals(dataGridViewPaintCompanies1) && item[0] == "")
                {
                    row.ErrorText = "Name cannot be empty";
                    error = true;
                }
                else if (DGView.Equals(dataGridViewTextNotification) && (item[0] == "" || item[2] == ""))
                {
                    row.ErrorText = "Dealer or Phone number cannot be empty";
                    error = true;
                }
                else if (DGView.Equals(dataGridViewShippingReport) && (item[0] == "" || item[1] == ""))
                {
                    row.ErrorText = "Dealer or email cannot be empty";
                    error = true;
                }
                data.Add(item.ToArray());
            }
            return data;
        }

        private async Task saveSetting()
        {
            bool error;
            string windowsassemnly_hide, windowsassemnly_hidetim, countSashFrame_boolean = "", bookwindowtype, bookduedate;
            List<string[]> slider, casement, su, shape, prefix, ig_shipping_prefix, windowsassembly_prefix, frame_clearing_prefix, colour_shipping_prefix,
                Brickmould, Casing, Casement_Frame, Casement_Sash, Slider_Frame, Slider_sash, Small_Fix, Large_Fix, casement_hardware_prefix,
                windows_shipping_prefix, colour_receiving_prefix, oceanviewpatiodoors, vistapatiodoors, hourThermalGlass_CutToSize, hourThermalGlass_Unit,
                hourThermalGlass_Sheets, Emails, taskBoardEmail_list, Emails_proccessed = new List<string[]>(), frame_assembly_prefix, windows_wrapping_prefix, patiodoors_receiving_prefix,
                patiodoors_shipping_prefix, glassrecut_prefix, Window_Casement, Window_Dummy, Window_Fix, Window_Sdwind, Window_Shape, Window_Slider, Window_SU, Window_SUSHP, Book_Slider_Frame,
                Book_Slider_Sash, VinylPro_Frame_Receiving_Prefix_Table, VinylPro_Frame_Shipping_Prefix_Table, DVCoatex_Color_Receiving_Prefix_Table, DVCoatex_Color_Shipping_Prefix_Table,
                ExpressCoating_Color_Receiving_Prefix_Table, ExpressCoating_Color_Shipping_Prefix_Table, FrameRecut_File_Naming, productionCut_SlotSize,
                paintCompanies,
                production_Casement, production_LargeFix, production_SmallFix, production_DHFrame, production_SHFrame, production_SmallSash1, production_SmallSash2,
                notification_dealers, shipping_report_dealers;
            int i;
            slider = getDataFromDGView(setOptSliderTable, out error);
            if (error)
            {
                MessageBox.Show("Name cannot be empty");
                return;
            }
            casement = getDataFromDGView(setOptCaseTable, out error);
            if (error)
            {
                MessageBox.Show("Name cannot be empty");
                return;
            }
            su = getDataFromDGView(setOptSUTable, out error);
            if (error)
            {
                MessageBox.Show("Name cannot be empty");
                return;
            }
            shape = getDataFromDGView(setOptShapeTable, out error);
            if (error)
            {
                MessageBox.Show("Name cannot be empty");
                return;
            }
            prefix = getDataFromDGView(setISortPrefixTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            ig_shipping_prefix = getDataFromDGView(setIShippingPrefixTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            windowsassembly_prefix = getDataFromDGView(setIWindowsAssemblyPrefixTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            frame_clearing_prefix = getDataFromDGView(setFrameClearingPrefixTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            colour_shipping_prefix = getDataFromDGView(setColourShippingPrefixTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            Brickmould = getDataFromDGView(setBrickmouldTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            Casing = getDataFromDGView(setCasingTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            Casement_Frame = getDataFromDGView(setCasementFrameTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            Casement_Sash = getDataFromDGView(setCasementSashTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            Slider_Frame = getDataFromDGView(setSliderFrameTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            Slider_sash = getDataFromDGView(setSliderSashTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            Small_Fix = getDataFromDGView(setSmallFixTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            Large_Fix = getDataFromDGView(setLargeFixTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            casement_hardware_prefix = getDataFromDGView(setCasementHardwarePrefixTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }

            colour_receiving_prefix = getDataFromDGView(setColourDeliveredPrefixTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            windows_shipping_prefix = getDataFromDGView(setWindowsShippingPrefixTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            oceanviewpatiodoors = getDataFromDGView(OceanviewPatioDoorsData, out error);
            if (error)
            {
                MessageBox.Show("Type and category cannot be empty");
                return;
            }
            vistapatiodoors = getDataFromDGView(VistaPatioDoorsData, out error);
            if (error)
            {
                MessageBox.Show("Type and category cannot be empty");
                return;
            }
            hourThermalGlass_Sheets = getDataFromDGView(HourThermalGlass_SheetsData, out error);
            if (error)
            {
                MessageBox.Show("Type and category cannot be empty");
                return;
            }
            hourThermalGlass_Unit = getDataFromDGView(HourThermalGlass_UnitData, out error);
            if (error)
            {
                MessageBox.Show("Type and category cannot be empty");
                return;
            }
            hourThermalGlass_CutToSize = getDataFromDGView(HourThermalGlass_CutToSizeData, out error);
            if (error)
            {
                MessageBox.Show("Type and category cannot be empty");
                return;
            }
            Emails = getDataFromDGView(EmaildataGridView, out error);
            if (error)
            {
                MessageBox.Show("Email table cannot be empty");
                return;
            }
            taskBoardEmail_list = getDataFromDGView(dataGridViewTaskBoardEmail, out error);
            if (error)
            {
                MessageBox.Show("Email table cannot be empty");
                return;
            }
            frame_assembly_prefix = getDataFromDGView(setFrameAssemblyPrefixTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }

            windows_wrapping_prefix = getDataFromDGView(setWindowsWrappingPrefixTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            patiodoors_receiving_prefix = getDataFromDGView(setPatioDoorReceivingPrefixTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            patiodoors_shipping_prefix = getDataFromDGView(setPatioDoorShippingPrefixTable, out error);
            if (error)
            {
                MessageBox.Show("Prefix and Name cannot be empty");
                return;
            }
            Window_Casement = getDataFromDGView(dataGridViewBookingCasement, out error);
            Window_Dummy = getDataFromDGView(dataGridViewBookingDUMMY, out error);
            Window_Fix = getDataFromDGView(dataGridViewBookingFix, out error);
            Window_Sdwind = getDataFromDGView(dataGridViewBookingSDWIND, out error);
            Window_Shape = getDataFromDGView(dataGridViewBookingShape, out error);
            Window_Slider = getDataFromDGView(dataGridViewBookingSlider, out error);
            Window_SU = getDataFromDGView(dataGridViewBookingSU, out error);
            Window_SUSHP = getDataFromDGView(dataGridViewBookingSUSHP, out error);
            Book_Slider_Frame = getDataFromDGView(dataGridViewBookingFrame, out error);
            Book_Slider_Sash = getDataFromDGView(dataGridViewBookingSash, out error);
            VinylPro_Frame_Receiving_Prefix_Table = getDataFromDGView(setVinylProFrameReceivingPrefixTable, out error);
            VinylPro_Frame_Shipping_Prefix_Table = getDataFromDGView(setVinylProFrameShippingPrefixTable, out error);
            DVCoatex_Color_Receiving_Prefix_Table = getDataFromDGView(setDVCoatexColorReceivingPrefixTable, out error);
            DVCoatex_Color_Shipping_Prefix_Table = getDataFromDGView(setDVCotexColorShippingPrefixTable, out error);
            ExpressCoating_Color_Receiving_Prefix_Table = getDataFromDGView(setExpressCoatingColorReceivingPrefixTable, out error);
            ExpressCoating_Color_Shipping_Prefix_Table = getDataFromDGView(setExpressCoatingColourShippingPrefixTable, out error);

            FrameRecut_File_Naming = getDataFromDGView(setFrameRecutFileNamingTable, out error);

            productionCut_SlotSize = getDataFromDGView(dataGridViewSlotSize, out error);
            paintCompanies = getDataFromDGView(dataGridViewPaintCompanies1, out error);
            if (error)
            {
                MessageBox.Show("Paint company name cannot be empty");
                return;
            }
            production_Casement = getDataFromDGView(dataGridViewProductionCasement, out error);
            production_LargeFix = getDataFromDGView(dataGridViewProductionLFix, out error);
            production_SmallFix = getDataFromDGView(dataGridViewProductionSFix, out error);
            production_DHFrame = getDataFromDGView(dataGridViewProductionDH, out error);
            production_SHFrame = getDataFromDGView(dataGridViewProductionSH, out error);
            production_SmallSash1 = getDataFromDGView(dataGridViewProductionSSash1, out error);
            production_SmallSash2 = getDataFromDGView(dataGridViewProductionSSash2, out error);

            if (error)
            {
                MessageBox.Show("Column H and Slot Size cannot be empty");
                return;
            }
            notification_dealers = getDataFromDGView(dataGridViewTextNotification, out error);
            if (error)
            {
                MessageBox.Show("Dealer or Phone number cannot be empty in notification setting.");
                return;
            }
            shipping_report_dealers = getDataFromDGView(dataGridViewShippingReport, out error);
            if (error)
            {
                MessageBox.Show("Dealer or Email cannot be empty in shipping report setting.");
                return;
            }
            // General Setting
            int hour = (int)setGeneralShutdownHour.Value;
            int min = (int)setGeneralShutdownMin.Value;
            Settings.Shutdown_Time = (hour > 9 ? hour.ToString() : "0" + hour) + ":" + (min > 9 ? min.ToString() : "0" + min);
            if (setGeneralUploadFrom.Text != "") Settings.Upload_From = setGeneralUploadFrom.Text;
            if (setGeneralUploadTo.Text != "") Settings.Upload_To = setGeneralUploadTo.Text;
            if (setGeneralUploadLog.Text != "") Settings.Log_Path = setGeneralUploadLog.Text;
            if (checkBoxCloseTime.Checked == true) Settings.CloseAppBoolean = "True";
            else Settings.CloseAppBoolean = "False";

            // Optimize
            Settings.Rack_Size_16 = (int)setOptRackSize16.Value;
            Settings.Rack_Size_8 = (int)setOptRackSize8.Value;
            Settings.Slider = slider;
            Settings.Casement = casement;
            Settings.SU = su;
            Settings.Shape = shape;
            Settings.Window_Type = new List<string[]>()
                { Settings.getTypeValue(Settings.Slider), Settings.getTypeValue(Settings.Casement),
                    Settings.getTypeValue(Settings.SU), Settings.getTypeValue(Settings.Shape) };

            // IG Sorting Setting
            Settings.IG_Sorting_Prefix_Table = prefix;
            Settings.IG_Sorting_Error_Time = Convert.ToInt32(setISortErrorTime.Value);
            Settings.IG_Sorting_Scan_Interval = Convert.ToInt32(setISortIntervalTime.Value);

            // IG Shipping Setting
            Settings.IG_Shipping_Prefix_Table = ig_shipping_prefix;
            Settings.IG_Shipping_Error_Time = Convert.ToInt32(setIShippingErrorTime.Value);

            // Windows Assembly Setting
            Settings.Windows_Assembly_Prefix_Table = windowsassembly_prefix;
            Settings.Windows_Assembly_Error_Time = Convert.ToInt32(setIWindowsAssemblyErrorTime.Value);

            // Frame Clearing Setting
            Settings.Frame_Clearing_Prefix_Table = frame_clearing_prefix;
            Settings.Frame_Clearing_Error_Time = Convert.ToInt32(setFrameClearingErrorTime.Value);
            Settings.Frame_Clearing_Scan_Interval = Convert.ToInt32(setFrameClearingScanInterval.Value);

            // Frame Types

            Settings.Brickmould = Brickmould;
            Settings.Casing = Casing;
            Settings.Casement_Frame = Casement_Frame;
            Settings.Casement_Sash = Casement_Sash;
            Settings.Slider_Frame = Slider_Frame;
            Settings.Slider_sash = Slider_sash;
            Settings.Small_Fix = Small_Fix;
            Settings.Large_Fix = Large_Fix;
            Settings.Frame_Types = new List<string[]>()
                { Settings.getTypeValue(Brickmould), Settings.getTypeValue(Casing), Settings.getTypeValue(Casement_Frame), Settings.getTypeValue(Casement_Sash), Settings.getTypeValue(Slider_Frame), Settings.getTypeValue(Slider_sash), Settings.getTypeValue(Small_Fix), Settings.getTypeValue(Large_Fix) };
            ;
            // Casement Hardware Setting
            Settings.Casement_Hardware_Prefix_Table = casement_hardware_prefix;
            Settings.Casement_Hardware_Error_Time = Convert.ToInt32(setCasementHardwareErrorTime.Value);
            Settings.Casement_Hardware_Scan_Interval = Convert.ToInt32(setCasementHardwareScanInterval.Value);

            // Colour Shipping Setting
            Settings.Colour_Shipping_Prefix_Table = colour_shipping_prefix;
            Settings.Colour_Shipping_Error_Time = Convert.ToInt32(setColourShippingErrorTime.Value);

            // Colour Receiving Setting
            Settings.Colour_Receiving_Prefix_Table = colour_receiving_prefix;
            Settings.Colour_Receiving_Error_Time = Convert.ToInt32(setColourReceivingErrorTime.Value);

            //email
            for (i = 0; i < Emails.Count; i++)
            {
                string types = "";
                if (Emails[i][2] == "True") types += " 24Hour Thermal Glass";
                if (Emails[i][3] == "True") types += " Oceanview Patio Doors";
                if (Emails[i][4] == "True") types += " Vista Patio Doors";
                if (Emails[i][5] == "True") types += " Woodbridge";
                if (Emails[i][6] == "True") types += " Colour Shipping Report";
                if (Emails[i][7] == "True") types += " Colour Receiving Report";
                if (Emails[i][8] == "True") types += " GlassRecut";
                if (Emails[i][9] == "True") types += " IG-Sorting";
                if (Emails[i][10] == "True") types += " FrameRecut";
                if (Emails[i][11] == "True") types += " FrameClearing";
                if (Emails[i][12] == "True") types += " VinylProFrameReceiving";

                Emails_proccessed.Add(new string[] { i.ToString(), Emails[i][1], types });
            }
            Settings.Receiving_Emails_Table = Emails_proccessed;

            Settings.EmailMessageVista = textBoxEmailMessageVista.Text;
            Settings.EmailSignatureVista = textBoxEmailSignatureVista.Text;
            Settings.EmailSubjectVista = textBoxEmailSubjectVista.Text;
            if (checkBoxEmailMessageVista.Checked == true) Settings.EmailMessageVista_boolean = "True"; else Settings.EmailMessageVista_boolean = "False";
            if (checkBoxEmailSignatureVista.Checked == true) Settings.EmailSignatureVista_boolean = "True"; else Settings.EmailSignatureVista_boolean = "False";
            if (checkBoxEmailSubjectVista.Checked == true) Settings.EmailSubjectVista_boolean = "True"; else Settings.EmailSubjectVista_boolean = "False";

            Settings.EmailMessage24Hour = textBoxEmailMessage24Hour.Text;
            Settings.EmailSignature24Hour = textBoxEmailSignature24Hour.Text;
            Settings.EmailSubject24Hour = textBoxEmailSubject24Hour.Text;
            if (checkBoxEmailMessage24Hour.Checked == true) Settings.EmailMessage24Hour_boolean = "True"; else Settings.EmailMessage24Hour_boolean = "False";
            if (checkBoxEmailSignature24Hour.Checked == true) Settings.EmailSignature24Hour_boolean = "True"; else Settings.EmailSignature24Hour_boolean = "False";
            if (checkBoxEmailSubject24Hour.Checked == true) Settings.EmailSubject24Hour_boolean = "True"; else Settings.EmailSubject24Hour_boolean = "False";

            Settings.EmailMessageOceanview = textBoxEmailMessageOceanview.Text;
            Settings.EmailSignatureOceanview = textBoxEmailSignatureOceanview.Text;
            Settings.EmailSubjectOceanview = textBoxEmailSubjectOceanview.Text;
            if (checkBoxEmailMessageOceanview.Checked == true) Settings.EmailMessageOceanview_boolean = "True"; else Settings.EmailMessageOceanview_boolean = "False";
            if (checkBoxEmailSignatureOceanview.Checked == true) Settings.EmailSignatureOceanview_boolean = "True"; else Settings.EmailSignatureOceanview_boolean = "False";
            if (checkBoxEmailSubjectOceanview.Checked == true) Settings.EmailSubjectOceanview_boolean = "True"; else Settings.EmailSubjectOceanview_boolean = "False";

            Settings.EmailMessageWoodbridge = textBoxEmailMessageWoodbridge.Text;
            Settings.EmailSignatureWoodbridge = textBoxEmailSignatureWoodbridge.Text;
            Settings.EmailSubjectWoodbridge = textBoxEmailSubjectWoodbridge.Text;
            if (checkBoxEmailMessageWoodbridge.Checked == true) Settings.EmailMessageWoodbridge_boolean = "True"; else Settings.EmailMessageWoodbridge_boolean = "False";
            if (checkBoxEmailSignatureWoodbridge.Checked == true) Settings.EmailSignatureWoodbridge_boolean = "True"; else Settings.EmailSignatureWoodbridge_boolean = "False";
            if (checkBoxEmailSubjectWoodbridge.Checked == true) Settings.EmailSubjectWoodbridge_boolean = "True"; else Settings.EmailSubjectWoodbridge_boolean = "False";


            // OceanviewPatioDoors
            Settings.OceanviewPatioDoors_fields = oceanviewpatiodoors;
            Settings.OceanviewPatioDoors_days = Convert.ToInt32(OceanviewPatioDoorsDays.Text);
            Settings.NAAutoSelectOceanView = NAcheckBoxOceanView.Checked.ToString();
            Settings.OceanviewPatioDoors_Custom_Limit = Convert.ToInt32(textBoxOceanviewLimit.Text);

            // VistaPatioDoors
            Settings.VistaPatioDoors_fields = vistapatiodoors;
            Settings.VistaPatioDoors_days = Convert.ToInt32(VistaPatioDoorsDays.Text);
            Settings.NAAutoSelectVista = NAcheckBoxVista.Checked.ToString();
            Settings.VistaPatioDoors_Custom_Limit = Convert.ToInt32(textBoxVistaLimit.Text);

            //Windows Assemnly Hide
            Settings.WindowsAssemblyHide = checkBoxWindowsAssemblyHide.Checked.ToString();
            Settings.WindowsAssemblyHideTime = Convert.ToInt32(textBoxWindowsAssemblyHideTime.Text);
            Settings.WindowsAssemblyUpdateTime = Convert.ToInt32(textBoxWindowsAssemblyUpdateTime.Text);
            // 24 hour thermal glass
            Settings.HourThermalGlass_CutToSize_fields = hourThermalGlass_CutToSize;
            Settings.HourThermalGlass_CutToSize_days = Convert.ToInt32(HourThermalGlass_CutToSizeRequiredDays.Text);
            Settings.HourThermalGlass_Sheets_fields = hourThermalGlass_Sheets;
            Settings.HourThermalGlass_Sheets_days = Convert.ToInt32(HourThermalGlass_SheetsRequiredDays.Text);
            Settings.HourThermalGlass_Unit_fields = hourThermalGlass_Unit;
            Settings.HourThermalGlass_Unit_days = Convert.ToInt32(HourThermalGlass_UnitRequiredDays.Text);

            // Task Board Email
            Settings.TaskBoardEmail_list = taskBoardEmail_list;
            // Windows Shipping
            Settings.Windows_Shipping_Prefix_Table = windows_shipping_prefix;
            //Frame Assembly
            Settings.Frame_Assembly_Prefix_Table = frame_assembly_prefix;

            Settings.CountSashFrame_boolean = checkBoxCountTogether.Checked.ToString();

            // Windows Wrapping
            Settings.Windows_Wrapping_Prefix_Table = windows_wrapping_prefix;

            //Windows Wrapping Hide
            Settings.WindowsWrappingHide = checkBoxWindowsWrappingHide.Checked.ToString();
            Settings.WindowsWrappingHideTime = Convert.ToInt32(textBoxWindowsWrappingHideTime.Text);
            Settings.WindowsWrappingUpdateTime = Convert.ToInt32(textBoxWindowsWrappingUpdateTime.Text);
            //Patio Doors Receiving
            Settings.PatioDoors_Receiving_Prefix_Table = patiodoors_receiving_prefix;

            //Patio Doors Shipping
            Settings.PatioDoors_Shipping_Prefix_Table = patiodoors_shipping_prefix;
            Settings.PatioDoors_Shipping_Obligatory_Order_boolean = checkBoxPatioDoorReceivingOrder.Checked.ToString();

            //Patio Doors Shipping
            Settings.PatioDoors_Shipping_Prefix_Table = patiodoors_shipping_prefix;
            Settings.PatioDoors_Shipping_Obligatory_Order_boolean = checkBoxPatioDoorReceivingOrder.Checked.ToString();

            //Glass Recut

            Settings.GlassRecut_Obligatory_Name_boolean = checkBoxGlassRecutMandatoryName.Checked.ToString();
            Settings.GlassRecut_Obligatory_Reason_boolean = checkBoxGlassRecutMandatoryReason.Checked.ToString();

            //Booking
            Settings.Window_Casement = Window_Casement;
            Settings.Window_Dummy = Window_Dummy;
            Settings.Window_Fix = Window_Fix;
            Settings.Window_Sdwind = Window_Sdwind;
            Settings.Window_Shape = Window_Shape;
            Settings.Window_Slider = Window_Slider;
            Settings.Window_SU = Window_SU;
            Settings.Window_SUSHP = Window_SUSHP;
            Settings.Window_Types = new List<string[]>();
            Settings.Window_Types.AddRange(Window_Casement);
            Settings.Window_Types.AddRange(Window_Dummy);
            Settings.Window_Types.AddRange(Window_Fix);
            Settings.Window_Types.AddRange(Window_Sdwind);
            Settings.Window_Types.AddRange(Window_Shape);
            Settings.Window_Types.AddRange(Window_Slider);
            Settings.Window_Types.AddRange(Window_SU);

            Settings.Book_Slider_Frame = Book_Slider_Frame;
            Settings.Book_Slider_Sash = Book_Slider_Sash;
            Settings.Book_Slider = new List<string[]>();
            Settings.Book_Slider.AddRange(Book_Slider_Frame);
            Settings.Book_Slider.AddRange(Book_Slider_Sash);
            Settings.BookDueDate = textBoxBookDueDate.Text;
            Settings.BookListDueDate = textBoxBookListDueDate.Text;
            Settings.BookDueDate_Message = textBoxBookDueDateMessage.Text;
            Settings.BookListDate_Message = textBoxBookListDateMessage.Text;
            Settings.BookCheckPassword = checkBoxBookingPassword.Checked.ToString();
            Settings.BookPassword = textBoxBookingPassword.Text;
            Settings.BookPswdTime = textBoxPswdTime.Text;
            Settings.BookDateFilterType = RadioOrderDateFilter.Checked ? "ORDER DATE" : "DUE DATE";
            Settings.BookDateFilter = textBoxDateFilter.Text;

            //Frame&Colour Receiving and Shipping
            Settings.VinylPro_Frame_Receiving_Prefix_Table = VinylPro_Frame_Receiving_Prefix_Table;
            Settings.VinylPro_Frame_Shipping_Prefix_Table = VinylPro_Frame_Shipping_Prefix_Table;
            Settings.DVCoatex_Color_Receiving_Prefix_Table = DVCoatex_Color_Receiving_Prefix_Table;
            Settings.DVCoatex_Color_Shipping_Prefix_Table = DVCoatex_Color_Shipping_Prefix_Table;
            Settings.ExpressCoating_Color_Receiving_Prefix_Table = ExpressCoating_Color_Receiving_Prefix_Table;
            Settings.ExpressCoating_Color_Shipping_Prefix_Table = ExpressCoating_Color_Shipping_Prefix_Table;

            Settings.VinylPro_Frame_Receiving_Error_Time = Convert.ToInt32(setVinylProFrameReceivingErrorTime.Value);
            Settings.VinylPro_Frame_Shipping_Error_Time = Convert.ToInt32(setVinylProFrameShippingErrorTime.Value);
            Settings.DVCoatex_Color_Receiving_Error_Time = Convert.ToInt32(setDVCoatexColorReceivingErrorTime.Value);
            Settings.DVCoatex_Color_Shipping_Error_Time = Convert.ToInt32(setDVCoatexColorShippingErrorTime.Value);
            Settings.ExpressCoating_Color_Receiving_Error_Time = Convert.ToInt32(setExpressCoatingColorReceivingErrorTime.Value);
            Settings.ExpressCoating_Color_Shipping_Error_Time = Convert.ToInt32(setExpressCoatingColorShippingErrorTime.Value);

            //Frame Recut File Naming
            Settings.Frame_Recut_File_Naming_Table = FrameRecut_File_Naming;
            Settings.Frame_Recut_Obligatory_Name_boolean = checkBoxFrameRecutMandatoryName.Checked.ToString();
            Settings.Frame_Recut_Obligatory_Reason_boolean = checkBoxFrameRecutMandatoryReason.Checked.ToString();
      
            Settings.Production_Cut_SlotSize_Table = productionCut_SlotSize;

            //Paint Company
            Settings.Paint_Companies1_Table.Clear();
            for (i = 0; i < paintCompanies.Count; i++)
            {
                Settings.Paint_Companies1_Table.Add(new string[] { (i + 1).ToString(), paintCompanies[i][0] });
            }

            //Production Frame Types
            Settings.Production_Casement = production_Casement;
            Settings.Production_LargeFix = production_LargeFix;
            Settings.Production_SmallFix = production_SmallFix;
            Settings.Production_DHFrame = production_DHFrame;
            Settings.Production_SHFrame = production_SHFrame;
            Settings.Production_SmallSash1 = production_SmallSash1;
            Settings.Production_SmallSash2 = production_SmallSash2;

            Settings.Production_Types = new List<string[]>();
            Settings.Production_Types.AddRange(production_Casement);
            Settings.Production_Types.AddRange(production_LargeFix);
            Settings.Production_Types.AddRange(production_SmallFix);
            Settings.Production_Types.AddRange(production_DHFrame);
            Settings.Production_Types.AddRange(production_SHFrame);
            Settings.Production_Types.AddRange(production_SmallSash1);
            Settings.Production_Types.AddRange(production_SmallSash2);

            //Text Notification
            Settings.Notification_Dealers = notification_dealers;
            Settings.Notification_Consider_Tag = checkBoxNotificationConsiderTag.Checked;
            Settings.Notification_Upper_Message = textBoxNotificationUpperMessage.Text;
            Settings.Notification_Down_Message = textBoxNotificationDownMessage.Text;
            Settings.Notification_Active_Password = checkBoxNotificationActivePassword.Checked;
            Settings.Notification_Password = textBoxNotificationPassword.Text;
            Settings.TrueDialog_APIURL = textBoxNotificationTrueDialogAPIURL.Text;
            Settings.TrueDialog_AccountId = textBoxNotificationTrueDialogAccountID.Text;
            Settings.TrueDialog_KEY = textBoxNotificationTrueDialogKEY.Text;
            Settings.TrueDialog_SECRET = textBoxNotificationTrueDialogSECRET.Text;
            Settings.TrueDialog_CampaignId = textBoxNotificationTrueDialogCampaignID.Text;

            //Shape PDF
            Settings.ShapePDF_Path = textBoxShapePDFBrowse.Text;

            //Shipping Report
            Settings.Shipping_Report_Dealers = shipping_report_dealers;

            thread.Tick += Save_Tick;
            thread.Start();

            progress.Show();
        }

        private void Save_Tick(object sender, EventArgs e)
        {
            thread.Stop();
            thread.Tick -= Save_Tick;

            Settings.saveSetting();
            is_saved = true;

            progress.Close();
            Close();
        }

        private void setBtnCancel_Click(object sender, EventArgs e)
        {
            is_cancel = true;
            Close();
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        //Common Event
        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var comboBox = e.Control as DataGridViewComboBoxEditingControl;
            if (comboBox != null)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }


        //General Setting
        private void setGeneralBtnSelectDate_Click(object sender, EventArgs e)
        {
            SelectDateRangeDialog select_daterange = new SelectDateRangeDialog();
            DateTime[] list_date = select_daterange.InputBox();
            if (list_date != null)
            {
                string start_date = list_date[0].ToString("yyyy-MM-dd");
                string end_date = list_date[1].ToString("yyyy-MM-dd");
                if (start_date != end_date) setGeneralLblSelectedDate.Text = start_date + " - " + end_date;
                else setGeneralLblSelectedDate.Text = start_date;
                Settings.Selected_Date = list_date;
                is_saved = false;
                setBtnSave.Enabled = true;
            }
        }

        private void setGeneralDirectoryBrowse_Click(object sender, EventArgs e)
        {
            TextBox txtPath;
            string selected_path;
            if (sender.Equals(setGeneralUploadFromBrowse))
            {
                selected_path = Settings.Upload_From;
                txtPath = setGeneralUploadFrom;
            }
            else if (sender.Equals(setGeneralUploadToBrowse))
            {
                selected_path = Settings.Upload_To;
                txtPath = setGeneralUploadTo;
            }
            else if (sender.Equals(setGeneralUploadLogBrowse))
            {
                selected_path = Settings.Log_Path;
                txtPath = setGeneralUploadLog;
            }
            else if (sender.Equals(buttonShapePDFBrowse))
            {
                selected_path = Settings.ShapePDF_Path;
                txtPath = textBoxShapePDFBrowse;
            }
            else
            {
                return;
            }
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            dialog.SelectedPath = selected_path;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dialog.SelectedPath;
                if (selected_path != txtPath.Text)
                {
                    setBtnSave.Enabled = true;
                    is_saved = false;
                }
            }
        }

        // Optimize
        private void setOptTypeTables_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgView;
            if (sender.Equals(setOptSliderTable)) dgView = setOptSliderTable;
            else if (sender.Equals(setOptCaseTable)) dgView = setOptCaseTable;
            else if (sender.Equals(setOptSUTable)) dgView = setOptSUTable;
            else dgView = setOptShapeTable;
            int r = e.RowIndex, c = e.ColumnIndex;
            if (dgView.Rows[r].IsNewRow) return;
            if (e.FormattedValue.ToString() == "")
            {
                dgView.Rows[r].ErrorText = "Name cannot be empty";
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgView.CurrentCell = dgView.Rows[r].Cells[c];
                e.Cancel = true;
            }
        }

        private void setOptTypeTables_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgView;
            if (sender.Equals(setOptSliderTable)) dgView = setOptSliderTable;
            else if (sender.Equals(setOptCaseTable)) dgView = setOptCaseTable;
            else if (sender.Equals(setOptSUTable)) dgView = setOptSUTable;
            else dgView = setOptShapeTable;
            int r = e.RowIndex, c = e.ColumnIndex;
            dgView.Rows[r].ErrorText = "";
            if (dgView.CurrentCell.Value != null)
            {
                dgView.CurrentCell.Value = dgView.CurrentCell.Value.ToString().ToUpper();
            }
        }

        private void setOptTypeTables_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (sender.Equals(setOptSliderTable)) setOptSliderTable.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "SLIDER";
            else if (sender.Equals(setOptCaseTable)) setOptCaseTable.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "CASEMENT";
            else if (sender.Equals(setOptSUTable)) setOptSUTable.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "SU";
            else setOptShapeTable.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "SHAPE";
        }

        // IG Sorting Setting
        private void setISortPrefixTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            string value = e.FormattedValue.ToString();
            if (setISortPrefixTable.Rows[r].IsNewRow) return;
            if (c == 1)
            {
                bool isAlphaBet = Regex.IsMatch(value, "[a-z]", RegexOptions.IgnoreCase);
                if (!isAlphaBet)
                {
                    setISortPrefixTable.Rows[r].ErrorText = "Prefix letter should be alphabet";
                    MessageBox.Show("Prefix letter should be alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setISortPrefixTable.CurrentCell = setISortPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
            else if (c == 3)
            {
                if (value == "")
                {
                    setISortPrefixTable.Rows[r].ErrorText = "Name cannot be empty";
                    MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setISortPrefixTable.CurrentCell = setISortPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
        }

        private void setISortPrefixTable_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            setISortPrefixTable.Rows[r].ErrorText = "";
            if (c == 1 && setISortPrefixTable.CurrentCell.Value != null)
            {
                setISortPrefixTable.CurrentCell.Value = setISortPrefixTable.CurrentCell.Value.ToString().ToUpper();
            }
        }

        // Windows Assembly Setting
        private void setIWindowsAssemblyPrefixTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            string value = e.FormattedValue.ToString();
            if (setIWindowsAssemblyPrefixTable.Rows[r].IsNewRow) return;
            if (c == 1)
            {
                bool isAlphaBet = Regex.IsMatch(value, "[a-z]", RegexOptions.IgnoreCase);
                if (!isAlphaBet)
                {
                    setIWindowsAssemblyPrefixTable.Rows[r].ErrorText = "Prefix letter should be alphabet";
                    MessageBox.Show("Prefix letter should be alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setIWindowsAssemblyPrefixTable.CurrentCell = setIWindowsAssemblyPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
            else if (c == 3)
            {
                if (value == "")
                {
                    setIWindowsAssemblyPrefixTable.Rows[r].ErrorText = "Name cannot be empty";
                    MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setIWindowsAssemblyPrefixTable.CurrentCell = setIWindowsAssemblyPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
        }

        private void setIIWindowsAssemblyPrefixTable_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            setIWindowsAssemblyPrefixTable.Rows[r].ErrorText = "";
            if (c == 1 && setIWindowsAssemblyPrefixTable.CurrentCell.Value != null)
            {
                setIWindowsAssemblyPrefixTable.CurrentCell.Value = setIWindowsAssemblyPrefixTable.CurrentCell.Value.ToString().ToUpper();
            }
        }

        // IG Shipping Setting
        private void setIShippingPrefixTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            string value = e.FormattedValue.ToString();
            if (setIShippingPrefixTable.Rows[r].IsNewRow) return;
            if (c == 1)
            {
                bool isAlphaBet = Regex.IsMatch(value, "[a-z]", RegexOptions.IgnoreCase);
                if (!isAlphaBet)
                {
                    setIShippingPrefixTable.Rows[r].ErrorText = "Prefix letter should be alphabet";
                    MessageBox.Show("Prefix letter should be alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setIShippingPrefixTable.CurrentCell = setIShippingPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
            else if (c == 3)
            {
                if (value == "")
                {
                    setIShippingPrefixTable.Rows[r].ErrorText = "Name cannot be empty";
                    MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setIShippingPrefixTable.CurrentCell = setIShippingPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
        }

        private void setIShippingPrefixTable_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            setIShippingPrefixTable.Rows[r].ErrorText = "";
            if (c == 1 && setIShippingPrefixTable.CurrentCell.Value != null)
            {
                setIShippingPrefixTable.CurrentCell.Value = setIShippingPrefixTable.CurrentCell.Value.ToString().ToUpper();
            }
        }

        // Frame Types
        private void FrameTypesTables_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgView;
            if (sender.Equals(setBrickmouldTable)) dgView = setBrickmouldTable;
            else if (sender.Equals(setCasingTable)) dgView = setCasingTable;
            else if (sender.Equals(setCasementFrameTable)) dgView = setCasementFrameTable;
            else if (sender.Equals(setCasementSashTable)) dgView = setCasementSashTable;
            else if (sender.Equals(setSliderFrameTable)) dgView = setSliderFrameTable;
            else if (sender.Equals(setSliderSashTable)) dgView = setSliderSashTable;
            else if (sender.Equals(setSmallFixTable)) dgView = setSmallFixTable;
            else dgView = setLargeFixTable;

            int r = e.RowIndex, c = e.ColumnIndex;
            dgView.Rows[r].ErrorText = "";
            if (dgView.CurrentCell.Value != null)
            {
                dgView.CurrentCell.Value = dgView.CurrentCell.Value.ToString().ToUpper();
            }
        }

        private void FrameTypesTables_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgView;
            if (sender.Equals(setBrickmouldTable)) dgView = setBrickmouldTable;
            else if (sender.Equals(setCasingTable)) dgView = setCasingTable;
            else if (sender.Equals(setCasementFrameTable)) dgView = setCasementFrameTable;
            else if (sender.Equals(setCasementSashTable)) dgView = setCasementSashTable;
            else if (sender.Equals(setSliderFrameTable)) dgView = setSliderFrameTable;
            else if (sender.Equals(setSliderSashTable)) dgView = setSliderSashTable;
            else if (sender.Equals(setSmallFixTable)) dgView = setSmallFixTable;
            else dgView = setLargeFixTable;
            int r = e.RowIndex, c = e.ColumnIndex;
            if (dgView.Rows[r].IsNewRow) return;
            if (e.FormattedValue.ToString() == "")
            {
                dgView.Rows[r].ErrorText = "Name cannot be empty";
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgView.CurrentCell = dgView.Rows[r].Cells[c];
                e.Cancel = true;
            }
        }

        private void FrameTypesTables_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (sender.Equals(setBrickmouldTable)) setBrickmouldTable.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "Brickmould";
            else if (sender.Equals(setCasingTable)) setCasingTable.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "Casing";
            else if (sender.Equals(setCasementFrameTable)) setCasementFrameTable.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "Casement Frame";
            else if (sender.Equals(setCasementSashTable)) setCasementSashTable.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "Casement Sash";
            else if (sender.Equals(setSliderFrameTable)) setSliderFrameTable.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "Slider Frame";
            else if (sender.Equals(setSliderSashTable)) setSliderSashTable.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "Slider sash";
            else if (sender.Equals(setSmallFixTable)) setSmallFixTable.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "Small Fix";
            else setLargeFixTable.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "Large Fix";
        }

        // Common events
        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            is_saved = false;
            setBtnSave.Enabled = true;
        }

        private void textBox_ValueChanged(object sender, EventArgs e)
        {
            is_saved = false;
            setBtnSave.Enabled = true;
        }

        private void numericUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == '-')
            {
                e.Handled = true;
                return;
            }
            setBtnSave.Enabled = true;
        }

        private void setFrameClearingPrefixTable_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            setFrameClearingPrefixTable.Rows[r].ErrorText = "";
            if (c == 1 && setFrameClearingPrefixTable.CurrentCell.Value != null)
            {
                setFrameClearingPrefixTable.CurrentCell.Value = setFrameClearingPrefixTable.CurrentCell.Value.ToString().ToUpper();
            }
        }

        private void setFrameClearingPrefixTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            int r = e.RowIndex, c = e.ColumnIndex;
            string value = e.FormattedValue.ToString();
            if (setFrameClearingPrefixTable.Rows[r].IsNewRow) return;
            if (c == 1)
            {
                bool isAlphaBet = Regex.IsMatch(value, "[a-z]", RegexOptions.IgnoreCase);
                if (!isAlphaBet)
                {
                    setFrameClearingPrefixTable.Rows[r].ErrorText = "Prefix letter should be alphabet";
                    MessageBox.Show("Prefix letter should be alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setFrameClearingPrefixTable.CurrentCell = setFrameClearingPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
            else if (c == 3)
            {
                if (value == "")
                {
                    setFrameClearingPrefixTable.Rows[r].ErrorText = "Name cannot be empty";
                    MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setFrameClearingPrefixTable.CurrentCell = setFrameClearingPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
        }

        //Casement Hardware
        private void setCasementHardwarePrefixTable_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            setCasementHardwarePrefixTable.Rows[r].ErrorText = "";
            if (c == 1 && setCasementHardwarePrefixTable.CurrentCell.Value != null)
            {
                setCasementHardwarePrefixTable.CurrentCell.Value = setCasementHardwarePrefixTable.CurrentCell.Value.ToString().ToUpper();
            }
        }

        private void setCasementHardwarePrefixTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            int r = e.RowIndex, c = e.ColumnIndex;
            string value = e.FormattedValue.ToString();
            if (setCasementHardwarePrefixTable.Rows[r].IsNewRow) return;
            if (c == 1)
            {
                bool isAlphaBet = Regex.IsMatch(value, "[a-z]", RegexOptions.IgnoreCase);
                if (!isAlphaBet)
                {
                    setCasementHardwarePrefixTable.Rows[r].ErrorText = "Prefix letter should be alphabet";
                    MessageBox.Show("Prefix letter should be alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setCasementHardwarePrefixTable.CurrentCell = setCasementHardwarePrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
            else if (c == 3)
            {
                if (value == "")
                {
                    setCasementHardwarePrefixTable.Rows[r].ErrorText = "Name cannot be empty";
                    MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setCasementHardwarePrefixTable.CurrentCell = setCasementHardwarePrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
        }

        private void setColourShippingPrefixTable_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            setColourShippingPrefixTable.Rows[r].ErrorText = "";
            if (c == 1 && setColourShippingPrefixTable.CurrentCell.Value != null)
            {
                setColourShippingPrefixTable.CurrentCell.Value = setColourShippingPrefixTable.CurrentCell.Value.ToString().ToUpper();
            }
        }

        private void setColourShippingPrefixTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            string value = e.FormattedValue.ToString();
            if (setColourShippingPrefixTable.Rows[r].IsNewRow) return;
            if (c == 1)
            {
                bool isAlphaBet = Regex.IsMatch(value, "[a-z]", RegexOptions.IgnoreCase);
                if (!isAlphaBet)
                {
                    setColourShippingPrefixTable.Rows[r].ErrorText = "Prefix letter should be alphabet";
                    MessageBox.Show("Prefix letter should be alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setColourShippingPrefixTable.CurrentCell = setColourShippingPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
            else if (c == 3)
            {
                if (value == "")
                {
                    setColourShippingPrefixTable.Rows[r].ErrorText = "Name cannot be empty";
                    MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setColourShippingPrefixTable.CurrentCell = setColourShippingPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
        }

        private void setFrameAssemblyPrefixTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            int r = e.RowIndex, c = e.ColumnIndex;
            string value = e.FormattedValue.ToString();
            if (setFrameAssemblyPrefixTable.Rows[r].IsNewRow) return;
            if (c == 1)
            {
                bool isAlphaBet = Regex.IsMatch(value, "[a-z]", RegexOptions.IgnoreCase);
                if (!isAlphaBet)
                {
                    setFrameAssemblyPrefixTable.Rows[r].ErrorText = "Prefix letter should be alphabet";
                    MessageBox.Show("Prefix letter should be alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setFrameAssemblyPrefixTable.CurrentCell = setFrameAssemblyPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
            else if (c == 3)
            {
                if (value == "")
                {
                    setFrameAssemblyPrefixTable.Rows[r].ErrorText = "Name cannot be empty";
                    MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setFrameAssemblyPrefixTable.CurrentCell = setFrameAssemblyPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
        }

        private void setFrameAssemblyPrefixTable_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            setFrameAssemblyPrefixTable.Rows[r].ErrorText = "";
            if (c == 1 && setFrameAssemblyPrefixTable.CurrentCell.Value != null)
            {
                setFrameAssemblyPrefixTable.CurrentCell.Value = setFrameAssemblyPrefixTable.CurrentCell.Value.ToString().ToUpper();
            }
        }

        private void setWindowsShippingPrefixTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            int r = e.RowIndex, c = e.ColumnIndex;
            string value = e.FormattedValue.ToString();
            if (setWindowsShippingPrefixTable.Rows[r].IsNewRow) return;
            if (c == 1)
            {
                bool isAlphaBet = Regex.IsMatch(value, "[a-z]", RegexOptions.IgnoreCase);
                if (!isAlphaBet)
                {
                    setWindowsShippingPrefixTable.Rows[r].ErrorText = "Prefix letter should be alphabet";
                    MessageBox.Show("Prefix letter should be alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setWindowsShippingPrefixTable.CurrentCell = setWindowsShippingPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
            else if (c == 3)
            {
                if (value == "")
                {
                    setWindowsShippingPrefixTable.Rows[r].ErrorText = "Name cannot be empty";
                    MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setWindowsShippingPrefixTable.CurrentCell = setWindowsShippingPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
        }

        private void setWindowsShippingPrefixTable_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            setWindowsShippingPrefixTable.Rows[r].ErrorText = "";
            if (c == 1 && setWindowsShippingPrefixTable.CurrentCell.Value != null)
            {
                setWindowsShippingPrefixTable.CurrentCell.Value = setWindowsShippingPrefixTable.CurrentCell.Value.ToString().ToUpper();
            }
        }

        private void setColourReceivingPrefixTable_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            setColourDeliveredPrefixTable.Rows[r].ErrorText = "";
            if (c == 1 && setColourDeliveredPrefixTable.CurrentCell.Value != null)
            {
                setColourDeliveredPrefixTable.CurrentCell.Value = setColourDeliveredPrefixTable.CurrentCell.Value.ToString().ToUpper();
            }
        }

        private void setColourReceivingPrefixTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            int r = e.RowIndex, c = e.ColumnIndex;
            string value = e.FormattedValue.ToString();
            if (setColourDeliveredPrefixTable.Rows[r].IsNewRow) return;
            if (c == 1)
            {
                bool isAlphaBet = Regex.IsMatch(value, "[a-z]", RegexOptions.IgnoreCase);
                if (!isAlphaBet)
                {
                    setColourDeliveredPrefixTable.Rows[r].ErrorText = "Prefix letter should be alphabet";
                    MessageBox.Show("Prefix letter should be alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setColourDeliveredPrefixTable.CurrentCell = setColourDeliveredPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
            else if (c == 3)
            {
                if (value == "")
                {
                    setColourDeliveredPrefixTable.Rows[r].ErrorText = "Name cannot be empty";
                    MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setColourDeliveredPrefixTable.CurrentCell = setColourDeliveredPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
        }

        private void setWindowsWrappingPrefixTable_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            setWindowsWrappingPrefixTable.Rows[r].ErrorText = "";
            if (c == 1 && setWindowsWrappingPrefixTable.CurrentCell.Value != null)
            {
                setWindowsWrappingPrefixTable.CurrentCell.Value = setWindowsWrappingPrefixTable.CurrentCell.Value.ToString().ToUpper();
            }
        }

        private void setWindowsWrappingPrefixTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            int r = e.RowIndex, c = e.ColumnIndex;
            string value = e.FormattedValue.ToString();
            if (setWindowsWrappingPrefixTable.Rows[r].IsNewRow) return;
            if (c == 1)
            {
                bool isAlphaBet = Regex.IsMatch(value, "[a-z]", RegexOptions.IgnoreCase);
                if (!isAlphaBet)
                {
                    setWindowsWrappingPrefixTable.Rows[r].ErrorText = "Prefix letter should be alphabet";
                    MessageBox.Show("Prefix letter should be alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setWindowsWrappingPrefixTable.CurrentCell = setWindowsWrappingPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
            else if (c == 3)
            {
                if (value == "")
                {
                    setWindowsWrappingPrefixTable.Rows[r].ErrorText = "Name cannot be empty";
                    MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setWindowsWrappingPrefixTable.CurrentCell = setWindowsWrappingPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
        }

        private void checkBoxHide_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWindowsAssemblyHide.Checked == true)
            {
                labelHideTime.Visible = true;
                textBoxWindowsAssemblyHideTime.Visible = true;
            }
            else
            {
                labelHideTime.Visible = false;
                textBoxWindowsAssemblyHideTime.Visible = false;
            }
        }

        private void NAcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            is_saved = false;
            setBtnSave.Enabled = true;
        }

        private void EmaildataGridView_CellValidating_1(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            string value = EmaildataGridView.Rows[e.RowIndex].Cells[1].EditedFormattedValue.ToString();
            if (EmaildataGridView.Rows[r].IsNewRow) return;
            if (c == 1)
            {
                if (!IsValidEmail(value))
                {
                    MessageBox.Show("Email is not in correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void TextDialog_Click(object sender, EventArgs e)
        {
            string note = "";
            NoteDialog noteDialog = new NoteDialog();
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == null || textBox.Text == "") note = noteDialog.InputBox();
            else note = noteDialog.InputBox(textBox.Text);
            if (note != null) textBox.Text = note;
        }

        private void TextboxDigitClick_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridViewEmail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            string value = dataGridViewTaskBoardEmail.Rows[e.RowIndex].Cells[1].EditedFormattedValue.ToString();
            if (dataGridViewTaskBoardEmail.Rows[r].IsNewRow) return;
            if (c == 1)
            {

                if (!IsValidEmail(value))
                {

                    MessageBox.Show("Email is not in correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    e.Cancel = true;
                }
            }
        }

        private void setPatioDoorReceivingPrefixTable_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            setPatioDoorReceivingPrefixTable.Rows[r].ErrorText = "";
            if (c == 1 && setPatioDoorReceivingPrefixTable.CurrentCell.Value != null)
            {
                setPatioDoorReceivingPrefixTable.CurrentCell.Value = setPatioDoorReceivingPrefixTable.CurrentCell.Value.ToString().ToUpper();
            }
        }

        private void setPatioDoorShippingPrefixTable_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            setPatioDoorShippingPrefixTable.Rows[r].ErrorText = "";
            if (c == 1 && setPatioDoorShippingPrefixTable.CurrentCell.Value != null)
            {
                setPatioDoorShippingPrefixTable.CurrentCell.Value = setPatioDoorShippingPrefixTable.CurrentCell.Value.ToString().ToUpper();
            }
        }

        private void setPatioDoorReceivingPrefixTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            string value = e.FormattedValue.ToString();
            if (setPatioDoorReceivingPrefixTable.Rows[r].IsNewRow) return;
            if (c == 1)
            {
                bool isAlphaBet = Regex.IsMatch(value, "[a-z]", RegexOptions.IgnoreCase);
                if (!isAlphaBet)
                {
                    setPatioDoorReceivingPrefixTable.Rows[r].ErrorText = "Prefix letter should be alphabet";
                    MessageBox.Show("Prefix letter should be alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setPatioDoorReceivingPrefixTable.CurrentCell = setPatioDoorReceivingPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
            else if (c == 3)
            {
                if (value == "")
                {
                    setPatioDoorReceivingPrefixTable.Rows[r].ErrorText = "Name cannot be empty";
                    MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setPatioDoorReceivingPrefixTable.CurrentCell = setPatioDoorReceivingPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
        }

        private void setPatioDoorShippingPrefixTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            string value = e.FormattedValue.ToString();
            if (setPatioDoorShippingPrefixTable.Rows[r].IsNewRow) return;
            if (c == 1)
            {
                bool isAlphaBet = Regex.IsMatch(value, "[a-z]", RegexOptions.IgnoreCase);
                if (!isAlphaBet)
                {
                    setPatioDoorShippingPrefixTable.Rows[r].ErrorText = "Prefix letter should be alphabet";
                    MessageBox.Show("Prefix letter should be alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setPatioDoorShippingPrefixTable.CurrentCell = setPatioDoorShippingPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
            else if (c == 3)
            {
                if (value == "")
                {
                    setPatioDoorShippingPrefixTable.Rows[r].ErrorText = "Name cannot be empty";
                    MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setPatioDoorShippingPrefixTable.CurrentCell = setPatioDoorShippingPrefixTable.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
        }

        private void textBoxHideTime_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Convert.ToInt32((sender as TextBox).Text) > 0) return;
            else MessageBox.Show("Time should be greater than 0 ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonGlassRecutBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxGlassRecutPath.Text = folderDlg.SelectedPath;
                Properties.Settings.Default.GlassRecutPath = textBoxGlassRecutPath.Text;
                Properties.Settings.Default.Save();
            }
        }
        
        // Booking
        // Booking window type
        private void BookingWindowTypesTables_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgView;
            if (sender.Equals(dataGridViewBookingCasement)) dgView = dataGridViewBookingCasement;
            else if (sender.Equals(dataGridViewBookingDUMMY)) dgView = dataGridViewBookingDUMMY;
            else if (sender.Equals(dataGridViewBookingFix)) dgView = dataGridViewBookingFix;
            else if (sender.Equals(dataGridViewBookingSDWIND)) dgView = dataGridViewBookingSDWIND;
            else if (sender.Equals(dataGridViewBookingShape)) dgView = dataGridViewBookingShape;
            else if (sender.Equals(dataGridViewBookingSlider)) dgView = dataGridViewBookingSlider;
            else if (sender.Equals(dataGridViewBookingSU)) dgView = dataGridViewBookingSU;
            else dgView = dataGridViewBookingSUSHP;

            int r = e.RowIndex, c = e.ColumnIndex;
            dgView.Rows[r].ErrorText = "";
            if (dgView.CurrentCell.Value != null)
            {
                dgView.CurrentCell.Value = dgView.CurrentCell.Value.ToString().ToUpper();
            }
        }

        private void BookingWindowTypesTables_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgView;
            if (sender.Equals(dataGridViewBookingCasement)) dgView = dataGridViewBookingCasement;
            else if (sender.Equals(dataGridViewBookingDUMMY)) dgView = dataGridViewBookingDUMMY;
            else if (sender.Equals(dataGridViewBookingFix)) dgView = dataGridViewBookingFix;
            else if (sender.Equals(dataGridViewBookingSDWIND)) dgView = dataGridViewBookingSDWIND;
            else if (sender.Equals(dataGridViewBookingShape)) dgView = dataGridViewBookingShape;
            else if (sender.Equals(dataGridViewBookingSlider)) dgView = dataGridViewBookingSlider;
            else if (sender.Equals(dataGridViewBookingSU)) dgView = dataGridViewBookingSU;
            else dgView = dataGridViewBookingSUSHP;

            int r = e.RowIndex, c = e.ColumnIndex;
            if (dgView.Rows[r].IsNewRow) return;
            if (e.FormattedValue.ToString() == "")
            {
                dgView.Rows[r].ErrorText = "Name cannot be empty";
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgView.CurrentCell = dgView.Rows[r].Cells[c];
                e.Cancel = true;
            }
        }

        private void BookingWindowTypesTables_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (sender.Equals(dataGridViewBookingCasement)) dataGridViewBookingCasement.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "CASEMENT";
            else if (sender.Equals(dataGridViewBookingDUMMY)) dataGridViewBookingDUMMY.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "DUMMY";
            else if (sender.Equals(dataGridViewBookingFix)) dataGridViewBookingFix.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "FIX";
            else if (sender.Equals(dataGridViewBookingSDWIND)) dataGridViewBookingSDWIND.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "SDWIND";
            else if (sender.Equals(dataGridViewBookingShape)) dataGridViewBookingShape.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "SHAPE";
            else if (sender.Equals(dataGridViewBookingSlider)) dataGridViewBookingSlider.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "SLIDER";
            else if (sender.Equals(dataGridViewBookingSU)) dataGridViewBookingSU.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "SU";
            else dataGridViewBookingSUSHP.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "SUSHP";
        }

        private void textBoxBookDueDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                //allows just number keys
                e.Handled = !char.IsNumber(e.KeyChar);
            }
        }

        private void MessageText_Click(object sender, EventArgs e)
        {
            string note = "";
            NoteDialog noteDialog = new NoteDialog();
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == null || textBox.Text == "") note = noteDialog.InputBox();
            else note = noteDialog.InputBox(textBox.Text);
            if (note != null) textBox.Text = note;
        }

        private void textBoxDateFilter_Click(object sender, EventArgs e)
        {
            SelectDateDialogBooking select_date = new SelectDateDialogBooking(textBoxDateFilter.Text);
            DateTime? date = select_date.InputBox("Select Booking Date Filter");
            if (date != null) textBoxDateFilter.Text = ((DateTime)date).Date.ToString("yyyy-MM-dd");
            else textBoxDateFilter.Text = "";
        }

        // Slider
        private void dataGridViewBookingSliderTypes_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgView;
            if (sender.Equals(dataGridViewBookingFrame)) dgView = dataGridViewBookingFrame;
            else dgView = dataGridViewBookingSash;

            int r = e.RowIndex, c = e.ColumnIndex;
            dgView.Rows[r].ErrorText = "";
            if (dgView.CurrentCell != null)
            {
                if (dgView.CurrentCell.Value != null)
                {
                    dgView.CurrentCell.Value = dgView.CurrentCell.Value.ToString().ToUpper();
                }
            }
        }

        private void dataGridViewBookingSliderTypes_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgView;
            if (sender.Equals(dataGridViewBookingFrame)) dgView = dataGridViewBookingFrame;
            else dgView = dataGridViewBookingSash;

            int r = e.RowIndex, c = e.ColumnIndex;
            if (dgView.Rows[r].IsNewRow) return;
            if (e.FormattedValue.ToString() == "")
            {
                dgView.Rows[r].ErrorText = "Name cannot be empty";
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgView.CurrentCell = dgView.Rows[r].Cells[c];
                e.Cancel = true;
            }
            if (c == 3)
            {
                int i;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                    e.Cancel = true;
            }
        }

        private void dataGridViewBookingSliderTypes_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (sender.Equals(dataGridViewBookingFrame)) dataGridViewBookingFrame.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "FRAME";
            else dataGridViewBookingSash.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "SASH";
        }

        private void ColourFramePrefixTable_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgView;
            if (sender.Equals(setVinylProFrameReceivingPrefixTable)) dgView = setVinylProFrameReceivingPrefixTable;
            else if (sender.Equals(setVinylProFrameShippingPrefixTable)) dgView = setVinylProFrameShippingPrefixTable;
            else if (sender.Equals(setDVCoatexColorReceivingPrefixTable)) dgView = setDVCoatexColorReceivingPrefixTable;
            else if (sender.Equals(setDVCotexColorShippingPrefixTable)) dgView = setDVCotexColorShippingPrefixTable;
            else if (sender.Equals(setExpressCoatingColorReceivingPrefixTable)) dgView = setExpressCoatingColorReceivingPrefixTable;
            else dgView = setExpressCoatingColourShippingPrefixTable;

            int r = e.RowIndex, c = e.ColumnIndex;
            dgView.Rows[r].ErrorText = "";
            if (c == 1 && dgView.CurrentCell.Value != null)
            {
                dgView.CurrentCell.Value = dgView.CurrentCell.Value.ToString().ToUpper();
            }
        }

        private void ColourFramePrefixTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgView;
            if (sender.Equals(setVinylProFrameReceivingPrefixTable)) dgView = setVinylProFrameReceivingPrefixTable;
            else if (sender.Equals(setVinylProFrameShippingPrefixTable)) dgView = setVinylProFrameShippingPrefixTable;
            else if (sender.Equals(setDVCoatexColorReceivingPrefixTable)) dgView = setDVCoatexColorReceivingPrefixTable;
            else if (sender.Equals(setDVCotexColorShippingPrefixTable)) dgView = setDVCotexColorShippingPrefixTable;
            else if (sender.Equals(setExpressCoatingColorReceivingPrefixTable)) dgView = setExpressCoatingColorReceivingPrefixTable;
            else dgView = setExpressCoatingColourShippingPrefixTable;

            int r = e.RowIndex, c = e.ColumnIndex;
            string value = e.FormattedValue.ToString();
            if (dgView.Rows[r].IsNewRow) return;
            if (c == 1)
            {
                bool isAlphaBet = Regex.IsMatch(value, "[a-z]", RegexOptions.IgnoreCase);
                if (!isAlphaBet)
                {
                    dgView.Rows[r].ErrorText = "Prefix letter should be alphabet";
                    MessageBox.Show("Prefix letter should be alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgView.CurrentCell = dgView.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
            else if (c == 3)
            {
                if (value == "")
                {
                    dgView.Rows[r].ErrorText = "Name cannot be empty";
                    MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgView.CurrentCell = dgView.Rows[r].Cells[c];
                    e.Cancel = true;
                }
            }
        }

        private void checkBoxWindowsWrappingHide_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWindowsWrappingHide.Checked == true)
            {
                textBoxWindowsWrappingHideTime.Visible = true;
            }
            else
            {
                textBoxWindowsWrappingHideTime.Visible = false;
            }
        }

        private void buttonFrameRecutBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxFrameRecutPath.Text = folderDlg.SelectedPath;
                Properties.Settings.Default.FrameRecutPath = textBoxFrameRecutPath.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void setFrameRecutFileNamingTable_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["FirstLetter"].Value = false;
            e.Row.Cells["UCS4590"].Value = false;
            e.Row.Cells["SCS4545"].Value = false;
        }

        private void EmaildataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            string value = EmaildataGridView.Rows[e.RowIndex].Cells[1].EditedFormattedValue.ToString();
            if (EmaildataGridView.Rows[r].IsNewRow) return;

            if (!IsValidEmail(value))
            {
                MessageBox.Show("Email is not in correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void buttonAddComapny_Click(object sender, EventArgs e)
        {
            AddPaintComapny addPaintComapnyForm = new AddPaintComapny("add");
            var colors = addPaintComapnyForm.CompanyColors();
            string compName = "";
            if (colors != null)
            {
                //   string value = colors.Values;
                foreach (var element in colors)
                {
                    compName = element.Key;
                    foreach (var valuePair in element.Value)
                    {
                        Settings.Paint_Companies_Table.Add(new string[] { element.Key, valuePair[0], valuePair[1] });
                        Settings.UsedColorsList.Add(new string[] { valuePair[0], valuePair[1] });
                    }
                }
                dataGridViewPaintCompanies.Rows.Add(compName);
                Settings.CompaniesList.Add(compName);
                Settings.NotUsedColorsList = Settings.NotUsedColorsList.Where(p => !Settings.UsedColorsList.Any(l => p.SequenceEqual(l))).ToList();
            }
        }
      
        private void dataGridViewPaintCompanies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewPaintCompanies.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                string company = dataGridViewPaintCompanies.Rows[e.RowIndex].Cells[0].Value.ToString();
                AddPaintComapny addPaintComapnyForm = new AddPaintComapny("edit", company);
                var colors = addPaintComapnyForm.CompanyColors();
                if (colors != null)
                {
                    Settings.Paint_Companies_Table.RemoveAll(x => x[0] == company);
                    foreach (var element in colors)
                    {
                        foreach (var valuePair in element.Value)
                        {
                            Settings.Paint_Companies_Table.Add(new string[] { element.Key, valuePair[0], valuePair[1] });
                        }
                    }
                }
            }
            else if (e.ColumnIndex == dataGridViewPaintCompanies.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                string company = dataGridViewPaintCompanies.Rows[e.RowIndex].Cells[0].Value.ToString();
                foreach (var element in Settings.Paint_Companies_Table.Where(x => x[0] == company))
                {
                    Settings.UsedColorsList.Remove(new string[] { element[1], element[2] });
                    Settings.NotUsedColorsList.Add(new string[] { element[1], element[2] });
                }
                dataGridViewPaintCompanies.Rows.RemoveAt(e.RowIndex);
                Settings.Paint_Companies_Table.RemoveAll(x => x[0] == company);
            }
        }

        private void dataGridViewProductionTypes_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (sender.Equals(dataGridViewProductionCasement)) dataGridViewProductionCasement.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "CASEMENT";
            else if (sender.Equals(dataGridViewProductionLFix)) dataGridViewProductionLFix.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "LARGE FIX";
            else if (sender.Equals(dataGridViewProductionSFix)) dataGridViewProductionSFix.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "SMALL FIX";
            else if (sender.Equals(dataGridViewProductionDH)) dataGridViewProductionDH.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "DH Frame";
            else if (sender.Equals(dataGridViewProductionSH)) dataGridViewProductionSH.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "SH Frame";
            else if (sender.Equals(dataGridViewProductionSSash1)) dataGridViewProductionSSash1.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "Small Sash 1";
            else if (sender.Equals(dataGridViewProductionSSash2)) dataGridViewProductionSSash2.Rows[e.RowIndex].Cells[(int)TYPES.TYPE].Value = "Small Sash 2";
        }

        private void dataGridViewSlotSize_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2) // 1 should be your column index
            {
                if (!int.TryParse(Convert.ToString(e.FormattedValue), out int i))
                {
                    e.Cancel = true;
                }
            }
        }

        private void buttonProductionCutBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxProductionCutPath.Text = folderDlg.SelectedPath;
                Properties.Settings.Default.ProductionCutPath = textBoxProductionCutPath.Text;
                Properties.Settings.Default.Save();
            }
        }

        //Text Notification
        private void textBoxNotificationMessage_Enter(object sender, EventArgs e)
        {
            if (sender.Equals(textBoxNotificationUpperMessage)
                && textBoxNotificationUpperMessage.Text == "Enter upper message...")
            {
                textBoxNotificationUpperMessage.Text = "";
            }
            else if (sender.Equals(textBoxNotificationDownMessage)
                && textBoxNotificationDownMessage.Text == "Enter down message...")
            {
                textBoxNotificationDownMessage.Text = "";
            }
        }

        private void textBoxNotificationMessage_Leave(object sender, EventArgs e)
        {
            if (sender.Equals(textBoxNotificationUpperMessage)
                && string.IsNullOrWhiteSpace(textBoxNotificationUpperMessage.Text))
            {
                textBoxNotificationUpperMessage.Text = "Enter upper message...";
            }
            else if (sender.Equals(textBoxNotificationDownMessage)
                && string.IsNullOrWhiteSpace(textBoxNotificationDownMessage.Text))
            {
                textBoxNotificationDownMessage.Text = "Enter down message...";
            }
        }

        //Shipping Report
        private void dataGridViewShippingReport_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int r = e.RowIndex, c = e.ColumnIndex;
            string value = dataGridViewShippingReport.Rows[e.RowIndex].Cells[1].EditedFormattedValue.ToString();
            if (dataGridViewShippingReport.Rows[r].IsNewRow) return;
            if (c == 1 && value != "" && !IsValidEmail(value))
            {
                MessageBox.Show("Email is not in correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
