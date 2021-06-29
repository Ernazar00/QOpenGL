using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{

    public enum MyCurrentSchema { rgb,hsl,lab};
    interface MySchema
    {
        double[] ToMySchema();
        int[] ToRGB();

    }
}
