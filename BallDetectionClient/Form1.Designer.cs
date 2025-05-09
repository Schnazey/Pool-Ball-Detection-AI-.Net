namespace BallDetectionClient
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            MainMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openCameraToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            cameraToolStripMenuItem = new ToolStripMenuItem();
            InspectFrameButton = new Button();
            richTextBox1 = new RichTextBox();
            chkShowImage = new CheckBox();
            FpsTimer = new System.Windows.Forms.Timer(components);
            lblFps = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            MainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 56);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(583, 382);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // MainMenu
            // 
            MainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, settingsToolStripMenuItem });
            MainMenu.Location = new Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Size = new Size(878, 24);
            MainMenu.TabIndex = 1;
            MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openCameraToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openCameraToolStripMenuItem
            // 
            openCameraToolStripMenuItem.Name = "openCameraToolStripMenuItem";
            openCameraToolStripMenuItem.Size = new Size(147, 22);
            openCameraToolStripMenuItem.Text = "&Open Camera";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cameraToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "&Settings";
            // 
            // cameraToolStripMenuItem
            // 
            cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            cameraToolStripMenuItem.Size = new Size(115, 22);
            cameraToolStripMenuItem.Text = "&Camera";
            cameraToolStripMenuItem.Click += cameraToolStripMenuItem_Click;
            // 
            // InspectFrameButton
            // 
            InspectFrameButton.Location = new Point(480, 27);
            InspectFrameButton.Name = "InspectFrameButton";
            InspectFrameButton.Size = new Size(115, 23);
            InspectFrameButton.TabIndex = 2;
            InspectFrameButton.Text = "Inspect Frame";
            InspectFrameButton.UseVisualStyleBackColor = true;
            InspectFrameButton.Click += InspectFrameButton_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(601, 56);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(265, 382);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // chkShowImage
            // 
            chkShowImage.AutoSize = true;
            chkShowImage.Location = new Point(653, 34);
            chkShowImage.Name = "chkShowImage";
            chkShowImage.Size = new Size(91, 19);
            chkShowImage.TabIndex = 4;
            chkShowImage.Text = "Show Image";
            chkShowImage.UseVisualStyleBackColor = true;
            chkShowImage.CheckedChanged += chkShowImage_CheckedChanged;
            // 
            // FpsTimer
            // 
            FpsTimer.Enabled = true;
            FpsTimer.Interval = 1000;
            FpsTimer.Tick += FpsTimer_Tick;
            // 
            // lblFps
            // 
            lblFps.AutoSize = true;
            lblFps.Location = new Point(601, 35);
            lblFps.Name = "lblFps";
            lblFps.Size = new Size(46, 15);
            lblFps.TabIndex = 5;
            lblFps.Text = "FPS = 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 447);
            Controls.Add(lblFps);
            Controls.Add(chkShowImage);
            Controls.Add(richTextBox1);
            Controls.Add(InspectFrameButton);
            Controls.Add(pictureBox1);
            Controls.Add(MainMenu);
            MainMenuStrip = MainMenu;
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private MenuStrip MainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openCameraToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem cameraToolStripMenuItem;
        private Button InspectFrameButton;
        private RichTextBox richTextBox1;
        private CheckBox chkShowImage;
        private System.Windows.Forms.Timer FpsTimer;
        private Label lblFps;
    }
}
