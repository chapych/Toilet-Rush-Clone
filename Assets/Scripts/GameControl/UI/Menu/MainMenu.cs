using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MainMenu : Menu
{
	public void StartGame() => base.Transition(SceneManager.GetActiveScene().buildIndex + 1);
}
