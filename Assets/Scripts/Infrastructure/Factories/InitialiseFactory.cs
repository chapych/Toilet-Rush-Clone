using Drawing;
using Logic.BaseClasses;
using Logic.Character;
using Logic.Drawing;
using Logic.GamePlay;
using Logic.UI;
using Services.StaticDataService;
using Services.StaticDataService.StaticData;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class InitialiseFactory
    {
        private readonly IStaticDataService staticDataService;
        
        public InitialiseFactory(IStaticDataService staticDataService)
        {
            this.staticDataService = staticDataService;
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
            GameObject gameObject = Object.Instantiate(finishData.prefab, position, Quaternion.identity);

            gameObject.GetComponent<ILineHolder>().Kind = kind;

            return gameObject;
        }

        public UIObserver CreateUIObserver(UIFactory factory) => new UIObserver(factory);
    }
}