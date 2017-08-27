using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hasher
{
    public class HashDb: IFileTreater
    {
        private Dictionary<long, List<Hash>> _files;

        public HashDb()
        {
            _files = new Dictionary<long, List<Hash>>();
        }

        public void TreatFile(string fileName)
        {
            var h = new Hash();
            h.HashFile(fileName);
            List<Hash> files;
            if (!_files.TryGetValue(h.FileInfo.Length, out files))
            {
                files = new List<Hash>();
                _files.Add(h.FileInfo.Length, files);
            }
            files.Add(h);
            Console.WriteLine("=========\n{0}", h);
        }
    }
}
