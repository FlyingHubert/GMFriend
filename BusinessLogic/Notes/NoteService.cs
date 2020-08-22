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
        private readonly IFileService fileService;
        private readonly ISetting setting;

        public NoteService(ISetting setting, IFileService fileService)
        {
            this.setting = setting;
            this.fileService = fileService;
        }

        public IEnumerable<Chapter> Chapters => CurrentGroup?.Chapters ?? Enumerable.Empty<Chapter>();
        public Group CurrentGroup { get; private set; }

        public void AddChapter(Chapter chapter)
        {
            throw new NotImplementedException();
        }

        public void AddNewGroup(Group group)
        {
            var newGroups = fileService.GetEnumerable<Group>(setting.GroupFilePath)
                                       .Append(group);
            fileService.Update(setting.GroupFilePath, newGroups);
        }

        public IEnumerable<Group> LoadGroups()
        {
            return fileService.GetEnumerable<Group>(setting.GroupFilePath);
        }

        public void SetCurrentGroup(Group selectedGroup)
        {
            CurrentGroup = selectedGroup;
        }
    }
}