using DataAccess.FileService;
using DataAccess.Settings;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAccess.Music
{
    public class ConfigMusicSource : IMusicSource
    {
        private readonly IFileService fileService;
        private readonly ISetting settings;

        public ConfigMusicSource(ISetting settings, IFileService fileService)
        {
            this.fileService = fileService;
            this.settings = settings;
        }

        public event EventHandler MusicChanged;

        public IEnumerable<MusicEntity> AvaiableMusic => from item in fileService.GetEnumerable<MusicEntity>(settings.MusicConfigPath)
                                                         where File.Exists(item.Path)
                                                         select item;

        public void AddMusic(MusicEntity entity)
        {
            fileService.Update(settings.MusicConfigPath, AvaiableMusic.Append(entity));
        }
    }
}