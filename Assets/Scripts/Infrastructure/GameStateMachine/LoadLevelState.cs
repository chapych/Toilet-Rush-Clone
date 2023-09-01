using System;
using System.Collections.Generic;
using System.Linq;
using Character;
using Drawing;
using Finish;
using Infrastructure.Factories;
using Logic.BaseClasses;
using Logic.GamePlay;
using Logic.Interfaces;
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
		private readonly IWindowService windowService;
		private readonly InitialiseFactory initFactory;
		private readonly UIFactory uiFactory;

		public LoadLevelState(IGameStateMachine stateMachine,
			ISceneLoader sceneLoader,
			InitialiseFactory initFactory,
			UIFactory uiFactory,
			IStaticDataService staticDataService)
		{
			this.stateMachine = stateMachine;
			this.sceneLoader = sceneLoader;
			this.initFactory = initFactory;
			this.uiFactory = uiFactory;
			this.staticDataService = staticDataService;
		}

		public void Enter(string scene)
		{
			sceneLoader.Load(scene, Init);
		}

		private void Init()
		{
			InitUI();
			InitGameWorld();
		}

		private void InitUI() => uiFactory.CreateRootUI();

		private void InitGameWorld()
		{
			LevelStaticData levelData = GetLevelStaticData();

			var instantiatedCharacters =
				InitialiseFromData<CharacterData>(levelData.characterPoints, initFactory.CreateCharacter);
			var instantiatedFinishes = 
				InitialiseFromData<FinishData>(levelData.finishPoints, initFactory.CreateFinish);
			
			Drawer drawer = CreateDrawer();
			UIObserver uiObserver = CreateUIObserver();
			IProperNumberOfElements properReachedHandler = CreateProperReachedHandler(instantiatedCharacters,
				instantiatedFinishes);
			IProperNumberOfElements properDrawnHandler = CreateProperNumberOfElementsHandler(instantiatedCharacters,
				drawer);

			InitialiseProperDrawnHandler(properDrawnHandler as IObservable, instantiatedCharacters);
			InitialiseProperReachedHandler(properReachedHandler as IObservable);
			InitialiseDrawer(drawer);
			InitialiseUIObserver(instantiatedCharacters, uiObserver);
		}

		private static void InitialiseUIObserver(CharacterData[] instantiatedCharacters, UIObserver uiObserver)
		{
			foreach (CollisionObserver observer in instantiatedCharacters.Select(x => x.GetComponent<CollisionObserver>()))
			{
				observer.OnRaised += uiObserver.CreateGameOver;
			}
		}

		private UIObserver CreateUIObserver() => initFactory.CreateUIObserver(uiFactory);

		private Drawer CreateDrawer() => initFactory.CreateDrawer();

		private IProperNumberOfElements CreateProperNumberOfElementsHandler(CharacterData[] instantiatedCharacters,
			IObservable drawer)
		{
			int length = instantiatedCharacters.Length;
			IProperNumberOfElements properDrawnHandler = initFactory.CreateProperDrawnHandler(length);
			properDrawnHandler.Subscribe(drawer);
			return properDrawnHandler;
		}

		private IProperNumberOfElements CreateProperReachedHandler(CharacterData[] instantiatedCharacters,
						FinishData[] instantiatedFinishes)
		{
			int length = instantiatedCharacters.Length;
			var finishReached = instantiatedFinishes
				.Select(x => x.GetComponent<IObservable>())
				.ToArray();
			IProperNumberOfElements properReachedHandler = initFactory.CreateProperReachedHandler(length);
			foreach (IObservable finish in finishReached)
			{
				properReachedHandler.Subscribe(finish);
			}
			return properReachedHandler;
		}

		private LevelStaticData GetLevelStaticData()
			=> staticDataService.ForLevel(SceneManager.GetActiveScene().name);

		private void InitialiseProperReachedHandler(IObservable properReachedHandler)
			=> properReachedHandler.OnRaised += new LevelCleared().OnAllElementsHandle;

		private void InitialiseProperDrawnHandler(IObservable properDrawnHandler, CharacterData[] instantiatedCharacters)
		{
			foreach (CharacterData data in instantiatedCharacters)
			{
				var characterObserver = new CharacterDrawingObserver(data);
				properDrawnHandler.OnRaised += characterObserver.OnAllDrawnHandler;
			}
		}

		private void InitialiseDrawer(Drawer drawer) => drawer.Initialise();

		private T[] InitialiseFromData<T>(List<Point> levelData, Func<Kind, Vector2, GameObject> creatingFunc)
		{
			return levelData.Select(x => creatingFunc(x.kind, x.position)
					.GetComponent<T>())
				.ToArray();
		}

		public void Exit() { }
		public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState> { }
	}
}