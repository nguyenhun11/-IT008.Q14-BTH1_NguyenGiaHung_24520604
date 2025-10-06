using System;

namespace Bai02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Nhập số nguyên dương
            Console.Write("Nhap so nguyen n > 0: ");
            int n = Convert.ToInt32(Console.ReadLine());

            //2. In ra tổng số nguyên tố nhỏ hơn n
            Console.WriteLine("Tong so nguyen to nho hon n: " 
                + TongSoNguyenToNhoHon(n));
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

        //Tính tổng số nguyên tố bé hơn n
        static int TongSoNguyenToNhoHon(int n)
        {
            int sum = 0;
            for (int i = 2; i < n; i++)
            {
                if (IsPrime(i)) sum += i;
            }
            return sum;
        }
    }
}
