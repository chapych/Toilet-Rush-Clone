using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
	public const string GAMEOVER_PANEL_ID = "Game Over";
	public const string LEVELCLEARED_PANEL_ID = "Level Cleared";

	[SerializeField] private GameOverPanel gameOver;
	[SerializeField] private LevelSucceedPanel levelCleared;
	public override void InstallBindings()
	{
		BindGameOver();
		BindLevelCleared();
	}

	private void BindLevelCleared()
	{				 
		Container.Bind<IPanel>()
				 .WithId(LEVELCLEARED_PANEL_ID)
				 .FromInstance(levelCleared)
				 .AsCached();
	}

	private void BindGameOver()
	{
		Container.Bind<IPanel>()
				 .WithId(GAMEOVER_PANEL_ID)
				 .FromInstance(gameOver)
				 .AsCached();
	}
}