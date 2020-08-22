using DataAccess.Notes.Group;

using System.Collections.Generic;

namespace BusinessLogic
{
    public interface INoteService
    {
        IEnumerable<Chapter> Chapters { get; }

        void AddChapter(Chapter chapter);

        void AddNewGroup(Group group);

        IEnumerable<Group> LoadGroups();

        void SetCurrentGroup(Group selectedGroup);
    }
}