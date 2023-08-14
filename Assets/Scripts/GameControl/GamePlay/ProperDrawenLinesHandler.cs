using System;
using System.Collections;
using System.Collections.Generic;
using Drawing;
using GameControl.GamePlay;
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
		creator.OnProperLineCreated += OnOneElementHandle;
	}
	
	public override void Subscribe()
	{
		foreach (var character in Elements)
		{
			OnAllElements += character.OnAllElementsHandle;
		}
	}

	public override void Unsubcribe()
	{
		foreach (var character in Elements)
		{
			OnAllElements -= character.OnAllElementsHandle;
		}
	}
	
	public class Factory : OnProperNumberOfElementsHandleBase<CharacterObserver>.Factory
	{
		public Factory(DiContainer container) : base(container)
		{
		}

		public override IProperNumberOfElementsHandler Create()
		{
			return Container.Instantiate<ProperDrawenLinesHandler>();
		}
	}
}
