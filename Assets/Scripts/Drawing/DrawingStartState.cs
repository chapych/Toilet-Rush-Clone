using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DrawingStartState : DrawingState
{
	public DrawingStartState(DrawingStateMachine stateMachine) : base(stateMachine) {}
	
	public override void UpdateHandler(IDrawingContext context) {}

	public override void TouchHandle(IDrawingContext context)
	{	
		Collider2D collider = Physics2D.OverlapCircle(context.TouchPosition, Constants.DETECTING_RADIUS);
		if(!collider) return;
		if(collider.TryGetComponent<CharacterData>(out CharacterData character))
		{
			if(!context.CanCreateLine(character)) return;
			
			context.CreateLine(character, context.TouchPosition);
			stateMachine.Transition<DrawingPressedState>();
		}
	}
	
}