using DataAccess.Notes.Group;

using System.Collections.Generic;

namespace BusinessLogic
{
    public interface INoteService
    {
        IEnumerable<Group> LoadGroups();
        void SetCurrentGroup(Group selectedGroup);
        void AddNewGroup(Group group);
    }
}