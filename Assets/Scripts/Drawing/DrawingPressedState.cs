using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DrawingPressedState : DrawingState
{
	private float detectingRadius = 0.1f;
	public DrawingPressedState(DrawingStateMachine stateMachine) : base(stateMachine) {}
	
	public override void UpdateHandler(IDrawingContext context)
	{
		context.ContinueLine(context.TouchPosition);
	}

	public override void TouchHandle(IDrawingContext context)
	{
		Collider2D collider = Physics2D.OverlapCircle(context.TouchPosition, detectingRadius);
		if(collider && collider.TryGetComponent<FinishData>(out FinishData data))
			context.TryRegisterLine(data);
		else context.DestroyLine();
		
		stateMachine.Transition<DrawingStartState>();
	}
	
}