using System.ComponentModel;
using Timer = System.Windows.Forms.Timer;
using Emgu.CV;
using Emgu.CV.Structure;

namespace image_processing
{
    public partial class Form1 : Form
    {
        Bitmap loaded, processed;
        private VideoCapture _capture = null;
        private bool isLive = false;
        private int filterIndex = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void mirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {
            // Load the image from file and display it
            loaded = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = loaded;
            pictureBox2.Image = loaded;
            pictureBox1.Refresh(); // Force the PictureBox to repaint
            pictureBox2.Refresh(); // Force the PictureBox to repaint
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                pictureBox2.Image.Save(saveFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("No image available to save.");
            }
        }

        // BasicDIP functions

        private void pixelCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLive)
            {
                processed = BasicDIP.PixelCopy(loaded);
                pictureBox2.Image = processed;
            } else
            {
                filterIndex = 0;
            }
            
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLive)
            {
                processed = BasicDIP.Greyscale(loaded);
                pictureBox2.Image = processed;
            }
            else
            {
                filterIndex = 1;
            }
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!isLive)
            {
                processed = BasicDIP.Invert(loaded);
                pictureBox2.Image = processed;
            }
            else
            {
                filterIndex = 2;
            }
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLive)
            {
                processed = BasicDIP.Histogram(loaded);
                pictureBox2.Image = processed;
            }
            else
            {
                filterIndex = 3;
            }
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLive)
            {
                processed = BasicDIP.Sepia(loaded);
                pictureBox2.Image = processed;
            }
            else
            {
                filterIndex = 4;
            }
        }

        private void subtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Create and configure the SubtractForm
            using (SubtractForm subtractForm = new SubtractForm())
            {
                // Ensure the form uses manual positioning
                subtractForm.StartPosition = FormStartPosition.Manual;
                // Set the new form's location to match the current form's location
                subtractForm.Location = this.Location;

                // Show the form as a modal dialog
                subtractForm.ShowDialog();
            }

            // After the SubtractForm closes, show the original form again
            this.Show();
        }

        private void smoothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLive)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                if (ConvolutionFilters.Smooth(bmp, 1))
                {
                    pictureBox2.Image = bmp;
                }
                else
                {
                    MessageBox.Show("Smoothing operation failed.");
                }
            } else
            {
                filterIndex = 5;
            }
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLive)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                if (ConvolutionFilters.GaussianBlur(bmp))
                {
                    pictureBox2.Image = bmp;
                }
                else
                {
                    MessageBox.Show("Gaussian Blur operation failed.");
                }
            }
            else
            {
                filterIndex = 6;
            }
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLive)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                if (ConvolutionFilters.Sharpen(bmp))
                {
                    pictureBox2.Image = bmp;
                }
                else
                {
                    MessageBox.Show("Sharpening operation failed.");
                }
            }
            else
            {
                filterIndex = 7;
            }
        }

        private void meanRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLive)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                if (ConvolutionFilters.MeanRemoval(bmp))
                {
                    pictureBox2.Image = bmp;
                }
                else
                {
                    MessageBox.Show("Mean Removal operation failed.");
                }
            }
            else
            {
                filterIndex = 8;
            }
        }

        private void embossingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLive)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                if (ConvolutionFilters.Emboss(bmp, EmbossType.Classic))
                {
                    pictureBox2.Image = bmp;
                }
                else
                {
                    MessageBox.Show("Embossing operation failed.");
                }
            }
            else
            {
                filterIndex = 9;
            }
        }

        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLive)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                if (ConvolutionFilters.Emboss(bmp, EmbossType.Classic))
                {
                    pictureBox2.Image = bmp;
                }
                else
                {
                    MessageBox.Show("Embossing operation failed.");
                }
            }
            else
            {
                filterIndex = 9;
            }
        }

        private void horizontaVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLive)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                if (ConvolutionFilters.Emboss(bmp, EmbossType.HorizontalOrVertical))
                {
                    pictureBox2.Image = bmp;
                }
                else
                {
                    MessageBox.Show("Embossing operation failed.");
                }
            }
            else
            {
                filterIndex = 10;
            }
        }

        private void allDirectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLive)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                if (ConvolutionFilters.Emboss(bmp, EmbossType.AllDirections))
                {
                    pictureBox2.Image = bmp;
                }
                else
                {
                    MessageBox.Show("Embossing operation failed.");
                }
            }
            else
            {
                filterIndex = 11;
            }
        }
        private void lossyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLive)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                if (ConvolutionFilters.Emboss(bmp, EmbossType.Lossy))
                {
                    pictureBox2.Image = bmp;
                }
                else
                {
                    MessageBox.Show("Embossing operation failed.");
                }
            }
            else
            {
                filterIndex = 12;
            }
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLive)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                if (ConvolutionFilters.Emboss(bmp, EmbossType.HorizontalOnly))
                {
                    pictureBox2.Image = bmp;
                }
                else
                {
                    MessageBox.Show("Embossing operation failed.");
                }
            }
            else
            {
                filterIndex = 13;
            }
        }

        private void verticalOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLive)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                if (ConvolutionFilters.Emboss(bmp, EmbossType.VerticalOnly))
                {
                    pictureBox2.Image = bmp;
                }
                else
                {
                    MessageBox.Show("Embossing operation failed.");
                }
            } else
            {
                filterIndex = 14;
            }
        }

        private void liveToolStripMenuItem_Click(object sender, EventArgs e)
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
                // Convert the frame to a Bitmap
                Bitmap liveImage = new Bitmap(frame.ToBitmap());
                Bitmap processedImage = null;
                // Process the image using PixelCopy
                if (filterIndex == 0)
                {
                    processedImage = BasicDIP.PixelCopy(liveImage);
                } 
                else if (filterIndex == 1)
                {
                    processedImage = BasicDIP.Greyscale(liveImage);
                }
                else if (filterIndex == 2)
                {
                    processedImage = BasicDIP.Invert(liveImage);
                }
                else if (filterIndex == 3)
                {
                    processedImage = BasicDIP.Histogram(liveImage);
                }
                else if (filterIndex == 4)
                {
                    processedImage = BasicDIP.Sepia(liveImage);
                }
                else if (filterIndex == 5)
                {
                    ConvolutionFilters.Smooth(liveImage, 1);
                    processedImage = liveImage;
                }
                else if (filterIndex == 6)
                {
                    ConvolutionFilters.GaussianBlur(liveImage);
                    processedImage = liveImage;
                }
                else if (filterIndex == 7)
                {
                    ConvolutionFilters.Sharpen(liveImage);
                    processedImage = liveImage;
                }
                else if (filterIndex == 8)
                {
                    ConvolutionFilters.MeanRemoval(liveImage);
                    processedImage = liveImage;
                }
                else if (filterIndex == 9)
                {
                    ConvolutionFilters.Emboss(liveImage, EmbossType.Classic);
                    processedImage = liveImage;
                }
                else if (filterIndex == 10)
                {
                    ConvolutionFilters.Emboss(liveImage, EmbossType.HorizontalOrVertical);
                    processedImage = liveImage;
                }
                else if (filterIndex == 11)
                {
                    ConvolutionFilters.Emboss(liveImage, EmbossType.AllDirections);
                    processedImage = liveImage;
                }
                else if (filterIndex == 12)
                {
                    ConvolutionFilters.Emboss(liveImage, EmbossType.Lossy);
                    processedImage = liveImage;
                }
                else if (filterIndex == 13)
                {
                    ConvolutionFilters.Emboss(liveImage, EmbossType.HorizontalOnly);
                    processedImage = liveImage;
                }
                else if (filterIndex == 14)
                {
                    ConvolutionFilters.Emboss(liveImage, EmbossType.VerticalOnly);
                    processedImage = liveImage;
                }



                // Update the PictureBoxes on the UI thread
                if (pictureBox1.InvokeRequired)
                {
                    pictureBox1.Invoke(new Action(() =>
                    {
                        pictureBox1.Image = new Bitmap(frame.ToBitmap()); ; // Show the raw live feed
                        pictureBox2.Image = processedImage; // Show the PixelCopy processed image
                    }));
                }
                else
                {
                    pictureBox1.Image = new Bitmap(frame.ToBitmap()); ;
                    pictureBox2.Image = processedImage;
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
