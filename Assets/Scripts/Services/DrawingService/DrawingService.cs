using System;
using Drawing;
using Extensions;
using Finish;
using Logic.BaseClasses;
using Logic.Character;
using Logic.Drawing;
using Services.DrawingStateMachine;

namespace Services.DrawingService
{
	public class DrawingService : IDrawingService
	{
		private readonly IDrawingStateMachine stateMachine;
		private readonly IInputService input;
		
		private ILineHolder currentLineHolder;
		private bool canDraw;
		public event Action OnDrawn;


		public DrawingService(IDrawingStateMachine stateMachine,
			IInputService input)
		{
			this.stateMachine = stateMachine;
			this.input = input;
		}

		public void Initialise()
		{
			input.TouchStartedEvent += TouchStartedHandle;
			input.TouchPerformedEvent += TouchPerformedHandle;
		}

		public void TurnOnDrawing() => canDraw = true;

		public void TurnOffDrawing() => canDraw = false;

		private void TouchStartedHandle()
		{
			if(!canDraw) return;

			bool hasComponent = Physics2DExtension.TryOverlapCircle(input.Position, Constants.DETECTING_RADIUS,
				out ILineHolder instance);
			if (!hasComponent || instance.Line!=null) return;

			currentLineHolder = instance;
			stateMachine.Enter<DrawingStartedState, ILineHolder>(currentLineHolder);
		}

		private void TouchPerformedHandle()
		{
			if(!IsDrawing()) return;

			bool hasComponent = Physics2DExtension.TryOverlapCircle(input.Position, Constants.DETECTING_RADIUS,
				out IFinishData finish);
			if (!hasComponent || !CanBeFinishPoint(finish))
				stateMachine.Enter<DestroyLineState>();
			else
			{
				stateMachine.Enter<ConfigureFinishedLineState, ILineHolder>(currentLineHolder);
				currentLineHolder.Finish = finish;
				OnDrawn?.Invoke();
			}

			ResetLineHolder();
		}

		private bool IsDrawing() => currentLineHolder != null;
		private void ResetLineHolder() => currentLineHolder = null;
		private bool CanBeFinishPoint(IFinishData finish)
			=> finish.Kind == Kind.Universal || finish.Kind == currentLineHolder.Kind;
	}
}