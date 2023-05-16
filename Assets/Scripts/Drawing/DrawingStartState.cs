using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DrawingStartState : DrawingState
{
	public DrawingStartState() : base() {}
	private float detectingRadius = 0.1f;//protected
	
	public override void UpdateHandler(IDrawingContext context)
	{
		return;
	}

	public override void TouchHandle(IDrawingContext context)
	{
		base.TouchHandle(context);
		
		Vector2 position = context.TouchPosition;
		Collider2D collider = Physics2D.OverlapCircle(position, detectingRadius);
		if(!collider) return;
		if(collider.TryGetComponent<CharacterData>(out CharacterData character))
		{
			if(!context.CanCreateLine(character)) return;
			
			context.CreateLine(character, position);
			DrawingState.TransitionTo<DrawingPressedState>(this);
		}
	}
	
}