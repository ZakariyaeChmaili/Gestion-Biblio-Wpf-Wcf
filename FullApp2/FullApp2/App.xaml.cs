using FullApp2.Modules.ModuleName;
using FullApp2.Services;
using FullApp2.Services.Interfaces;
using FullApp2.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace FullApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
