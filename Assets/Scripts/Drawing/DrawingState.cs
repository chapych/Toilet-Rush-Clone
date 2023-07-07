using UnityEngine;
public abstract class DrawingState
{
	protected IDrawingContext context;
	protected Vector2 position;
		
	public virtual void TouchHandle(IDrawingContext context) 
	{
		if(this.context is null)
			this.context = context;
	}
	
	public virtual void UpdateHandler(IDrawingContext context) {}
	
	static public void TransitionTo<T>(DrawingState state) where T : DrawingState, new()
	{
		state.context.Transition<T>();
		state.context = null;
	}
	
	private bool ConvertToNonNullable(Vector2? nullablePosition, out Vector2 position)
	{
		position = default(Vector2);
		if(nullablePosition is null) return false;
		
		position = nullablePosition ?? position;
		return true;
	}
}
