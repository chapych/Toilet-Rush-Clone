using System;
using System.Collections;
using System.Collections.Generic;
using Drawing;
using UnityEngine;
using Zenject;

public class ProperDrawenLinesHandler : OnProperNumberOfElementsHandleBase<CharacterObserver>
{
	private LineCreator creator;
	[Inject]
	public void Contruct(LineCreator lineCreator)
	{
		this.creator = lineCreator;
	}

	private void Start()
	{
		creator.OnProperLineCreated += OnProperNumberOfElementsHandle;
	}
	
	public override void Subscribe()
	{
		foreach (var character in characters)
		{
			OnAllElements += character.OnAllElementsHandle;
		}
	}

	public override void Unsubcribe()
	{
		foreach (var character in characters)
		{
			OnAllElements -= character.OnAllElementsHandle;
		}
	}
}
