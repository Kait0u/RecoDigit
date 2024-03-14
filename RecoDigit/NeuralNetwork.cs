using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RecoDigit
{
    /// <summary>
    /// A class representing a MNIST-dataset bent Neural Network.
    /// It's got an input layer and two hidden layers, and an output layer (actually the second hidden layer).
    /// The size of the first hidden layer can be set by the user.
    /// The class possesses all the functionalities needed to train it and predict it.
    /// It relies on the <see cref="Matrix"/> class a lot.
    /// </summary>
    /// <seealso cref="Matrix"/>
    public class NeuralNetwork
    {
        /// <summary>
        /// The weights of connections from the input layer to the 1st hidden layer.
        /// </summary>
        private Matrix W0;

        /// <summary>
        /// The weights of connections from the 1st hidden layer to the 2nd hidden layer.
        /// </summary>
        private Matrix W1;

        /// <summary>
        /// The input layer neuron values.
        /// </summary>
        private Matrix Z0;
        
        /// <summary>
        /// The 1st hidden layer neuron values.
        /// </summary>
        private Matrix Z1;
        
        /// <summary>
        /// The 2nd hidden layer neuron values (output layer)
        /// </summary>
        private Matrix Z2;
        
        /// <summary>
        /// The activation values for the 1st hidden layer.
        /// </summary>
        private Matrix A1;

        /// <summary>
        /// The activation values for the 2nd hidden layer.
        /// </summary>
        private Matrix A2;

        /// <summary>
        /// The bias vector added to the 1st hidden layer.
        /// </summary>
        private Matrix B0;

        /// <summary>
        /// The bias vector added to the 2nd hidden layer.
        /// </summary>
        private Matrix B1;

        /// <summary>
        /// The size of the first hidden layer.
        /// </summary>
        private int firstHiddenLayerSize;

        /// <summary>
        /// Hyperparameter alpha - the rate at which the network adjusts its values.
        /// </summary>
        private double learningRate;

        /// <summary>
        /// For training purposes: a measurement of the network's accuracy on the training set.
        /// </summary>
        private double trainingSetAccuracy = 0;


        /// <summary>
        /// Constructor that creates a neural network using the given size of the 1st hidden layer (<paramref name="firstHiddenLayerSize"/>) and a <paramref name="learningRate"/>
        /// </summary>
        /// <param name="firstHiddenLayerSize">The size of the 1st hidden layer.</param>
        /// <param name="learningRate">The rate at which the network adjusts its values.</param>
        /// <remarks>A network instantiated using this constructor should undergo training before being used.</remarks>
        public NeuralNetwork(int firstHiddenLayerSize = 10, double learningRate = 0.15)
        {
            this.firstHiddenLayerSize = firstHiddenLayerSize;
            this.learningRate = learningRate;
            Initialize(1);
        }

        /// <summary>
        /// A constructor used by <see cref="ImportFromFile"/> that creates a network from a-priori prepared values, stored in a .neuro file.
        /// </summary>
        /// <param name="W0">The weights of connections from the input layer to the 1st hidden layer.</param>
        /// <param name="W1">The weights of connections from the 1st hidden layer to the 2nd hidden layer.</param>
        /// <param name="B0">The bias vector added to the 1st hidden layer.</param>
        /// <param name="B1">The bias vector added to the 2nd hidden layer.</param>
        /// <param name="learningRate">Hyperparameter alpha - the rate at which the network adjusts its values.</param>
        private NeuralNetwork(Matrix W0, Matrix W1, Matrix B0, Matrix B1, double learningRate = 0.15)
        {
            this.W0 = W0;
            this.W1 = W1;
            this.B0 = B0;
            this.B1 = B1;
            this.learningRate = learningRate;
        }

        /// <summary>
        /// Initializes the matrices used by the NeuralNetwork.
        /// </summary>
        /// <param name="batchSize">How many training examples are expected</param>
        private void Initialize(int batchSize)
        {
            W0 = new Matrix(new double[firstHiddenLayerSize, 784], true);
            W1 = new Matrix(new double[10, firstHiddenLayerSize], true);
            
            Z0 = new Matrix(new double[784, batchSize], true);
            Z1 = new Matrix(new double[firstHiddenLayerSize], true);
            Z2 = new Matrix(new double[10, batchSize], true);
            
            B0 = new Matrix(new double[firstHiddenLayerSize], true).Transpose();
            B1 = new Matrix(new double[10], true).Transpose();
        }

        /// <summary>
        /// Makes a prediction for a single input array.
        /// </summary>
        /// <param name="x">A training example.</param>
        /// <returns>The output layer values for the single training example.</returns>
        public double[] Predict(double[] x)
        {
            Z0 = new Matrix(x).Transpose();
            Z1 = Matrix.DotProduct(W0, Z0) + B0;
            A1 = ReLu(Z1);
            Z2 = Matrix.DotProduct(W1, A1) + B1;
            A2 = Sigmoid(Z2);

            return A2.ToArray();
        }

        /// <summary>
        /// Makes a prediction for an array of multiple inputs - for <see cref="BackPropagation"/> purposes.
        /// </summary>
        /// <param name="X">A matrix of inputs (where each COLUMN is an input vector)</param>
        private void PredictMultiple(double[][] X)
        {
            Z0 = new Matrix(X).Transpose();
            Z1 = Matrix.ColumnwiseBroadcastAdd(Matrix.DotProduct(W0, Z0), B0); // We need to add B0 to every column
            A1 = ReLu(Z1);
            Z2 = Matrix.ColumnwiseBroadcastAdd(Matrix.DotProduct(W1, A1), B1); // Same here
            A2 = Sigmoid(Z2);
        }

        /// <summary>
        /// Backwards Propagation implementation, to be used by <see cref="Train"/>.
        /// </summary>
        /// <param name="X">A matrix of inputs (where each COLUMN is an input vector)</param>
        /// <param name="oneHotY">A matrix of expected outcomes (where each COLUMN is a One-Hot encoded label)</param>
        /// <remarks>Equations for this method are taken from: https://web.archive.org/web/20210124091644/https://www.samsonzhang.com/2020/11/24/understanding-the-math-behind-neural-networks-by-building-one-from-scratch-no-tf-keras-just-numpy.html</remarks>
        private void BackPropagation(double[][] X, double[][] oneHotY)
        {
            int batchSize = X.Length;
            PredictMultiple(X); // Make sure the values are fresh after making a prediction
            Matrix targetY = new Matrix(oneHotY).Transpose();
            
            Matrix dZ2 = A2 - targetY;
            Matrix dW1 = Matrix.DotProduct(dZ2, A1.Transpose()) / batchSize;
            double dB1 = dZ2.Sum() / batchSize;

            Matrix dZ1 = Matrix.ElementProduct(Matrix.DotProduct(W1.Transpose(), dZ2), ReLuDer(Z1));
            Matrix dW0 = Matrix.DotProduct(dZ1, Z0.Transpose()) / batchSize;
            double dB0 = dZ1.Sum() / batchSize;

            W1 = W1 - learningRate * dW1;
            W0 = W0 - learningRate * dW0;
            B1 = B1 - learningRate * dB1;
            B0 = B0 - learningRate * dB0;
        }

        /// <summary>
        /// Trains the network.
        /// </summary>
        /// <param name="X">A matrix of inputs (where each COLUMN is an input vector)</param>
        /// <param name="Y">A matrix of expected outcomes (where each COLUMN is a One-Hot encoded label)</param>
        /// <param name="iterations">The number of repeats that the algorithm will go through to train the network.</param>
        /// <param name="logCallback">An optional callback function for the network to report the progress of its learning to the outside world, as training proceeds.</param>
        //// <exception cref="InvalidOperationException">If sizes of X and Y are incompatible.</exception>
        public void Train(double[][] X, double[][] Y, int iterations = 500, Action<string?, int> logCallback = null)
        {
            bool debug = logCallback != null;

            int exampleCount = X.Length;
            Initialize(exampleCount);

            if (Y.Length != exampleCount) throw new InvalidOperationException("X and Y have to be of the same size for the training to proceed!");

            for (int iterIdx = 0; iterIdx < iterations; ++iterIdx)
            {
                int successes = 0;
                BackPropagation(X, Y);

                for (int idx = 0; idx < exampleCount; ++idx)
                {
                    int prediction = Utilities.ArgMax(A2.ExtractColumn(idx));
                    int actually = Utilities.ArgMax(Y[idx]);

                    if (prediction == actually) ++successes;
                }

                trainingSetAccuracy = (double)successes / exampleCount;
                if (debug && iterIdx % 10 == 0) logCallback(string.Format("[ITERATION {0,6}]: ACCURACY = {1,6:F3}", iterIdx, trainingSetAccuracy), iterIdx + 1);
                else if (debug) logCallback(null, iterIdx + 1);
            }

            if (debug) logCallback(string.Format("[FINAL RESULT]: ACCURACY = {0,6:F3}", trainingSetAccuracy), iterations);
        }

        /// <summary>
        /// A standard ReLU activation function.
        /// </summary>
        /// <param name="m">The matrix to whose items the function will be applied.</param>
        /// <returns>A new matrix with ReLU performed on it.</returns>
        public static Matrix ReLu(Matrix m)
        {
            int rowSize = m.Rows, colSize = m.Columns;
            Matrix result = new Matrix(rowSize, colSize);

            Parallel.For(0, rowSize, (r) =>
            {
                for (int c = 0; c < colSize; ++c)
                {
                    result[r, c] = Math.Max(0, m[r, c]);
                }
            });

            return result;
        }

        /// <summary>
        /// A derivative of <see cref="ReLU"/>
        /// </summary>
        /// <param name="m">The matrix to whose items the derivative will be applied.</param>
        /// <returns>A new matrix with the derivetive of <see cref="ReLu"/> performed on it.</returns>
        /// <seealso cref="ReLu"/>
        public static Matrix ReLuDer(Matrix m)
        {
            int rowSize = m.Rows, colSize = m.Columns;
            Matrix result = new Matrix(rowSize, colSize);

            Parallel.For(0, rowSize, (r) =>
            {
                for (int c = 0; c < colSize; ++c)
                {
                    result[r, c] = m[r, c] > 0 ? 1 : 0;
                }
            });

            return result;
        }


        /// <summary>
        /// A standard sigmoid activation function.
        /// </summary>
        /// <param name="m">The matrix to whose items the function will be applied.</param>
        /// <returns></returns>
        /// <remarks>It can be used in a MNIST digit recognition network, but the most common pick in this scenario is SoftMax. This implementation uses Sigmoid, though.</remarks>
        public static Matrix Sigmoid(Matrix m)
        {
            int rowSize = m.Rows, colSize = m.Columns;
            Matrix result = new Matrix(rowSize, colSize);

            Parallel.For(0, rowSize, (r) =>
            {
                for (int c = 0; c < colSize; ++c)
                {
                    result[r, c] = Math.Exp(m[r, c]) / (1 + Math.Exp(m[r, c]));
                }
            });

            return result;
        }


        /// <summary>
        /// Export the neural network to a .neuro file.
        /// </summary>
        /// <param name="path">The path at which the network will have its file saved.</param>
        /// <seealso cref="ImportFromFile"/>
        public void ExportToFile(string path)
        {
            string name = Path.GetFileNameWithoutExtension(path);
            string dir = Path.GetDirectoryName(path)

            Dictionary<string, string> exports = new Dictionary<string, string>();
            exports.Add("W0", W0.ExportToString());
            exports.Add("W1", W1.ExportToString());
            exports.Add("B0", B0.ExportToString());
            exports.Add("B1", B1.ExportToString());
            exports.Add("ALPHA", $"{learningRate}");

            using (FileStream fileToOpen = new FileStream(path, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(fileToOpen, ZipArchiveMode.Update)) 
                {
                    foreach (KeyValuePair<string, string> subfile in exports)
                    {
                        ZipArchiveEntry exportedSubfile = archive.CreateEntry(subfile.Key);
                        using (StreamWriter writer = new StreamWriter(exportedSubfile.Open()))
                        {
                            writer.Write(subfile.Value);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Create a neural network using an a-priori created .neuro file with all the necessary values.
        /// </summary>
        /// <param name="path">The file at which the .neuro file can be found.</param>
        /// <returns>A pre-trained neural network.</returns>
        public static NeuralNetwork ImportFromFile(string path)
        {
            NeuralNetwork nn = null;
            Dictionary<string, object> entries = new Dictionary<string, object>()
            {
                { "W0", null },
                { "W1", null },
                { "B0", null },
                { "B1", null },
                { "ALPHA", null },
            };

            using (FileStream fileToOpen = new FileStream(path, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(fileToOpen, ZipArchiveMode.Read))
                {
                    foreach (var entryFile in archive.Entries)
                    {
                        using (StreamReader entryReader = new StreamReader(entryFile.Open()))
                        {
                            string data = entryReader.ReadToEnd();
                            
                            if (entryFile.Name == "ALPHA")
                            {
                                entries["ALPHA"] = Double.Parse(data);
                            }
                            else
                            {
                                entries[entryFile.Name] = Matrix.Parse(data);
                            }
                        }
                    }
                }
            }

            
            nn = new NeuralNetwork(entries["W0"] as Matrix, entries["W1"] as Matrix, entries["B0"] as Matrix, entries["B1"] as Matrix, (double)entries["ALPHA"]);

            return nn;
        }
    }
}
