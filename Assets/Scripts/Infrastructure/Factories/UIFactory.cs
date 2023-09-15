using Base.BaseClasses.Enums;
using Logic.BaseClasses;
using Services.StaticDataService;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class UIFactory
    {
        private readonly IStaticDataService staticData;
        private readonly IAssetProvider assetProvider;

        private Transform uiRoot;

        public UIFactory(IStaticDataService staticData, IAssetProvider assetProvider)
        {
            this.staticData = staticData;
            this.assetProvider = assetProvider;
        }

        public void CreateRootUI()
        {
            GameObject prefab = assetProvider.Get(AssetPath.UI_ROOT_PATH);
            uiRoot = Object.Instantiate(prefab).transform;
        }

        public GameObject CreateGameOverWindow()
        {
            WindowStaticData config = staticData.ForWindow(WindowType.GameOver);
            return Object.Instantiate(config.Prefab, uiRoot);
        }

        public GameObject CreateLevelClearedWindow()
        {
            WindowStaticData config = staticData.ForWindow(WindowType.LevelCleared);
            return Object.Instantiate(config.Prefab, uiRoot);
        }
    }
}