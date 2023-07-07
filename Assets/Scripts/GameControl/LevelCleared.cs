using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelCleared
{
	private IPanel panel;
	private IPanel gui;
	
	[Inject]
	public void Construct([Inject(Id = UIInstaller.LEVELCLEARED_PANEL_ID)]IPanel panel, 
							[Inject(Id = UIInstaller.GUI_PANEL_ID)]IPanel gui)
	{
		this.panel = panel;
		this.gui = gui;
	}
	public void OnAllElementsHandle()
	{
		gui.Hide();
		panel.Show();
	}
}
