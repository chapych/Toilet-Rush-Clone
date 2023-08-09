using System;
using UnityEngine;

namespace Drawing
{
    public class TouchStartedState : IEnteringState
    {
        private readonly IInputService input;
        private readonly IDrawingStateMachine context;

        public TouchStartedState(IDrawingStateMachine context, IInputService input)
        {
            this.context = context;
            this.input = input;
        }

        public void Enter()
        {
           bool hasComponent = Physics2DExtension.TryOverlapCircle(input.Position, Constants.DETECTING_RADIUS,
               out ICharacterData character);
           if (!hasComponent || character.Line != null) return;
           context.Character = character;
           context.Enter<DrawingStartedState, Vector2>(input.Position);
        }

        public void Exit()
        {
        }
    }
}