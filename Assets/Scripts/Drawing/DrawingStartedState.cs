using UnityEngine;

namespace Drawing
{
	public class DrawingStartedState : IPayloadedEnteringState<Vector2>
	{
		private readonly IDrawingStateMachine context;
		private readonly ILineCreator creator;

		public DrawingStartedState(IDrawingStateMachine context, ILineCreator creator)
		{
			this.context = context;
			this.creator = creator;
		}

		public void Exit()
		{
		}

		public void Enter(Vector2 activeState)
		{
			CreateLine(activeState, context.Character);

			context.Enter<DrawingPressedState>();
		}

		private void CreateLine(Vector2 position, ICharacterData character)
		{
			ILine line = creator.Create(position);
		
			line.Color = KindToColor.GetColor(character.Kind);
		}
	}
}