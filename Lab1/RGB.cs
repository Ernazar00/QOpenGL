using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class RGB : MySchema
    {
        public int R;
        public int G;
        public int B;
        public double r;
        public double g;
        public double b;
        public RGB(int r, int g, int b)
        {
            if (r < 3) R = 3;
            else if (r > 255) R = 255;
            else R = r;

            if (g < 3) G = 3;
            else if (g > 255) G = 255;
            else G = g;
            
            if (b < 3) B = 3;
            else if (b > 255) B = 255;
            else B = b;
        }
        public RGB(System.Drawing.Color color)
        {
            R = color.R; r = (double)R / 255.0;
            G = color.G; g = (double)G / 255.0;
            B = color.B; b = (double)B / 255.0;

            r = r * (232.0 / 255.0)+3.0/255.0;
            g = g * (232.0 / 255.0)+3.0/255.0;
            b = b * (232.0 / 255.0)+3.0/255.0;
        }
        public RGB(LMS lms)
        {
            r = (4.4679 * lms.L - 3.5873 * lms.M + 0.1193 * lms.S) * (255.0 / 232.0);
            g = (-1.2186 * lms.L + 2.3809 * lms.M - 0.1624 * lms.S) * (255.0 / 232.0);
            b = (0.0497 * lms.L - 0.2439 * lms.M + 1.2045 * lms.S) * (255.0 / 232.0);

            R = (int)Math.Round(r * 255.0, 0);
            G = (int)Math.Round(g * 255.0, 0);
            B = (int)Math.Round(b * 255.0, 0);
        }
        public RGB(HSL hsl)
        {
            int[] rgb = hslToRgb(hsl.h, hsl.s, hsl.l);
            R = rgb[0];
            G = rgb[1];
            B = rgb[2];
        }
        public static int[] hslToRgb(double h, double s, double l)
        {
            double r, g, b;

            if (s == 0f)
            {
                r = g = b = l; // achromatic
            }
            else
            {
                double q = l < 0.5f ? l * (1 + s) : l + s - l * s;
                double p = 2 * l - q;
                r = hueToRgb(p, q, h + 1f / 3f);
                g = hueToRgb(p, q, h);
                b = hueToRgb(p, q, h - 1f / 3f);
            }
            int[] rgb = { to255(r), to255(g), to255(b) };
            return rgb;
        }
        public static int to255(double v) { return (int)Math.Min(255, 256 * v); }

        public static double hueToRgb(double p, double q, double t)
        {
            if (t < 0f)
                t += 1f;
            if (t > 1f)
                t -= 1f;
            if (t < 1f / 6f)
                return p + (q - p) * 6f * t;
            if (t < 1f / 2f)
                return q;
            if (t < 2f / 3f)
                return p + (q - p) * (2f / 3f - t) * 6f;
            return p;
        }
        public int[] ToRGB()
        {
            return new int[] {R,G,B};
        }
        public double[] ToMySchema()
        {
            double[] res = new double[3];
            res[0] = r;
            res[1] = g;
            res[2] = b;

            return res;
        }
    }
}
