using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProperReachesFinishPointHandler : OnProperNumberOfElementsHandleBase<CharacterObserver>
{
	private LevelCleared levelCleared;
	
	[Inject]
	public void Contruct(LevelCleared levelCleared, [Inject(Id = SetupInstaller.FINISH_HOLDER_ID)] GameObject holder)
	{
		this.levelCleared = levelCleared;
		
		foreach(var element in holder.GetComponentsInChildren<ReachingFinish>())
			element.OnReachedFinish += OnProperNumberOfElementsHandle;
	}
	public override void Subscribe()
	{
		OnAllElements += levelCleared.OnAllElementsHandle;
	}

	public override void Unsubcribe()
	{
		OnAllElements -= levelCleared.OnAllElementsHandle;
	}
}