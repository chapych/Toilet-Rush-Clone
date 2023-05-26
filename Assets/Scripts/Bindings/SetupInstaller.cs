using UnityEngine;
using Zenject;

public class SetupInstaller : MonoInstaller
{
	[SerializeField] private GameOverScreen gameOverScreen;
	public override void InstallBindings()
	{
		BindGameOverScreen();
		BindGameOver();
		
	}

	private void BindGameOverScreen()
	{
		Container.Bind<GameOverScreen>()
						 .FromInstance(gameOverScreen)
						 .AsSingle();
	}

	private void BindGameOver()
	{
		Container.Bind<GameOver>()
				 .AsSingle();
	}
}