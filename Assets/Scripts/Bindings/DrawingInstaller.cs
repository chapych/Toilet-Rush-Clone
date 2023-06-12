using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DrawingInstaller : MonoInstaller
{
	[SerializeField] private DrawingContext context;
	
	
	public override void InstallBindings()
	{
		BindDrawingContext();
	}
	
	public void BindDrawingContext()
	{
		Container.Bind<IDrawingContext>()
				 .FromInstance(context)
				 .AsSingle();
	}
}
