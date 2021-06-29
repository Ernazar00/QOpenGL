using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class LMS
    {
        public double L, M, S;
        public LMS(RGB rgb)
        {
            L = (0.3811 * (double)rgb.r + 0.5783 * (double)rgb.g + 0.0402 * (double)rgb.b);
            M = (0.1967 * (double)rgb.r + 0.7244 * (double)rgb.g + 0.0782 * (double)rgb.b);
            S = (0.0241 * (double)rgb.r + 0.1288 * (double)rgb.g + 0.8444 * (double)rgb.b);
        }

        public LMS(Lab lab)
        {
            L = Math.Pow(10, (0.5774 * lab.l + 0.4082 * lab.a + 1*0.7071 * lab.b));
            M = Math.Pow(10, (0.5774 * lab.l + 0.4082 * lab.a - 2*0.7071 * lab.b));
            S = Math.Pow(10, (0.5774 * lab.l - 0.4082 * lab.a + 0*0.7071 * lab.b));
        }
    }
}
