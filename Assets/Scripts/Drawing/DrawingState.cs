public abstract class DrawingState
{
	protected DrawingContext context;
		
	public virtual void Handle(DrawingContext context) 
	{
		if(!this.context)
			this.context = context;
	}
}
