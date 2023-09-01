using Infrastructure.GameStateMachine;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
	public class GameBootstrapper : MonoBehaviour
	{
		private Game game;
	
		[Inject]
		public void Construct(Game game)
		{
			this.game = game;
		}
	
		private void Awake()
		{
			game.StateMachine.Enter<BootstrapGameState>();
		
			DontDestroyOnLoad(this);
		}
	
	
	}
}
