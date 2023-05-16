using UnityEngine;
public abstract class DrawingState
{
	protected IDrawingContext context;
		
	public virtual void TouchHandle(IDrawingContext context) 
	{
		if(this.context is null)
			this.context = context;
	}
	
	public abstract void UpdateHandler(IDrawingContext context);
	
	static public void TransitionTo<T>(DrawingState state) where T : DrawingState, new()
	{
		state.context.Transition<T>();
		state.context = null;
	}
}
