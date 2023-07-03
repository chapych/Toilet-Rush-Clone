using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnProperNumberOfElementsHandleBase<T> : MonoBehaviour, IProperNumberOfElementsHandler where T : MonoBehaviour
{
	private int charactersCount;
	private int linesCount = 0;
	protected T[] characters;
	public event Action OnAllElements;
	
	private void Awake()
	{
		characters = FindObjectsOfType<T>();
		charactersCount = characters.Length;
		Subscribe();
	}

	public void OnProperNumberOfElementsHandle()
	{
		linesCount++;
		if (linesCount == charactersCount)
		{
			OnAllElements?.Invoke();
			Unsubcribe();
		}
	}

	public abstract void Subscribe();

	public abstract void Unsubcribe();
}