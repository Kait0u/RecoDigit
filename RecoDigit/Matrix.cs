using System;
using System.Threading.Tasks;

namespace RecoDigit
{
    /// <summary>A class representing matrices. Can be used for vectors, too.</summary>
    /// The main workforce behind this project, necessary for the implementation of the NeuralNetwork class.
    /// <seealso cref="NeuralNetwork"/>
    public class Matrix
    {
        /// <summary>A number of rows in the matrix.</summary>
        private int rows;
        /// <summary>A number of columns in the matrix.</summary>
        private int cols;
        
        /// <summary>A 2D array ([,]) that will hold the Matrix' items.</summary>
        private double[,] matrix;  

        /// <summary>Constructor creating a Matrix of doubles given its dimensions.</summary>
        /// <param name="rows"> The number of rows of the matrix.</param>
        /// <param name="cols"> The number of columns of the matrix.</param>
        /// <param name="randomize"> Whether to randomize the matrix upon its creation or not (default is not).</param>
        public Matrix(int rows, int cols, bool randomize = false) 
        {
            this.rows = rows;
            this.cols = cols;
            matrix = new double[rows, cols];

            if (randomize) Randomize();
        }

        /// <summary>Constructor creating a Matrix of doubles given a 2D array.</summary>
        /// <param name="array2D">A 2D array ([][]) of doubles that will be turned into a matrix.</param>
        /// <param name="randomize"> Whether to randomize the matrix upon its creation or not (default is not).</param>
        public Matrix(double[][] array2D, bool randomize = false)
        {
            rows = array2D.Length;
            cols = array2D[0].Length;

            matrix = new double[rows, cols];

            Parallel.For(0, rows, (r) =>
            {
                for (int c = 0; c < cols; ++c)
                    matrix[r, c] = array2D[r][c];
            });

            if (randomize) Randomize();
        }

        /// <summary>Constructor creating a Matrix of doubles given a 1D array.</summary>
        /// <param name="array">A 1D array of doubles that will be turned into a matrix (actually a vector)</param>
        /// <param name="randomize"> Whether to randomize the matrix upon its creation or not (default is not).</param>
        public Matrix(double[] array, bool randomize = false)
        {
            rows = 1;
            cols = array.Length;

            matrix = new double[rows, cols];
            if (!randomize)
            {
                for (int c = 0; c < cols; ++c)
                    matrix[0, c] = array[c];
            }
            else Randomize();
        }

        /// <summary>Constructor creating a Matrix of doubles given a 2D array.</summary>
        /// <param name="array2D">A 2D array ([,]) of doubles that will be turned into a matrix.</param>
        /// <param name="randomize"> Whether to randomize the matrix upon its creation or not (default is not).</param>
        public Matrix(double[,] array2D, bool randomize = false)
        {
            rows = array2D.GetLength(0);
            cols = array2D.GetLength(1);
            if (!randomize)
            {
                matrix = (double[,])array2D.Clone();
            }
            else
            {
                matrix = new double[rows, cols];
                Randomize();
            }   
        }

        /// <summary>Gets or sets the value at a given index.</summary>
        public double this[int row, int col]
        {
            /// <summary>
            /// Gets the value at a given pair of indices.
            /// </summary>
            /// <returns>The value at a given pair of indices.</returns>
            get { return matrix[row, col]; }

            /// <summary>
            /// Sets the value at a given pair of indices.
            /// </summary>
            /// <param name="value">The value to be set.</param>
            set { matrix[row, col] = value; }
        }

        /// <summary>
        /// The number of rows in the matrix.
        /// </summary>
        /// <returns>The number of rows in the matrix.</returns>
        public int Rows => rows;

        /// <summary>
        /// The number of columns in the matrix.
        /// </summary>
        /// <returns>The number of columns in the matrix.</returns>
        public int Columns => cols;

        /// <summary>
        /// Transposes the matrix.
        /// </summary>
        /// <returns>A transposed copy of the matrix.</returns>
        public Matrix Transpose()
        {
            Matrix result = new Matrix(cols, rows);

            Parallel.For(0, rows, (r) =>
            {
                for (int c = 0; c < cols; ++c)
                {
                    result[c, r] = matrix[r, c];
                }
            });

            return result;
        }

        /// <summary>
        /// Matrix addition.
        /// </summary>
        /// <param name="matrix1">The "left" matrix.</param>
        /// <param name="matrix2">The "right" matrix</param>
        /// <returns>The sum of two matrices.</returns>
        /// <exception cref="InvalidOperationException">If two matrices have different dimensions.</exception>
        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                throw new InvalidOperationException("Incompatible matrices!");

