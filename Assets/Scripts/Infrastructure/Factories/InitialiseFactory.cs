using Character;
using Drawing;
using Logic.BaseClasses;
using Logic.GamePlay;
using Logic.Interfaces;
using Services.StaticDataService;
using Services.StaticDataService.StaticData;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class InitialiseFactory
    {
        private readonly Drawer.Factory drawerFactory;
        private readonly IStaticDataService staticDataService;
        
        public InitialiseFactory(Drawer.Factory drawerFactory, 
            IStaticDataService staticDataService)
        {
            this.drawerFactory = drawerFactory;
            this.staticDataService = staticDataService;
        }

        public Drawer CreateDrawer()
        {
            return drawerFactory.Create();
        }

        public IProperNumberOfElements CreateProperDrawnHandler(int maxTimeToBeInvoked)
        {
            return new ProperDrawnLines(maxTimeToBeInvoked);
        }

        public IProperNumberOfElements CreateProperReachedHandler(int maxTimeToBeInvoked)
        {
            return new ProperReachedFinishPoint(maxTimeToBeInvoked);
        }
        
        public GameObject CreateFinish(Kind kind, Vector2 position)
        {
            FinishStaticData finishData = staticDataService.ForFinish(kind);
            GameObject prefab = finishData.prefab;
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }

        public GameObject CreateCharacter(Kind kind, Vector2 position)
        {
            CharacterStaticData finishData = staticDataService.ForCharacter(kind);
            GameObject prefab = finishData.prefab;
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }
    }
}