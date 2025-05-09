namespace BallDetectionClient
{
    partial class CameraForm
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
            CameraNamesComboBox = new ComboBox();
            button1 = new Button();
            groupBox1 = new GroupBox();
            OpenButton = new Button();
            groupBox2 = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // CameraNamesComboBox
            // 
            CameraNamesComboBox.FormattingEnabled = true;
            CameraNamesComboBox.Location = new Point(6, 13);
            CameraNamesComboBox.Name = "CameraNamesComboBox";
            CameraNamesComboBox.Size = new Size(518, 23);
            CameraNamesComboBox.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(6, 36);
            button1.Name = "button1";
            button1.Size = new Size(73, 23);
            button1.TabIndex = 1;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(OpenButton);
            groupBox1.Controls.Add(CameraNamesComboBox);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(609, 65);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Camera List";
            // 
            // OpenButton
            // 
            OpenButton.Location = new Point(451, 36);
            OpenButton.Name = "OpenButton";
            OpenButton.Size = new Size(73, 23);
            OpenButton.TabIndex = 2;
            OpenButton.Text = "Open";
            OpenButton.UseVisualStyleBackColor = true;
            OpenButton.Click += OpenButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(flowLayoutPanel1);
            groupBox2.Location = new Point(12, 83);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(609, 296);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Camera Settings";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(6, 22);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(597, 268);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // CameraForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 391);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "CameraForm";
            Text = "CameraForm";
            Load += CameraForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox CameraNamesComboBox;
        private Button button1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button OpenButton;
    }
}