using System;

namespace Bai04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Tạo và nhập tháng, kiểm tra tháng
            int month;
            do
            {
                month = NhapSoNguyen("Nhap thang: ");
                if (month < 1 || month > 12)
                {
                    Console.WriteLine("Thang khong hop le!");
                }
                else break;
            }
            while (true);

            //2. Tạo và nhập năm
            int year = NhapSoNguyen("Nhap nam: ");
            int namCheck;//Chuyển năm hợp lệ sử dụng Datetime
            if (year < 1 || year > 9999)
            {
                namCheck = ((year % 9999) + 9999) % 9999;
                if (namCheck == 0) namCheck = 9999;
            }
            else
            {
                namCheck = year;
            }

            //3. In ra số ngày trong tháng
            Console.WriteLine("So ngay trong thang {0} năm {1} là: {2}",
                month, year, DateTime.DaysInMonth(namCheck, month));
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
