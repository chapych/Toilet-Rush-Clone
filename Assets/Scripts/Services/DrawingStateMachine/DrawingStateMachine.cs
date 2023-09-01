using System;
using System.Collections.Generic;
using Character;
using Infrastructure.Factories;

namespace Services.DrawingStateMachine
{
	public class DrawingStateMachine : IDrawingStateMachine
	{
		private IExitableState active;
		private readonly Dictionary<Type, IExitableState> states;


		public DrawingStateMachine(DrawingStateFactory factory)
		{
			states = new Dictionary<Type, IExitableState>
			{
				[typeof(DrawingStartedState)] = factory.CreateStartState(this),
				[typeof(DrawingPressedState)] = factory.CreatePressedState(this),
				[typeof(ConfigureFinishedLineState)] = factory.CreateConfigureLineState(this),
				[typeof(DestroyLineState)] = factory.CreateDestroyLineState(this)
			};
		}

		public void Enter<TState>() where TState : class, IEnteringState
		{
			active?.Exit();
			IEnteringState state = GetState<TState>();
			active = state;
			state.Enter();
		}

		public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedEnteringState<TPayload>
		{
			active?.Exit();
			IPayloadedEnteringState<TPayload> state = GetState<TState>();
			active = state;
			state.Enter(payload);
		}

		private T GetState<T>() where T: class
		{
			return states[typeof(T)] as T;
		}
	}
}
