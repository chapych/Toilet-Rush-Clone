using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSucceedPanel : PanelBase
{
	private int max;
	private void Start()
	{
		max = SceneManager.sceneCount;
	}
	public void PlayNextLevel()
	{
		int current = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(current + 1);
	}
}
