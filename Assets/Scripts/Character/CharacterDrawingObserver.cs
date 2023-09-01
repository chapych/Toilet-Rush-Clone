using System;
using Drawing;
using Logic.GamePlay;
using Logic.Interfaces;
using UnityEngine;

namespace Character
{
	public class CharacterDrawingObserver
	{
		private readonly CharacterData characterData;
		private MoveComponent moveComponent;
		
		public CharacterDrawingObserver(CharacterData characterData)
		{
			this.characterData = characterData;

			moveComponent = characterData.GetComponent<MoveComponent>();
		}

		public void OnAllDrawnHandler(object sender, EventArgs e)
		{
			ILine line = characterData.Line;
			var lineShortener = new LineShortener(line);

			var points = line.Points;
			moveComponent.StartMovement(points.ConvertToQueue(),
				() => lineShortener.ReducePointsByOne());
		}
	}
}