using System;
using System.Collections.Generic;
using System.Linq;
using Base.BaseClasses.Enums;
using Infrastructure.Factories;
using Logic.BaseClasses;
using Logic.Character;
using Logic.Drawing;
using Logic.Finish;
using Logic.GamePlay;
using Services.OpenWindow;
using Services.StaticDataService;
using Services.StaticDataService.Points;
using Services.StaticDataService.StaticData;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Infrastructure.GameStateMachine
{
    public class InitGamePlayState : IPayloadedEnteringState<string>
    {
	    private readonly IDrawingService drawingService;
	    private readonly IWindowService windowService;
	    private readonly IStaticDataService staticDataService;
	    private readonly InitialiseFactory initFactory;

	    private GameObject[] instantiatedCharacters;
	    private GameObject[] instantiatedFinishes;

	    public InitGamePlayState(IDrawingService drawingService,
		    IWindowService windowService,
		    IStaticDataService staticDataService,
		    InitialiseFactory initFactory)
	    {
		    this.drawingService = drawingService;
		    this.windowService = windowService;
		    this.staticDataService = staticDataService;
		    this.initFactory = initFactory;
	    }
        public void Enter(string name)
        {
	        LevelStaticData levelStaticData = staticDataService.ForLevel(name);

            InitGameWorld(levelStaticData);
            TurnOnDrawing();
        }

        private void InitGameWorld(LevelStaticData levelStaticData)
        {
	       instantiatedCharacters =
		        InitialiseFromData(levelStaticData.characterPoints, initFactory.CreateCharacter);
	       instantiatedFinishes =
		        InitialiseFromData(levelStaticData.finishPoints, initFactory.CreateFinish);

	       IProperNumberOfElements properDrawnHandler =
		        CreateProperNumberOfDrawnElementsHandler(instantiatedCharacters.Length);
	       IProperNumberOfElements properReachedHandler = CreateProperReachedHandler(instantiatedCharacters.Length);

	       InitialiseGameOverScenario();
	       InitialiseProperDrawnHandler(properDrawnHandler);
	       InitialiseProperReachedHandler(properReachedHandler);
        }

        private void InitialiseGameOverScenario()
		{
			IWindowService windowServiceLocal = windowService;
			bool hasCalled = false;
			foreach (GameObject character in instantiatedCharacters)
			{
				character.GetComponent<CollisionObserver>().OnCollision +=
					delegate
					{
						if (hasCalled) return;
						hasCalled = true;
						windowServiceLocal.Open(WindowType.GameOver);
					};
			}
		}

		private void TurnOnDrawing() => drawingService.TurnOnDrawing();

		private IProperNumberOfElements CreateProperNumberOfDrawnElementsHandler(int length)
			=> initFactory.CreateProperDrawnHandler(length);

		private void InitialiseProperDrawnHandler(IProperNumberOfElements properDrawnHandler)
		{
			drawingService.OnDrawn += properDrawnHandler.OnOneElementHandler;
			foreach (GameObject character in instantiatedCharacters)
			{
				var lineHolder = character.GetComponent<ILineHolder>();
				var moveComponent = character.GetComponent<IMovable>();
				properDrawnHandler.OnAllElements += () => moveComponent.StartMovement(
					lineHolder
						.Line
						.Points
						.ToQueue(),
					lineHolder.ShortenLineByPoint
					);
			}
			properDrawnHandler.OnAllElements += () => drawingService.OnDrawn -= properDrawnHandler.OnOneElementHandler;
		}

		private IProperNumberOfElements CreateProperReachedHandler(int length)
			=> initFactory.CreateProperReachedHandler(length);

		private void InitialiseProperReachedHandler(IProperNumberOfElements properReachedHandler)
		{
			Action onOneElementHandler = properReachedHandler.OnOneElementHandler;
			IWindowService windowServiceLocal = windowService;

			foreach (GameObject finishData in instantiatedFinishes)
			{
				var target = finishData.GetComponent<ITarget>();
				target.OnTargetReached += onOneElementHandler;
				properReachedHandler.OnAllElements += () => target.OnTargetReached -= onOneElementHandler;
			}
			properReachedHandler.OnAllElements += () => windowServiceLocal.Open(WindowType.LevelCleared);
		}
		private GameObject[] InitialiseFromData(IEnumerable<Point> levelData, Func<Kind, Vector2, GameObject> creatingFunc)
			=> levelData.Select(x => creatingFunc(x.kind, x.position))
					.ToArray();

		private void CleanUpFor(GameObject[] toDestroy)
		{
			foreach (GameObject gameObject in toDestroy) Object.Destroy(gameObject);
		}

		public void Exit()
        {
	        drawingService.TurnOffDrawing();
	        CleanUpFor(instantiatedCharacters);
	        CleanUpFor(instantiatedFinishes);
        }
		public class Factory : PlaceholderFactory<IGameStateMachine, InitGamePlayState>{}
    }
}