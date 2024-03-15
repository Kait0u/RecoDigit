using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RecoDigit
{
    /// <summary>
    /// The main window of the application, where the user can draw and browse history.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The size of the pen that the app should start up with.
        /// </summary>
        const uint initialPenSize = 20;

        /// <summary>
        /// The size of an output image (necessary to be compatible with the neural network's datasets).
        /// </summary>
        const int outputImageSize = 28;

        /// <summary>
        /// A Bitmap object to store the current image.
        /// </summary>
        Bitmap bitmap;

        /// <summary>
        /// A Graphics object to manipulate the <see cref="bitmap"/>.
        /// </summary>
        Graphics graphics;

        /// <summary>
        /// A state variable that keeps track of whether the user is drawing or not.
        /// </summary>
        bool isDrawing = false;

        /// <summary>
        /// Previous cursor location.
        /// </summary>
        Point prevLoc;

        /// <summary>
        /// Current cursor location.
        /// </summary>
        Point currLoc;

        /// <summary>
        /// Pen object to draw.
        /// </summary>
        Pen pen;


        /// <summary>
        /// A currently used <see cref="NeuralNetwork"/> model.
        /// </summary>
        NeuralNetwork neuralNetwork;

        /// <summary>
        /// A dictionary that holds the full-sized images to be called back from the memory upon user's request.
        /// </summary>
        Dictionary<DataGridViewRow, Bitmap> fullSizeBitmapHistory;

        /// <summary>
        /// A constructor that configures the objects needed to draw.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            bitmap = new Bitmap(drawingPictureBox.Width, drawingPictureBox.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.Black);
            drawingPictureBox.Image = bitmap;

            pen = new Pen(Color.White, initialPenSize);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Square;

            penSizeLabel.Text = initialPenSize.ToString();

            fullSizeBitmapHistory = new Dictionary<DataGridViewRow, Bitmap>();
        }

        /// <summary>
        /// A property to get or set the current NeuralNetwork of the application. Made primarily for public usage.
        /// </summary>
        public NeuralNetwork Network
        {
            /// <summary>Gets the current <see cref="NeuralNetwork"/>.</summary>
            /// <returns>The current <see cref="NeuralNetwork"/>.</returns>
            get 
            {
                return neuralNetwork; 
            }

            /// <summary>Sets the current <see cref="NeuralNetwork"/>.</summary>
            /// <param name="value">Another <see cref="NeuralNetwork"/>.</param>
            set { neuralNetwork = value; }
        }

        /// <summary>
        /// A method to update the log text box at the bottom of the screen, with a message.
        /// </summary>
        /// <param name="message">The message to be printed to the text box.</param>
        /// <param name="clear">Optional; Whether to clear the text box before printing to it, or not (default: not)</param>
        public void UpdateLog(string message, bool clear = false)
        {
            if (clear) predictionTextBox.Clear();
            predictionTextBox.AppendText(message);
        }

        /// <summary>
        /// Enables drawing, remembers the cursor's current position.
        /// </summary>
        private void drawingPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            currLoc = e.Location;
            prevLoc = e.Location;
        }

        /// <summary>
        /// Actually draws, and updates cursor's position for future drawing.
        /// </summary>
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

        /// <summary>
        /// Stops drawing.
        /// </summary>
        private void drawingPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }


        /// <summary>
        /// Clears the canvas.
        /// </summary>
        private void imageOptionsClearButton_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.Black);
            drawingPictureBox.Refresh();
        }


        /// <summary>
        /// Decreases the pen size by 1.
        /// </summary>
        private void penSizeMinusButton_Click(object sender, EventArgs e)
        {
            pen.Width = Math.Max(1, pen.Width - 1);
            penSizeLabel.Text = (pen.Width).ToString();
        }

        /// <summary>
        /// Increases the pen size by 1.
        /// </summary>
        private void penSizePlusButton_Click(object sender, EventArgs e)
        {
            penSizeLabel.Text = (++pen.Width).ToString();
        }

        /// <summary>
        /// Exports the image as a 28x28 bitmap.
        /// </summary>
        /// <remarks>Functionality made with future training in mind.</remarks>
        private void imageOptionsExportButton_Click(object sender, EventArgs e)
        {
            Bitmap result = ImageUtilities.Resize(bitmap, outputImageSize, outputImageSize);

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

        /// <summary>
        /// Grabs the image drawn by the user and feeds it into the current <see cref="NeuralNetwork"/> and prints its prediction to the textbox.
        /// </summary>
        /// <remarks>Given it's a neural network and it was trained on handwritten digits that were written on paper, the accuracy can be relatively low.</remarks>
        private void recognizeButton_Click(object sender, EventArgs e)
        {
            if (neuralNetwork == null)
            {
                predictionTextBox.Text = "Load or train your neural network first!";
            }
            else
            {
                Bitmap resized = ImageUtilities.Resize(bitmap, outputImageSize, outputImageSize);
                byte[] bytes = ImageUtilities.BitmapToArray(resized);
                double[] inputImage = bytes.Select(pixel => pixel / 255.0).ToArray();

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


        /// <summary>
        /// Shows a popup about the author.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RecoDigit, by Jakub Jaworski (Kait0u)\nWIT Academy, Warsaw (2024)", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Loads a pre-trained NeuralNetwork
        /// </summary>
        /// <seealso cref="NeuralNetwork"/>
        /// <seealso cref="NeuralNetwork.ImportFromFile"/>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Locate your neural network",
                InitialDirectory = Path.Combine(Application.StartupPath, "models"), 
                Filter = "Neural Network file (*.neuro)|*.neuro"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                neuralNetwork = NeuralNetwork.ImportFromFile(fileName);
                predictionTextBox.Text = $"Loaded model: {fileName}";

            }
        }

        /// <summary>
        /// Clears the history of drawings and predictions.
        /// </summary>
        private void drawingHistoryClearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will clear the entire history. Are you sure?", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                drawingHistoryDataGrid.Rows.Clear();
                fullSizeBitmapHistory.Clear();
            }
        }

        /// <summary>
        /// Removes the selected item from the history of drawings and predictions.
        /// </summary>
        private void drawingHistoryRemoveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will clear the selected item from the history. Are you sure?", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                var row = drawingHistoryDataGrid.SelectedRows[0];
                fullSizeBitmapHistory.Remove(row);
                drawingHistoryDataGrid.Rows.Remove(row);
            }
        }
        
        /// <summary>
        /// Loads the selected drawing from the history of drawings back into the canvas.
        /// </summary>
        private void drawingHistoryCopyButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = drawingHistoryDataGrid.SelectedRows[0];
            Bitmap selectedBitmap = fullSizeBitmapHistory[selectedRow];
            graphics.DrawImage(selectedBitmap, 0, 0);
            drawingPictureBox.Refresh();
        }

        /// <summary>
        /// Opens a <see cref="TrainingForm"/> dialog
        /// </summary>
        private void trainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TrainingForm(this).ShowDialog();
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
