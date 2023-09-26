using Base.BaseClasses.Enums;
using Infrastructure.GameStateMachine;
using Logic.BaseClasses;
using Logic.UI;
using Logic.UI.Windows;
using Services.OpenWindow;
using Services.StaticDataService;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class UIFactory
    {
        private readonly IStaticDataService staticData;
        private readonly IAssetProvider assetProvider;
        private IGameStateMachine stateMachine;

        private Transform uiRoot;

        public UIFactory(IStaticDataService staticData,
            IAssetProvider assetProvider)
        {
            this.staticData = staticData;
            this.assetProvider = assetProvider;
        }

        public void Init(IGameStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void CreateRootUI()
        {
            GameObject prefab = assetProvider.Get(AssetPath.UI_ROOT_PATH);
            uiRoot = Object.Instantiate(prefab).transform;
        }

        public GameObject CreatHUD()
        {
            GameObject prefab = assetProvider.Get(AssetPath.HUD_PATH);
            return Object.Instantiate(prefab);
        }

        public GameObject CreateGameOverWindow()
        {
            GameObject gameObject = CreateWindow(WindowType.GameOver);
            gameObject.GetComponent<GameOverWindow>().Construct(stateMachine);

            return gameObject;
        }

        public GameObject CreateLevelClearedWindow() => CreateWindow(WindowType.LevelCleared);

        public GameObject CreatePauseWindow(IWindowService windowService)
        {
            GameObject gameObject = CreateWindow(WindowType.Pause);
            var window = gameObject.GetComponent<PauseWindow>();
            window.SetWindowService(windowService);
            window.InitialiseButtons();

            return gameObject;
        }

        public GameObject CreateSettingsWindow(IWindowService windowService)
        {
            GameObject gameObject = CreateWindow(WindowType.Settings);
            var window = gameObject.GetComponent<SettingsWindow>();
            window.SetWindowService(windowService);
            window.InitialiseButtons();

            return gameObject;
        }

        private GameObject CreateWindow(WindowType windowType)
        {
            WindowStaticData config = staticData.ForWindow(windowType);
            return Object.Instantiate(config.Prefab, uiRoot);
        }
    }
}