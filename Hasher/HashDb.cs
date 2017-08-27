using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

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

        public void TreatFile(string fileName)
        {
            var h = new Hash();
            h.HashFile(fileName);
            List<Hash> files;
            if (!_files.TryGetValue(h.Length, out files))
            {
                files = new List<Hash>();
                _files.Add(h.Length, files);
            }
            files.Add(h);
            Console.WriteLine("=========\n{0}", h);
        }

        public void SaveToXml(string path)
        {
            var h0 = _files.Values.ToList();
            XmlSerializer xs = new XmlSerializer(typeof(List<List<Hash>>));
            using (StreamWriter wr = new StreamWriter(path))
            {
                xs.Serialize(wr, h0);
            }
        }
    }
}
