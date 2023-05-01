using UnityEngine;
using UnityEngine.InputSystem;

public class DrawingStartState : DrawingState
{
	public DrawingStartState() : base() {}
	private float detectingRadius = 0.1f;

	public override void Handle(DrawingContext context)
	{
		base.Handle(context);
		Collider2D collider = Physics2D.OverlapCircle(context.DrawingPosition, detectingRadius);
		if(collider) Debug.Log("smth)");
	}
	
}