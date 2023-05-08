using UnityEngine;
public abstract class DrawingState
{
	protected DrawingContext context;
		
	public virtual void TouchHandle(DrawingContext context) 
	{
		if(!this.context)
			this.context = context;
	}
	
	public abstract void UpdateHandler(DrawingContext context);
	
	static public void TransitionFrom<T>(DrawingState state) where T : DrawingState, new()
	{
		state.context.Transition<T>();
		state.context = null;
	}
}
