using System;

namespace Bai03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Tạo và nhập ngày
            Day ngay = new Day();
            Console.WriteLine("Nhap ngay can kiem tra:");
            ngay.Nhap();

            //2. Kiểm tra ngày hợp lệ
            if (ngay.NgayHopLe)
            {
                Console.Write("Ngay hop le: ");
                ngay.Xuat();
            }
            else
            {
                Console.WriteLine("Ngay khong hop le");
            }
        }

        class Day
        {
            private int ngay, thang, nam;

            //Hàm nhập số nguyên
            private int NhapSoNguyen(string thongBao)
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

            //Nhập ngày tháng năm
            public void Nhap()
            {
                ngay = NhapSoNguyen("Ngay: ");
                thang = NhapSoNguyen("Thang: ");
                nam = NhapSoNguyen("Nam: ");
            }

            //In ra ngày/tháng/năm
            public void Xuat()
            {
                if (NgayHopLe)
                {
                    Console.Write("{0}/{1}/{2}", ngay, thang, nam);
                }
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
        }
    }
}
