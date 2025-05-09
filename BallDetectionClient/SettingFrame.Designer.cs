namespace BallDetectionClient
{
    partial class SettingFrame
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblSettingName = new Label();
            tbValue = new TrackBar();
            lblValue = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)tbValue).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblSettingName
            // 
            lblSettingName.AutoSize = true;
            lblSettingName.Location = new Point(3, 0);
            lblSettingName.Name = "lblSettingName";
            lblSettingName.Size = new Size(39, 15);
            lblSettingName.TabIndex = 0;
            lblSettingName.Text = "Name";
            // 
            // tbValue
            // 
            tableLayoutPanel1.SetColumnSpan(tbValue, 2);
            tbValue.Location = new Point(3, 18);
            tbValue.Name = "tbValue";
            tbValue.Size = new Size(492, 45);
            tbValue.TabIndex = 1;
            tbValue.TickStyle = TickStyle.TopLeft;
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Location = new Point(48, 0);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(13, 15);
            lblValue.TabIndex = 2;
            lblValue.Text = "0";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblSettingName, 0, 0);
            tableLayoutPanel1.Controls.Add(tbValue, 0, 1);
            tableLayoutPanel1.Controls.Add(lblValue, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(498, 65);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // SettingFrame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "SettingFrame";
            Size = new Size(498, 65);
            ((System.ComponentModel.ISupportInitialize)tbValue).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblSettingName;
        private TrackBar tbValue;
        private Label lblValue;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
