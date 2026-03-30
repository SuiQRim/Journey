namespace Journey.Applications.JourneyWinforms.Forms
{
    partial class AddTourForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            LocationTextBox = new TextBox();
            NightCountNUpDown = new NumericUpDown();
            CostPerVacationerNUpDown = new NumericUpDown();
            VacotionerCountNUpDown = new NumericUpDown();
            SurchargeNUpDown = new NumericUpDown();
            AcceptButton = new Button();
            LocationLabel = new Label();
            CostPerVacationerLabel = new Label();
            DepartureDateTimePicker = new DateTimePicker();
            VacotionerCountLabel = new Label();
            WiFiAvailableCheckBox = new CheckBox();
            FormNameLabel = new Label();
            NightCountLabel = new Label();
            DepartureDateLabel = new Label();
            SurchargeLabel = new Label();
            TourErrorProvider = new ErrorProvider(components);
            ErrorsLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)NightCountNUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CostPerVacationerNUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)VacotionerCountNUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SurchargeNUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TourErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // LocationTextBox
            // 
            LocationTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LocationTextBox.Location = new Point(145, 81);
            LocationTextBox.MaxLength = 100;
            LocationTextBox.Name = "LocationTextBox";
            LocationTextBox.Size = new Size(209, 23);
            LocationTextBox.TabIndex = 0;
            // 
            // NightCountNUpDown
            // 
            NightCountNUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NightCountNUpDown.Location = new Point(234, 139);
            NightCountNUpDown.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            NightCountNUpDown.Name = "NightCountNUpDown";
            NightCountNUpDown.Size = new Size(120, 23);
            NightCountNUpDown.TabIndex = 1;
            // 
            // CostPerVacationerNUpDown
            // 
            CostPerVacationerNUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CostPerVacationerNUpDown.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            CostPerVacationerNUpDown.Location = new Point(234, 168);
            CostPerVacationerNUpDown.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            CostPerVacationerNUpDown.Name = "CostPerVacationerNUpDown";
            CostPerVacationerNUpDown.Size = new Size(120, 23);
            CostPerVacationerNUpDown.TabIndex = 3;
            // 
            // VacotionerCountNUpDown
            // 
            VacotionerCountNUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            VacotionerCountNUpDown.Location = new Point(234, 197);
            VacotionerCountNUpDown.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            VacotionerCountNUpDown.Name = "VacotionerCountNUpDown";
            VacotionerCountNUpDown.Size = new Size(120, 23);
            VacotionerCountNUpDown.TabIndex = 4;
            // 
            // SurchargeNUpDown
            // 
            SurchargeNUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SurchargeNUpDown.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            SurchargeNUpDown.Location = new Point(234, 226);
            SurchargeNUpDown.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            SurchargeNUpDown.Name = "SurchargeNUpDown";
            SurchargeNUpDown.Size = new Size(120, 23);
            SurchargeNUpDown.TabIndex = 6;
            // 
            // AcceptButton
            // 
            AcceptButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AcceptButton.Location = new Point(163, 311);
            AcceptButton.Name = "AcceptButton";
            AcceptButton.Size = new Size(112, 31);
            AcceptButton.TabIndex = 7;
            AcceptButton.Text = "Добавить";
            AcceptButton.UseVisualStyleBackColor = true;
            AcceptButton.Click += AcceptButton_Click;
            // 
            // LocationLabel
            // 
            LocationLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LocationLabel.AutoSize = true;
            LocationLabel.Location = new Point(85, 84);
            LocationLabel.Name = "LocationLabel";
            LocationLabel.Size = new Size(54, 15);
            LocationLabel.TabIndex = 8;
            LocationLabel.Text = "Локация";
            LocationLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // CostPerVacationerLabel
            // 
            CostPerVacationerLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CostPerVacationerLabel.AutoSize = true;
            CostPerVacationerLabel.Location = new Point(66, 170);
            CostPerVacationerLabel.Name = "CostPerVacationerLabel";
            CostPerVacationerLabel.Size = new Size(162, 15);
            CostPerVacationerLabel.TabIndex = 9;
            CostPerVacationerLabel.Text = "Стоимость за отдыхающего";
            CostPerVacationerLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // DepartureDateTimePicker
            // 
            DepartureDateTimePicker.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DepartureDateTimePicker.Location = new Point(213, 110);
            DepartureDateTimePicker.Name = "DepartureDateTimePicker";
            DepartureDateTimePicker.Size = new Size(141, 23);
            DepartureDateTimePicker.TabIndex = 2;
            // 
            // VacotionerCountLabel
            // 
            VacotionerCountLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            VacotionerCountLabel.AutoSize = true;
            VacotionerCountLabel.Location = new Point(106, 199);
            VacotionerCountLabel.Name = "VacotionerCountLabel";
            VacotionerCountLabel.Size = new Size(122, 15);
            VacotionerCountLabel.TabIndex = 10;
            VacotionerCountLabel.Text = "Кол-во отдыхающих";
            VacotionerCountLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // WiFiAvailableCheckBox
            // 
            WiFiAvailableCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            WiFiAvailableCheckBox.AutoSize = true;
            WiFiAvailableCheckBox.Location = new Point(248, 255);
            WiFiAvailableCheckBox.Name = "WiFiAvailableCheckBox";
            WiFiAvailableCheckBox.Size = new Size(106, 19);
            WiFiAvailableCheckBox.TabIndex = 5;
            WiFiAvailableCheckBox.Text = "Наличие Wi-Fi";
            WiFiAvailableCheckBox.UseVisualStyleBackColor = true;
            // 
            // FormNameLabel
            // 
            FormNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FormNameLabel.AutoSize = true;
            FormNameLabel.Font = new Font("Segoe UI", 14F);
            FormNameLabel.Location = new Point(107, 27);
            FormNameLabel.Name = "FormNameLabel";
            FormNameLabel.Size = new Size(228, 25);
            FormNameLabel.TabIndex = 11;
            FormNameLabel.Text = "Добавление нового тура";
            // 
            // NightCountLabel
            // 
            NightCountLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NightCountLabel.AutoSize = true;
            NightCountLabel.Location = new Point(145, 141);
            NightCountLabel.Name = "NightCountLabel";
            NightCountLabel.Size = new Size(83, 15);
            NightCountLabel.TabIndex = 12;
            NightCountLabel.Text = "Кол-во ночей";
            NightCountLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // DepartureDateLabel
            // 
            DepartureDateLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DepartureDateLabel.AutoSize = true;
            DepartureDateLabel.Location = new Point(133, 116);
            DepartureDateLabel.Name = "DepartureDateLabel";
            DepartureDateLabel.Size = new Size(74, 15);
            DepartureDateLabel.TabIndex = 13;
            DepartureDateLabel.Text = "Дата вылета";
            DepartureDateLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // SurchargeLabel
            // 
            SurchargeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SurchargeLabel.AutoSize = true;
            SurchargeLabel.Location = new Point(175, 228);
            SurchargeLabel.Name = "SurchargeLabel";
            SurchargeLabel.Size = new Size(53, 15);
            SurchargeLabel.TabIndex = 14;
            SurchargeLabel.Text = "Доплата";
            SurchargeLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // TourErrorProvider
            // 
            TourErrorProvider.ContainerControl = this;
            // 
            // ErrorsLabel
            // 
            ErrorsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ErrorsLabel.Font = new Font("Segoe UI", 8F);
            ErrorsLabel.ForeColor = Color.Red;
            ErrorsLabel.Location = new Point(85, 277);
            ErrorsLabel.Name = "ErrorsLabel";
            ErrorsLabel.Size = new Size(269, 31);
            ErrorsLabel.TabIndex = 15;
            ErrorsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddTourForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 354);
            Controls.Add(ErrorsLabel);
            Controls.Add(SurchargeLabel);
            Controls.Add(DepartureDateLabel);
            Controls.Add(NightCountLabel);
            Controls.Add(FormNameLabel);
            Controls.Add(VacotionerCountLabel);
            Controls.Add(CostPerVacationerLabel);
            Controls.Add(LocationLabel);
            Controls.Add(AcceptButton);
            Controls.Add(SurchargeNUpDown);
            Controls.Add(WiFiAvailableCheckBox);
            Controls.Add(VacotionerCountNUpDown);
            Controls.Add(CostPerVacationerNUpDown);
            Controls.Add(DepartureDateTimePicker);
            Controls.Add(NightCountNUpDown);
            Controls.Add(LocationTextBox);
            Name = "AddTourForm";
            Text = "AddTourForm";
            ((System.ComponentModel.ISupportInitialize)NightCountNUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)CostPerVacationerNUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)VacotionerCountNUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)SurchargeNUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)TourErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LocationTextBox;
        private NumericUpDown NightCountNUpDown;
        private NumericUpDown CostPerVacationerNUpDown;
        private NumericUpDown VacotionerCountNUpDown;
        private NumericUpDown SurchargeNUpDown;
        private Button AcceptButton;
        private Label LocationLabel;
        private Label CostPerVacationerLabel;
        private DateTimePicker DepartureDateTimePicker;
        private Label VacotionerCountLabel;
        private CheckBox WiFiAvailableCheckBox;
        private Label FormNameLabel;
        private Label NightCountLabel;
        private Label DepartureDateLabel;
        private Label SurchargeLabel;
        private ErrorProvider TourErrorProvider;
        private Label ErrorsLabel;
    }
}
