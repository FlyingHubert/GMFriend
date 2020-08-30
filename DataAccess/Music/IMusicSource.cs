using System;
using System.Collections.Generic;

namespace DataAccess.Music
{
    public interface IMusicSource
    {
        event EventHandler MusicChanged;

        IEnumerable<MusicEntity> AvaiableMusic { get; }

        void AddMusic(MusicEntity entity);
    }
}