using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Hasher
{
    public class HashDb: IFileTreater
    {
        public enum Control { UpdateAll, CheckShortHash }

        private Dictionary<long, List<Hash>> _files;

        public Control _control;

        public HashDb()
        {
            _files = new Dictionary<long, List<Hash>>();
            _control = Control.UpdateAll;
        }

        public void SetControl(Control control)
        {
            _control = control;
        }

        private void AddHash(Hash hash)
        {
            List<Hash> files;
            if (!_files.TryGetValue(hash.Length, out files))
            {
                files = new List<Hash>();
                _files.Add(hash.Length, files);
            }
            files.Add(hash);
        }

        public void TreatFile(string fileName)
        {
            var hash = new Hash();
            hash.HashFile(fileName);
            AddHash(hash);
            Console.WriteLine("=========\n{0}", hash);
        }

        public void SaveToXml(string path)
        {
            var h0 = _files.Values.ToList();
            var xs = new XmlSerializer(typeof(List<List<Hash>>));
            using (StreamWriter wr = new StreamWriter(path))
            {
                xs.Serialize(wr, h0);
            }
        }

        public void LoadFromXml(string path)
        {
            var xs = new XmlSerializer(typeof(List<List<Hash>>));
            List<List<Hash>> hashes;
            using (XmlReader reader = XmlReader.Create(path))
            {
                hashes = (List<List<Hash>>)xs.Deserialize(reader);
            }
            // TODO: Recreer le dico depuis hashes
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Nb distinct lengths: {0}", _files.Count).AppendLine();
            foreach (var files in _files)
            {
                sb.AppendFormat("****** Length: {0} (Count: {1})", files.Key, files.Value.Count).AppendLine();
                foreach (var file in files.Value)
                {
                    sb.Append("=======\n").AppendFormat(file.ToString()).AppendLine();
                }
            }
            return sb.ToString();
        }
    }
}
