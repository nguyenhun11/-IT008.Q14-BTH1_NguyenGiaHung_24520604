using System;
using System.Collections.Generic;


namespace Bai01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Nhập n và tạo mảng
            int n = NhapSoNguyen("1. Nhap n > 0: ");
            MangSoNguyen mang = new MangSoNguyen(n);

            //2. In ra mảng
            Console.WriteLine("2. Da tao mang");
            mang.Xuat();

            //3. Tổng các số lẻ
            Console.WriteLine("\n3. Tong so le: " + 
                mang.Sum(x => (x % 2 == 1)));
            
            //4. Đếm số nguyên tố
            Console.WriteLine("4. Dem so nguyen to: " +
                mang.Count(x => IsPrime(x)));
            
            //5. Tìm số chính phương nhỏ nhất
            Console.WriteLine("5. So chinh phuong nho nhat: " +
                mang.FindMin(x => IsSoChinhPhuong(x)));
        }

        public delegate bool DieuKien(int i);

        public class MangSoNguyen
        {
            List<int> array;

            public int Size
            {
                get
                {
                    return array.Count;
                }
            }

            //Khởi tạo n số ngẫu nhiên
            public MangSoNguyen(int n = 0)
            {
                CreateRandom(n);
            }

            //Tạo mảng ngẫu nhiên
            private void CreateRandom(int n, int minVal = -100, int maxVal = 100)
            {
                Random rnd = new Random();
                array = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    int r = rnd.Next(minVal, maxVal + 1);
                    array.Add(r);
                }
            }

            //Tính tổng các số thỏa điều kiện dk
            public int Sum(DieuKien dk)
            {
                int sum = 0;
                foreach (int x in array)
                {
                    if (dk(x)) sum += x;
                }
                return sum;
            }

            //Đếm các số thỏa điều kiện dk
            public int Count(DieuKien dk)
            {
                int count = 0;
                foreach (int x in array)
                {
                    if (dk(x)) count++;
                }
                return count;
            }

            //Tìm số nhỏ nhất thỏa điều kiện dk
            public int FindMin(DieuKien dk)
            {
                bool Found = false;
                int Result = -1;
                foreach (int x in array)
                {
                    if (dk(x))
                    {
                        if (!Found)
                        {
                            Result = x;
                            Found = true;
                        }
                        else
                        {
                            if (x < Result)
                            {
                                Result = x;
                            }
                        }

                    }
                }
                return Result;
            }

            //In ra mảng
            public void Xuat()
            {
                foreach (int x in array)
                {
                    Console.Write(x + " ");
                }
            }
        }

        //Kiểm tra số nguyên tố
        private static bool IsPrime(int x)
        {
            if (x <= 1) return false;
            int root = (int)Math.Sqrt(x);
            for (int i = 2; i <= root; i++)
            {
                if (x % i == 0) return false;
            }
            return true;
        }

        //Kiểm tra số chính phương
        private static bool IsSoChinhPhuong(int x)
        {
            int root = (int)Math.Sqrt(x);
            return root * root == x;
        }

        //Hàm nhập số nguyên
        static private int NhapSoNguyen(string thongBao)
        {
            int value;
            bool ok;
            do
            {
                Console.Write(thongBao);
                ok = int.TryParse(Console.ReadLine(), out value);
                if (!ok)
                {
                    Console.WriteLine("Gia tri khong hop le, vui long nhap lai!");
                }
            } while (!ok);
            return value;
        }
    }
}
