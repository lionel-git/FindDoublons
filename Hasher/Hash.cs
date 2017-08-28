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
        // File infos
        public String FullName { get; set; }
        public long Length { get; set; }

        public DateTime LastWriteTimeUtc { get; set; }
       
        // Hash controls
        public Guid ShortHash { get; set; }
        public Guid FullHash { get; set; }

        public DateTime CreationTimeUtc { get; set; }

        // Size of sample for short hash
        private static readonly int BlockSizeSH = 16;
        // Nb of samples for short hash
        private static readonly int NbBlockSH = 3;
        // Total size of buffer for Short Hash
        private static readonly int TotalBlockSizeSH = NbBlockSH * BlockSizeSH;

        public Hash()
        {
        }

        // Ne pas lire le fichier complet mais que les blocs utilises pour short Hash
        // Changer signature
        private void CalculateShortHash(byte[] content, MD5 md5Hash)
        {
            if (content.Length > TotalBlockSizeSH)
            {
                // Create digest from 3 sample blocks
                // |xxxxxBBxxxxxBBxxxxxBBxxxxx|
                // So 4x+3B=L
                // x = (L-3B)/4
                // Start(k) = x+k*(B+x)
                var digest = new byte[TotalBlockSizeSH];
                int x = (content.Length - TotalBlockSizeSH) / (NbBlockSH + 1);
                for (int k=0;k< NbBlockSH; k++)
                    Buffer.BlockCopy(content, x+k*(BlockSizeSH + x), digest, k*BlockSizeSH, BlockSizeSH);
                ShortHash = new Guid(md5Hash.ComputeHash(digest));
            }
            else
                ShortHash = FullHash;
        }

        public void HashFile(string path)
        {
            var fileInfo= new FileInfo(path);
            FullName = fileInfo.FullName;
            Length = fileInfo.Length;
            LastWriteTimeUtc = fileInfo.LastWriteTimeUtc;
            CreationTimeUtc = fileInfo.CreationTimeUtc;
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
            sb.AppendFormat("Name: {0}", FullName).AppendLine();
            sb.AppendFormat("Length: {0}", Length).AppendLine();
            sb.AppendFormat("LWT: {0}", LastWriteTimeUtc).AppendLine();
            sb.AppendFormat("CT: {0}", CreationTimeUtc).AppendLine();
            sb.AppendFormat("FullHash: {0}", FullHash).AppendLine();
            sb.AppendFormat("ShortHash: {0}", ShortHash);
            return sb.ToString();
        }




    }
}
