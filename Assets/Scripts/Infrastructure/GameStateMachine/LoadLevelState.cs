using Infrastructure.Factories;
using Logic.UI;
using Services.OpenWindow;
using Services.StaticDataService.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.GameStateMachine
{
	public class LoadLevelState : IPayloadedEnteringState<string>
	{
		private readonly IGameStateMachine stateMachine;
		private readonly ISceneLoader sceneLoader;
		private readonly IWindowService windowService;
		private readonly UIFactory uiFactory;
		private string sceneName;

		public LoadLevelState(IGameStateMachine stateMachine,
			ISceneLoader sceneLoader,
			UIFactory uiFactory,
			IWindowService windowService)
		{
			this.stateMachine = stateMachine;
			this.sceneLoader = sceneLoader;
			this.uiFactory = uiFactory;
			this.windowService = windowService;
		}

		public void Enter(string scene)
		{
			sceneName = scene;
			sceneLoader.Load(scene, Init);
		}

		private void Init()
		{
			InitUI();

			stateMachine.Enter<InitGamePlayState, string>(sceneName);
		}

		private void InitUI()
		{
			uiFactory.CreateRootUI();
			CreateInitHub();
		}

		private void CreateInitHub()
		{
			GameObject hud = uiFactory.CreatHUD();
			var openButtons = hud.GetComponentsInChildren<OpenButton>();
			foreach (OpenButton openButton in openButtons)
				openButton.Construct(windowService);
		}


		public void Exit() {}

		public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState> { }
	}
}