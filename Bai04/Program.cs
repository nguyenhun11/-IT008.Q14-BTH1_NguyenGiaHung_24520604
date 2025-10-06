using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai04
{
    class Day
    {
        int ngay, thang, nam;
        public void Nhap()
        {
            Console.WriteLine("Nhap ngay / thang / nam");
            ngay = Convert.ToInt32(Console.ReadLine());
            thang = Convert.ToInt32(Console.ReadLine());
            nam = Convert.ToInt32(Console.ReadLine());
            
            if (!KiemTra())
            {
                Console.WriteLine("Ngay khong hop le");
                Nhap();
            }
        }

        private bool IsNamNhuan()
        {
            return (nam % 4 == 0 && nam % 100 != 0) || (nam % 400 == 0);
        }

        private bool KiemTra()
        {
            if (thang < 1 || thang > 12) return false;
            if (ngay < 0) return false;
            
            if (ngay > DaysInMonth()) return false;
            return true;
        }

        public int DaysInMonth()
        {
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
            return maxNgay;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Day ngay = new Day();
            ngay.Nhap();
            Console.WriteLine("So ngay trong thang: " + ngay.DaysInMonth());
        }
    }
}
