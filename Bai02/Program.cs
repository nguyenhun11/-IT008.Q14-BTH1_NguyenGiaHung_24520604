using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai02
{
    internal class Program
    {
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

        static int TongSoNguyenToNhoHon(int n)
        {
            int sum = 0;
            for(int i = 2; i < n; i++)
            {
                if (IsPrime(i)) sum += i;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Tong so nguyen to nho hon n: " + TongSoNguyenToNhoHon(n));
        }
    }
}
