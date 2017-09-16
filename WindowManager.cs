using System;
using System.Text;

namespace Grapher
{
    static class WindowManager
    {
        //this stuff is still mostly for testing
        public static GraphWindow graphWindow;
        public static double charAspectRatio = 1;

        static WindowManager()
        {
            graphWindow = new GraphWindow(200,25,0,0,100,100,0,0);
        }
        public static void render()
        {
            Console.Clear();

            graphWindow.getPoints();

            for (int i = 0; i < graphWindow.charPoints.Count; i++)
            {
                int x = graphWindow.charPoints[i].x;
                int y = graphWindow.hight - graphWindow.charPoints[i].y;

                if(x <= graphWindow.with && x >= 0 && y <= graphWindow.hight && y >= 0 )
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(graphWindow.charPoints[i].symbol);
                }
            }
            Console.SetCursorPosition(0, graphWindow.hight);
        }
    }
}