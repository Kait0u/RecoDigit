using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecoDigit
{
    /// <summary>
    /// A dialog for training new neural networks.
    /// </summary>
    public partial class TrainingForm : Form
    {
        /// <summary>
        /// Reference to the main window for <see cref="NeuralNetwork"/> transferring purposes.
        /// </summary>
        private MainForm parent;

        /// <summary>
        /// Path to the CSV dataset.
        /// </summary>
        private string datasetPath;

        /// <summary>
        /// Path to output the model after training.
        /// </summary>
        private string outputModelPath;

        /// <summary>
        /// The rate at which the network adjusts its values.
        /// </summary>
        private double learningRate;

        /// <summary>
        /// How many samples should be taken from the dataset.
        /// </summary>
        private int samples;

        /// <summary>
        /// For how many iterations the training should go on.
        /// </summary>
        private int iterations;

        /// <summary>
        /// How many neurons the first hidden layer should have.
        /// </summary>
        private int firstHiddenLayer;

        /// <summary>
        /// Whether the newly trained network should replace the old one without asking for confirmation.
        /// </summary>
        private bool autoLoad;

        /// <summary>
        /// A newly trained network.
        /// </summary>
        private NeuralNetwork trainedNetwork;

        /// <summary>
        /// A 2D array of training examples, where each column is an input vector.
        /// </summary>
        private double[][] xTrain;

        /// <summary>
        /// A 2D array of training outcomes, where each column is a One-Hot encoded label.
        /// </summary>
        private double[][] yTrain;

        /// <summary>
        /// Specifies whether the form is currently performing a training sequence (<c>true</c>) or not (<c>false</c>).
        /// </summary>
        private bool trainingInProgress = false;

        /// <summary>
        /// Constructor taking a reference to the main window that will be needed to send the trained network to.
        /// </summary>
        /// <param name="mainForm">A reference to the main window</param>
        /// <seealso cref="MainForm"/>
        public TrainingForm(MainForm mainForm)
        {
            InitializeComponent();
            parent = mainForm;
        }

        /// <summary>
        /// A method to print a <paramref name="message"/> out to the output text box at the bottom of the window.
        /// </summary>
        /// <param name="message">The message to print to the text box.</param>
        /// <param name="clear">Optional; Whether the text box should be cleared before printing the <paramref name="message"/> to it. (Default: not)</param>
        void UpdateLog(string message, bool clear = false)
        {
            if (clear) outputLogTextBox.Clear();
            outputLogTextBox.AppendText(message + Environment.NewLine);
        }

        /// <summary>
        /// A threaded version of <see cref="UpdateLog"/>.
        /// </summary>
        /// <param name="message">The message to print to the text box.</param>
        /// <param name="clear">Optional; Whether the text box should be cleared before printing the <paramref name="message"/> to it. (Default: not)</param>
        /// <remarks>To be used by an asynchronously performed training task.</remarks>
        void UpdateLogThread(string message, bool clear = false)
        {
            Invoke(new Action(() => UpdateLog(message, clear)));
        }

        /// <summary>
        /// Update the progress bar with the index of the current training iteration.
        /// </summary>
        /// <param name="currIter">The index of the current training iteration.</param>
        void UpdateProgressBarThread(int currIter)
        {
            Invoke(new Action(() => { trainingProgressBar.Value = currIter; }));
        }

        /// <summary>
        /// Browses for the training dataset.
        /// </summary>
        private void learningDatasetPathButton_Click(object sender, EventArgs e)
        {

            string path = Path.Exists(Path.GetDirectoryName(learningDatasetPathTextBox.Text)) ?
                Path.GetDirectoryName(learningDatasetPathTextBox.Text) :
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Navigate to your CSV dataset",
                InitialDirectory = path,
                Filter = "CSV files (*.CSV)|*.CSV"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                learningDatasetPathTextBox.Text = openFileDialog.FileName;

        }


        /// <summary>
        /// Browses for the <see cref="NeuralNetwork"/> output model (.neuro file) save location.
        /// </summary>
        private void outputModelPathButton_Click(object sender, EventArgs e)
        {
            string path = Path.Exists(Path.GetDirectoryName(outputModelPathTextBox.Text)) ?
                Path.GetDirectoryName(outputModelPathTextBox.Text) :
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string name = "EXPORT";

            if (Path.GetFileName(path).EndsWith(".neuro"))
                name = Path.GetFileName(path);

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Navigate where you'd like to save your NN model",
                InitialDirectory = path,
                Filter = "Neural Network file (*.neuro)|*.neuro",
                OverwritePrompt = true,
                FileName = name,
                AddExtension = true,
                DefaultExt = "neuro",
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputModelPathTextBox.Text = saveFileDialog.FileName;
            }
        }

        /// <summary>
        /// Performs an attempt at collecting data from the form fields.
        /// </summary>
        /// <exception cref="InvalidDataException">Invalid data in at least one field.</exception>
        private void GetData()
        {
            if (!double.TryParse(learningRateTextBox.Text, CultureInfo.InvariantCulture, out learningRate))
                throw new InvalidDataException("Error parsing provided Learning Rate!");

            if (learningRate <= 0 || learningRate >= 1.0)
                throw new InvalidDataException("Invalid Learning Rate!");

            if (!int.TryParse(sampleCountTextBox.Text, out samples))
                throw new InvalidDataException("Error parsing provided Sample Count!");

            if (samples <= 0)
                throw new InvalidDataException("Invalid sample count!");

            if (!int.TryParse(iterationsCountTextBox.Text, out iterations))
                throw new InvalidDataException("Error parsing provided Iterations Count!");

            if (iterations <= 0)
                throw new InvalidDataException("Invalid iteration count!");

            if (!int.TryParse(fiestHiddenSizeTextBox.Text, out firstHiddenLayer))
                throw new InvalidDataException("Error parsing the provided size for the 1st hidden layer!");

            if (firstHiddenLayer <= 0)
                throw new InvalidDataException("Invalid 1st hidden layer size!");

            datasetPath = learningDatasetPathTextBox.Text;
            outputModelPath = outputModelPathTextBox.Text;

            if (datasetPath == null || datasetPath == "" || !Path.Exists(datasetPath))
                throw new InvalidDataException("Something went wrong locating the dataset!");

            if (outputModelPath == null || outputModelPath == "" || !Path.Exists(Path.GetDirectoryName(outputModelPath)))
                throw new InvalidDataException("Something went wrong establishing the Neural Network export location!");

            autoLoad = autoLoadCheckbox.Checked;
        }

        /// <summary>
        /// Loads and parses the training data for the currently trained <see cref="NeuralNetwork"/>.
        /// </summary>
        /// <param name="trainingBatchSize">How many training samples should be taken.</param>
        private void LoadTrainingData(int trainingBatchSize)
        {
            {
                List<int> labels = new List<int>();
                List<List<double>> images = new List<List<double>>();

                using (StreamReader reader = new StreamReader(datasetPath))
                {
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(",");

                        labels.Add(int.Parse(values[0]));

                        var tempImageString = values.Skip(1).ToList();
                        var tempImage = new List<double>();

                        foreach (var pixel in tempImageString)
                        {
                            tempImage.Add(int.Parse(pixel));
                        }

                        images.Add(tempImage);
                    }
                }

                double[][] imagesArray = new double[images.Count][];
                for (int i = 0; i < images.Count; ++i)
                {
                    imagesArray[i] = images[i].ToArray();
                }

                double[][] oneHotY = labels.Select(label => Utilities.OneHotEncode<double>(label, 10)).ToArray();
                xTrain = imagesArray.Take(trainingBatchSize).Select(row => row.Select(pixel => pixel / 255.0).ToArray()).ToArray();
                yTrain = oneHotY.Take(trainingBatchSize).ToArray();
            }
        }

        /// <summary>
        /// Starts the training sequence.
        /// </summary>
        /// <remarks>This blocks the start button so that the user cannot break anything by attempting to start training the network parallelly.</remarks>
        private async void trainButton_Click(object sender, EventArgs e)
        {
            outputLogTextBox.Clear();
            trainingInProgress = true;
            trainButton.Enabled = false;
            trainingProgressBar.Value = 0;

            Action<string?, int> trainingLogCallback = (string? message, int currIter) =>
            {
                if (message != null)
                    UpdateLogThread(message);

                UpdateProgressBarThread(currIter);
            };

            try
            {
                GetData();
                LoadTrainingData(samples);
                trainingProgressBar.Maximum = iterations;
                trainedNetwork = new NeuralNetwork(firstHiddenLayer, learningRate);
                await Task.Run(() => trainedNetwork.Train(xTrain, yTrain, iterations, trainingLogCallback));
                trainedNetwork.ExportToFile(outputModelPath);

            }
            catch (Exception ex)
            {
                UpdateLog(ex.Message);
                trainingInProgress = false;
                trainButton.Enabled = true;
                return;
            }

            UpdateLog("");
            UpdateLog("Training complete! You may close this window now.");

            bool load = autoLoad;

            trainingInProgress = false;
            trainButton.Enabled = true;

            if (!load)
            {
                load = DialogResult.Yes == MessageBox.Show(
                    "Training complete! Would you like to load your network into the program?",
                    "Training complete!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            }

            if (load)
            {
                parent.Network = trainedNetwork;
                parent.UpdateLog("Trained network loaded.", true);
                Close();
            }
        }

        /// <summary>
        /// If there is training in progress, prevents the user from quitting.
        /// </summary>
        private void TrainingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (trainingInProgress)
            {
                MessageBox.Show("Cannot quit - there is a training process going on!", "Can't quit!", MessageBoxButtons.OK);
                e.Cancel = true;
            }
        }
    }
}
