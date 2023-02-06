using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SparseMatrixProject
{
    public class SparseMatrix<T>: IEnumerable<int>
    {
        public Dictionary<string, int> MatrixDictionary { get; set; }
        int _size;
        public int Size 
        { 
            get => _size;
            set
            {
                if (value <= 0)
                    throw new Exception("Size is negative or equals 0, not allowed");
                else
                    _size = value;
            }
        }
        public SparseMatrix(Dictionary<string, int> matrix, int size)
        {
            if (matrix.Count == size * size)
                MatrixDictionary = matrix;
            else
                throw new Exception("Dictionary doesn't correspond square matrix");       
            Size = size;
        }
        public int this[int i, int j] // индексатор с двумя индексами
        {
            get => MatrixDictionary.Where(x => x.Key == $"[{i}, {j}]").First().Value;
            set
            {
                if (i < 0 || j < 0)
                    throw new Exception("Indexes can not be negative");
                    
                MatrixDictionary[$"[{i}, {j}]"] = value;
            }
        }
        public Dictionary<string, int> CreateDictionaryThatContainsNonZeroValues(Dictionary<string, int> matrixDictionary) // словарь, кот содерждит ненулевые элементы
            => matrixDictionary.Where(x => x.Value != 0).ToDictionary(x => x.Key, x => x.Value);
        public IEnumerator<int> GetEnumerator() // возвращаются элементы матрицы, расположенные на диагонали
        {            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i == j)
                        yield return MatrixDictionary[$"[{i}, {j}]"];
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public int Track(Dictionary<string, int> dict) // возвращает сумму элементов на главной диагонали, может можно переиспользовать GetEnumerator, чтобы не дублировать код????
        {
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i == j)
                        sum = dict.Values.Sum();
                }
            }
            return sum;
        }
        public int CheckCount(Dictionary<string, int> dict, int x) // возвращает, сколько раз элемент x встречается в матрице
        {
            int count = 0;
            foreach (KeyValuePair<string, int> kvp in dict)
            {
                if (x == kvp.Value)
                    count = dict.Values.Count(i => i == x);
            }
            return count;
        }
        public override string ToString() // переопределен ToString
        {
            string s = "";
            foreach (KeyValuePair<string, int> kvp in MatrixDictionary)
            {
                s += $"\nkey: {kvp.Key}, value: {kvp.Value}";
            }
            return $"Dictionary: {s} \nMatrix size: {Size}";
        }
    }
}
