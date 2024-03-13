using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecoDigit
{
    public partial class MainForm : Form
    {
        const int initialPenSize = 10;
        const int outputImageSide = 28;

        Bitmap bitmap;
        Graphics graphics;
        bool isDrawing = false;
        Point prevLoc, currLoc;
        Pen pen;


        public MainForm()
        {
            InitializeComponent();
            bitmap = new Bitmap(drawingPictureBox.Width,drawingPictureBox.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.Clear(Color.Black);
            drawingPictureBox.Image = bitmap;
            
            pen = new Pen(Color.White, initialPenSize);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Triangle;
            
            penSizeLabel.Text = initialPenSize.ToString();
        }

        private void drawingPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            currLoc = e.Location;
            prevLoc = e.Location;
        }

        private void drawingPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                currLoc = e.Location;
                graphics.DrawLine(pen, prevLoc, currLoc);
                prevLoc = currLoc;
                drawingPictureBox.Refresh();
            }
        }

        private void drawingPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }


        private void imageOptionsClearButton_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.Black);
            drawingPictureBox.Refresh();
        }

        private void penSizeMinusButton_Click(object sender, EventArgs e)
        {
            penSizeLabel.Text = (--pen.Width).ToString();
        }

        private void penSizePlusButton_Click(object sender, EventArgs e)
        {
            penSizeLabel.Text = (++pen.Width).ToString();
        }

        private void imageOptionsExportButton_Click(object sender, EventArgs e)
        {
            Bitmap result = ImageUtilities.Resize(bitmap, outputImageSide, outputImageSide);

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Export your drawing",
                FileName = "EXPORT",
                AddExtension = true,
                DefaultExt = "BMP",
                Filter = "BMP file (*.BMP)|*.BMP",
                OverwritePrompt = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream file = saveFileDialog.OpenFile()) 
                    result.Save(file, ImageFormat.Bmp);
            }
        }

        private void recognizeButton_Click(object sender, EventArgs e)
        {
            byte[] bytes = ImageUtilities.BitmapToArray(ImageUtilities.Resize(bitmap, outputImageSide, outputImageSide));
        }

    }
}
