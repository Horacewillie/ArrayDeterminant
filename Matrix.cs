using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayDeterminant
{
    public class Matrix
    {
        public int Determinant(int[][] matrix)
        {
            //int numRows = matrix.GetLength(0);
            //int numCols = matrix.GetLength(1);
            int numRows = matrix.Length;
            int numCols = matrix[0].Length;

            if (numRows != numCols) throw new ArgumentException("Array must have equal number of rows and columns");
            //if (numRows == 1 && numCols == 1) return matrix[0,0];
            if (numRows == 1 && numCols == 1) return matrix[0][0];
            //if (numRows == 2 && numCols == 2) return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            if (numRows == 2 && numCols == 2) return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
            //if(numRows == 3 && numCols == 3)
            //{
            //    return matrix[0][0] * Determinant(GetSubsetMatrix(0, 0, matrix)) -
            //        matrix[0][1] * Determinant(GetSubsetMatrix(0, 1, matrix)) + matrix[0][2] * Determinant(GetSubsetMatrix(0, 2, matrix));
            //}
            int result = 0;
            for(int col = 0; col < numCols; col++)
            {
                if(col % 2 == 0)
                {
                    result += matrix[0][col] * Determinant(GetSubsetMatrix(0, col, matrix));
                }
                else
                {
                    result -= matrix[0][col] * Determinant(GetSubsetMatrix(0, col, matrix));
                }
            }
            return result;
        }

        public int[][] GetSubsetMatrix(int row, int col, int[][] matrix) //int[,] matrix
        {
            int numRows = matrix.Length;
            int numCols = matrix[0].Length;
            int rowIndex = 0;
            int[][] subset = new int[numRows - 1][]; //A jagged Array with 1 value less which is an array
            for(int i = 0; i < numRows; i++)
            {
                if (i == row) continue; //Continue iteration if row to remove is at the value specified
                subset[rowIndex] = new int[numCols - 1]; //Initialize the array(s) in the jagged array to contain 1 value less of the num of cols(integers)
                int colIndex = 0;

                for(int j = 0; j < numCols; j++) {
                    if (j == col) continue;
                    subset[rowIndex][colIndex++] = matrix[i][j]; //subset[0][0] = matrix[1][1]
                }
                rowIndex++;
            }
            return subset;

        }

        public void multiply(int[,] firstMat, int[,] secondMat)
        {
            int firstMatRows = firstMat.GetLength(0);
            int firstMatCols = firstMat.GetLength(1);
            int secondMatRows = secondMat.GetLength(0);
            int secondMatCols = secondMat.GetLength(1);

            if (firstMatCols != secondMatRows)
            {
                Console.WriteLine("The 2 matrices cannot be multiplied");
                return;
            }

            int[,] product = new int[firstMatRows, secondMatCols];

            for (int i = 0; i < firstMatRows; i++)
            {
                for (int j = 0; j < secondMatCols; j++)
                {
                    for (int k = 0; k < firstMatCols; k++)
                    {
                        product[i, j] += firstMat[i, k] * secondMat[k, j];
                    }
                    Console.Write(" " + product[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
