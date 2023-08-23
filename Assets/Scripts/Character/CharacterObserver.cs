using System;
using Drawing;
using Logic.GamePlay;
using Logic.Interfaces;
using UnityEngine;

namespace Character
{
	public class CharacterObserver 
	{
		private readonly IObservable onAllDrawn;
		private CharacterData characterData;
		
		public CharacterObserver(CharacterData characterData, IObservable onAllDrawn)
		{
			this.characterData = characterData;
			onAllDrawn.OnRaised += OnAllDrawnHandler;
		}

		private void OnAllDrawnHandler(object sender, EventArgs e)
		{
			Debug.Log("OnAllElementsHandler");
			ILine line = characterData.Line;
			var lineShortener = new LineShortener(line);
			var moveComponent = characterData.GetComponent<MoveComponent>();
		
			moveComponent.OnLinePointWalkedBy += lineShortener.OnLinePointWalkedByHandler;
		
			var points = line.Points;
			moveComponent.StartMovement(points.ConvertToQueue());
		}
	}
}