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
		
		Vector2 position = context.TouchPosition;
		Collider2D collider = Physics2D.OverlapCircle(position, detectingRadius);
		if(collider.TryGetComponent<CharacterData>(out CharacterData character))
		{
			if(context.lineCreator.ContainsLineFor(character)) return;
			
			context.Line = context.lineCreator.Create(character, position);
			context.Line.transform.parent = context.transform;
			DrawingState.TransitionFrom<DrawingPressedState>(this);
		}
	}
	
}