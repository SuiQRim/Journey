namespace Journey.Applications.ToursWinforms
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
            var dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            ((System.ComponentModel.ISupportInitialize)ToursDataViewGrid).BeginInit();
            SuspendLayout();
            // 
            // ToursDataViewGrid
            // 
            ToursDataViewGrid.AllowUserToAddRows = false;
            ToursDataViewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ToursDataViewGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ToursDataViewGrid.Columns.AddRange(new DataGridViewColumn[] { Id, TourLocation, DepartureDate, VacotionerCount, WiFiAvailable, NightsNumber, CostPerVacationer, Surcharge, PricePerNight, TotalPrice });
            ToursDataViewGrid.Dock = DockStyle.Fill;
            ToursDataViewGrid.Location = new Point(0, 0);
            ToursDataViewGrid.Name = "ToursDataViewGrid";
            ToursDataViewGrid.Size = new Size(1115, 591);
            ToursDataViewGrid.TabIndex = 0;
            ToursDataViewGrid.CellFormatting += dataGridView1_CellFormatting;
            ToursDataViewGrid.CellPainting += ToursDataViewGrid_CellPainting;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            // 
            // TourLocation
            // 
            TourLocation.DataPropertyName = "Location";
            TourLocation.HeaderText = "Локация";
            TourLocation.Name = "TourLocation";
            // 
            // DepartureDate
            // 
            DepartureDate.DataPropertyName = "DepartureDate";
            DepartureDate.HeaderText = "Дата вылета";
            DepartureDate.Name = "DepartureDate";
            // 
            // VacotionerCount
            // 
            VacotionerCount.DataPropertyName = "VacotionerCount";
            VacotionerCount.HeaderText = "Количество отдыхающих";
            VacotionerCount.Name = "VacotionerCount";
            // 
            // WiFiAvailable
            // 
            WiFiAvailable.DataPropertyName = "WiFiAvailabble";
            WiFiAvailable.HeaderText = "Наличие Wi-Fi";
            WiFiAvailable.Name = "WiFiAvailable";
            // 
            // NightsNumber
            // 
            NightsNumber.DataPropertyName = "NightCount";
            NightsNumber.HeaderText = "Кол-во ночей";
            NightsNumber.Name = "NightsNumber";
            // 
            // CostPerVacationer
            // 
            CostPerVacationer.DataPropertyName = "CostPerVacationer";
            CostPerVacationer.HeaderText = "Стоимость за отдыхающего (руб)";
            CostPerVacationer.Name = "CostPerVacationer";
            // 
            // Surcharge
            // 
            Surcharge.DataPropertyName = "Surcharge";
            Surcharge.HeaderText = "Доплаты (руб)";
            Surcharge.Name = "Surcharge";
            // 
            // PricePerNight
            // 
            PricePerNight.DataPropertyName = "PricePerNight";
            PricePerNight.HeaderText = "Цена за ночь";
            PricePerNight.Name = "PricePerNight";
            // 
            // TotalPrice
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            TotalPrice.DefaultCellStyle = dataGridViewCellStyle1;
            TotalPrice.HeaderText = "Общая стоимость";
            TotalPrice.Name = "TotalPrice";
            // 
            // TourForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1115, 591);
            Controls.Add(ToursDataViewGrid);
            Name = "TourForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)ToursDataViewGrid).EndInit();
            ResumeLayout(false);
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
    }
}
