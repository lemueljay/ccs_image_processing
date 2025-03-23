using System.ComponentModel;
using Timer = System.Windows.Forms.Timer;

namespace image_processing
{
    public partial class Form1 : Form
    {
        Bitmap loaded, processed;

        public Form1()
        {
            InitializeComponent();
        }

        private void mirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {
            loaded = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = loaded;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            processed.Save(saveFileDialog1.FileName);
        }

        // BasicDIP functions

        private void pixelCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = BasicDIP.PixelCopy(loaded);
            pictureBox2.Image = processed;
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = BasicDIP.Greyscale(loaded);
            pictureBox2.Image = processed;
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {

            processed = BasicDIP.Invert(loaded);
            pictureBox2.Image = processed;
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = BasicDIP.Histogram(loaded);
            pictureBox2.Image = processed;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = BasicDIP.Sepia(loaded);
            pictureBox2.Image = processed;
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
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            if (ConvolutionFilters.Smooth(bmp, 1))
            {
                pictureBox2.Image = bmp;
            }
            else
            {
                MessageBox.Show("Smoothing operation failed.");
            }
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void meanRemovalToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void embossingToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void horizontaVerticalToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void allDirectionsToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void lossyToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void verticalOnlyToolStripMenuItem_Click(object sender, EventArgs e)
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
        }
    }
}
