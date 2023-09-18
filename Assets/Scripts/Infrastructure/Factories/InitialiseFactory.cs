using Drawing;
using Finish;
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
            FinishStaticData data = staticDataService.ForFinish(kind);
            GameObject gameObject = Object.Instantiate(data.prefab, position, Quaternion.identity);

            gameObject.GetComponent<IFinishData>().Kind = kind;

            return gameObject;
        }

        public GameObject CreateCharacter(Kind kind, Vector2 position)
        {
            CharacterStaticData data = staticDataService.ForCharacter(kind);
            GameObject gameObject = Object.Instantiate(data.prefab, position, Quaternion.identity);

            gameObject.GetComponent<ILineHolder>().Kind = kind;

            return gameObject;
        }

    }
}