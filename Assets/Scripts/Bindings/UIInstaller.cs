using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
	public const string GAMEOVER_PANEL_ID = "Game Over";
	public const string LEVELCLEARED_PANEL_ID = "Level Cleared";
	public const string GUI_PANEL_ID = "GUI";


	[SerializeField] private GameOverPanel gameOver;
	[SerializeField] private LevelSucceedPanel levelCleared;
	[SerializeField] private GUIPanel gui;
	public override void InstallBindings()
    {
        BindGameOver();
        BindLevelCleared();
        BindGUI();
    }

    private void BindGUI()
    {
        Container.Bind<IPanel>()
         .WithId(GUI_PANEL_ID)
         .FromInstance(gui)
         .AsCached();
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
	// 	Container.Bind<IPanel>()
	// 			 .WithId(GAMEOVER_PANEL_ID)
	// 			 .FromInstance(gameOver)
	// 			 .AsCached();
	}
}