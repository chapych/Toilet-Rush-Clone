using Infrastructure.Factories;
using Logic.UI.Windows;
using Services.OpenWindow;
using Zenject;

namespace Bindings
{
    internal class UIFactoryInstaller : Installer<UIFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<UIFactory>()
                .AsSingle();
        }
    }
}