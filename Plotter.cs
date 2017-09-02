using System;
using System.Text;

namespace Grapher
{
    class Plotter
    {
        public char[] slopChars = {'|',(char)92,'-','/'};
        public double charScalar = 1.5;
        public int textHight = 100;
        public int textWith = 100;
        public double windowHight = 20;
        public double windowWith = 20;
        private double xScaler;
        private double yScaler;
        private char[,] plot;
        private IGraph[] graphs;

        public Plotter(IGraph[] _graphs)
        {
            plot = new char[textWith, textHight];
            for (int x = 0; x < textWith; x++)
            {
                for (int y = 0; y < textHight; y++)
                {
                    plot[x,y] = ' ';
                }          
            }
            graphs = new IGraph [_graphs.Length];
            graphs = _graphs;
            xScaler = textWith/windowWith;
            yScaler = textHight/windowHight;
        }

        public override string ToString()
        {
            int y = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = graphs.Length - 1; i >= 0; i--)
            {
                for (int x = 0; x < textWith; x++)
                {
                    y = (int)graphs[i].func.func((double)(x / (charScalar * xScaler)));
                    if(y < textHight)
                        plot[x,y] = SlopChar((graphs[i].prime(1).func((double)x / (charScalar * xScaler)))*yScaler);
                }
            }

            for (int l = textHight - 1; l >= 0; l--)
            {
                  for (int x = 0; x < textWith; x++)
                {
                     sb.Append(plot[x,l]);
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        private char SlopChar(double slop)
        {
            int i = (int)((((2*Math.Atan(slop))/Math.PI)+ 0.9) * (slopChars.Length)/2);
            if(i >= slopChars.Length || i < 0)
            {
                Console.WriteLine("thats not good math in slopChar :.C");
            }
            return slopChars[i];
        }
    }
}