using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProperCreatedLinesHandler : MonoBehaviour
{
	private int charactersCount;
	private int linesCount = 0;
	[SerializeField] DrawingContext context;
 	public event Action OnAllLinesCreated;
	private void Awake()
	{
		var characters = FindObjectsOfType<CharacterObserver>();
		charactersCount = characters.Length;
		foreach(var character in characters)
		{
			OnAllLinesCreated+=character.OnAllLinesCreatedHandle;
		}
		context.OnProperLineCreated+=OnProperLineCreatedHandle;
	}
	public void OnProperLineCreatedHandle()
	{
		linesCount++;
		if(linesCount == charactersCount)
		{
			OnAllLinesCreated?.Invoke();
		}
	}
}
