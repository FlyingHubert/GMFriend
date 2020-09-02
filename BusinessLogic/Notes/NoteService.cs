using DataAccess;
using DataAccess.FileService;
using DataAccess.Notes.Group;
using DataAccess.Settings;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace BusinessLogic
{
    public class NoteService : INoteService
    {
        private readonly IPersistenceService persistence;

        private readonly ISetting setting;

        public NoteService(ISetting setting, IPersistenceService persistence)
        {
            this.setting = setting;
            this.persistence = persistence;
        }

        public IEnumerable<Chapter> Chapters => CurrentGroup?.Chapters ?? Enumerable.Empty<Chapter>();
        public Group CurrentGroup { get; private set; }

        public void AddChapter(Chapter chapter)
        {
            throw new NotImplementedException();
        }

        public void AddNewGroup(Group group)
        {
            persistence.AddToCollection(setting.GroupEntriesKey, group);
        }

        public IEnumerable<Group> LoadGroups()
        {
            return persistence.GetCollection<Group>(setting.GroupEntriesKey);
        }

        public void SetCurrentGroup(Group selectedGroup)
        {
            CurrentGroup = selectedGroup;
        }
    }
}