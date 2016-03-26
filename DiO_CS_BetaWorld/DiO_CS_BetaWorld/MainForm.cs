using AForge;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision.GlyphRecognition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using Video;

namespace DiO_CS_BetaWorld
{
    /// <summary>
    /// Main form application logic part.
    /// </summary>
    public partial class MainForm : Form
    {
        // -=== To do list ===-
        // DONE: Install AForge image processing (Use PM console).
        // Install-Package AForge.Imaging
        // Install-Package AForge.Vision
        // Install-Package AForge.Video
        // TODO: Install AForge glyph recognizer (Refer to DiO_CS_GlyphRecognizer).
        // DONE: Create frame graber (Form timer, no need for delegates to draw to the form.).
        // DONE: Create video selector (DirectShow). Use listing method from (DiO_CS_StereoScopic).
        // DONE: Create video capture device (building capture device).
        // TODO: Create image processor (Glyph Processor).
        // TODO: Create robot controller (Betino). Will use standard (OR) protocol. The robot controller will be in different namespace.
        // TODO: Use grid view for the responsive design.
        // DONE: Use AppUtils helper class from (WCount or UViewr).
        // 

        #region Variables

        /// <summary>
        /// Video capture devices.
        /// </summary>
        private VideoDevice[] videoDevices;

        /// <summary>
        /// Camera 1
        /// </summary>
        private VideoCaptureDevice videoSource;

        /// <summary>
        /// Captured image.
        /// </summary>
        private Bitmap capturedImage;

        /// <summary>
        /// Frame grabber.
        /// </summary>
        private System.Windows.Forms.Timer frameGrabber;

        /// <summary>
        /// Capture synk lock bit.
        /// </summary>
        private bool captureLockSynk = false;

        /// <summary>
        /// Collection of glyph databases.
        /// </summary>
        private GlyphDatabases glyphDatabases;

        /// <summary>
        /// Glyph recognizer to use for glyph recognition in video.
        /// </summary>
        private GlyphRecognizer recognizer;

        /// <summary>
        /// Recogniesed database.
        /// </summary>
        private List<ExtractedGlyphData> recognisedGlyphs;

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

            // Set the frame grabber timer.
            this.frameGrabber = new Timer();
            this.frameGrabber.Stop();
            this.frameGrabber.Interval = 10;

            // Create data base?
            this.glyphDatabases = new GlyphDatabases();
            
            // Create 
            this.recognisedGlyphs = new List<ExtractedGlyphData>();
            //this.imagePoints = new AForge.Point[4];
            //this.pointsColors = new Color[4]
            //{
            //    Color.Yellow,
            //    Color.Blue,
            //    Color.Red,
            //    Color.Lime
            //};

            // Load glyph data base.
            this.LoadGlyphDatabases5();

            // Setup data grid view for glyph data.
            this.SetupDGVGlyphData();
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
            //DsDevice[] systemCamereas = DsDevice.GetDevicesOfCat(AForge.Video.DirectShow.FilterCategory.VideoInputDevice);

            // Enumerate video devices
            FilterInfoCollection systemCamereas = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            
            VideoDevice[] videoDevices = new VideoDevice[systemCamereas.Count];

            for (int index = 0; index < systemCamereas.Count; index++)
            {
                videoDevices[index] = new VideoDevice(index, systemCamereas[index].Name, systemCamereas[index].MonikerString);
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
                mItem.Tag = device;
                mItem.Enabled = true;
                mItem.Checked = false;

                //TODO: Grozno
                mItem.Click += callback;

                menu.DropDown.Items.Add(mItem);
            }
        }

        /// <summary>
        /// Start video capture.
        /// </summary>
        /// <param name="monikerString">Moniker string.</param>
        private void StartCapture(string monikerString)
        {
            this.videoSource = new VideoCaptureDevice(monikerString);

            // We will only use 1 frame ready event this is not really safe but it fits the purpose.
            this.videoSource.NewFrame += new NewFrameEventHandler(this.videoSource_NewFrame);

            //_Capture2.Start(); //We make sure we start Capture device 2 first.
            this.videoSource.Start();

            // Start the timer.
            this.frameGrabber.Tick += this.frameGrabber_Tick;
            this.frameGrabber.Start();
        }

        /// <summary>
        /// Stop video capture.
        /// </summary>
        private void StopCapture()
        {
            if (this.videoSource != null)
            {
                // We will only use 1 frame ready event this is not really safe but it fits the purpose.
                this.videoSource.NewFrame -= new NewFrameEventHandler(this.videoSource_NewFrame);

                this.videoSource.Stop();
            }

            // Stop the timer.
            this.frameGrabber.Tick -= this.frameGrabber_Tick;
            this.frameGrabber.Stop();
        }

