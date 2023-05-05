using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DrawingStartState : DrawingState
{
	public DrawingStartState() : base() {}
	private float detectingRadius = 0.1f;//protected
	
	public override void UpdateHandler(DrawingContext context)
	{
		return;
	}

	public override void Handle(DrawingContext context)
	{
		base.Handle(context);
		
		Collider2D character = Physics2D.OverlapCircle(context.TouchPosition, detectingRadius);
		if(character) //check if it is character
		{
			if(context.Line) return; //mb let not context carry thoae lines but objects themselves
			//or create gfabric-like data container
			
			context.Line = GameObject.Instantiate(context.LinePrefab, context.TouchPosition, Quaternion.identity);
			context.Line.transform.parent = context.transform;
			DrawingState.TransitionFrom<DrawingPressedState>(this);
		}
	}
	
}