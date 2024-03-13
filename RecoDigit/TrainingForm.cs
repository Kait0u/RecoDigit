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
    public partial class TrainingForm : Form
    {
        MainForm parent;
        string datasetPath, outputModelPath;

        double learningRate;
        int samples, iterations;
        bool autoLoad;
        NeuralNetwork trainedNetwork;



        public TrainingForm(MainForm mainForm)
        {
            InitializeComponent();
            parent = mainForm;
        }

        void UpdateLog(string message, bool clear = false)
        {
            if (clear) outputLogTextBox.Text = ""; 
            outputLogTextBox.Text += message + Environment.NewLine;
        }

        void ClearLog()
        {
            outputLogTextBox.Text = "";
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

        private void trainButton_Click(object sender, EventArgs e)
        {
            ClearLog();

            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                UpdateLog(ex.Message, true);
            }

            trainedNetwork = new NeuralNetwork(learningRate);

            //trainedNetwork.Train();
        }
    }
}
