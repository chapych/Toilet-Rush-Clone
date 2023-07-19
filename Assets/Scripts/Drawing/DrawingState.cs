using UnityEngine;

public abstract class DrawingState : IDrawingState
{
    protected DrawingStateMachine stateMachine;

    public DrawingState(DrawingStateMachine stateMachine) =>
         this.stateMachine = stateMachine;

    public abstract void TouchHandle(IDrawingContext context);

    public abstract void UpdateHandler(IDrawingContext context);

}
