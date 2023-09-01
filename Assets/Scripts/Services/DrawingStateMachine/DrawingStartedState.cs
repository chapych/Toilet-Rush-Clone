using Character;
using Drawing;
using UnityEngine;

namespace Services.DrawingStateMachine
{
	public class DrawingStartedState : IPayloadedEnteringState<ILineHolder>
	{
		private readonly IDrawingStateMachine context;
		private readonly ILineCreator creator;
		private readonly IInputService input;

		public DrawingStartedState(IDrawingStateMachine context, ILineCreator creator, IInputService input)
		{
			this.context = context;
			this.creator = creator;
			this.input = input;
		}

		public void Enter(ILineHolder lineHolder)
		{
			CreateLine(input.Position, lineHolder.Color);

			context.Enter<DrawingPressedState>();
		}

		public void Exit()
		{
		}

		private void CreateLine(Vector2 position, Color color)
		{
			ILine line = creator.Create(position);
			line.Color = color;
		}
	}
}