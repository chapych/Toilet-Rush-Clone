using Drawing;
using Infrastructure.Factories;
using Logic.Drawing;
using Services.StaticDataService;
using Zenject;

namespace Infrastructure.GameStateMachine
{
	public class BootstrapGameState : IEnteringState
	{
		private const string INITIAL = "Initial";
		private const string LEVEL_NAME = "Game";
		
		private readonly IGameStateMachine stateMachine;
		private readonly ISceneLoader sceneLoader;
		private readonly IInputService input;
		private readonly IStaticDataService staticDataService;
		private readonly IDrawingService drawingService;

		public BootstrapGameState(IGameStateMachine stateMachine,
			ISceneLoader sceneLoader,
			IInputService input,
			IStaticDataService staticDataService,
			IDrawingService drawingService)
		{
			this.stateMachine = stateMachine;
			this.sceneLoader = sceneLoader;
			this.input = input;
			this.staticDataService = staticDataService;
			this.drawingService = drawingService;
		}

		private void InitialiseServices()
		{
			InitialiseInputService();
			InitialiseStaticDataService();
			InitialiseDrawingService();
		}

		private void InitialiseDrawingService()
		{
			drawingService.Initialise();
		}

		private void InitialiseStaticDataService()
		{
			staticDataService.Load();
		}

		private void InitialiseInputService()
		{
			input.Initialise();
		}
		public void Enter()
		{
			sceneLoader.Load(INITIAL, InitialiseServices);
			stateMachine.Enter<LoadLevelState, string>(LEVEL_NAME);
		}

		public void Exit()
		{ }

		public class Factory : PlaceholderFactory<IGameStateMachine, BootstrapGameState>
		{
			
		}
	}
}
