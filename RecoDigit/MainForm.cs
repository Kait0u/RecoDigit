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
        const uint initialPenSize = 20;
        const int outputImageSide = 28;

        Bitmap bitmap;
        Graphics graphics;
        bool isDrawing = false;
        Point prevLoc, currLoc;
        Pen pen;

        NeuralNetwork neuralNetwork;

        Dictionary<DataGridViewRow, Bitmap> fullSizeBitmapHistory;

        public MainForm()
        {
            InitializeComponent();
            bitmap = new Bitmap(drawingPictureBox.Width, drawingPictureBox.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.Clear(Color.Black);
            drawingPictureBox.Image = bitmap;

            pen = new Pen(Color.White, initialPenSize);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Triangle;

            penSizeLabel.Text = initialPenSize.ToString();

            fullSizeBitmapHistory = new Dictionary<DataGridViewRow, Bitmap>();
        }

        public NeuralNetwork Network
        {
            get { return neuralNetwork; }
            set { neuralNetwork = value; }
        }

        public void UpdateLog(string message, bool clear = false)
        {
            if (clear) predictionTextBox.Clear();
            predictionTextBox.AppendText(message);
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
            pen.Width = Math.Max(1, pen.Width - 1);
            penSizeLabel.Text = (pen.Width).ToString();
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
            if (neuralNetwork == null)
            {
                predictionTextBox.Text = "Load or train your neural network first!";
            }
            else
            {
                Bitmap resized = ImageUtilities.Resize(bitmap, outputImageSide, outputImageSide, System.Drawing.Drawing2D.InterpolationMode.Low);
                byte[] bytes = ImageUtilities.BitmapToArray(resized);
                double[] inputImage = bytes.Select((pixel) => ((double)pixel / 255.0)).ToArray();

                double[] result = neuralNetwork.Predict(inputImage);
                int prediction = Utilities.ArgMax(result);

                predictionTextBox.Text = $"My prediction is: {prediction}";

                int iconSize = drawingHistoryDataGrid.Columns[0].Width;
                Bitmap icon = ImageUtilities.Resize(bitmap, iconSize, iconSize);

                int rowIdx = drawingHistoryDataGrid.Rows.Add();
                var row = drawingHistoryDataGrid.Rows[rowIdx];
                row.Cells[0].Value = icon;
                row.Cells[1].Value = prediction;
                row.Height = iconSize;

                fullSizeBitmapHistory[row] = bitmap.Clone() as Bitmap;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RecoDigit, by Jakub Jaworski (Kait0u)\nWIT Academy, Warsaw (2024)", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Locate your neural network",
                InitialDirectory = "./models",
                Filter = "Neural Network file (*.neuro)|*.neuro"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                neuralNetwork = NeuralNetwork.ImportFromFile(fileName);
                predictionTextBox.Text = $"Loaded model: {fileName}";

            }
        }

        private void drawingHistoryClearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will clear the entire history. Are you sure?", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                drawingHistoryDataGrid.Rows.Clear();
                fullSizeBitmapHistory.Clear();
            }
        }

        private void drawingHistoryRemoveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will clear the selected item from the history. Are you sure?", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                var row = drawingHistoryDataGrid.SelectedRows[0];
                fullSizeBitmapHistory.Remove(row);
                drawingHistoryDataGrid.Rows.Remove(row);
            }
        }

        private void drawingHistoryCopyButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = drawingHistoryDataGrid.SelectedRows[0];
            Bitmap selectedBitmap = fullSizeBitmapHistory[selectedRow];
            int size = drawingPictureBox.Size.Width;
            graphics.DrawImage(selectedBitmap, 0, 0);
            drawingPictureBox.Refresh();
        }

        private void trainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TrainingForm(this).ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
