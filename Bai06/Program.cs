using System;
using System.Collections.Generic;

namespace Bai06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Nhập n dòng và m cột
            Console.WriteLine("1. Tao ma tran: ");
            int n = NhapSoNguyenDuong("Dong: ");
            int m = NhapSoNguyenDuong("Cot: ");

            //2. Tạo và in ra ma trận
            Console.WriteLine("\n2. Ma tran da tao:");
            MaTran mat = new MaTran(n, m);
            mat.Xuat();

            //3. Phần tử lớn nhất/nhỏ nhất
            Console.WriteLine("\n3a. Phan tu lon nhat: " + mat.MaxValue);
            Console.WriteLine("3b. Phan tu nho nhat: " + mat.MinValue);

            //4. Dòng có tổng lớn nhất
            Console.WriteLine("\n4. Dong co tong lon nhat: " + mat.MaxSumRowIndex);

            //5. Tổng các số không phải số nguyên tố
            Console.WriteLine("\n5. Tong so khong phai so nguyen to: " +
                mat.Sum(x => !IsPrime(x)));

            //6. Xóa hàng thứ k
            int k = NhapSoNguyenDuong("\n6. Xoa dong thu: ");
            mat.DeleteRow(k);
            Console.WriteLine("Ma tran da xoa dong " + k);
            mat.Xuat();

            //7. Xóa cột có số lớn nhất
            int colToDelete = mat.FindMaxValue().col;
            Console.WriteLine("\n7. Xoa cot co so lon nhat ({0}, cot {1}):",
                mat.MaxValue, colToDelete);
            mat.DeleteCol(colToDelete);
            Console.WriteLine("Ma tran da xoa cot {0}:", colToDelete);
            mat.Xuat();
        }

        //Hàm kiểm tra số nguyên tố
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

        //Hàm nhập số nguyên dương
        static private int NhapSoNguyenDuong(string thongBao)
        {
            int value;
            bool ok;
            do
            {
                Console.Write(thongBao);
                ok = int.TryParse(Console.ReadLine(), out value)
                    && value >= 0;
                if (!ok)
                {
                    Console.WriteLine("Gia tri khong hop le, vui long nhap lai!");
                }
            } while (!ok);
            return value;
        }

        public delegate bool DieuKien(int i);

        class MaTran
        {
            //Mảng 2 chiều
            private List<List<int>> mat;

            //Số hàng của ma trận
            public int Row
            {
                get
                {
                    return mat.Count;
                }
            }

            //Số cột của ma trận
            public int Col
            {
                get
                {
                    return Row > 0 ? mat[0].Count : 0;
                }
            }

            //Khởi tạo ma trận r hàng và c cột, giá trị ngẫu nhiên
            public MaTran(int r, int c, int minVal = -100, int maxVal = 100)
            {
                mat = new List<List<int>>();
                if (r <= 0 || c <= 0)
                {
                    return;
                }
                Random rnd = new Random();
                for (int i = 0; i < r; i++)
                {
                    List<int> _row = new List<int>();
                    for (int j = 0; j < c; j++)
                    {
                        int randomNum = rnd.Next(minVal, maxVal + 1);
                        _row.Add(randomNum);
                    }
                    mat.Add(_row);
                }
            }

            //In ma trận
            public void Xuat()
            {
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                    {
                        Console.Write(mat[i][j] + "\t");
                    }
                    Console.WriteLine();
                }
            }

            //Giá trị lớn nhất trong ma trận
            public int MaxValue
            {
                get
                {
                    if (Row == 0 || Col == 0) return -1;
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

            //Giá trị nhỏ nhất trong ma trận
            public int MinValue
            {
                get
                {
                    if (Row == 0 || Col == 0) return -1;
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

            //Tổng hàng thứ row
            private int SumRow(int row)
            {
                if (row < 0 || row > Row) return 0;
                int sum = 0;
                foreach (int i in mat[row])
                {
                    sum += i;
                }
                return sum;
            }

            //Hàng có tổng lớn nhất
            public int MaxSumRowIndex
            {
                get
                {
                    if (Row == 0 || Col == 0) return -1;
                    int index = 0;
                    int maxSum = SumRow(0);
                    for (int i = 1; i < Row; i++)
                    {
                        int sum = SumRow(i);
                        if (sum > maxSum)
                        {
                            index = i;
                            maxSum = sum;
                        }
                    }
                    return index;
                }
            }

            //Tính tổng các số thỏa điều kiện trong ma trận
            public int Sum(DieuKien dieukien)
            {
                int sum = 0;
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                    {
                        if (dieukien(mat[i][j]))
                            sum += mat[i][j];
                    }
                }
                return sum;
            }

            //Xóa dòng
            public void DeleteRow(int k)
            {
                if (k < 0 || k >= Row)
                {
                    Console.WriteLine("Ma tran khong thay doi!");
                    return;
                }
                mat.RemoveAt(k);
            }

            //Xóa cột
            public void DeleteCol(int k)
            {
                if (k < 0 || k >= Col)
                {
                    Console.WriteLine("Ma tran khong thay doi!");
                    return;
                }
                foreach (var row in mat)
                {
                    row.RemoveAt(k);
                }
            }

            //Struct vị trí trong ma trận
            public struct Position
            {
                public int row { get; private set; }
                public int col { get; private set; }
                public Position(int r, int c)
                {
                    row = r; col = c;
                }
            }

            //Tìm vị trí giá trị lớn nhất của ma trận
            public Position FindMaxValue()
            {
                if (Row == 0 || Col == 0) return new Position(-1, -1);
                int max = mat[0][0];
                Position maxPosition = new Position(0, 0);
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                    {
                        if (mat[i][j] > max)
                        {
                            max = mat[i][j];
                            maxPosition = new Position(i, j);
                        }
                    }
                }
                return maxPosition;
            }
        }
    }
}
