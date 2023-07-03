using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProperDrawenLinesHandler : OnProperNumberOfElementsHandleBase<CharacterObserver>
{
	[Inject]
	public void Contruct(IDrawingContext context)
	{
		context.OnProperLineCreated += OnProperNumberOfElementsHandle;
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
