using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tourist
{
    class Date
    {
        public int D = 0;
        public int M = 0;
        public int Y = 0;
        public Date(int d, int m, int y)
        {
            if (CheckDate(d, m, y) == true)
            {
                D = d;
                M = m;
                Y = y;
            }
        }
        private bool CheckDate(int d, int m, int y)
        {
            if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12)
                if (d <= 31 && d >= 1) return true;
            if (m == 4 || m == 6 || m == 9 || m == 11)
                if (d <= 30 && d >= 1) return true;
            if (m == 2)
            {
                bool vis = false;
                if ((y % 400 == 0) || (y % 100 != 0 && y % 4 == 0)) vis = true;
                if (vis == true && d <= 29 && d >= 1) return true;
                if (vis == false && d <= 28 && d >= 1) return true;
            }
            return false;
        }
    }
}
