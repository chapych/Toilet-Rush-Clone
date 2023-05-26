using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProperCreatedLinesHandler : MonoBehaviour
{
	private int charactersCount;
	private CharacterObserver[] characters;
	private int linesCount = 0;
	private IDrawingContext context;
	
	[Inject]
	public void Contruct(IDrawingContext context)
	{
		this.context = context;
	}
 	public event Action OnAllLinesCreated;
	private void Awake()
	{
		characters = FindObjectsOfType<CharacterObserver>();
		charactersCount = characters.Length;
		SubcribeCharacters();
		context.OnProperLineCreated += OnProperLineCreatedHandle;
	}

	private void SubcribeCharacters()
	{
		foreach (var character in characters)
		{
			OnAllLinesCreated += character.OnAllLinesCreatedHandle;
		}
	}
	
	private void UnsubcribeCharacters()
	{
		foreach (var character in characters)
		{
			OnAllLinesCreated -= character.OnAllLinesCreatedHandle;
		}
	}

	public void OnProperLineCreatedHandle()
	{
		linesCount++;
		if(linesCount == charactersCount)
		{
			OnAllLinesCreated?.Invoke();
			UnsubcribeCharacters();
		}
	}
}
