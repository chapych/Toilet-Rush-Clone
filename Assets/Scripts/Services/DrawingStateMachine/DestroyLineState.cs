using Drawing;

namespace Services.DrawingStateMachine
{
    public class DestroyLineState : IEnteringState
    {
        private readonly IDrawingStateMachine context;
        private readonly ILineCreator creator;

        public DestroyLineState(IDrawingStateMachine context, ILineCreator creator)
        {
            this.context = context;
            this.creator = creator;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            creator.CurrentLine?.DestroySelf();
            creator.CurrentLine = null;
        }
    }
}