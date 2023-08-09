using System;
using System.Collections.Generic;
using GameControl.Factories;
using UnityEngine;

namespace Drawing
{
	public class DrawingStateMachine : IDrawingStateMachine
	{
		private IExitableState active;
		private ICharacterData current;
		private readonly Dictionary<Type, IExitableState> states;

		public ICharacterData Character { get; set; }

		public DrawingStateMachine(DrawingStateFactory factory)
		{
			states = new Dictionary<Type, IExitableState>
			{
				[typeof(TouchStartedState)] = factory.CreateTouchStartedState(this),
				[typeof(TouchPerformedState)] = factory.CreateTouchPerformedState(this),
				[typeof(DrawingStartedState)] = factory.CreateStartState(this),
				[typeof(DrawingPressedState)] = factory.CreatePressedState(this),
				[typeof(ConfigureFinishedLineState)] = factory.CreateReleasingState(this),
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
