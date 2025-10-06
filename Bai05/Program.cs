using System;
using System.Collections.Generic;

namespace Bai05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap ngay: ");
            Day ngay = new Day();
            ngay.Nhap();
            Console.WriteLine("Thu trong tuan la " + ngay.DayInWeek);
        }
    }

    class Day
    {
        private int ngay, thang, nam;

        //Nhập ngày tháng năm
        public void Nhap()
        {
            thang = 1;
            nam = 4;
            do
            {

                do
                {

                    do
                    {
                        Console.Write("Ngay: ");
                        ngay = Convert.ToInt32(Console.ReadLine());
                        if (!NgayHopLe) Console.WriteLine("Ngay khong hop le!");
                        else break;
                    }
                    while (true);

                    Console.Write("Thang: ");
                    thang = Convert.ToInt32(Console.ReadLine());
                    if (!NgayHopLe)
                    {
                        thang = 1;
                        Console.WriteLine("Thang khong hop le!");
                    }
                    else break;
                }
                while (true);

                Console.Write("Nam: ");
                nam = Convert.ToInt32(Console.ReadLine());
                if (!NgayHopLe)
                {
                    thang = 1;
                    nam = 4;
                    Console.WriteLine("Nam khong hop le!");
                }
                else break;
            }
            while (true);
        }

        //Kiểm tra năm nhuận
        private bool IsNamNhuan
        {
            get
            {
                return (nam % 4 == 0 && nam % 100 != 0) || (nam % 400 == 0);
            }
        }

        //Kiểm tra ngày hợp lệ
        private bool NgayHopLe
        {
            get
            {
                if (thang < 1 || thang > 12) return false;
                if (ngay < 1) return false;
                int maxNgay;
                switch (thang)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        maxNgay = 31; break;
                    case 2:
                        if (IsNamNhuan) maxNgay = 29;
                        else maxNgay = 28;
                        break;
                    default:
                        maxNgay = 30; break;
                }
                if (ngay > maxNgay) return false;
                return true;
            }
        }

        //Danh sách ngày trong tuần
        private Dictionary<int, string> dayInWeek = new Dictionary<int, string>()
        {
            {0, "Chu nhat" },
            {1, "Thu hai" },
            {2, "Thu ba" },
            {3, "Thu tu" },
            {4, "Thu nam" },
            {5, "Thu sau" },
            {6, "Thu bay" }
        };
        
        //Trả về ngày trong tuần
        public string DayInWeek
        {
            get
            {
                DateTime date = new DateTime(nam, thang, ngay);
                int thu = (int)date.DayOfWeek;
                return dayInWeek[thu];
            }
        }
    }
}
