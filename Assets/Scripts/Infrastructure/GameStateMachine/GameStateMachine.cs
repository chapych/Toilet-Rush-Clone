using System.Collections.Generic;

namespace Infrastructure.GameStateMachine
{
	public class GameStateMachine : IGameStateMachine
	{
		private IExitableState active;
		private readonly Dictionary<System.Type, IExitableState> states;
		
		public GameStateMachine(BootstrapGameState.Factory bootstrapFactory,
			LoadProgressGameState.Factory loadProgressFactory,
			LoadLevelState.Factory loadLevelFactory,
			InitGamePlayState.Factory initGamePlayFactory)
		{
			states = new Dictionary<System.Type, IExitableState>
			{
				[typeof(BootstrapGameState)] = bootstrapFactory.Create(this),
				[typeof(LoadProgressGameState)] = loadProgressFactory.Create(this),
				[typeof(LoadLevelState)] = loadLevelFactory.Create(this),
				[typeof(InitGamePlayState)] = initGamePlayFactory.Create(this)
			};
		}
	
		public void Enter<TState>() where TState : class, IEnteringState
		{
			active?.Exit();
			IEnteringState state = GetState<TState>();
			active = state;
			state.Enter();
		}
		public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedEnteringState<TPayload>
		{
			active?.Exit();
			IPayloadedEnteringState<TPayload> state = GetState<TState>();
			active = state;
			state.Enter(payload);
		}
		private TState GetState<TState>() where TState : class
		{
			return states[typeof(TState)] as TState;
		}
	}
}
