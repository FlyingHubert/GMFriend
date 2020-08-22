using BusinessLogic.Notes.Markdown;

using DataAccess.FileService;
using DataAccess.Music;
using DataAccess.Settings;

using GMFriend.Properties;
using GMFriend.UserInterface.Tabs.Music;
using GMFriend.UserInterface.Tabs.Notes;

using Ninject.Modules;

namespace GMFriend.DependencyInjection
{
    public class ModuleBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IFileService>().To<JsonFileService>();
            Bind<ISetting>().To<ConstantSetting>();
            Bind<IMusicSource>().To<ConfigMusicSource>();
            Bind<MusicViewModel>().ToSelf();
            Bind<NotesViewModel>().ToSelf();
            Bind<IMarkdownService>().To<MarkdownService>();
        }
    }
}