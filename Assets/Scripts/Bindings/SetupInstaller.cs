using UnityEngine;
using Zenject;

public class SetupInstaller : MonoInstaller
{
	public const string FINISH_HOLDER_ID = "Finish holder";
	[SerializeField] private GameOverScreen gameOverScreen;
	[SerializeField] private DustControl dustControl;
	[SerializeField] private GameObject finishPointsHolder;
	[SerializeField] private LevelCleared levelCleared;
	public override void InstallBindings()
	{
		BindGameOverScreen();
		BindGameOver();
		BindDustControl();
		BindFinishPointsHolder();
		BindLevelCreated();
	}

	private void BindLevelCreated()
	{
		Container.Bind<LevelCleared>()
						 .FromInstance(levelCleared)
						 .AsSingle();
	}

	private void BindFinishPointsHolder()
	{
		Container.Bind<GameObject>()
						 .WithId(FINISH_HOLDER_ID)
						 .FromInstance(finishPointsHolder)
						 .AsSingle();
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