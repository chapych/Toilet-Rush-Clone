using Character;
using Logic.GamePlay;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class SetupInstaller : MonoInstaller
{
	public const string FINISH_HOLDER_ID = "Finish holder";
	[FormerlySerializedAs("dustControl")] [SerializeField] private ParticlesOnCollision particlesOnCollision;
	[SerializeField] private GameObject finishPointsHolder;
	public override void InstallBindings()
	{
		BindGameOver();
		BindDustControl();
		BindFinishPointsHolder();
		BindLevelCleared();
	}
	private void BindLevelCleared()
	{
		Container.Bind<LevelCleared>()
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
		Container.Bind<ParticlesOnCollision>()
						 .FromInstance(particlesOnCollision)
						 .AsSingle();
	}


	private void BindGameOver()
	{
		Container.Bind<GameOver>()
				 .AsSingle();
	}
}