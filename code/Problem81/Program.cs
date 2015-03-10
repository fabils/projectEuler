using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Problem81
{
    public class Program
    {
        static void Main()
        {
            // Open File
            var matrix = loadMatrix("C:/problem81/p081_matrix.txt");

            // 
            int size = matrix.GetLength(0);

            // bottom and right solution
            for (int i = size - 2; i >= 0; i--)
            {
                matrix[size - 1, i] += matrix[size - 1, i + 1];
                matrix[i, size - 1] += matrix[i + 1, size - 1];

            }

            for (int i = size - 2; i >= 0; i--)
            {
                for (int j = size - 2; j >= 0; j--)
                {
                    matrix[i, j] += Math.Min(matrix[i + 1, j], matrix[i, j + 1]);
                }
            }

            // Show the answer
            Console.Write("Answer:" + matrix[0, 0].ToString());
            Console.ReadLine();  

            
        }

        /// <summary>
        /// Method for load the file and create a matrix
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        static int[,] loadMatrix(string file)
        {
            // Load file
            StreamReader reader = new StreamReader(file);
            string text = reader.ReadToEnd();

            // matrix initialize
            int line = text.Split('\n').Count() -1; // There is one \n in the end 
            int column = text.Split('\n')[0].Split(',').Count(); 
            int[,] Matrix = new int[line, column];
            
            // populate the matrix
            for (int i = 0; i < line ; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Matrix[i, j] = int.Parse(text.Split('\n')[i].Split(',')[j]);
                }
            }
            return Matrix;

        }
    }
}
