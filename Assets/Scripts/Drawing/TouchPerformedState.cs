using UnityEngine;

namespace Drawing
{
    public class TouchPerformedState : IEnteringState
    {
        private readonly IDrawingStateMachine context;
        private readonly IInputService input;

        public TouchPerformedState(IDrawingStateMachine context, IInputService input)
        {
            this.context = context;
            this.input = input;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            ICharacterData character = context.Character;
            bool hasComponent = Physics2DExtension.TryOverlapCircle(input.Position, Constants.DETECTING_RADIUS,
                out IKindData finish);
            if (!hasComponent || character == null)
            {
                context.Enter<DestroyLineState>();
                return;
            }
            if (finish.IsGenderNeutral || finish.Kind == character.Kind)
                context.Enter<ConfigureFinishedLineState, IKindData>(finish);
        }
    }

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
            context.Character = null;
            creator.CurrentLine = null;
        }
    }
}