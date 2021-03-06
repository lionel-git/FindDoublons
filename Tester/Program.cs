﻿using Hasher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Tester
{
    class Program
    {
        static readonly ILog Logger = LogManager.GetLogger("Tester");

        const string xmlFileName = "HashDb.xml";

        static void Main(string[] args)
        {
            try
            {
                Logger.Info("Starting Tester...");
                var h = new HashDb();
                var w = new FileWalker(h);
                w.WalkDirectory(@"c:\tmp");
                h.SaveToXml(xmlFileName);
                h.LoadFromXml(xmlFileName);

                Console.WriteLine(h);
               
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }

        }
    }
}
