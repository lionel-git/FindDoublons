using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Hashes = new ObservableCollection<Hash>();
            Hashes.Add(new Hash());

            Directories = new ObservableCollection<Dir>();
            Directories.Add(new Dir(@"c:\tmp2"));

        }

        public ObservableCollection<Hash> Hashes { get; set; }
        public ObservableCollection<Dir> Directories { get; set; }

    }
}
