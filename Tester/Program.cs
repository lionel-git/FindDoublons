﻿using Hasher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var h = new Hash();
                h.HashFile(@"c:\tmp\zz2.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
