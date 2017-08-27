using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hasher
{
    public class FileWalker
    {
        IFileTreater _fileTreater;

        public FileWalker(IFileTreater fileTreater)
        {
            _fileTreater = fileTreater;
        }

        public void WalkDirectory(string directoryPath)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(directoryPath);
            foreach (string fileName in fileEntries)
                _fileTreater.TreatFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(directoryPath);
            foreach (string subdirectory in subdirectoryEntries)
                WalkDirectory(subdirectory);
        }
    }
}
