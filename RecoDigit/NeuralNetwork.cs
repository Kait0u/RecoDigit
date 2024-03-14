using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoDigit
{
    public class NeuralNetwork
    {
        private Matrix W0, W1;          // W0 - input weights,      W1 - 1st hidden layer weights
        private Matrix Z0, Z1, Z2;      // Z0 - input layer,        Z1 - hidden layer, Z2 - output layer
        private Matrix A1, A2;          // A1 - ReLU activation,    A2 - Sigmoid activation
        private Matrix B0, B1;          // B0 - input bias,         B1 - 1st hidden layer bias

        int firstHiddenLayerSize;
        private double learningRate;    // Hyperparameter alpha
        private double trainingSetAccuracy = 0;



        public NeuralNetwork(int firstHiddenLayerSize = 10, double learningRate = 0.15)
        {
            this.firstHiddenLayerSize = firstHiddenLayerSize;
            this.learningRate = learningRate;
            Initialize(1, this.firstHiddenLayerSize);
        }

        private NeuralNetwork(Matrix W0, Matrix W1, Matrix B0, Matrix B1, double learningRate = 0.15)
        {
            this.W0 = W0;
            this.W1 = W1;
            this.B0 = B0;
            this.B1 = B1;
            this.learningRate = learningRate;
        }

        void Initialize(int batchSize, int firstHiddenSize)
        {
            W0 = new Matrix(new double[firstHiddenSize, 784], true);
            W1 = new Matrix(new double[10, firstHiddenSize], true);
            
            Z0 = new Matrix(new double[784, batchSize], true);
            Z1 = new Matrix(new double[firstHiddenSize], true);
            Z2 = new Matrix(new double[10, batchSize], true);
            
            B0 = new Matrix(new double[firstHiddenSize], true).Transpose();
            B1 = new Matrix(new double[10], true).Transpose();
        }

        public double[] Predict(double[] x)
        {
            Z0 = new Matrix(x).Transpose();
            Z1 = Matrix.DotProduct(W0, Z0) + B0;
            A1 = ReLu(Z1);
            Z2 = Matrix.DotProduct(W1, A1) + B1;
            A2 = Sigmoid(Z2);

            return A2.ToArray();
        }

        private void PredictMultiple(double[][] X)
        {
            Z0 = new Matrix(X).Transpose();
            Z1 = Matrix.ColumnwiseBroadcastAdd(Matrix.DotProduct(W0, Z0), B0); // We need to add B0 to every column
            A1 = ReLu(Z1);
            Z2 = Matrix.ColumnwiseBroadcastAdd(Matrix.DotProduct(W1, A1), B1); // Same here
            A2 = Sigmoid(Z2);
        }

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

        public void Train(double[][] X, double[][] Y, int iterations = 500, Action<string?, int> logCallback = null)
        {
            bool debug = logCallback != null;

            int exampleCount = X.Length;
            Initialize(exampleCount, firstHiddenLayerSize);

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
            //for (int r = 0; r < rowSize; ++r)
            //{
            //    for (int c = 0; c < colSize; ++c)
            //    {
            //        result[r, c] = Math.Max(0, m[r, c]);
            //    }
            //}

            return result;
        }

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

            //for (int r = 0; r < rowSize; ++r)
            //{
            //    for (int c = 0; c < colSize; ++c)
            //    {
            //        result[r, c] = m[r, c] > 0 ? 1 : 0;
            //    }
            //}

            return result;
        }

        //public static Matrix SoftMax(Matrix m)
        //{
        //    int rowSize = m.Rows, colSize = m.Columns;
        //    Matrix result = new Matrix(rowSize, colSize);

        //    double denominator = 0;

        //    for (int r = 0; r < rowSize; ++r)
        //    {
        //        for (int c = 0; c < colSize; ++c)
        //        {
        //            double val = Math.Exp(m[r, c]);
        //            result[r, c] = val;
        //            denominator += val;
        //        }
        //    }

        //    for (int r = 0; r < rowSize; ++r)
        //    {
        //        for (int c = 0; c < colSize; ++c)
        //        {
        //            result[r, c] /= denominator;
        //        }
        //    }

        //    return result;
        //}

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

            //for (int r = 0; r < rowSize; ++r)
            //{
            //    for (int c = 0; c < colSize; ++c)
            //    {
            //        result[r, c] = Math.Exp(m[r, c]) / (1 + Math.Exp(m[r, c]));
            //    }
            //}

            return result;
        }

        public void ExportToFile(string path)
        {
            string name = Path.GetFileNameWithoutExtension(path);
            string dir = Path.GetDirectoryName(path);



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
