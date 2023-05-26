using UnityEngine;
using Zenject;

public class SetupInstaller : MonoInstaller
{
	[SerializeField] private GameOverScreen gameOverScreen;
	[SerializeField] private DustControl dustControl;
	public override void InstallBindings()
    {
        BindGameOverScreen();
        BindGameOver();
        BindDustControl();
    }

    private void BindDustControl()
    {
        Container.Bind<DustControl>()
                         .FromInstance(dustControl)
                         .AsSingle();
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