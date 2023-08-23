using Bindings;
using Character;
using Drawing;
using GameControl.GamePlay;
using Logic.GamePlay;
using Logic.Interfaces;
using Services.StaticDataService;
using Services.StaticDataService.StaticData;
using UnityEngine;
using Zenject;

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

        public IProperNumberOfElements CreateProperDrawnHandler(int max, IObservable observable)
        {
            return new ProperDrawnLines(max, observable);
        }

        public IProperNumberOfElements CreateProperReachedHandler(int max, IObservable[] observables)
        {
            return new ProperReachedFinishPoint(max, observables);
        }
        
        public GameObject CreateFinish(Kind kind, Vector2 position)
        {
            FinishStaticData finishData = staticDataService.ForFinish(kind);
            GameObject prefab = finishData.prefab;
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }

        public GameObject CreateCharacter(Kind kind, Vector2 position)
        {
            var finishData = staticDataService.ForCharacter(kind);
            GameObject prefab = finishData.prefab;
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }
    }
}