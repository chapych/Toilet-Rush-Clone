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
		
		Line line = context.Line;
		if(line.CanContinue(context.TouchPosition, DrawingContext.THRESHOLD))
		{
			line.ContinueLine(context.TouchPosition);
		}
	}

	public override void Handle(DrawingContext context)
	{
		base.Handle(context);
		Collider2D character = Physics2D.OverlapCircle(context.TouchPosition, detectingRadius);
		Debug.Log(character);
		if(!character) GameObject.Destroy(context.Line.gameObject); //use pool instead?
		DrawingState.TransitionFrom<DrawingStartState>(this);
	}
	
}