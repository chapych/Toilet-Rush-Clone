using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelCleared
{
	private IPanel panel;
	
	[Inject]
	public void Construct(GameOverPanel screen)
	{
		this.panel = screen;
	}
	public void OnAllElementsHandle()
	{
		Debug.Log("cleared");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
