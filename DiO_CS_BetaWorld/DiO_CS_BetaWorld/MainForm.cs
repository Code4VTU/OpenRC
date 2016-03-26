using DirectShowLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Video;

// C:\Program Files (x86)\AForge.NET\Framework\Release

namespace DiO_CS_BetaWorld
{
    /// <summary>
    /// Main form application logic part.
    /// </summary>
    public partial class MainForm : Form
    {
        // -=== To do list ===-
        // TODO: Install AForge image processing (Use PM console).
        // Install-Package AForge.Imaging
        // Install-Package AForge.Vision
        // Install-Package AForge.Video
        // TODO: Install AForge glyph recognizer (Refer to DiO_CS_GlyphRecognizer).
        // TODO: Create frame graber (Form timer, no need for delegates to draw to the form.).
        // DONE: Create video selector (FFMpeg). Use listing method from (DiO_CS_StereoScopic).
        // TODO: Create video capture device (building capture device).
        // TODO: Create image processor (Glyph Processor).
        // TODO: Create robot controller (Betino). Will use standard (OR) protocol. The robot controller will be in different namespace.
        // TODO: Use grid view for the responsive design.
        // TODO: Use AppUtils helper class from (WCount or UViewr).
        // 

        #region Variables

        /// <summary>
        /// Video capture devices.
        /// </summary>
        private VideoDevice[] videoDevices;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Check to see what video inputs we have available.
            this.videoDevices = this.GetDevices();

            if (videoDevices.Length == 0)
            {
                DialogResult res = MessageBox.Show("A camera device was not detected. Do you want to exit?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else if (videoDevices.Length < 2)
            {
                DialogResult res = MessageBox.Show("Only 1 camera detected. Stero Imaging can not be emulated. Do you want to exit?", "",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                }
            }

            // Add cameras to the menus.
            this.AddCameras(this.videoDevices, this.mItCaptureeDevice, this.mItCaptureeDevice_Click);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get list of all available devices on the PC.
        /// </summary>
        /// <returns></returns>
        private VideoDevice[] GetDevices()
        {
            //Set up the capture method 
            //-> Find systems cameras with DirectShow.Net dll, thanks to Carles Lloret.
            DsDevice[] systemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

            VideoDevice[] videoDevices = new VideoDevice[systemCamereas.Length];

            for (int index = 0; index < systemCamereas.Length; index++)
            {
                videoDevices[index] = new VideoDevice(index, systemCamereas[index].Name, systemCamereas[index].ClassID);
            }

            return videoDevices;
        }

        /// <summary>
        /// Add video devices to the tool stript menu.
        /// </summary>
        /// <param name="videoDevices">List of camears.</param>
        /// <param name="menu">Menu item.</param>
        /// <param name="callback">Callback</param>
        private void AddCameras(VideoDevice[] videoDevices, ToolStripMenuItem menu, EventHandler callback)
        {
            if (videoDevices.Length == 0)
            {
                return;
            }

            menu.DropDown.Items.Clear();

            foreach (VideoDevice device in videoDevices)
            {
                // Store the each retrieved available capture device into the MenuItems.
                ToolStripMenuItem mItem = new ToolStripMenuItem();

                mItem.Text = String.Format("{0:D2} / {1}", device.Index, device.Name);
                mItem.Tag = device.Index;
                mItem.Enabled = true;
                mItem.Checked = false;

                //TODO: Grozno
                mItem.Click += callback;

                menu.DropDown.Items.Add(mItem);
            }
        }

        #endregion

        #region Capturee Device Menu

        private void mItCaptureeDevice_Click(object sender, EventArgs e)
        {
            // Get instace from sender.
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            // Get device index.
            int index = (int)item.Tag;
        }

        #endregion
    }
}