        /// <summary>
        /// Refresh the list displaying available databases of glyphss
        /// </summary>
        private void LoadGlyphDatabases5()
        {
            const string dbName = "ExampleSize5";
            const int glyphSize = 5;

            // Create glyph.
            string glyphName1 = "Test1";
            byte[,] glyphData1 = new byte[glyphSize, glyphSize]
            {
                {0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 1, 0, 0, 0},
                {0, 0, 0, 0, 0}
            };

            Glyph testGlyph1 = new Glyph(glyphName1, glyphData1);
            testGlyph1.UserData = new GlyphVisualizationData(Color.Purple);

            // Create glyph.
            string glyphName2 = "Test2";
            byte[,] glyphData2 = new byte[glyphSize, glyphSize]
            {
                {0, 0, 0, 0, 0},
                {0, 1, 0, 1, 0},
                {0, 0, 1, 0, 0},
                {0, 1, 0, 0, 0},
                {0, 0, 0, 0, 0}
            };

            Glyph testGlyph2 = new Glyph(glyphName2, glyphData2);
            testGlyph2.UserData = new GlyphVisualizationData(Color.Blue);

            // Create glyph.
            string glyphName3 = "Test3";
            byte[,] glyphData3 = new byte[glyphSize, glyphSize]
            {
                {0, 0, 0, 0, 0},
                {0, 1, 0, 1, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 1, 1, 0},
                {0, 0, 0, 0, 0}
            };

            Glyph testGlyph3 = new Glyph(glyphName3, glyphData3);
            testGlyph3.UserData = new GlyphVisualizationData(Color.Green);

            // Create database.
            GlyphDatabase lGlyphDatabase = new GlyphDatabase(glyphSize);

            // Add glyph to database.
            lGlyphDatabase.Add(testGlyph1);
            lGlyphDatabase.Add(testGlyph2);
            lGlyphDatabase.Add(testGlyph3);

            // Add database.
            this.glyphDatabases.AddGlyphDatabase(dbName, lGlyphDatabase);

            this.recognizer = new GlyphRecognizer(glyphSize);

            // set the database to image processor ...
            this.recognizer.GlyphDatabase = this.glyphDatabases[dbName]; ;
        }

        /// <summary>
        /// Process image form the camera.
        /// </summary>
        /// <param name="bitmap">Image for recognition.</param>
        private void ProcessImage(Bitmap image)
        {
            // Create tmp buffer.
            List<ExtractedGlyphData> tmpGlyps = recognizer.FindGlyphs(this.capturedImage);
            // Rewrite the glyph buffer.
            this.recognisedGlyphs = tmpGlyps;
        }

        private void SetupDGVGlyphData()
        {
            //this.Controls.Add(dgvSelectWorkpiece);
            
            this.dgvGlyphData.ColumnCount = 2;

            this.dgvGlyphData.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            this.dgvGlyphData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvGlyphData.ColumnHeadersDefaultCellStyle.Font =
                new Font(this.dgvGlyphData.Font, FontStyle.Bold);

            this.dgvGlyphData.Name = "this.dgvGlyphData";
            this.dgvGlyphData.Location = new System.Drawing.Point(8, 8);
            this.dgvGlyphData.Size = new Size(500, 250);
            this.dgvGlyphData.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvGlyphData.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            this.dgvGlyphData.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.dgvGlyphData.GridColor = Color.Black;
            this.dgvGlyphData.RowHeadersVisible = false;

            this.dgvGlyphData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvGlyphData.Columns[0].Name = "Name";
            this.dgvGlyphData.Columns[0].Width = 70;
            this.dgvGlyphData.Columns[1].Name = "Coordinates";
            this.dgvGlyphData.Columns[1].Width = 150;

            //dgvSelectWorkpiece.Columns[4].DefaultCellStyle.Font =
            //    new Font(dgvSelectWorkpiece.DefaultCellStyle.Font, FontStyle.Italic);

            this.dgvGlyphData.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            this.dgvGlyphData.MultiSelect = false;
            this.dgvGlyphData.Dock = DockStyle.Fill;
        }


        private void PopulateGlyhData(List<ExtractedGlyphData> glyphs)
        {
            this.dgvGlyphData.Rows.Clear();

            foreach (ExtractedGlyphData item in glyphs)
            {
                string[] row = new string[]
                {
                    "",
                    "",
                };

                this.dgvGlyphData.Rows.Add(row);
            }
        }

        #endregion

        #region Capturee Device Menu

        private void mItCaptureeDevice_Click(object sender, EventArgs e)
        {
            // Create instance of caller.
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            // Display text.
            this.pbMain.Tag = item.Text;

            // Get device.
            VideoDevice videoDevice = (VideoDevice)item.Tag;

            // Stop if other stream was displaing.
            this.StopCapture();

            // Start the new stream.
            this.StartCapture(videoDevice.MonikerString);
        }

        #endregion

        #region Video Source

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (captureLockSynk)
            {
                return;
            }

            // Clone the content.
            this.capturedImage = (Bitmap)eventArgs.Frame.Clone();

            // Exif there is a problem with data cloning.
            if (this.capturedImage == null)
            {
                return;
            }

            // Convert image to RGB if it is grayscale.
            if (this.capturedImage.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                GrayscaleToRGB filter = new GrayscaleToRGB();
                Bitmap temp = filter.Apply(this.capturedImage);
                this.capturedImage.Dispose();
                this.capturedImage = temp;
            }

            captureLockSynk = true;
        }

        #endregion

        #region Frame Grabber

        private void frameGrabber_Tick(object sender, EventArgs e)
        {
            // Dispose last frame.
            if (this.capturedImage == null)
            {
                return;
                //this.capturedImage.Dispose();
            }

            // Exit if not synced.
            if (!captureLockSynk)
            {
                return;
            }
            captureLockSynk = false;


            //TODO: Make preprocessing hear if it is needed.

            this.ProcessImage(this.capturedImage);

            this.PopulateGlyhData(this.recognisedGlyphs);

            Bitmap rszImage = AppUtils.FitImage(this.capturedImage, this.pbMain.Size);
            this.pbMain.Image = rszImage;
        }

        #endregion

        #region Main Form

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close video source.
            if (this.videoSource != null)
            {
                this.videoSource.Stop();
            }

        }

        #endregion

    }
}
