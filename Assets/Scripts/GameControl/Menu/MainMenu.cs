using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MainMenu : MonoBehaviour
{
	private RectTransform levelMenu;
	[SerializeField] private MenuTransition transition;
	[Inject]
	public void Construct([Inject(Id = (MenuInstaller.LEVELS_MENU_ID))] RectTransform levelMenu,
							MenuTransition transition)
	{
		this.levelMenu = levelMenu;
		levelMenu.gameObject.SetActive(false);
		
		this.transition = transition;
	}
	public void StartGame() => transition.RunAnimationTransition(SceneManager.GetActiveScene().buildIndex + 1);
	public void ChooseLevel()
	{
		transition.RunAnimationTransition(this, levelMenu);
	}
	
	public void Settings()
	{
	//	transition.RunAnimationTransition(this, //settings);
	}
	
	
	
}
