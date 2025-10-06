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

            //Nhập ngày tháng năm
            public void Nhap()
            {
                Console.Write("Ngay: ");
                ngay = Convert.ToInt32(Console.ReadLine());
                Console.Write("Thang: ");
                thang = Convert.ToInt32(Console.ReadLine());
                Console.Write("Nam: ");
                nam = Convert.ToInt32(Console.ReadLine());
            }

            //In ra ngày/tháng/năm
            public void Xuat()
            {
                if (NgayHopLe)
                {
                    Console.Write("{0}/{1}/{2}", ngay, thang, nam);
                }
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
            public bool NgayHopLe
            {
                get
                {
                    if (thang < 1 || thang > 12) return false;
                    if (ngay < 0) return false;
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
        }
    }
}
