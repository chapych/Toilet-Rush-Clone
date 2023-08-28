using System;
using Drawing;
using Logic.GamePlay;
using Logic.Interfaces;
using UnityEngine;

namespace Character
{
	public class CharacterObserver 
	{
		private CharacterData characterData;
		
		public CharacterObserver(CharacterData characterData)
		{
			this.characterData = characterData;
		}

		public void OnAllDrawnHandler(object sender, EventArgs e)
		{
			ILine line = characterData.Line;
			var lineShortener = new LineShortener(line);
			var moveComponent = characterData.GetComponent<MoveComponent>();
		
			Subscribe(moveComponent, lineShortener);
		
			var points = line.Points;
			moveComponent.StartMovement(points.ConvertToQueue(),
				() => UnSubscribe(moveComponent, lineShortener));
		}

		private void Subscribe(MoveComponent component, LineShortener shortener) => 
			component.OnLinePointWalkedBy += shortener.OnLinePointWalkedByHandler;

		private void UnSubscribe(MoveComponent component, LineShortener shortener) => 
			component.OnLinePointWalkedBy -= shortener.OnLinePointWalkedByHandler;
	}
}