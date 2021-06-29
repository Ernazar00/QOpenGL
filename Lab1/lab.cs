using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Lab : MySchema
    {
        public double l { get; set; }
        public double a { get; set; }
        public double b { get; set; }
        public Lab(LMS lms)
        {
            l = 0.5774 * (Math.Log10((lms.L * lms.M * lms.S)));
            a = 0.4082 * (Math.Log10(lms.L * lms.M)) - 0.8162 * Math.Log10(lms.S);
            b = 0.7071 * (Math.Log10(lms.L / lms.M));
        }
        public double[] ToMySchema()
        {
            double[] res = new double[3];
            res[0] = l;
            res[1] = a;
            res[2] = b;

            return res;
        }

        public int[] ToRGB()
        {
            LMS lms = new LMS(this);
           double r = (4.4679 * lms.L - 3.5873 * lms.M + 0.1193 * lms.S) * (255.0 / 232.0);
           double g = (-1.2186 * lms.L + 2.3809 * lms.M - 0.1624 * lms.S) * (255.0 / 232.0);
           double b = (0.0497 * lms.L - 0.2439 * lms.M + 1.2045 * lms.S) * (255.0 / 232.0);

           int R = (int)Math.Round(r * 255.0, 0);
           int G = (int)Math.Round(g * 255.0, 0);
           int B = (int)Math.Round(b * 255.0, 0);
            
            return new int[] {R,G,B };
        }
    }
}
