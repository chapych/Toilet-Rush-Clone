using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver
{
	[SerializeField] private GameOverScreen screen;
	private bool hasCalled = false;
	
	public GameOver()
	{
		screen = GameObject.FindObjectOfType<GameOverScreen>();
	}
	public void GameOverHandle()
	{
		if(!hasCalled)
		{
			hasCalled = true;
			screen.SetActive();
		}
	}
}
