using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
	public const string GAMEOVER_PANEL_ID = "Game Over";
	public const string LEVELCLEARED_PANEL_ID = "Level Cleared";

	[SerializeField] private PanelBase gameOver;
	[SerializeField] private PanelBase levelCleared;
	public override void InstallBindings()
	{
		BindGameOver();
		BindLevelCleared();
	}

	private void BindLevelCleared()
	{
		// Container.Bind<IPanel>()
		// 		 .WithId(LEVELCLEARED_PANEL_ID)
		// 		 .To<LevelSucceedPanel>()
		// 		 .AsSingle();
				 
		Container.Bind<IPanel>()
				 .WithId(LEVELCLEARED_PANEL_ID)
				 .FromInstance(levelCleared as LevelSucceedPanel)
				 .AsCached();
		// Container.BindInterfacesAndSelfTo<LevelCleared>()
		// 		 //.WithConcreteId(LEVELCLEARED_PANEL_ID)
		// 		 .FromInstance(LevelCleared)
		// 		 .AsSingle();
	}

	private void BindGameOver()
	{
		Container.Bind<IPanel>()
				 .WithId(GAMEOVER_PANEL_ID)
				 .FromInstance(gameOver as GameOverPanel)
				 .AsCached();
	}
}