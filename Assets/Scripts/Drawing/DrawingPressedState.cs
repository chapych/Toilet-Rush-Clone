using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DrawingPressedState : DrawingState
{
	private float detectingRadius = 0.1f;
	public DrawingPressedState() : base() {}
	
	public override void UpdateHandler(DrawingContext context)
	{
		if(!context)
			this.context = context;
		context.ContinueLine();
	}

	public override void TouchHandle(DrawingContext context)
	{
		base.TouchHandle(context);
		Collider2D collider = Physics2D.OverlapCircle(context.TouchPosition, detectingRadius);
		if(collider && collider.TryGetComponent<FinishData>(out FinishData data))
			context.RegisterLine(data);
		else context.DestroyLine();
		DrawingState.TransitionFrom<DrawingStartState>(this);
	}
	
}