using System;

namespace Bai04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Tạo và nhập tháng, kiểm tra tháng
            int month;
            Console.Write("Nhap thang: ");
            do
            {
                month = int.Parse(Console.ReadLine());
                if (month < 1 || month > 12)
                {
                    Console.Write("Thang khong hop le, nhap lai thang: ");
                }
                else break;
            }
            while (true);

            //2. Tạo và nhập năm
            Console.Write("Nhap nam: ");
            int year = int.Parse(Console.ReadLine());

            //3. In ra số ngày trong tháng
            Console.WriteLine("So ngay trong thang {0} năm {1} là: {2}",
                month, year, DateTime.DaysInMonth(year, month));
        }
    }
}
