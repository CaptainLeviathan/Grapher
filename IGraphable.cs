using System;
using System.Collections.Generic;
namespace Grapher
{
    interface IGraphable
    {
        List<CharPoint> getPoints(GraphWindow window);
    }
}