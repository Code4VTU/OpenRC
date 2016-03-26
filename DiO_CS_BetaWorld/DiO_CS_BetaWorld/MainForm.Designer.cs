namespace DiO_CS_BetaWorld
{
    partial class MainForm
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
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.mItCaptureeDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.mItSerialPort = new System.Windows.Forms.ToolStripMenuItem();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSide = new System.Windows.Forms.TableLayoutPanel();
            this.dgvGlyphData = new System.Windows.Forms.DataGridView();
            this.pnlManualControl = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblIsConnected = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.trbSpeed = new System.Windows.Forms.TrackBar();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.lblRobotMessage = new System.Windows.Forms.Label();
            this.msMain.SuspendLayout();
            this.tblMain.SuspendLayout();
            this.tlpSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlyphData)).BeginInit();
            this.pnlManualControl.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItCaptureeDevice,
            this.mItSerialPort});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(844, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // mItCaptureeDevice
            // 
            this.mItCaptureeDevice.Name = "mItCaptureeDevice";
            this.mItCaptureeDevice.Size = new System.Drawing.Size(104, 20);
            this.mItCaptureeDevice.Text = "Capture Devices";
            // 
            // mItSerialPort
            // 
            this.mItSerialPort.Name = "mItSerialPort";
            this.mItSerialPort.Size = new System.Drawing.Size(72, 20);
            this.mItSerialPort.Text = "Serial Port";
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.03791F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.96209F));
            this.tblMain.Controls.Add(this.pbMain, 0, 0);
            this.tblMain.Controls.Add(this.tlpSide, 1, 0);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 24);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 1;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.Size = new System.Drawing.Size(844, 427);
            this.tblMain.TabIndex = 1;
            // 
            // tlpSide
            // 
            this.tlpSide.ColumnCount = 1;
            this.tlpSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSide.Controls.Add(this.dgvGlyphData, 0, 0);
            this.tlpSide.Controls.Add(this.pnlManualControl, 0, 1);
            this.tlpSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSide.Location = new System.Drawing.Point(399, 3);
            this.tlpSide.Name = "tlpSide";
            this.tlpSide.RowCount = 2;
            this.tlpSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.99548F));
            this.tlpSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.00452F));
            this.tlpSide.Size = new System.Drawing.Size(442, 421);
            this.tlpSide.TabIndex = 1;
            // 
            // dgvGlyphData
            // 
            this.dgvGlyphData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGlyphData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGlyphData.Location = new System.Drawing.Point(3, 3);
            this.dgvGlyphData.Name = "dgvGlyphData";
            this.dgvGlyphData.Size = new System.Drawing.Size(436, 124);
            this.dgvGlyphData.TabIndex = 0;
            // 
            // pnlManualControl
            // 
            this.pnlManualControl.Controls.Add(this.lblRobotMessage);
            this.pnlManualControl.Controls.Add(this.btnStop);
            this.pnlManualControl.Controls.Add(this.lblSpeed);
            this.pnlManualControl.Controls.Add(this.trbSpeed);
            this.pnlManualControl.Controls.Add(this.btnDown);
            this.pnlManualControl.Controls.Add(this.btnRight);
            this.pnlManualControl.Controls.Add(this.btnLeft);
            this.pnlManualControl.Controls.Add(this.btnUp);
            this.pnlManualControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlManualControl.Location = new System.Drawing.Point(3, 133);
            this.pnlManualControl.Name = "pnlManualControl";
            this.pnlManualControl.Size = new System.Drawing.Size(436, 285);
            this.pnlManualControl.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblIsConnected});
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(844, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblIsConnected
            // 
            this.lblIsConnected.Name = "lblIsConnected";
            this.lblIsConnected.Size = new System.Drawing.Size(91, 17);
            this.lblIsConnected.Text = "Connected: Not";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(172, 168);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(50, 13);
            this.lblSpeed.TabIndex = 16;
            this.lblSpeed.Text = "Speed: 0";
            // 
            // trbSpeed
            // 
            this.trbSpeed.Location = new System.Drawing.Point(169, 195);
            this.trbSpeed.Maximum = 15;
            this.trbSpeed.Name = "trbSpeed";
            this.trbSpeed.Size = new System.Drawing.Size(72, 45);
            this.trbSpeed.TabIndex = 15;
            this.trbSpeed.ValueChanged += new System.EventHandler(this.trbSpeed_ValueChanged);
            // 
            // pbMain
            // 
            this.pbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMain.Location = new System.Drawing.Point(3, 3);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(390, 421);
            this.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            // 
            // btnStop
            // 
            this.btnStop.Image = global::DiO_CS_BetaWorld.Images.Stop;
            this.btnStop.Location = new System.Drawing.Point(91, 90);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(72, 72);
            this.btnStop.TabIndex = 17;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnDown
            // 
            this.btnDown.Image = global::DiO_CS_BetaWorld.Images.ArrowDown;
            this.btnDown.Location = new System.Drawing.Point(91, 168);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(72, 72);
            this.btnDown.TabIndex = 14;
            this.btnDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseDown);
            this.btnDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseUp);
            // 
            // btnRight
            // 
            this.btnRight.Image = global::DiO_CS_BetaWorld.Images.ArrowRight;
            this.btnRight.Location = new System.Drawing.Point(169, 90);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(72, 72);
            this.btnRight.TabIndex = 13;
            this.btnRight.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseDown);
            this.btnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseUp);
            // 
            // btnLeft
            // 
            this.btnLeft.Image = global::DiO_CS_BetaWorld.Images.ArrowLeft;
            this.btnLeft.Location = new System.Drawing.Point(13, 90);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(72, 72);
            this.btnLeft.TabIndex = 12;
            this.btnLeft.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseDown);
            this.btnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseUp);
            // 
            // btnUp
            // 
            this.btnUp.Image = global::DiO_CS_BetaWorld.Images.ArrowUp;
            this.btnUp.Location = new System.Drawing.Point(91, 12);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(72, 72);
            this.btnUp.TabIndex = 11;
            this.btnUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseDown);
            this.btnUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseUp);
            // 
            // lblRobotMessage
            // 
            this.lblRobotMessage.AutoSize = true;
            this.lblRobotMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRobotMessage.Location = new System.Drawing.Point(263, 12);
            this.lblRobotMessage.Name = "lblRobotMessage";
            this.lblRobotMessage.Size = new System.Drawing.Size(76, 16);
            this.lblRobotMessage.TabIndex = 18;
            this.lblRobotMessage.Text = "Message:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 451);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tblMain);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Name = "MainForm";
            this.Text = "BetaWorld";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tblMain.ResumeLayout(false);
            this.tlpSide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlyphData)).EndInit();
            this.pnlManualControl.ResumeLayout(false);
            this.pnlManualControl.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem mItCaptureeDevice;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.TableLayoutPanel tlpSide;
        private System.Windows.Forms.DataGridView dgvGlyphData;
        private System.Windows.Forms.Panel pnlManualControl;
        private System.Windows.Forms.ToolStripMenuItem mItSerialPort;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblIsConnected;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.TrackBar trbSpeed;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Label lblRobotMessage;
    }
}

