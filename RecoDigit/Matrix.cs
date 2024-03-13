using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RecoDigit
{
    public class Matrix
    {
        private int rows, cols;
        private double[,] matrix;

        public Matrix(int rows, int cols, bool randomize = false) 
        {
            this.rows = rows;
            this.cols = cols;
            matrix = new double[rows, cols];

            if (randomize) Randomize();
        }

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

            //for (int r = 0; r < rows; ++r) 
            //{ 
            //    for (int c = 0; c < cols; ++c)
            //        matrix[r, c] = array2D[r][c];
            //}

            if (randomize) Randomize();
        }

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

        public double this[int row, int col]
        {
            get { return matrix[row, col]; }
            set { matrix[row, col] = value; }
        }

        public int Rows => rows;
        public int Columns => cols;

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

            //for (int r = 0; r < rows; ++r)
            //{
            //    for (int c = 0; c < cols; ++c)
            //    {
            //        result[c, r] = matrix[r, c];
            //    }
            //}

            return result;
        }

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

            //for (int r = 0; r < rows; ++r)
            //{
            //    for (int c = 0; c < cols; ++c)
            //    {
            //        result[r, c] = matrix1[r, c] + matrix2[r, c];
            //    }
            //}
            
            return result;
        }

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

            //for (int c = 0; c < cols; ++c)
            //{
            //    for (int r = 0; r < rows; ++r)
            //    {
            //        result[r, c] += matrix2[r, 0];
            //    }
            //}

            return result;
        }

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

            //for (int r = 0; r < rows; ++r)
            //{
            //    for (int c = 0; c < cols; ++c)
            //    {
            //        result[r, c] += matrix2[0, c];
            //    }
            //}

            return result;
        }

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

            //for (int r = 0; r < rows; ++r)
            //{
            //    for (int c = 0; c < cols; ++c)
            //    {
            //        result[r, c] = matrix1[r, c] - matrix2[r, c];
            //    }
            //}

            return result;
        }

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

            //for (int r = 0; r < rows; ++r)
            //{
            //    for (int c = 0; c < cols; ++c)
            //    {
            //        result[r, c] = matrix1[r, c] + d;
            //    }
            //}
            
            return result;
        }

        public static Matrix operator +(double d, Matrix matrix1) => matrix1 + d;

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

            //for (int r = 0; r < rows; ++r)
            //{
            //    for (int c = 0; c < cols; ++c)
            //    {
            //        result[r, c] = matrix1[r, c] - d;
            //    }
            //}

            return result;
        }

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
            //for (int r = 0; r < rows; ++r)
            //{
            //    for (int c = 0; c < cols; ++c)
            //    {
            //        result[r, c] = matrix1[r, c] * d;
            //    }
            //}

            return result;
        }

        public static Matrix operator *(double d, Matrix matrix1) => matrix1 * d;

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
            
            //for (int r = 0; r < rows; ++r)
            //{
            //    for (int c = 0; c < cols; ++c)
            //    {
            //        result[r, c] = matrix1[r, c] / d;
            //    }
            //}

            return result;
        }

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
            //for (int r = 0; r < rowSize; ++r)
            //{
            //    for (int c = 0; c < colSize; ++c)
            //    {
            //        for (int idx = 0; idx < idxSize; ++idx)
            //        {
            //            result[r, c] += m1[r, idx] * m2[idx, c];
            //        }
            //    }
            //}

            return result;
        }

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

            //for (int r = 0; r < rowSize; ++r)
            //{
            //    for (int c = 0; c < colSize; ++c)
            //    {
            //        result[r, c] = m1[r, c] * m2[r, c];
            //    }
            //}

            return result;
        }

        public double ToScalar()
        {
            if (rows != 1 || cols != 1) throw new InvalidOperationException("A matrix can only be treated as a scalar if it's 1x1!");

            return matrix[0, 0];
        }

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

                //for (int idx = 0; idx < size; ++idx)
                //{
                //    result[idx] = matrix[0, idx];
                //}
            }
            else
            {
                Parallel.For(0, size, (idx) =>
                {
                    result[idx] = matrix[idx, 0];
                });

                //for (int idx = 0; idx < size; ++idx)
                //{
                //    result[idx] = matrix[idx, 0];
                //}
            }

            return result;
        }

        public double Sum()
        {
            double result = 0;
            foreach (double val in matrix) result += val;
            return result;
        }

        public void Randomize(double left = -0.5, double right = 0.5)
        {
            if (left > right) throw new ArgumentException("Left cannot be more than right!");

            for (int r =  0; r < rows; ++r)
            {
                for (int c = 0; c < cols; ++c)
                    matrix[r, c] = Utilities.RandomDoubleRange(left, right);
            }
        }

        public Matrix Copy()
        {
            return new Matrix((double[,])matrix.Clone());
        }

        public double[] ExtractColumn(int index)
        {
            double[] result = new double[rows];

            Parallel.For(0, rows, (r) =>
            {
                result[r] = matrix[r, index];
            });

            //for (int r = 0; r < rows; ++r)
            //{
            //    result[r] = matrix[r, index];
            //}

            return result;
        }

        public string ExportToString()
        {
            string result = "";
            for (int r = 0; r < rows; ++r)
            {
                string line = "";
                for (int c = 0; c < cols; ++c)
                {
                    line += $"{matrix[r, c]} ";
                }
                line.Remove(cols - 1);
                line += Environment.NewLine;
                result += line;
            }
            return result;
        }

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
                    result[r, c] = double.Parse(columns[c]);
                }
            }

            return result;
        }
    }
}
