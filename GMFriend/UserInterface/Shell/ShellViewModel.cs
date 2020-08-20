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
    public class ShellViewModel
    {
        public ShellViewModel()
        {
            InitializeTabs();
        }

        public UserControl MusicTab { get; private set; }

        private UserControl Create<T>()
        {
            var type = typeof(T);
            var view = Activator.CreateInstance<T>() as UserControl;
            var fullTypeName = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name.EndsWith($"{type.Name}Model"))
                                    .FullName;
            view.DataContext = Activator.CreateInstance(null, fullTypeName);
            return view;
        }

        private void InitializeTabs()
        {
            MusicTab = Create<MusicView>();
        }
    }
}