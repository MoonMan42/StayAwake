using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StayAwake
{
    class TestConsole
    {
        static void Main(String [] args)
        {
            PowerHelper.ForceSystemAwake();
            Console.ReadKey();
        }
    }
}
