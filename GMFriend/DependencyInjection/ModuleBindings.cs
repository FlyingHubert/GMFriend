using DataAccess;

using GMFriend.UserInterface.Tabs.Music;

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
            Bind<IPersistenceService>().To<SimplePersistenceService>();
            Bind<JsonFileService>().ToSelf();
            Bind<ISetting>().To<ConstantStringSettings>();
            Bind<IMusicSource>().To<MusicSource>();
            Bind<MusicViewModel>().ToSelf();
        }
    }
}