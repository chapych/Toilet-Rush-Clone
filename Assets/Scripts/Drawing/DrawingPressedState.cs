using System.Collections;
using UnityEngine;

namespace Drawing
{
	public class DrawingPressedState : IEnteringState
	{
		private IDrawingStateMachine context;
		private readonly ILineCreator creator;
		private readonly IInputService input;
		private readonly ICoroutineRunner coroutineRunner;
		
		private Coroutine coroutine;
		public DrawingPressedState(IDrawingStateMachine context,IInputService input, 
			ILineCreator creator, ICoroutineRunner coroutineRunner)
		{
			this.context = context;
			this.creator = creator;
			this.input = input;
			this.coroutineRunner = coroutineRunner;					
		}

		public void Exit()
		{
			coroutineRunner.StopCoroutine(coroutine);
		}

		public void Enter()
		{
			coroutine = coroutineRunner.StartCoroutine(DrawLine());
		}

		private IEnumerator DrawLine()
		{
			while(true)
			{
				Vector2 position = input.Position;
				creator.ContinueLine(position);
				yield return null;
			}
		}
	}
}