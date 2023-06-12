using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProperCreatedLinesHandler : MonoBehaviour, IProperNumberOfElementsHandler
{
	private int charactersCount;
	private int linesCount = 0;
	private CharacterObserver[] characters;
	private IDrawingContext context;

	[Inject]
	public void Contruct(IDrawingContext context)
	{
		this.context = context;
	}
	public event Action OnAllElements;
	private void Awake()
	{
		characters = FindObjectsOfType<CharacterObserver>();
		charactersCount = characters.Length;
		SubcribeAll();
		context.OnProperLineCreated += OnProperNumberOfElementsHandle;
	}

	public void OnProperNumberOfElementsHandle()
	{
		linesCount++;
		if (linesCount == charactersCount)
		{
			OnAllElements?.Invoke();
			UnsubcribeAll();
		}
	}

	public void SubcribeAll()
	{
		foreach (var character in characters)
		{
			OnAllElements += character.OnAllElementsHandle;
		}
	}

	public void UnsubcribeAll()
	{
		foreach (var character in characters)
		{
			OnAllElements -= character.OnAllElementsHandle;
		}
	}


}
