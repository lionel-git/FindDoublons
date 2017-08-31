using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

    public class HashDBViewModel : INotifyPropertyChanged
    {
        public HashDBViewModel()
        {
            Hashes = new ObservableCollection<Hash>();
            Hashes.Add(new Hash());

            Directories = new ObservableCollection<Dir>();
            Directories.Add(new Dir(@"c:\tmp2"));
            Directories.Add(new Dir(@"c:\tmp3"));
            Directories.Add(new Dir(@"c:\tmp35"));
        }

       

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Hash> _hashes;
        public ObservableCollection<Hash> Hashes
        {
            get { return _hashes; }
            set
            {
                if (_hashes != value)
                {
                    _hashes = value;
                    NotifyPropertyChanged();
                }
            }
        }

        //TODO: prop changed
        public ObservableCollection<Dir> Directories { get; set; }

    }
}
