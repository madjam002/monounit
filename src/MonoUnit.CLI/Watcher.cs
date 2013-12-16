using System;
using System.IO;

namespace MonoUnit.CLI
{
    public class Watcher
    {
        public Watcher()
        {
        }

        public void Watch(string path)
        {
            if (!Directory.Exists(path))
            {
                path = Directory.GetDirectoryRoot(path);
            }
            FileSystemWatcher watcher = new FileSystemWatcher(path, "*.dll");
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime | NotifyFilters.FileName;

            watcher.Changed += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Created += OnChanged;

            watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("{0} changed", e.FullPath);
            if (Changed != null)
            {
                Changed();
            }
        }

        public delegate void ChangedHandler();
        public event ChangedHandler Changed;
    }
}

