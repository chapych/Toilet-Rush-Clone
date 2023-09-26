using Drawing;
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
            Container.BindFactory<IGameStateMachine, InitGamePlayState, InitGamePlayState.Factory>();

            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        }
    }
}