using System;
using Character;
using Extensions;
using Finish;
using Logic.BaseClasses;
using Logic.GamePlay;
using Logic.Interfaces;
using Services.DrawingStateMachine;
using UnityEngine;
using Zenject;

namespace Drawing
{
	public class Drawer : ObservableBase
	{
		private readonly IDrawingStateMachine stateMachine;
		private readonly IInputService input;
		
		private ILineHolder currentLineHolder;
		
		public Drawer(IDrawingStateMachine stateMachine,
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

		public void DeInitialise()
		{
			input.TouchStartedEvent -= TouchStartedHandle;
			input.TouchPerformedEvent -= TouchPerformedHandle;
		}

		private void TouchStartedHandle()
		{
			Vector2 position = input.Position;
			bool hasComponent = Physics2DExtension.TryOverlapCircle(position, Constants.DETECTING_RADIUS,
				out ILineHolder instance);
			if (!hasComponent || !instance.IsFree) return;

			currentLineHolder = instance;
			stateMachine.Enter<DrawingStartedState, ILineHolder>(instance);
		}

		private void TouchPerformedHandle()
		{
			Vector2 position = input.Position;
			Physics2DExtension.TryOverlapCircle(position, Constants.DETECTING_RADIUS, out IFinishData finish);
			ILineHolder character = currentLineHolder;
			
			if (IsDrawing() && CanBeFinishPoint(finish))
			{
				stateMachine.Enter<ConfigureFinishedLineState, ILineHolder>(character);

				character.Configure(finish);
				RaiseEvent();
				return;
			}
			ResetLineHolder();
			stateMachine.Enter<DestroyLineState>();

			void ResetLineHolder() => currentLineHolder = null;
		}

		private bool CanBeFinishPoint(IFinishData finish)
		{
			return currentLineHolder.CanBeFinishPoint(finish);
		}

		private bool IsDrawing()
		{
			return currentLineHolder != null;
		}

		public class Factory : PlaceholderFactory<Drawer>
		{

		}
	}
}