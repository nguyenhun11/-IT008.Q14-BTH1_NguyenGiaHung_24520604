using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai06
{
    class MaTran
    {
        private List<List<int>> mat;

        public int Row
        {
            get
            {
                return mat.Count;
            }
        }

        public int Col
        {
            get
            {
                return mat[0].Count;
            }
        }

        public MaTran(int r, int c)
        {
            mat = new List<List<int>>();
            Random rnd = new Random();
            for (int i = 0; i < r; i++)
            {
                List<int> _row = new List<int>();
                for (int j = 0; j < c; j++)
                {
                    int randomNum = rnd.Next(100);
                    _row.Add(randomNum);
                }
                mat.Add(_row);
            }
        }

        public MaTran(int r, int c, int value)
        {
            mat = new List<List<int>>();
            for (int i = 0; i < r; i++)
            {
                List<int> _row = new List<int>();
                for (int j = 0; j < c; j++)
                {
                    _row.Add(value);
                }
                mat.Add(_row);
            }
        }

        public void Xuat()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    Console.Write(mat[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public int MaxValue
        {
            get
            {
                int max = mat[0][0];
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                    {
                        if (mat[i][j] > max)
                        {
                            max = mat[i][j];
                        }
                    }
                }
                return max;
            }
        }

        public int MinValue
        {
            get
            {
                int min = mat[0][0];
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                    {
                        if (mat[i][j] < min)
                        {
                            min = mat[i][j];
                        }
                    }
                }
                return min;
            }
        }

        private int SumRow(int row)
        {
            int sum = 0;
            foreach (int i in mat[row])
            {
                sum += i;
            }
            return sum;
        }

        private int SumCol(int col)
        {
            int sum = 0;
            foreach(var row in mat)
            {
                sum += row[col];
            }
            return sum;
        }

        public int MaxSumRowIndex
        {
            get
            {
                int index = 0;
                int maxSum = SumRow(0);
                for (int i = 1; i < Row; i++)
                {
                    if (SumRow(i) > maxSum)
                    {
                        index = i;
                    }
                }
                return index;
            }
        }

        public int MaxSumColIndex
        {
            get
            {
                int index = 0;
                int maxSum = SumCol(0);
                for (int i = 1; i < Col; i++)
                {
                    if (SumCol(i) > maxSum) index = i;
                }
                return index;
            }
        }

        public int Sum(Func<int, bool> dieukien)
        {
            int sum = 0;
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (dieukien(mat[i][j])) sum += mat[i][j];
                }
            }
            return sum;
        }

        public void DeleteRow(int k)
        {
            if (k < 0 || k >= Row) return;
            mat.RemoveAt(k);
        }

        public void DeleteCol(int k)
        {
            if (k < 0 || k >= Col) return;
            foreach (var row in mat)
            {
                row.RemoveAt(k);
            }
        }

        public struct Position
        {
            public int row, col;
            public Position(int r, int c)
            {
                row = r; col = c;
            }
        }

        public Position FindMaxValue()
        {
            int max = mat[0][0];
            Position maxPosition = new Position(0,0);
            for(int i = 0; i < Row; i++)
            {
                for(int j = 0; j < Col; j++)
                {
                    if (mat[i][j] > max)
                    {
                        maxPosition.row = i; maxPosition.col = j;
                    }
                }
            }
            return maxPosition;
        }
    }   

    

    internal class Program
    {
        static bool IsPrime(int x)
        {
            if (x < 2) return false;
            int root = (int)Math.Sqrt(x);
            for (int i = 2; i <= root; i++)
            {
                if (x % i == 0) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Nhap so dong va cot: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            MaTran mat = new MaTran(n, m);
            mat.Xuat();
            Console.WriteLine("Phan tu lon nhat: " + mat.MaxValue);
            Console.WriteLine("Phan tu nho nhat: " + mat.MinValue);
            Console.WriteLine("Dong co tong lon nhat: " + mat.MaxSumRowIndex);
            Console.WriteLine("Tong so khong phai so nguyen to: " +
                mat.Sum(x => !IsPrime(x)));
            
            Console.Write("Xoa hang thu: ");
            int k = Convert.ToInt32(Console.ReadLine());
            mat.DeleteRow(k);
            mat.Xuat();

            Console.WriteLine("Xoa cot co so lon nhat:");
            mat.DeleteCol(mat.FindMaxValue().col);
            mat.Xuat();
        }
    }
}
