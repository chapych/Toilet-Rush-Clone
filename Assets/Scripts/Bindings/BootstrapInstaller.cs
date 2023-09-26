using Drawing;
using GameControl;
using Infrastructure;
using Infrastructure.Factories;
using Infrastructure.GameStateMachine;
using Logic.Drawing;
using Services.DrawingService;
using Services.DrawingStateMachine;
using Services.OpenWindow;
using Services.StaticDataService;
using Zenject;

namespace Bindings
{
	public class BootstrapInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindCoroutineRunner();
			BindSceneLoader();
			BindGameStateMachine();
			BindDrawingStateMachine();
			BindInitialFactory();
			BindGame();
			BindAssetProvider();
			BindInputService();
			BindLineCreator();
			BindDrawingStateFactory();
			BindGameFactory();
			BindSaveLoadService();
			BindProgressService();
			BindStaticService();
			BindUIFactory();
			BindDrawingService();
			BindWindowService();
		}

		private void BindWindowService()
		{
			Container.Bind<IWindowService>()
				.To<WindowService>()
				.AsSingle();
		}

		private void BindDrawingService()
		{
			Container.Bind<IDrawingService>()
				.To<DrawingService>()
				.AsSingle();
		}

		private void BindUIFactory()
		{
			Container.Bind<UIFactory>()
				.FromSubContainerResolve()
				.ByInstaller<UIFactoryInstaller>()
				.AsSingle();
		}

		private void BindInitialFactory()
		{
			Container.Bind<InitialiseFactory>()
				.AsSingle();
		}

		private void BindStaticService()
		{
			Container.Bind<IStaticDataService>()
				.To<StaticDataService>()
				.AsSingle();
		}

		private void BindProgressService()
		{
			Container.Bind<IProgressService>()
				.To<ProgressService>()
				.AsSingle();
		}

		private void BindSaveLoadService()
		{
			Container.Bind<ISaveLoadService>()
				.To<SaveLoadService>()
				.AsSingle();
		}

		private void BindSceneLoader()
		{
			Container.Bind<ISceneLoader>()
				.To<SceneLoader>()
				.AsSingle();
		}


		private void BindDrawingStateFactory()
		{
			Container.Bind<DrawingStateFactory>()
				.AsSingle();
		}

		private void BindGameFactory()
		{
			Container.Bind<GameFactory>()
				.AsSingle();
		}

		private void BindAssetProvider()
		{
			Container.Bind<IAssetProvider>()
				.To<AssetProvider>()
				.AsSingle();
		}

		private void BindLineCreator()
		{
			Container.Bind<ILineCreator>()
				.To<LineCreator>()
				.AsSingle();
		}

		private void BindDrawingStateMachine()
		{
			Container.Bind<IDrawingStateMachine>()
				.To<DrawingStateMachine>()
				.AsSingle();
		}

		private void BindInputService()
		{
			Container.Bind<IInputService>()
				.To<InputService>()
				.AsSingle();
		}

		private void BindGame()
		{
			Container.Bind<Game>()
				.AsSingle();
		}

		private void BindGameStateMachine()
		{
			Container.Bind<IGameStateMachine>()
				.FromSubContainerResolve()
				.ByInstaller<GameStateMachineInstaller>()
				.AsSingle();
		}
		

		private void BindCoroutineRunner()
		{
			Container.Bind<ICoroutineRunner>()
				.FromComponentInNewPrefabResource(AssetPath.COROUTINE_RUNNER_PATH)
				.AsSingle();
		}
	}
}
