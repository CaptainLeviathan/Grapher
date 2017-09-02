using System;

namespace Grapher
{
    class Starter
    {
        TestFunc func;
        TestGraph[] graphs;
        public Plotter plot;

        public Starter()
        {
            func = new TestFunc();
            graphs = new TestGraph[1];
            graphs[0] = new TestGraph();
            graphs[0].func = func;
            plot = new Plotter(graphs);
            Console.Write(plot.ToString());
        }
        
        public static void Main(string[] args)
        {
            Starter pro = new Starter();
        }
    }
}