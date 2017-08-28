using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hasher;

namespace FindDoublons
{
    public class Dir
    {
        public Dir(string path)
        {
            Path = path;
        }
        public string Path { get; set; }
    }

    public class HashDBViewModel
    {
        public HashDBViewModel()
        {
            Hashes = new List<Hash>();
            Hashes.Add(new Hash());

            Directories = new List<Dir>();
            Directories.Add(new Dir(@"c:\tmp2"));

        }

        public List<Hash> Hashes { get; set; }
        public List<Dir> Directories { get; set; }

    }
}
