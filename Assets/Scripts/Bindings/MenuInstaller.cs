using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
	public const string MAIN_MENU_ID = "Main Menu";
	public const string LEVELS_MENU_ID = "Levels Menu";

	[SerializeField] RectTransform mainMenu;
	[SerializeField] RectTransform levelsMenu;
	[SerializeField] Animator transitionAnimator;

	public override void InstallBindings()
	{
		Container.Bind<RectTransform>()
				 .WithId(MAIN_MENU_ID)
				 .FromInstance(mainMenu);
		Container.Bind<RectTransform>()
				 .WithId(LEVELS_MENU_ID)
				 .FromInstance(levelsMenu);		
		Container.Bind<Animator>()
				 .FromInstance(transitionAnimator);
	}
}
