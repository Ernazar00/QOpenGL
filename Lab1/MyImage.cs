using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class MyImage
    {
        string dir;
        public System.Drawing.Bitmap bitmap { get; set; }
        public Statistic statistic;
        public MyCurrentSchema mySchema = MyCurrentSchema.lab;
        public MyImage(string dir)
        {
            this.dir = dir;
            bitmap = new System.Drawing.Bitmap(dir);
            statistic = new Statistic(bitmap,mySchema);
        }
        public int GetWidth()
        {
            if (bitmap != null) return bitmap.Width;
            else return 0;
        }
        public int GetHeight()
        {
            if (bitmap != null) return bitmap.Height;
            else return 0;
        }
    }
}
