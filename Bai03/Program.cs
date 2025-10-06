using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai03
{
    internal class Program
    {
        class Day
        {
            int ngay, thang, nam;
            public void Nhap()
            {
                ngay = Convert.ToInt32(Console.ReadLine());
                thang = Convert.ToInt32(Console.ReadLine());
                nam = Convert.ToInt32(Console.ReadLine());
            }

            private bool IsNamNhuan()
            {
                return (nam % 4 == 0 && nam % 100 != 0) || (nam % 400 == 0);
            }

            public bool KiemTra()
            {
                if (thang < 1 || thang > 12) return false;
                if (ngay < 0) return false;
                int maxNgay = 0;
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
                        if (IsNamNhuan()) maxNgay = 29;
                        else maxNgay = 28;
                        break;
                    default:
                        maxNgay = 30; break;
                }
                if (ngay > maxNgay) return false;
                return true;
            }
        }

        static void Main(string[] args)
        {
            Day ngay = new Day();
            ngay.Nhap();
            if (ngay.KiemTra())
            {
                Console.WriteLine("Ngay hop le");
            }
            else
            {
                Console.WriteLine("Ngay khong hop le");
            }
        }
    }
}
