namespace Tours
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
            dataGridView1 = new DataGridView();
            TourLocation = new DataGridViewTextBoxColumn();
            DepartureDate = new DataGridViewTextBoxColumn();
            NightsNumber = new DataGridViewTextBoxColumn();
            CostPerVacationer = new DataGridViewTextBoxColumn();
            VacotionerCount = new DataGridViewTextBoxColumn();
            WiFiAvailable = new DataGridViewTextBoxColumn();
            Surcharge = new DataGridViewTextBoxColumn();
            TotalPrice = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { TourLocation, DepartureDate, NightsNumber, CostPerVacationer, VacotionerCount, WiFiAvailable, Surcharge, TotalPrice });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1091, 567);
            dataGridView1.TabIndex = 0;
            // 
            // TourLocation
            // 
            TourLocation.HeaderText = "Локация";
            TourLocation.Name = "TourLocation";
            // 
            // DepartureDate
            // 
            DepartureDate.HeaderText = "Дата вылета";
            DepartureDate.Name = "DepartureDate";
            // 
            // NightsNumber
            // 
            NightsNumber.HeaderText = "Кол-во ночей";
            NightsNumber.Name = "NightsNumber";
            // 
            // CostPerVacationer
            // 
            CostPerVacationer.HeaderText = "Стоимость за отдыхающего (руб)";
            CostPerVacationer.Name = "CostPerVacationer";
            // 
            // VacotionerCount
            // 
            VacotionerCount.HeaderText = "Количество отдыхающих";
            VacotionerCount.Name = "VacotionerCount";
            // 
            // WiFiAvailable
            // 
            WiFiAvailable.HeaderText = "Наличие Wi-Fi";
            WiFiAvailable.Name = "WiFiAvailable";
            // 
            // Surcharge
            // 
            Surcharge.HeaderText = "Доплаты (руб)";
            Surcharge.Name = "Surcharge";
            // 
            // TotalPrice
            // 
            TotalPrice.HeaderText = "Общая стоимость";
            TotalPrice.Name = "TotalPrice";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1115, 591);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn TourLocation;
        private DataGridViewTextBoxColumn DepartureDate;
        private DataGridViewTextBoxColumn NightsNumber;
        private DataGridViewTextBoxColumn CostPerVacationer;
        private DataGridViewTextBoxColumn VacotionerCount;
        private DataGridViewTextBoxColumn WiFiAvailable;
        private DataGridViewTextBoxColumn Surcharge;
        private DataGridViewTextBoxColumn TotalPrice;
    }
}
