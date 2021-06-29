using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    class Statistic
    {
        public double E1, E2, E3;
        public double D1, D2, D3;
        public Statistic(System.Drawing.Bitmap bitmap,MyCurrentSchema schema)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            MySchema[,] mySchema = new Lab[width,height];
            if (schema == MyCurrentSchema.hsl) mySchema = new HSL[width, height];
            if (schema == MyCurrentSchema.rgb) mySchema = new RGB[width, height];

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    if(schema == MyCurrentSchema.lab) mySchema[i, j] = new Lab(new LMS(new RGB(bitmap.GetPixel(i, j))));
                    if (schema == MyCurrentSchema.hsl) mySchema[i, j] = new HSL(new RGB(bitmap.GetPixel(i, j)));
                    if (schema == MyCurrentSchema.rgb) mySchema[i, j] = new RGB(bitmap.GetPixel(i, j));
                }
            } 
            double resl = 0.0;
            double resa = 0.0;
            double resb = 0.0;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height;j++)
                {
                    double[] temp = mySchema[i, j].ToMySchema();
                    resl += temp[0];
                    resa += temp[1];
                    resb += temp[2];
                }
            }
            int Length = width * height;
            E1 = resl / Length;
            E2 = resa / Length;
            E3 = resb / Length; 

            double sumOfD1 = 0.0;
            double sumOfD2 = 0.0;
            double sumOfD3 = 0.0;

            for (int y = 0; y < width; ++y)
            {
                for (int x = 0; x < height; ++x)
                {
                    var r = mySchema[y, x].ToMySchema();
                    double D1 = r[0] - E1;
                    double D2 = r[1] - E2;
                    double D3 = r[2] - E3;
                    sumOfD1 += Math.Pow(D1, 2);
                    sumOfD2 += Math.Pow(D2, 2);
                    sumOfD3 += Math.Pow(D3, 2);
                }
            }
            D1 = sumOfD1 / Length;
            D2 = sumOfD2 / Length;
            D3 = sumOfD3 / Length;
        }
    }
}
