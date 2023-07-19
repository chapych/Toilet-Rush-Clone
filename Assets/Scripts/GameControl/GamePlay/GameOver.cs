using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameOver
{
	private IPanel panel;
	private IPanel gui;
	[SerializeField] private float secondsToWait = 1f;
	
	[Inject]
	public void Construct([Inject(Id = UIInstaller.GAMEOVER_PANEL_ID)] IPanel panel, 
							[Inject(Id = UIInstaller.GUI_PANEL_ID)]IPanel gui)
	{
		this.panel = panel;
		this.gui = gui;
	}
	
	public async void OnCollisionHandleAsync(object sender, CollisionEventArgs args)
	{
		var timeInMSec = (int)(1000 * secondsToWait);
		
		await Task.Delay(timeInMSec);
		
		gui.Hide();
		panel.Show();
	}
}
