using System.Collections;
using System.Collections.Generic;
using Infrastructure.GameStateMachine;
using UnityEngine;
using Zenject;

public class Game
{
	public IGameStateMachine StateMachine { get; private set; }
	public Game(IGameStateMachine stateMachine)
	{
		StateMachine = stateMachine;
	}
}
