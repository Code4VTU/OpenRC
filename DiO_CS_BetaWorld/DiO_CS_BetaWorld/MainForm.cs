using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        // TODO: Create video selector (FFMpeg). Use listing method from (DiO_CS_StereoScopic).
        // TODO: Create video capture device (building capture device).
        // TODO: Create image processor (Glyph Processor).
        // TODO: Create robot controller (Betino). Will use standard (OR) protocol. The robot controller will be in different namespace.
        // TODO: Use grid view for the responsive design.
        // TODO: Use AppUtils helper class from (WCount or UViewr).
        // 

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();            
        }
    }
}
