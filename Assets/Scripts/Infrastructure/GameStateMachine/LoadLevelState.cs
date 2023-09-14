using System;
using System.Collections.Generic;
using System.Linq;
using Base.Interfaces;
using Finish;
using Infrastructure.Factories;
using Logic.BaseClasses;
using Logic.Character;
using Logic.Drawing;
using Logic.GamePlay;
using Logic.UI;
using Services.OpenWindow;
using Services.StaticDataService;
using Services.StaticDataService.Points;
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
		private readonly IStaticDataService staticDataService;
		private readonly IDrawingService drawingService;
		private readonly IWindowService windowService;
		private readonly InitialiseFactory initFactory;
		private readonly UIFactory uiFactory;

		public LoadLevelState(IGameStateMachine stateMachine,
			ISceneLoader sceneLoader,
			InitialiseFactory initFactory,
			UIFactory uiFactory,
			IStaticDataService staticDataService,
			IDrawingService drawingService)
		{
			this.stateMachine = stateMachine;
			this.sceneLoader = sceneLoader;
			this.initFactory = initFactory;
			this.uiFactory = uiFactory;
			this.staticDataService = staticDataService;
			this.drawingService = drawingService;
		}

		public void Enter(string scene) => sceneLoader.Load(scene, Init);

		private void Init()
		{
			drawingService.TurnOnDrawing();
			InitUI();
			InitGameWorld();
		}

		private void InitUI() => uiFactory.CreateRootUI();

		private void InitGameWorld()
		{
			LevelStaticData levelData = GetLevelStaticData();

			var instantiatedCharacters =
				InitialiseFromData(levelData.characterPoints, initFactory.CreateCharacter);
			var instantiatedFinishes = 
				InitialiseFromData(levelData.finishPoints, initFactory.CreateFinish);
			
			UIObserver uiObserver = CreateUIObserver();
			IProperNumberOfElements properDrawnHandler = CreateProperNumberOfDrawnElementsHandler(instantiatedCharacters.Length);
			IProperNumberOfElements properReachedHandler = CreateProperReachedHandler(instantiatedCharacters.Length);

			InitialiseProperDrawnHandler(properDrawnHandler, instantiatedCharacters);
			//InitialiseProperReachedHandler(properReachedHandler);
			//InitialiseUIObserver(instantiatedCharacters, uiObserver);
		}

		private IProperNumberOfElements CreateProperNumberOfDrawnElementsHandler(int length)
			=> initFactory.CreateProperDrawnHandler(length);

		private void InitialiseProperDrawnHandler(IProperNumberOfElements properDrawnHandler,
			IEnumerable<GameObject> instantiatedCharacters)
		{
			drawingService.OnDrawn += properDrawnHandler.OnOneElementHandler;
			foreach (GameObject character in instantiatedCharacters)
			{
				var lineHolder = character.GetComponent<ILineHolder>();
				properDrawnHandler.OnAllElements += ()=>character.GetComponent<MoveComponent>()
					.StartMovement(lineHolder.Line.Points.ConvertToQueue(),
						lineHolder.ShortenLineByPoint);

			}

			properDrawnHandler.OnAllElements += () => drawingService.OnDrawn -= properDrawnHandler.OnOneElementHandler;
		}

		private IProperNumberOfElements CreateProperReachedHandler(int length)
			=> initFactory.CreateProperReachedHandler(length);

		private void InitialiseProperReachedHandler(IProperNumberOfElements properReachedHandler,
			IEnumerable<IFinishData> instantiatedFinishes)
		{
			// foreach (IFinishData finishData in instantiatedFinishes)
			// {
			// 	finishData.
			// }
			properReachedHandler.OnAllElements += () => Debug.Log("Success");
		}

		private LevelStaticData GetLevelStaticData()
			=> staticDataService.ForLevel(SceneManager.GetActiveScene().name);


		private GameObject[] InitialiseFromData(IEnumerable<Point> levelData, Func<Kind, Vector2, GameObject> creatingFunc)
			=> levelData.Select(x => creatingFunc(x.kind, x.position))
					.ToArray();

		private UIObserver CreateUIObserver() => initFactory.CreateUIObserver(uiFactory);

		// private void InitialiseUIObserver(CharacterData[] instantiatedCharacters, UIObserver uiObserver)
		// {
		// 	foreach (CollisionObserver observer in instantiatedCharacters.Select(x => x.GetComponent<CollisionObserver>()))
		// 	{
		// 		//observer.OnRaised += uiObserver.CreateGameOver;
		// 	}
		// }

		public void Exit()
		{
			drawingService.TurnOffDrawing();
		}

		public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState> { }
	}
}