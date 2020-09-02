using DataAccess.Music;
using DataAccess.Settings;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAccess
{
    public class MusicSource : IMusicSource
    {
        private readonly IPersistenceService persistence;
        private readonly ISetting settings;

        public MusicSource(ISetting settings, IPersistenceService persistence)
        {
            this.persistence = persistence;
            this.settings = settings;
        }

        public event EventHandler MusicChanged;

        public IEnumerable<MusicEntity> AvaiableMusic => from item in persistence.GetCollection<MusicEntity>(settings.MusicEntriesKey)
                                                         where File.Exists(item.Path)
                                                         select item;

        public void AddMusic(MusicEntity entity)
        {
            persistence.AddToCollection(settings.MusicEntriesKey, entity);
            MusicChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}