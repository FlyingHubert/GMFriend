using BusinessLogic.Notes.Markdown;

using DataAccess;

using GMFriend.UserInterface.Tabs.Music;
using GMFriend.UserInterface.Tabs.Notes;

using Ninject.Modules;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMFriend.DependencyInjection
{
    public class ModuleBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IFileService>().To<JsonFileService>();
            Bind<ISetting>().To<Settings>();
            Bind<IMusicSource>().To<ConfigMusicSource>();
            Bind<MusicViewModel>().ToSelf();
            Bind<NotesViewModel>().ToSelf();
            Bind<IMarkdownService>().To<MarkdownService>();
        }
    }
}