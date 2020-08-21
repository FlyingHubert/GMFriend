using Caliburn.Micro;

using GMFriend.DependencyInjection;
using GMFriend.UserInterface.Tabs.Music;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GMFriend.UserInterface.Shell
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public ShellViewModel()
        {
            Items.Add(DI.Get<MusicViewModel>());
        }
    }
}