using UnityEngine;
using Zenject;

public class SetupInstaller : MonoInstaller
{
	public override void InstallBindings()
    {
        BindGameOver();
    }

    private void BindGameOver()
    {
        Container.Bind<GameOver>()
                         .AsSingle();
    }
}