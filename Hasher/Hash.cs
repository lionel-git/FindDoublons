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

        static readonly int ShortHashSize = 16;

        public Hash()
        {
        }

        private void CalculateShortHash(byte[] content, MD5 md5Hash)
        {
            if (content.Length > 3 * ShortHashSize)
            {
                // Create digest from 3 sample blocks
                // |xxxxxBBxxxxxBBxxxxxBBxxxxx|
                // So 4x+3B=L
                // x = (L-3B)/4
                // Start(k) = x+k*(B+x)
                var digest = new byte[3 * ShortHashSize];
                int x = (content.Length - 3 * ShortHashSize) / 4;
                for (int k=0;k<3;k++)
                    Buffer.BlockCopy(content, x+k*(ShortHashSize+x), digest, k*ShortHashSize, ShortHashSize);
                ShortHash = new Guid(md5Hash.ComputeHash(digest));
            }
            else
                ShortHash = FullHash;
        }

        public void HashFile(string path)
        {
            FileInfo = new FileInfo(path);
            var content = File.ReadAllBytes(path);
            using (MD5 md5Hash = MD5.Create())
            {
                FullHash = new Guid(md5Hash.ComputeHash(content));
                CalculateShortHash(content, md5Hash);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Name: {0}", FileInfo.FullName).AppendLine();
            sb.AppendFormat("Length: {0}", FileInfo.Length).AppendLine();
            sb.AppendFormat("FullHash: {0}", FullHash).AppendLine();
            sb.AppendFormat("ShortHash: {0}", ShortHash).AppendLine();
            return sb.ToString();
        }




    }
}
