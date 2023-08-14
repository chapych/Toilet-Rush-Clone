using System;
using System.Collections;
using System.Collections.Generic;
using Drawing;
using GameControl.GamePlay;
using UnityEngine;
using Zenject;

public class ProperReachedFinishPointHandler : OnProperNumberOfElementsHandleBase<CharacterObserver>
{
	private LevelCleared levelCleared;
	
	[Inject]
	public void Contruct(LevelCleared levelCleared, [Inject(Id = SetupInstaller.FINISH_HOLDER_ID)] GameObject holder)
	{
		this.levelCleared = levelCleared;
		
		foreach(var element in holder.GetComponentsInChildren<ReachingFinish>())
			element.OnReachedFinish += OnOneElementHandle;
	}
	public override void Subscribe()
	{
		OnAllElements += levelCleared.OnAllElementsHandle;
	}

	public override void Unsubcribe()
	{
		OnAllElements -= levelCleared.OnAllElementsHandle;
	}
	public class Factory : OnProperNumberOfElementsHandleBase<CharacterObserver>.Factory
	{
		public Factory(DiContainer container) : base(container)
		{
		}

		public override IProperNumberOfElementsHandler Create()
		{
			return Container.Instantiate<ProperReachedFinishPointHandler>();
		}
	}
	
}