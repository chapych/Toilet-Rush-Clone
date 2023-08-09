using UnityEngine;
using Drawing;

namespace GameControl.Factories
{
    public class DrawingStateFactory
    {
        private readonly IInputService input;
        private readonly ILineCreator creator;
        private readonly ICoroutineRunner coroutineRunner;

        public DrawingStateFactory(IInputService input, ILineCreator creator, ICoroutineRunner coroutineRunner)
        {
            this.input = input;
            this.creator = creator;
            this.coroutineRunner = coroutineRunner;
        }

        public IPayloadedEnteringState<Vector2> CreateStartState(IDrawingStateMachine stateMachine)
        {
            IPayloadedEnteringState<Vector2> state = new DrawingStartedState(stateMachine, creator);
            return state;
        }

        public IEnteringState CreatePressedState(IDrawingStateMachine stateMachine)
        {
            IEnteringState state = new DrawingPressedState(stateMachine, input, creator, coroutineRunner);
            return state;
        }

        public IPayloadedEnteringState<IKindData> CreateReleasingState(IDrawingStateMachine stateMachine)
        {
            IPayloadedEnteringState<IKindData> state = new ConfigureFinishedLineState(stateMachine, creator);
            return state;
        }

        public IEnteringState CreateTouchStartedState(IDrawingStateMachine stateMachine)
        {
            IEnteringState state = new TouchStartedState(stateMachine, input);
            return state;
        }

        public IEnteringState CreateTouchPerformedState(IDrawingStateMachine stateMachine)
        {
            IEnteringState state = new TouchPerformedState(stateMachine, input);
            return state;
        }

        public IEnteringState CreateDestroyLineState(IDrawingStateMachine stateMachine)
        {
            IEnteringState state = new DestroyLineState(stateMachine, creator);
            return state;
        }
    }
}