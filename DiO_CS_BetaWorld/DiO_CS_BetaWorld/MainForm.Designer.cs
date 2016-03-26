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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mItCaptureeDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.mItSerialPort = new System.Windows.Forms.ToolStripMenuItem();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.tlpSide = new System.Windows.Forms.TableLayoutPanel();
            this.dgvGlyphData = new System.Windows.Forms.DataGridView();
            this.pnlManualControl = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.tlpSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlyphData)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItCaptureeDevice,
            this.mItSerialPort});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(844, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            this.tblMain.Size = new System.Drawing.Size(844, 362);
            this.tblMain.TabIndex = 1;
            // 
            // pbMain
            // 
            this.pbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMain.Location = new System.Drawing.Point(3, 3);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(390, 356);
            this.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
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
            this.tlpSide.Size = new System.Drawing.Size(442, 356);
            this.tlpSide.TabIndex = 1;
            // 
            // dgvGlyphData
            // 
            this.dgvGlyphData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGlyphData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGlyphData.Location = new System.Drawing.Point(3, 3);
            this.dgvGlyphData.Name = "dgvGlyphData";
            this.dgvGlyphData.Size = new System.Drawing.Size(436, 104);
            this.dgvGlyphData.TabIndex = 0;
            // 
            // pnlManualControl
            // 
            this.pnlManualControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlManualControl.Location = new System.Drawing.Point(3, 113);
            this.pnlManualControl.Name = "pnlManualControl";
            this.pnlManualControl.Size = new System.Drawing.Size(436, 240);
            this.pnlManualControl.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 386);
            this.Controls.Add(this.tblMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "BetaWorld";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tblMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.tlpSide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlyphData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mItCaptureeDevice;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.TableLayoutPanel tlpSide;
        private System.Windows.Forms.DataGridView dgvGlyphData;
        private System.Windows.Forms.Panel pnlManualControl;
        private System.Windows.Forms.ToolStripMenuItem mItSerialPort;
    }
}

