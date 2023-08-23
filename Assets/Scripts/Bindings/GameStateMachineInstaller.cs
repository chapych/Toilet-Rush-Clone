using Character;
using Drawing;
using GameControl.GamePlay;
using Infrastructure.Factories;
using Infrastructure.GameStateMachine;
using Logic.GamePlay;
using Zenject;

namespace Bindings
{
    public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<IGameStateMachine, BootstrapGameState, BootstrapGameState.Factory>();
            Container.BindFactory<IGameStateMachine, LoadProgressGameState, LoadProgressGameState.Factory>();
            Container.BindFactory<IGameStateMachine, LoadLevelState, LoadLevelState.Factory>();
            
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        }
    }
    public class InitialiseFactoryInstaller : Installer<InitialiseFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<IProperNumberOfElements<CharacterObserver>, Drawer, Drawer.Factory>();
            Container.BindFactory<string, IProperNumberOfElements<CharacterObserver>, ProperNumberOfElementsHandlerFactory>()
                //.WithId(BootstrapInstaller.PROPER_DRAWN_HANDLER)
                .FromFactory<PrefabResourceFactory<IProperNumberOfElements<CharacterObserver>>>();
            // Container.BindFactory<string, IProperNumberOfElementsHandler, ProperNumberOfElementsHandlerFactory>()
            //     .WithId(BootstrapInstaller.PROPER_REACHED_HANDLER)
            //     .FromFactory<PrefabResourceFactory<IProperNumberOfElementsHandler>>();
            
            Container.Bind<InitialiseFactory>().AsSingle();
        }
    }
}