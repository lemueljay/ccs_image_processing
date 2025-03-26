using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Text.RegularExpressions;

namespace image_processing
{
    public partial class SubtractForm : Form
    {
        Bitmap imageB, imageA, colorgreen;
        private VideoCapture _capture = null;
        private bool isLive = false;
        private bool applyFilter = false;
        public SubtractForm()
        {
            InitializeComponent();
        }

        private void SubtractForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // If the camera is active, unsubscribe from the event and stop it
            if (isLive && _capture != null)
            {
                _capture.ImageGrabbed -= ProcessFrame;
                _capture.Stop();
                _capture.Dispose();
                _capture = null;
                isLive = false;
            }
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!isLive)
            {
                colorgreen = BasicDIP.Subtract(imageB, imageA);
                pictureBox3.Image = colorgreen;
            } else
            {
                applyFilter = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // If the camera is active, unsubscribe from the event and stop it
            if (isLive && _capture != null)
            {
                _capture.ImageGrabbed -= ProcessFrame;
                _capture.Stop();
                _capture.Dispose();
                _capture = null;
                isLive = false;
            }
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {
            imageB = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = imageB;
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            imageA = new Bitmap(openFileDialog2.FileName);
            pictureBox2.Image = imageA;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // We will be using EmguCV for this
            // Check if capture is already running
            if (_capture == null)
            {
                try
                {
                    isLive = true;
                    // Initialize the capture using the default webcam
                    _capture = new VideoCapture();
                    // Subscribe to the ImageGrabbed event
                    _capture.ImageGrabbed += ProcessFrame;
                    _capture.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error initializing webcam: " + ex.Message);
                }
            }
        }

        // Event handler for processing each frame from the webcam
        private void ProcessFrame(object sender, EventArgs e)
        {
            // Exit immediately if live capture has been stopped
            if (!isLive || _capture == null)
                return;

            Mat frame = new Mat();
            _capture.Retrieve(frame);
            if (!frame.IsEmpty)
            {
                imageB = new Bitmap(frame.ToBitmap());
                pictureBox1.Image = new Bitmap(frame.ToBitmap());

                if (applyFilter)
                {
                    colorgreen = BasicDIP.Subtract((Bitmap)imageB.Clone(), (Bitmap)imageA.Clone());
                    pictureBox3.Image = colorgreen;
                }

                // Update the PictureBoxes on the UI thread
                if (pictureBox1.InvokeRequired)
                {
                    pictureBox1.Invoke(new Action(() =>
                    {
                        pictureBox1.Image = new Bitmap(frame.ToBitmap()); // Show the raw live feed
                    }));
                }
                else
                {
                    pictureBox1.Image = new Bitmap(frame.ToBitmap());
                }
            }
        }

        // Stop the capture and release resources when the form is closing
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_capture != null)
            {
                _capture.Stop();
                _capture.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}
