using System.ComponentModel;

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
    }
}
