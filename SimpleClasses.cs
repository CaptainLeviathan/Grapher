using System;

namespace Grapher
{
    class IntPoint
    {
        public int x;
        public int y;

        public IntPoint(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class CharPoint : IntPoint
    {
        public char symbol;
        public CharPoint(int x,int y) : base(x,y)
        {
            symbol = ' ';
        }
        public CharPoint(int x, int y, char c) : base(x,y)
        {
            symbol = c;
        }
    }
    
    class GraphPoint
    {
        public double x;
        public double y;
        public GraphPoint(double x,double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}