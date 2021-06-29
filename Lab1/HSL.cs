using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class HSL:MySchema
    {
        public double h { get; set; }
        public double s { get; set; }
        public double l { get; set; }

        public HSL(RGB rgb)
        {
            double[] hsl = rgbToHsl(rgb.R, rgb.G, rgb.B);
            h = hsl[0];
            s = hsl[1];
            l = hsl[2];
        }
        public static double[] rgbToHsl(int pR, int pG, int pB)
        {
            double r = pR / 255f;
            double g = pG / 255f;
            double b = pB / 255f;

            double max = (r > g && r > b) ? r : (g > b) ? g : b;
            double min = (r < g && r < b) ? r : (g < b) ? g : b;

            double h, s, l;
            l = (max + min) / 2.0f;

            if (max == min)
            {
                h = s = 0.0f;
            }
            else
            {
                double d = max - min;
                s = (l > 0.5f) ? d / (2.0f - max - min) : d / (max + min);

                if (r > g && r > b)
                    h = (g - b) / d + (g < b ? 6.0f : 0.0f);

                else if (g > b)
                    h = (b - r) / d + 2.0f;

                else
                    h = (r - g) / d + 4.0f;

                h /= 6.0f;
            }

            double[] hsl = { h, s, l };
            return hsl;
        }

        public double[] ToMySchema()
        {
            double[] res = new double[3];
            res[0] = h;
            res[1] = s;
            res[2] = l;

            return res;
        }

        public int[] ToRGB()
        {
            int[] res = RGB.hslToRgb(h, s, l);

            return res;
        }
    }
}
