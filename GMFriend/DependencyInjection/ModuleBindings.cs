using BusinessLogic;
using BusinessLogic.Notes.Markdown;

using DataAccess;
using DataAccess.FileService;
using DataAccess.Music;
using DataAccess.Settings;

using GMFriend.Properties;
using GMFriend.UserInterface.Tabs.Music;
using GMFriend.UserInterface.Tabs.Notes;
using GMFriend.UserInterface.Tabs.Notes.Text;

using Ninject.Modules;

namespace GMFriend.DependencyInjection
{
    public class ModuleBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IPersistenceService>().To<SimplePersistenceService>();
            Bind<JsonFileService>().ToSelf();
            Bind<ISetting>().To<ConstantSetting>();
            Bind<IMusicSource>().To<MusicSource>();
            Bind<MusicViewModel>().ToSelf();
            Bind<NotesViewModel>().ToSelf();
            Bind<IMarkdownService>().To<MarkdownService>();
            Bind<INoteService>().To<NoteService>();
            Bind<TextNoteViewModel>().ToSelf();
        }
    }
}