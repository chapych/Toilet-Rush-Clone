using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnProperNumberOfElementsHandleBase<T> : MonoBehaviour, ISubscriber, 
									IProperNumberOfElementsHandler where T : MonoBehaviour
{
	private int max;
	private int current = 0;
	protected T[] characters;
	public event Action OnAllElements;
	
	private void Awake()
	{
		characters = FindObjectsOfType<T>();
		max = characters.Length;
		Subscribe();
	}

	public void OnProperNumberOfElementsHandle()
	{
		current++;
		if (current == max)
		{
			OnAllElements?.Invoke();
			Unsubcribe();
		}
	}

	public abstract void Subscribe();

	public abstract void Unsubcribe();
}