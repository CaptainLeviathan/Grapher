using System;
using System.Collections.Generic;
namespace Grapher
{
    class GraphWindow : Window
    {

        //theses are the propertys that describe the graph window in the equlidean plane
        public double graphWith; 
        public double graphHight;
        public double graphCenterX;
        public double graphCenterY; 

        public List<IGraphable> graphs;

        public GraphWindow(int with, int hight, int centerX, int centerY) : base(with, hight, centerX, centerY)
        {
         graphWith = 10; 
         graphHight = 12;
         graphCenterX = 0;
         graphCenterY = 0;
         graphs = new List<IGraphable>();
        }

        public GraphWindow(int with, int hight, int centerX, int centerY, double graphWith, double graphHight, double graphCenterX, double graphCenterY) : base(with, hight, centerX, centerY)
        {
         this.graphWith = graphWith; 
         this.graphHight = graphHight;
         this.graphCenterX = graphCenterX;
         this.graphCenterY = graphCenterY;
         graphs = new List<IGraphable>();
        }


        public IntPoint GraphToAsciiTrans(GraphPoint gPoint)
        {
            return new IntPoint(
            //Transform Equetions for converting somthing a function out puts to something that can be more esily ploted in ascii
            Convert.ToInt32(((gPoint.x - graphCenterX)*(Convert.ToDouble(with)/graphWith) / WindowManager.charAspectRatio) - with/2), 
            Convert.ToInt32(((gPoint.y - graphCenterY)*(Convert.ToDouble(hight)/graphHight)) + hight/2) 
            );
        }

        public GraphPoint AsciiToGraphTrans(IntPoint intPoint)
        {
            return new GraphPoint(
            //Transform Equations for converting a point on the Ascii graph to somthing that a function can take
            (Convert.ToDouble((intPoint.x - with/2) * WindowManager.charAspectRatio) / (Convert.ToDouble(with) / graphWith)) + graphCenterX,
            (Convert.ToDouble(intPoint.y - hight/2) / (Convert.ToDouble(hight) / graphHight) + graphCenterY)
            );
        }

        //taking the points maid by the IGraphble class and is pasting them on to our grid of ascii charictors
        override public void getPoints()
        {
            charPoints = new List<CharPoint>();

            for (int i = 0; i < graphs.Count; i++)
            {
                charPoints.AddRange(graphs[i].getPoints(this));
            }
        }
    }
}