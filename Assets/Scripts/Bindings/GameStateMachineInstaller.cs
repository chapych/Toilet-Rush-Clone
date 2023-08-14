using Drawing;
using Infrastructure.Factories;
using Infrastructure.GameStateMachine;
using UnityEngine;
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
            Container.BindFactory<Drawer, Drawer.Factory>();
            Container.BindFactory<>()

            
            Container.Bind<InitialiseFactory>().AsSingle();
        }
    }
}