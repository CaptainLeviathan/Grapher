using System;

namespace Grapher
{
    interface IGraph
    {
        IMFunc func
        {
            get;
            set;
        }
        double domain
        {
            get;
            set;
        }
        double range
        {
            get;
            set;
        }

        //this function intigrates and differenteatios the main function and returns a new one
        IMFunc prime(int p);
    }
}