            int rows = matrix1.rows, cols = matrix1.cols;

            Matrix result = new Matrix(rows, cols);

            Parallel.For(0, rows, (r) =>
            {
                for (int c = 0; c < cols; ++c)
                {
                    result[r, c] = matrix1[r, c] + matrix2[r, c];
                }
            });

            
            return result;
        }

        /// <summary>
        /// Adds a 1-column Matrix to each column of the first matrix.
        /// </summary>
        /// <param name="matrix1">Matrix with at least one column.</param>
        /// <param name="matrix2">Matrix with exactly one column.</param>
        /// <returns>A matrix that had a single-column matrix added to its every column.</returns>
        /// <exception cref="InvalidOperationException"><paramref name="matrix2"/> has got more than one column or two matrices have different numbers of rows.</exception>
        public static Matrix ColumnwiseBroadcastAdd(Matrix matrix1, Matrix matrix2)
        {
            int rows = matrix1.Rows;
            int cols = matrix1.Columns;
            if (rows != matrix2.Rows || matrix2.Columns != 1)
                throw new InvalidOperationException("Incompatible matrices!");

            Matrix result = matrix1.Copy();

            Parallel.For(0, cols, (c) =>
            {
                for (int r = 0; r < rows; ++r)
                {
                    result[r, c] += matrix2[r, 0];
                }
            });

            return result;
        }

        /// <summary>
        /// Adds a 1-row Matrix to each row of the first matrix.
        /// </summary>
        /// <param name="matrix1">Matrix with at least one row.</param>
        /// <param name="matrix2">Matrix with exactly one row.</param>
        /// <returns>A matrix that had a single-row matrix added to its every row.</returns>
        /// <exception cref="InvalidOperationException"><paramref name="matrix2"/> has got more than one row or two matrices have different numbers of columns.</exception>
        public static Matrix RowwiseBroadcastAdd(Matrix matrix1, Matrix matrix2)
        {
            int rows = matrix1.Rows;
            int cols = matrix1.Columns;
            if (cols != matrix2.Columns || matrix2.Rows != 1)
                throw new InvalidOperationException("Incompatible matrices!");

            Matrix result = matrix1.Copy();

            Parallel.For(0, rows, (r) =>
            {
                for (int c = 0; c < cols; ++c)
                {
                    result[r, c] += matrix2[0, c];
                }
            });

            return result;
        }

        /// <summary>
        /// Matrix subtraction.
        /// </summary>
        /// <param name="matrix1">The "left" matrix.</param>
        /// <param name="matrix2">The "right" matrix</param>
        /// <returns>The difference of two matrices.</returns>
        /// <exception cref="InvalidOperationException">If two matrices have different dimensions.</exception>
        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                throw new InvalidOperationException("Incompatible matrices!");

            int rows = matrix1.rows, cols = matrix1.cols;

            Matrix result = new Matrix(rows, cols);

            Parallel.For(0, rows, (r) =>
            {
                for (int c = 0; c < cols; ++c)
                {
                    result[r, c] = matrix1[r, c] - matrix2[r, c];
                }
            });

