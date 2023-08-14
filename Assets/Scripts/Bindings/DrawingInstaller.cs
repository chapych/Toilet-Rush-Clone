using System.Collections;
using System.Collections.Generic;
using Drawing;
using Services.DrawingStateMachine;
using UnityEngine;
using Zenject;

public class DrawingInstaller : MonoInstaller
{
	[SerializeField] private InputService inputControler;
	[SerializeField] private DrawingStateMachine context;
	[SerializeField] private Line prefab;
	[SerializeField] private ICoroutineRunner coroutineRunner;
	
	public override void InstallBindings()
    {
        BindCoroutineRunner();
    }

    private void BindCoroutineRunner()
    {
        Container.Bind<ICoroutineRunner>()
                 .FromInstance(coroutineRunner)
                 .AsSingle();
    }
	
}
