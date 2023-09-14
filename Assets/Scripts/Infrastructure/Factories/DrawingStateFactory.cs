using Drawing;
using Logic.Character;
using Services.DrawingStateMachine;
using UnityEngine;

namespace Infrastructure.Factories
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

        public IPayloadedEnteringState<ILineHolder> CreateStartState(IDrawingStateMachine stateMachine)
        {
            IPayloadedEnteringState<ILineHolder> state = new DrawingStartedState(stateMachine, creator, input);
            return state;
        }

        public IEnteringState CreatePressedState(IDrawingStateMachine stateMachine)
        {
            IEnteringState state = new DrawingPressedState(stateMachine, input, creator, coroutineRunner);
            return state;
        }

        public IPayloadedEnteringState<ILineHolder> CreateConfigureLineState(IDrawingStateMachine stateMachine)
        {
            IPayloadedEnteringState<ILineHolder> state = new ConfigureFinishedLineState(stateMachine, creator);
            return state;
        }

        public IEnteringState CreateDestroyLineState(IDrawingStateMachine stateMachine)
        {
            IEnteringState state = new DestroyLineState(stateMachine, creator);
            return state;
        }
    }
}