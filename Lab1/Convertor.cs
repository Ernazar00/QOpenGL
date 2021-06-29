using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Convertor
    {
        public static Bitmap resultBMP(MyImage sourse,MyImage target)
        {
            Bitmap res = (Bitmap)target.bitmap.Clone();

            int[,] r = new int[res.Width, res.Height];
            int[,] g = new int[res.Width, res.Height];
            int[,] b = new int[res.Width, res.Height];
            int min = 0;
            int max = 0;

            for (int i = 0; i < res.Width; i++)
            {
                for (int j = 0; j < res.Height; j++)
                {                   
                    Color color = res.GetPixel(i, j);
                    MySchema schema = new Lab(new LMS(new RGB(color)));
                    if (sourse.mySchema == MyCurrentSchema.hsl)
                    {
                        schema = new HSL(new RGB(color));
                        ((HSL)schema).h = sourse.statistic.E1 
                            + (((HSL)schema).h - target.statistic.E1) * (sourse.statistic.D1 / target.statistic.D1);
                        ((HSL)schema).s = sourse.statistic.E2
                            + (((HSL)schema).s - target.statistic.E2) * (sourse.statistic.D2 / target.statistic.D2);
                        ((HSL)schema).l = sourse.statistic.E3
                            + (((HSL)schema).l - target.statistic.E3) * (sourse.statistic.D3 / target.statistic.D3);
                    }
                    else if (sourse.mySchema == MyCurrentSchema.rgb)
                    {
                        schema = new RGB(color);
                        ((RGB)schema).r = sourse.statistic.E1
                            + (((RGB)schema).r - target.statistic.E1) * (sourse.statistic.D1 / target.statistic.D1);
                        ((RGB)schema).g = sourse.statistic.E2
                            + (((RGB)schema).g - target.statistic.E2) * (sourse.statistic.D2 / target.statistic.D2);
                        ((RGB)schema).b = sourse.statistic.E3
                            + (((RGB)schema).b - target.statistic.E3) * (sourse.statistic.D3 / target.statistic.D3);
                    }
                    else 
                    {
                        ((Lab)schema).l = sourse.statistic.E1 
                            + (((Lab)schema).l - target.statistic.E1) * (sourse.statistic.D1 / target.statistic.D1);
                        ((Lab)schema).a = sourse.statistic.E2 
                            + (((Lab)schema).a - target.statistic.E2) * (sourse.statistic.D2 / target.statistic.D2);
                        ((Lab)schema).b = sourse.statistic.E3 
                            + (((Lab)schema).b - target.statistic.E3) * (sourse.statistic.D3 / target.statistic.D3);                   
                    }


                    int[] rgb = schema.ToRGB();
                    r[i, j] = rgb[0];
                    g[i, j] = rgb[1];
                    b[i, j] = rgb[2];
                    //if (r[i, j] < min) min = r[i, j];
                    //if (g[i, j] < min) min = g[i, j];
                    //if (b[i, j] < min) min = b[i, j];
                    //if (r[i, j] > max) max = r[i, j];
                    //if (g[i, j] > max) max = g[i, j];
                    //if (b[i, j] > max) max = b[i, j];
                }
            }

            for (int i = 0; i < res.Width; i++)
            {
                for (int j = 0; j < res.Height; j++)
                {
                    int r0 = r[i, j];//(int)((double)(r[i, j] - min) * (255.0 / (max - min)));
                    int g0 = g[i, j];//(int)((double)(g[i, j] - min) * (255.0 / (max - min)));
                    int b0 = b[i, j];//(int)((double)(b[i, j] - min) * (255.0 / (max - min)));
                    if (r0 < 0) r0 = 0;if (r0 > 255) r0 = 255;
                    if (g0 < 0) g0 = 0;if (g0 > 255) g0 = 255;
                    if (b0 < 0) b0 = 0;if (b0 > 255) b0 = 255;
                    res.SetPixel(i,j,Color.FromArgb(r0,g0,b0));
                }
            }

            return res;
        }
    }
}