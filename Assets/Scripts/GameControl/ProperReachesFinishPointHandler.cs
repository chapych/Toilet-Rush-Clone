using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProperReachesFinishPointHandler : MonoBehaviour, IProperNumberOfElementsHandler
{
	private int charactersCount;
	private int reachedElements = 0;
	private CharacterObserver[] characters;
	private LevelCleared levelCleared;
	private FinishPointsHolder triggerEventHolder;
	public event Action OnAllElements;
	[Inject]
	public void Contruct(LevelCleared levelCleared, FinishPointsHolder triggerEventHolder)
	{
		this.levelCleared = levelCleared;
		this.triggerEventHolder = triggerEventHolder;
	}
	
	private void Awake()
	{
		characters = FindObjectsOfType<CharacterObserver>();
		charactersCount = characters.Length;
		foreach(var element in triggerEventHolder.GetComponentsInChildren<TriggerEventFinish>())
			element.OnReachedFinish+=OnProperNumberOfElementsHandle;
		OnAllElements+=levelCleared.OnAllElementsHandle;
	}

	public void OnProperNumberOfElementsHandle()
	{
		reachedElements++;
		if (reachedElements == charactersCount)
		{
			OnAllElements?.Invoke();
			OnAllElements-=levelCleared.OnAllElementsHandle;
		}
	}
}