            return result;
        }

        /// <summary>
        /// Addition of a double to every item in the matrix.
        /// </summary>
        /// <param name="matrix1">A matrix.</param>
        /// <param name="d">A double to be added to every item in the matrix.</param>
        /// <returns>A matrix with every of its items increased by <paramref name="d"/></returns>
        public static Matrix operator +(Matrix matrix1, double d)
        {
            int rows = matrix1.rows, cols = matrix1.cols;

            Matrix result = new Matrix(rows, cols);

            Parallel.For(0, rows, (r) =>
            {
                for (int c = 0; c < cols; ++c)
                {
                    result[r, c] = matrix1[r, c] + d;
                }
            });
            
            return result;
        }

        /// <summary>
        /// Addition of a double to every item in the matrix.
        /// </summary>
        /// <param name="d">A double to be added to every item in the matrix.</param>
        /// <param name="matrix1">A matrix.</param>
        /// <returns>A matrix with every of its items increased by <paramref name="d"/></returns>
        public static Matrix operator +(double d, Matrix matrix1) => matrix1 + d;

        /// <summary>
        /// Subtraction of a double from every item in the matrix.
        /// </summary>
        /// <param name="d">A double to be subtracted from every item in the matrix.</param>
        /// <param name="matrix1">A matrix.</param>
        /// <returns>A matrix with every of its items decreased by <paramref name="d"/></returns>
        public static Matrix operator -(Matrix matrix1, double d)
        {
            int rows = matrix1.rows, cols = matrix1.cols;

            Matrix result = new Matrix(rows, cols);

            Parallel.For(0, rows, (r) =>
            {
                for (int c = 0; c < cols; ++c)
                {
                    result[r, c] = matrix1[r, c] - d;
                }
            });

            return result;
        }

        /// <summary>
        /// Multiplication of every item in the matrix by a certain double.
        /// </summary>
        /// <param name="matrix1">A matrix.</param>
        /// <param name="d">A double to multiply every item in the matrix.</param>
        /// <returns>A matrix with every of its items multiplied by <paramref name="d"/></returns>
        public static Matrix operator *(Matrix matrix1, double d)
        {
            int rows = matrix1.rows, cols = matrix1.cols;

            Matrix result = new Matrix(rows, cols);
            Parallel.For(0, rows, (r) =>
            {
                for (int c = 0; c < cols; ++c)
                {
                    result[r, c] = matrix1[r, c] * d;
                }
            });

            return result;
        }

        /// <summary>
        /// Multiplication of every item in the matrix by a certain double.
        /// </summary>
        /// <param name="d">A double to multiply every item in the matrix.</param>
        /// <param name="matrix1">A matrix.</param>
        /// <returns>A matrix with every of its items multiplied by <paramref name="d"/></returns>
        public static Matrix operator *(double d, Matrix matrix1) => matrix1 * d;

        /// <summary>
        /// Division of every item in the matrix by a certain double.
        /// </summary>
        /// <param name="matrix1">A matrix.</param>
        /// /// <param name="d">A double to divide every item in the matrix.</param>
        /// <returns>A matrix with every of its items divided by <paramref name="d"/></returns>
        public static Matrix operator /(Matrix matrix1, double d)
        {
            int rows = matrix1.rows, cols = matrix1.cols;

            Matrix result = new Matrix(rows, cols);
            Parallel.For(0, rows, (r) =>
            {
                for (int c = 0; c < cols; ++c)
                {
                    result[r, c] = matrix1[r, c] / d;
                }
            });

            return result;
        }

        /// <summary>
        /// Matrix multiplication
        /// </summary>
        /// <param name="m1">The "left" matrix.</param>
        /// <param name="m2">The "right" matrix.</param>
        /// <returns>A product of two matrices - a new Matrix.</returns>
        /// <exception cref="InvalidOperationException">If the first matrix has got a different number of columns than the other has rows.</exception>
        public static Matrix DotProduct(Matrix m1, Matrix m2)
        {
            int rowSize = m1.Rows;
            int colSize = m2.Columns;
            int idxSize = m1.Columns;
            
            if (idxSize != m2.Rows) throw new InvalidOperationException("Incompatible matrices");

            Matrix result = new Matrix(rowSize, colSize);

            Parallel.For(0, rowSize, (r) =>
            {
                for (int c = 0; c < colSize; ++c)
                {
                    for (int idx = 0; idx < idxSize; ++idx)
                    {
                        result[r, c] += m1[r, idx] * m2[idx, c];
                    }
                }
            });

            return result;
        }

        /// <summary>
        /// Element-wise matrix multiplication.
        /// </summary>
        /// <param name="m1">The "left" matrix.</param>
        /// <param name="m2">The "right" matrix.</param>
        /// <returns>An element-wise product of two matrices - a new Matrix.</returns>
        /// <exception cref="InvalidOperationException">If two matrices are of different sizes.</exception>
        public static Matrix ElementProduct(Matrix m1, Matrix m2)
        {
            int rowSize = m1.Rows;
            int colSize = m1.Columns;

            if (rowSize != m2.Rows || colSize != m1.Columns) throw new InvalidOperationException("Matrices have to be of the same size to be multiplied element-by-element!");

            Matrix result = new Matrix(rowSize, colSize);

            Parallel.For(0, rowSize, (r) =>
            {
                for (int c = 0; c < colSize; ++c)
                {
                    result[r, c] = m1[r, c] * m2[r, c];
                }
            });

            return result;
        }

        /// <summary>
        /// Converts a 1x1 Matrix to a double.
        /// </summary>
        /// <returns>The only item in a 1x1 matrix, as that item.</returns>
        /// <exception cref="InvalidOperationException">If matrix is not 1x1</exception>
        public double ToScalar()
        {
            if (rows != 1 || cols != 1) throw new InvalidOperationException("A matrix can only be treated as a scalar if it's 1x1!");

            return matrix[0, 0];
        }

        /// <summary>
        /// Converts a single-row or single-column matrix to a 1D array of doubles.
        /// </summary>
        /// <returns>1D array of doubles - the only row or column of the original matrix.</returns>
        /// <exception cref="InvalidOperationException">Neither of the matrix' dimensions is 1.</exception>
        public double[] ToArray()
        {
            if (rows != 1 && cols != 1) throw new InvalidOperationException("To make an array out of a matrix, at least one dimension has to be 1!");

            int size = Math.Max(rows, cols);
            double[] result = new double[size];

            if (size == cols)
            {
                Parallel.For(0, size, (idx) =>
                {
                    result[idx] = matrix[0, idx];
                });

            }
            else
            {
                Parallel.For(0, size, (idx) =>
                {
                    result[idx] = matrix[idx, 0];
                });

            }

            return result;
        }

        /// <summary>
        /// Sum of every item in the matrix.
        /// </summary>
        /// <returns>Sum of every item in the matrix.</returns>
        public double Sum()
        {
            double result = 0;
            foreach (double val in matrix) result += val;
            return result;
        }

        /// <summary>
        /// Makes every item in the matrix a random double from between two doubles.
        /// </summary>
        /// <param name="left">The minimum (inclusive) for the RNG.</param>
        /// <param name="right">The maximum (exclusive) for the RNG.</param>
        /// <exception cref="ArgumentException">If the left end is greated than the right one.</exception>
        public void Randomize(double left = -0.5, double right = 0.5)
        {
            if (left > right) throw new ArgumentException("Left cannot be more than right!");

            for (int r =  0; r < rows; ++r)
            {
                for (int c = 0; c < cols; ++c)
                    matrix[r, c] = Utilities.RandomDoubleRange(left, right);
            }
        }

        /// <summary>
        /// Creates a copy of the matrix.
        /// </summary>
        /// <returns>A copy of the matrix.</returns>
        public Matrix Copy()
        {
            return new Matrix((double[,])matrix.Clone());
        }

        /// <summary>
        /// Extracts a column from the matrix as a 1D array.
        /// </summary>
        /// <param name="index">The index of the desired column to be extracted.</param>
        /// <returns>1D array representing a column in the matrix.</returns>
        public double[] ExtractColumn(int index)
        {
            double[] result = new double[rows];

            Parallel.For(0, rows, (r) =>
            {
                result[r] = matrix[r, index];
            });

            return result;
        }

        /// <summary>
        /// Exports a matrix to a string.
        /// </summary>
        /// <para>This method is aimed to be used when exporting the NeuralNetwork to a file.</para>
        /// <returns>A multi-line string representing the matrix.</returns>
        /// <seealso cref="NeuralNetwork"/>
        public string ExportToString()
        {
            string result = "";
            for (int r = 0; r < rows; ++r)
            {
                string line = "";
                for (int c = 0; c < cols; ++c)
                {
                    // Replace commas with dots to prevent issues with Polish locales.
                    line += $"{matrix[r, c]} ".Replace(',', '.');
                }
                line.Remove(cols - 1);
                line += Environment.NewLine;
                result += line;
            }
            return result;
        }

        /// <summary>
        /// Parses a multi-line string created by <see cref="ExportToString"/> into a Matrix.
        /// </summary>
        /// <param name="s">String created by <see cref="ExportToString"/></param>
        /// <returns>A matrix the string represented.</returns>
        /// <exception cref="InvalidOperationException">If Matrix is irregular (faulty string, perhaps?)</exception>
        public static Matrix Parse(string s)
        {
            string[] lines = s.Split("\r\n\v\f".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int rows = lines.Length, cols = 0;
            Matrix result = null;

            for (int r = 0; r < rows; ++r)
            {
                string[] columns = lines[r].Split(" \t;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (r == 0)
                {
                    cols = columns.Length;
                    result = new Matrix(rows, cols);
                }
                else if (cols != columns.Length)
                {
                    throw new InvalidOperationException("Irregular matrix forbidden");
                }

                for (int c = 0; c < cols; ++c)
                {
                    // Replace commas with dots to prevent issues with Polish locales.
                    result[r, c] = double.Parse(columns[c].Replace(',', '.')); 
                }
            }

            return result;
        }
    }
}
