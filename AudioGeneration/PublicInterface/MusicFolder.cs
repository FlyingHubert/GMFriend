using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AudioGeneration.PublicInterface
{
    /// <summary>
    /// This class is used to represent a music folder in the application. The folder is specified
    /// by the given path in the constructor.
    /// </summary>
    public class MusicFolder : IDisposable
    {
        public MusicFolder(string path)
        {
            DirectoryWatcher.IncludeSubdirectories = true;
            DirectoryWatcher.Changed += OnDirectoryChanged;
            Path = path;
        }

        public event EventHandler FolderChanged;

        public IEnumerable<Track> CurrentTracks { get; private set; }

        public string Path
        {
            get => DirectoryWatcher.Path;
            set
            {
                if (!Directory.Exists(value))
                {
                    try
                    {
                        Directory.CreateDirectory(value);
                    }
                    catch (Exception ex)
                    {
                        throw new IOException($"Couldn't use/create '{value}' as folder path.", ex);
                    }
                }
                DirectoryWatcher.Path = value;
                Scan();
            }
        }

        public IEnumerable<MusicFolder> SubFolders { get; private set; } = Enumerable.Empty<MusicFolder>();
        public string Title { get; private set; } = "";
        private FileSystemWatcher DirectoryWatcher { get; } = new FileSystemWatcher();

        public void Dispose()
        {
            DirectoryWatcher.Dispose();
        }

        private void OnDirectoryChanged(object sender, FileSystemEventArgs e)
        {
            Scan();
        }

        private void Scan()
        {
            DirectoryInfo info = new DirectoryInfo(Path);
            Title = info.Name;

            SubFolders = from dir in info.GetDirectories() select new MusicFolder(dir.FullName);
            CurrentTracks = from file in info.GetFiles() select TrackPlayingManager.Load(file.FullName);

            FolderChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}