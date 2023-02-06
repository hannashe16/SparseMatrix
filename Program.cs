using System;
using System.Collections.Generic;

namespace SparseMatrixProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, int>()
            {
                {"[0, 0]", 1},
                {"[0, 1]", 0},
                {"[0, 2]", 0 },
                {"[1, 0]", 0 },
                {"[1, 1]", 0 },
                {"[1, 2]", 0 },
                {"[2, 0]", 0 },
                {"[2, 1]", 0 },
                {"[2, 2]", 0 }
            };

            SparseMatrix<int> matrix = new SparseMatrix<int>(dictionary, 3);
            var a = matrix[2, 0]; //get часть индексатора
            matrix[1, 1] = 2; //set часть индексатора
            var dict = matrix.CreateDictionaryThatContainsNonZeroValues(dictionary);
            foreach (var item in matrix) //благодаря Enumerable и Enumerator можем бегать по матрице циклом и выводим все элементы, расположенные на диагонали
            {
                var list = item;
                Console.WriteLine(list);
            }

            int sum = matrix.Track(dictionary); //  сумма элементов на диагонали
            int count = matrix.CheckCount(dictionary, 4); // количество элементов x=4 в матрице
            Console.WriteLine(matrix.ToString()); // ToString
        }
    }
}
