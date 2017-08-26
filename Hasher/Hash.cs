using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace Hasher
{
    public class Hash
    {
        FileInfo FileInfo { get; set; }

        Guid FullHash { get; set; }

        Guid ShortHash { get; set; }

        public Hash()
        {
        }

        public void HashFile(string path)
        {
            FileInfo = new FileInfo(path);
            var content = File.ReadAllBytes(path);
            using (MD5 md5Hash = MD5.Create())
            {
                FullHash = new Guid(md5Hash.ComputeHash(content));
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Name: {0}", FileInfo.FullName).AppendLine();
            sb.AppendFormat("FullHash: {0}", FullHash).AppendLine();
            return sb.ToString();
        }
    }
}
