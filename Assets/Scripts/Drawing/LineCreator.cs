using System;
using UnityEngine;

namespace Drawing
{
	public class LineCreator : ILineCreator
	{
		private readonly GameFactory factory;
		public ILine CurrentLine { get; set; }
		public event Action OnProperLineCreated;

		public LineCreator(GameFactory factory)
		{
			this.factory = factory;
		}
		public ILine Create(Vector2 position)
		{
			GameObject line = factory.CreateLine(position);
			CurrentLine = line.GetComponent<ILine>();
		
			return CurrentLine;
		}

		public void ContinueLine(Vector2 position)
		{
			if(CurrentLine == null) return;
			if (CurrentLine.CanContinue(position, Constants.THRESHOLD))
			{
				CurrentLine.AddPoint(position);
			}
		}

		public void RegisterCurrent()
		{
			OnProperLineCreated?.Invoke();
		}
	}
}
