using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCleared : MonoBehaviour
{
	public void OnAllElementsHandle()
	{
		Debug.Log("cleared");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
