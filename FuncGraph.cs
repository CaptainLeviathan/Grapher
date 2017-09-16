using System;
using System.Collections.Generic;

namespace Grapher
{
    class FuncGraph : IGraphable
    {
        IMFunc mFunc;
        public FuncGraph(IMFunc mFunc)
        {
            this.mFunc = mFunc;
        }

        //returns completed charpoints to go and get placed on the graphwindow
        public List<CharPoint> getPoints (GraphWindow window)
        {
            List<CharPoint> ploted = new List<CharPoint>();

            IntPoint lastPoint = new IntPoint(-1,0);
            IntPoint point = new IntPoint(0,0);
            IntPoint nextPoint = new IntPoint(1,0);

            evalPoint(ref lastPoint);
            evalPoint(ref point);
            evalPoint(ref nextPoint);

            int deltaY;

            for (int x = 0; x < window.with; x++)
            {
                deltaY = nextPoint.y - lastPoint.y;

                if(point.y <= nextPoint.y && point.y >= lastPoint.y || point.y >= nextPoint.y && point.y <= lastPoint.y)
                {
                    if(deltaY >= -2 && deltaY <= 2)
                    {
                        //this is for the strate line case
                        //      ---
                        if(deltaY == 0)
                        {
                            ploted.Add(new CharPoint(point.x, point.y, '_'));
                        }
                        // this covers
                        // 
                        else if(deltaY <= 1 && deltaY >= -1)
                        {
                            if(point.y == lastPoint.y && deltaY == 1)
                            {
                                ploted.Add(new CharPoint(point.x, point.y, '/'));
                            }
                            else if(point.y == nextPoint.y && deltaY == -1)
                            {
                                ploted.Add(new CharPoint(point.x, point.y, (char)92));
                            }
                            else
                            {
                                ploted.Add(new CharPoint(point.x, point.y, '_'));
                            }
                        }
                        //this covers theses cases
                        //     /
                        //    /
                        //   /
                        else if(deltaY > 0)
                        {
                            ploted.Add(new CharPoint(point.x, point.y, '/'));
                        }
                        //this covers theses cases
                        //     \
                        //      \
                        //       \
                        else if(deltaY < 0)
                        {
                            ploted.Add(new CharPoint(point.x, point.y, (char)92));
                        }
                    }
                    else
                    {
                        //this is the intended behavior
                        //     _
                        //    /
                        //    |
                        //    |
                        // __/
                        //     
                        //    ._
                        //    |
                        //    |
                        // __/
                        if(deltaY > 0)
                        {
                            for (int y = lastPoint.y + 1; y < nextPoint.y; y++)
                            {
                                ploted.Add(new CharPoint(point.x, y, '|'));
                            }
                            if(point.y == nextPoint.y)
                            {
                                ploted.Add(new CharPoint(point.x, point.y, '.'));
                            }
                            else
                            {
                                ploted.Add(new CharPoint(point.x, point.y, '/'));                         
                            }
                        }
                        else if (deltaY < 0)
                        {
                            for (int y = lastPoint.y - 1; y > nextPoint.y; y--)
                            {
                                ploted.Add(new CharPoint(point.x, y, '|'));
                            }
                                if(point.y == nextPoint.y)
                            {
                                ploted.Add(new CharPoint(point.x, point.y, ' '));
                            }
                            else
                            {
                                ploted.Add(new CharPoint(point.x, point.y, '/'));                         
                            }
                        }
                    }
                }
                else
                {
                    ploted.Add(new CharPoint(point.x, point.y, '*'));
                }

                //points for next iteration
                lastPoint = point;
                point = nextPoint;
                nextPoint.x = x + 2;
                evalPoint(ref nextPoint);

            }
            
            return ploted;

            void evalPoint(ref IntPoint Ip)
            {
                GraphPoint gp = new GraphPoint(0, 0);
                gp = window.AsciiToGraphTrans(Ip);
                gp.y = mFunc.func(gp.x);
                Ip = window.GraphToAsciiTrans(gp);
            }
        }
    }
}