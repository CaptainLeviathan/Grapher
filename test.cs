using System;

namespace Grapher
{
    class TestGraph : IGraph
    {
        public IMFunc func{get; set;}
        public double domain{get; set;}
        public double range{get; set;}
        public IMFunc prime(int p)
        {
            return new Derivitive();
        }
    }

    class Derivitive : IMFunc
    {
        public double func(double x)
        {
            return x*2;
        }
    }

    class TestFunc : IMFunc
    {
        public double func(double x)
        {
            return x*x;
        }
    }
}
