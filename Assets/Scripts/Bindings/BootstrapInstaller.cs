using Drawing;
using GameControl;
using Infrastructure;
using Infrastructure.Factories;
using Infrastructure.GameStateMachine;
using Services.DrawingStateMachine;
using Services.StaticDataService;
using Zenject;

namespace Bindings
{
	public class BootstrapInstaller : MonoInstaller
	{
		public const string PROPER_DRAWN_HANDLER = "Proper Drawen Handler";
		public const string PROPER_REACHED_HANDLER = "Proper Reached Handler";

		//private IProperNumberOfElements<CharacterObserver> properDrawnLines;
		//[SerializeField] private IProperNumberOfElementsHandler properReachedFinishHandler;

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
		}

		private void BindUIFactory()
		{
			Container.Bind<UIFactory>()
				.AsSingle();
		}

		private void BindInitialFactory()
		{
			Container.Bind<InitialiseFactory>()
				.AsSingle();
			Container.BindFactory<Drawer, Drawer.Factory>();
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
				.FromComponentInNewPrefabResource(AssetPath.COROUTINE_RUNNER)
				.AsSingle();
		}
	}
}
