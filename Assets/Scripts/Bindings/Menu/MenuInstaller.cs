using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
	public const string MAIN_MENU_ID = "Main Menu";
	public const string LEVELS_MENU_ID = "Levels Menu";
	[SerializeField] Animator transitionAnimator;
	[SerializeField] AudioHolder audioHolder;
	//[SerializeField] private PlayerDataManager playerDataManager;


	public override void InstallBindings()
	{		
		BindPlayerData();
		Container.Bind<Animator>()
				 .FromInstance(transitionAnimator);
		Container.Bind<AudioHolder>()
				 .FromInstance(audioHolder);
	}
	private void BindPlayerData()
	{
	
	}
}
