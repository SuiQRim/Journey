using Journey.Winforms.Properties;

namespace Journey.Applications.JourneyWinforms.Forms
{
    partial class TourForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var dataGridViewCellStyle3 = new DataGridViewCellStyle();
            ToursDataViewGrid = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            TourLocation = new DataGridViewTextBoxColumn();
            DepartureDate = new DataGridViewTextBoxColumn();
            VacotionerCount = new DataGridViewTextBoxColumn();
            WiFiAvailable = new DataGridViewTextBoxColumn();
            NightsNumber = new DataGridViewTextBoxColumn();
            CostPerVacationer = new DataGridViewTextBoxColumn();
            Surcharge = new DataGridViewTextBoxColumn();
            PricePerNight = new DataGridViewTextBoxColumn();
            TotalPrice = new DataGridViewTextBoxColumn();
            ToursMenu = new ToolStrip();
            AddTourButton = new ToolStripButton();
            EditStripButton = new ToolStripButton();
            ToursStarusStrip = new StatusStrip();
            AvgVacationersLabel = new ToolStripStatusLabel();
            WifiPercentLabel = new ToolStripStatusLabel();
            SurchargePercentLabel = new ToolStripStatusLabel();
            TotalToursLabel = new ToolStripStatusLabel();
            MaxPriceLabel = new ToolStripStatusLabel();
            AvgNightsLabel = new ToolStripStatusLabel();
            SurchargeShareLabel = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)ToursDataViewGrid).BeginInit();
            ToursMenu.SuspendLayout();
            ToursStarusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // ToursDataViewGrid
            // 
            ToursDataViewGrid.AllowUserToAddRows = false;
            ToursDataViewGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ToursDataViewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ToursDataViewGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ToursDataViewGrid.Columns.AddRange(new DataGridViewColumn[] { Id, TourLocation, DepartureDate, VacotionerCount, WiFiAvailable, NightsNumber, CostPerVacationer, Surcharge, PricePerNight, TotalPrice });
            ToursDataViewGrid.Location = new Point(0, 28);
            ToursDataViewGrid.Name = "ToursDataViewGrid";
            ToursDataViewGrid.ReadOnly = true;
            ToursDataViewGrid.Size = new Size(1115, 563);
            ToursDataViewGrid.TabIndex = 0;
            ToursDataViewGrid.CellFormatting += dataGridView1_CellFormatting;
            ToursDataViewGrid.CellPainting += ToursDataViewGrid_CellPainting;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // TourLocation
            // 
            TourLocation.DataPropertyName = "Location";
            TourLocation.HeaderText = "Локация";
            TourLocation.Name = "TourLocation";
            TourLocation.ReadOnly = true;
            // 
            // DepartureDate
            // 
            DepartureDate.DataPropertyName = "DepartureDate";
            DepartureDate.HeaderText = "Дата вылета";
            DepartureDate.Name = "DepartureDate";
            DepartureDate.ReadOnly = true;
            // 
            // VacotionerCount
            // 
            VacotionerCount.DataPropertyName = "VacotionerCount";
            VacotionerCount.HeaderText = "Количество отдыхающих";
            VacotionerCount.Name = "VacotionerCount";
            VacotionerCount.ReadOnly = true;
            // 
            // WiFiAvailable
            // 
            WiFiAvailable.DataPropertyName = "WiFiAvailabble";
            WiFiAvailable.HeaderText = "Наличие Wi-Fi";
            WiFiAvailable.Name = "WiFiAvailable";
            WiFiAvailable.ReadOnly = true;
            // 
            // NightsNumber
            // 
            NightsNumber.DataPropertyName = "NightCount";
            NightsNumber.HeaderText = "Кол-во ночей";
            NightsNumber.Name = "NightsNumber";
            NightsNumber.ReadOnly = true;
            // 
            // CostPerVacationer
            // 
            CostPerVacationer.DataPropertyName = "CostPerVacationer";
            CostPerVacationer.HeaderText = "Стоимость за отдыхающего (руб)";
            CostPerVacationer.Name = "CostPerVacationer";
            CostPerVacationer.ReadOnly = true;
            // 
            // Surcharge
            // 
            Surcharge.DataPropertyName = "Surcharge";
            Surcharge.HeaderText = "Доплаты (руб)";
            Surcharge.Name = "Surcharge";
            Surcharge.ReadOnly = true;
            // 
            // PricePerNight
            // 
            PricePerNight.DataPropertyName = "PricePerNight";
            PricePerNight.HeaderText = "Цена за ночь";
            PricePerNight.Name = "PricePerNight";
            PricePerNight.ReadOnly = true;
            // 
            // TotalPrice
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            TotalPrice.DefaultCellStyle = dataGridViewCellStyle3;
            TotalPrice.HeaderText = "Общая стоимость";
            TotalPrice.Name = "TotalPrice";
            TotalPrice.ReadOnly = true;
            // 
            // ToursMenu
            // 
            ToursMenu.Items.AddRange(new ToolStripItem[] { AddTourButton, EditStripButton });
            ToursMenu.Location = new Point(0, 0);
            ToursMenu.Name = "ToursMenu";
            ToursMenu.Size = new Size(1115, 25);
            ToursMenu.TabIndex = 1;
            ToursMenu.Text = "toolStrip1";
            // 
            // AddTourButton
            // 
            AddTourButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            AddTourButton.Image = Resources.AddPic;
            AddTourButton.ImageTransparentColor = Color.Magenta;
            AddTourButton.Name = "AddTourButton";
            AddTourButton.Size = new Size(23, 22);
            AddTourButton.Text = "AddTour";
            AddTourButton.Click += AddTourButton_Click;
            // 
            // EditStripButton
            // 
            EditStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            EditStripButton.Image = Resources.EditPic;
            EditStripButton.ImageTransparentColor = Color.Magenta;
            EditStripButton.Name = "EditStripButton";
            EditStripButton.Size = new Size(23, 22);
            EditStripButton.Text = "EditStripButton";
            EditStripButton.Click += EditTourButton_Click;
            // 
            // ToursStarusStrip
            // 
            ToursStarusStrip.Items.AddRange(new ToolStripItem[] { AvgVacationersLabel, WifiPercentLabel, SurchargePercentLabel, TotalToursLabel, MaxPriceLabel, AvgNightsLabel, SurchargeShareLabel });
            ToursStarusStrip.Location = new Point(0, 569);
            ToursStarusStrip.Name = "ToursStarusStrip";
            ToursStarusStrip.Size = new Size(1115, 22);
            ToursStarusStrip.TabIndex = 2;
            ToursStarusStrip.Text = "statusStrip1";
            // 
            // AvgVacationersLabel
            // 
            AvgVacationersLabel.Name = "AvgVacationersLabel";
            AvgVacationersLabel.Size = new Size(116, 17);
            AvgVacationersLabel.Text = "AvgVacationersLabel";
            // 
            // WifiPercentLabel
            // 
            WifiPercentLabel.Name = "WifiPercentLabel";
            WifiPercentLabel.Size = new Size(96, 17);
            WifiPercentLabel.Text = "WifiPercentLabel";
            // 
            // SurchargePercentLabel
            // 
            SurchargePercentLabel.Name = "SurchargePercentLabel";
            SurchargePercentLabel.Size = new Size(128, 17);
            SurchargePercentLabel.Text = "SurchargePercentLabel";
            // 
            // TotalToursLabel
            // 
            TotalToursLabel.Name = "TotalToursLabel";
            TotalToursLabel.Size = new Size(88, 17);
            TotalToursLabel.Text = "TotalToursLabel";
            // 
            // MaxPriceLabel
            // 
            MaxPriceLabel.Name = "MaxPriceLabel";
            MaxPriceLabel.Size = new Size(84, 17);
            MaxPriceLabel.Text = "MaxPriceLabel";
            // 
            // AvgNightsLabel
            // 
            AvgNightsLabel.Name = "AvgNightsLabel";
            AvgNightsLabel.Size = new Size(91, 17);
            AvgNightsLabel.Text = "AvgNightsLabel";
            // 
            // SurchargeShareLabel
            // 
            SurchargeShareLabel.Name = "SurchargeShareLabel";
            SurchargeShareLabel.Size = new Size(117, 17);
            SurchargeShareLabel.Text = "SurchargeShareLabel";
            // 
            // TourForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1115, 591);
            Controls.Add(ToursStarusStrip);
            Controls.Add(ToursMenu);
            Controls.Add(ToursDataViewGrid);
            Name = "TourForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)ToursDataViewGrid).EndInit();
            ToursMenu.ResumeLayout(false);
            ToursMenu.PerformLayout();
            ToursStarusStrip.ResumeLayout(false);
            ToursStarusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ToursDataViewGrid;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn TourLocation;
        private DataGridViewTextBoxColumn DepartureDate;
        private DataGridViewTextBoxColumn VacotionerCount;
        private DataGridViewTextBoxColumn WiFiAvailable;
        private DataGridViewTextBoxColumn NightsNumber;
        private DataGridViewTextBoxColumn CostPerVacationer;
        private DataGridViewTextBoxColumn Surcharge;
        private DataGridViewTextBoxColumn PricePerNight;
        private DataGridViewTextBoxColumn TotalPrice;
        private ToolStrip ToursMenu;
        private ToolStripButton AddTourButton;
        private ToolStripButton EditStripButton;
        private StatusStrip ToursStarusStrip;
        private ToolStripStatusLabel AvgVacationersLabel;
        private ToolStripStatusLabel WifiPercentLabel;
        private ToolStripStatusLabel SurchargePercentLabel;
        private ToolStripStatusLabel TotalToursLabel;
        private ToolStripStatusLabel MaxPriceLabel;
        private ToolStripStatusLabel AvgNightsLabel;
        private ToolStripStatusLabel SurchargeShareLabel;
    }
}
