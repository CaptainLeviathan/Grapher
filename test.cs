using System;

namespace Grapher
{
    class TestFunc : IMFunc
    {
        public double func(double x)
        {
            return x*x;
        }
    }
}
