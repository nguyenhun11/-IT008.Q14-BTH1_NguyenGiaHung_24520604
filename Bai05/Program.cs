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
                            ngay = NhapSoNguyen("Ngay: ");
                            if (!NgayHopLe) Console.WriteLine("Ngay khong hop le!");
                            else break;
                        }
                        while (true);

                        thang = NhapSoNguyen("Thang: ");
                        if (!NgayHopLe)
                        {
                            thang = 1;
                            Console.WriteLine("Thang khong hop le!");
                        }
                        else break;
                    }
                    while (true);

                    nam = NhapSoNguyen("Nam: ");
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

            //Kiểm tra ngày hợp lệ
            public bool NgayHopLe
            {
                get
                {
                    if (thang < 1 || thang > 12) return false;
                    if (ngay < 1) return false;
                    int namCheck;//Chuyển năm hợp lệ sử dụng Datetime
                    if (nam < 1 || nam > 9999)
                    {
                        namCheck = ((nam % 9999) + 9999) % 9999;
                        if (namCheck == 0) namCheck = 9999;
                    }
                    else
                    {
                        namCheck = nam;
                    }
                    int maxNgay = DateTime.DaysInMonth(namCheck, thang);
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
}
