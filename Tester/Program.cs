using Hasher;
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

        static void ProcessFile(string fileName)
        {
            Console.WriteLine($"File: {fileName}");
        }

        static void Main(string[] args)
        {
            try
            {
                Logger.Info("Starting Tester...");
                var w = new FileWalker(ProcessFile);
                w.WalkDirectory(@"c:\tmp");

                var h = new Hash();
                h.HashFile(@"c:\tmp\zz2.txt");
                Console.WriteLine(h);
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }

        }
    }
}
