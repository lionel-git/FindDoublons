using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hasher
{
    public class Hash
    {
        public Hash()
        {
        }

        public void HashFile(string path)
        {
            var f=File.ReadAllBytes(path);

        }
    }
}
