using Caliburn.Micro;

using GMFriend.DependencyInjection;
using GMFriend.UserInterface.Dialogs.Startup;
using GMFriend.UserInterface.Shell;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GMFriend
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            await DisplayRootViewFor<ShellViewModel>();
            await ShowStartUpDialog();
        }

        private async Task ShowStartUpDialog()
        {
            var wm = new WindowManager();
            await wm.ShowDialogAsync(DI.Get<StartupViewModel>());
        }
    }
}