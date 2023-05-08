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

	public override void TouchHandle(DrawingContext context)
	{
		base.TouchHandle(context);
		
		Vector2 position = context.TouchPosition;
		Collider2D collider = Physics2D.OverlapCircle(position, detectingRadius);
		if(!collider) return;
		if(collider.TryGetComponent<CharacterData>(out CharacterData character))
		{
			if(!context.CanCreateLine(character)) return;
			
			context.CreateLine(character, position);
			DrawingState.TransitionFrom<DrawingPressedState>(this);
		}
	}
	
}