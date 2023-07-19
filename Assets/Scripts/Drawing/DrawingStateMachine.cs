using System;
using System.Collections.Generic;

public class DrawingStateMachine
{
	private IDrawingState active;
	private readonly Dictionary<Type, IDrawingState> states;

	public DrawingStateMachine()
	{
		states = new Dictionary<Type, IDrawingState>
		{
			[typeof(DrawingStartState)] = new DrawingStartState(this),
			[typeof(DrawingPressedState)] = new DrawingPressedState(this)
		};
	}
	
	public void Transition<T>() where T : IDrawingState
	{
		active = states[typeof(T)];
	}
	
	public void UpdateHandler(IDrawingContext context) => active.UpdateHandler(context);
	public void TouchHandle(IDrawingContext context) => active.TouchHandle(context);
}