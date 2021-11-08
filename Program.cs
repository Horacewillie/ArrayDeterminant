using System;

namespace ArrayDeterminant
{
    class Program
    {

        static void Main(string[] args)
        {
            int[][] myNumbers = new int[][]
            {
                new int[] { 4, 3, 2, 2},
                new int[] { 0, 1, -3, 3 },
                new int[] { 0, -1, 3, 3},
                new int[] { 0, 3, 1, 1}

            };

            int[,] matrix1 = new int[,]{
            {1,2,3,4},
            {5,6,7,7},
            {8,0,3,1 },
            {4,8,2,9 },
            };

            int[,] matrix2 = new int[,]{
            {1,2,7,4},
            {5,6,2,1},
            {2,9,0,1},
            {5,9,2,3 },
            };
            var determinant = new Matrix();
            determinant.multiply(matrix1, matrix2);
            Console.WriteLine("*************************************************************");
            Console.WriteLine("*************************************************************");
            Console.WriteLine(determinant.Determinant(myNumbers));
           
        }
    }
}
