using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecoDigit
{
    public partial class TrainingForm : Form
    {
        MainForm parent;
        string datasetPath, outputModelPath;

        double learningRate;
        int samples, iterations;
        bool autoLoad;
        NeuralNetwork trainedNetwork;

        double[][] xTrain, yTrain;



        public TrainingForm(MainForm mainForm)
        {
            InitializeComponent();
            parent = mainForm;
        }

        void UpdateLog(string message, bool clear = false)
        {
            if (clear) outputLogTextBox.Clear();
            outputLogTextBox.AppendText(message + Environment.NewLine);
        }

        void UpdateLogThread(string message, bool clear = false)
        {
            Invoke(new Action(() => UpdateLog(message, clear)));
        }


        void UpdateProgressBarThread(int currIter)
        {
            Invoke(new Action(() => { trainingProgressBar.Value = currIter; }));
        }

        private void learningDatasetPathButton_Click(object sender, EventArgs e)
        {
            string path = Path.Exists(learningDatasetPathTextBox.Text) ?
                learningDatasetPathTextBox.Text :
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Navigate to your CSV dataset",
                InitialDirectory = Path.GetDirectoryName(path),
                Filter = "CSV files (*.CSV)|*.CSV"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                learningDatasetPathTextBox.Text = openFileDialog.FileName;

        }


        private void outputModelPathButton_Click(object sender, EventArgs e)
        {
            string path = Path.Exists(learningDatasetPathTextBox.Text) ?
                learningDatasetPathTextBox.Text :
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string name = "EXPORT";

            if (Path.GetFileName(path).EndsWith(".neuro"))
                name = Path.GetFileName(path);

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Navigate where you'd like to save your NN model",
                InitialDirectory = Path.GetDirectoryName(path),
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

        private void GetData()
        {
            if (!Double.TryParse(learningRateTextBox.Text, out learningRate))
                throw new InvalidDataException("Error parsing provided Learning Rate!");

            if (learningRate <= 0)
                throw new InvalidDataException("Invalid Learning Rate!");

            if (!int.TryParse(sampleCountTextBox.Text, out samples))
                throw new InvalidDataException("Error parsing provided Sample Count!");

            if (samples <= 0)
                throw new InvalidDataException("Invalid sample count!");

            if (!int.TryParse(iterationsCountTextBox.Text, out iterations))
                throw new InvalidDataException("Error parsing provided Iterations Count!");

            if (iterations <= 0)
                throw new InvalidDataException("Invalid iteration count!");

            datasetPath = learningDatasetPathTextBox.Text;
            outputModelPath = outputModelPathTextBox.Text;

            if (datasetPath == null || datasetPath == "" || !Path.Exists(datasetPath))
                throw new InvalidDataException("Something went wrong locating the dataset!");

            if (outputModelPath == null || outputModelPath == "" || !Path.Exists(Path.GetDirectoryName(outputModelPath)))
                throw new InvalidDataException("Something went wrong establishing the Neural Network export location!");

            autoLoad = autoLoadCheckbox.Checked;
        }

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

        private async void trainButton_Click(object sender, EventArgs e)
        {
            outputLogTextBox.Clear();

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
                trainedNetwork = new NeuralNetwork(learningRate);
                await Task.Run(() => trainedNetwork.Train(xTrain, yTrain, iterations, trainingLogCallback));
                trainedNetwork.ExportToFile(outputModelPath);
                
            }
            catch (Exception ex)
            {
                UpdateLog(ex.Message);
                return;
            }

            UpdateLog("");
            UpdateLog("Training complete! You may close this window now.");

            bool load = autoLoad;

            if (!load)
            {
                load = DialogResult.Yes == MessageBox.Show(
                    "Training complete! Would you like to load your network into the program?", "Training complete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (load)
            {
                parent.Network = trainedNetwork;
                parent.UpdateLog("Trained network loaded.", true);
                Close();
            }
        }
    }
}
