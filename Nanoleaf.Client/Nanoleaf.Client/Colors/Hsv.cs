using System;

namespace Nanoleaf.Client.Colors
{
    internal class Hsv
    {
        public int H { get; set; }

        public int S { get; set; }

        public int V { get; set; }

        public Hsv(double h, double s, double v)
        {
            H = (int)Math.Round(h);
            S = (int)Math.Round(s);
            V = (int)Math.Round(v);
        }
    }
}