using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameOver
{
	private GameOverScreen screen;
	private bool hasCalled = false;
	
	[Inject]
	public void Construct(GameOverScreen screen)
	{
		this.screen = screen;
		screen.gameObject.SetActive(false);
	}
	
	public void GameOverExecute()
	{
		if(!hasCalled)
		{
			hasCalled = true;
			screen.gameObject.SetActive(true);
		}
	}
}
