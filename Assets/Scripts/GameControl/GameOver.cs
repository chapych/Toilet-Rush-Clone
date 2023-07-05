using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameOver
{
	private IPanel panel;
	[SerializeField] private float secondsToWait = 1f;
	
	[Inject]
	public void Construct([Inject(Id = UIInstaller.GAMEOVER_PANEL_ID)] IPanel panel)
	{
		this.panel = panel;
	}
	
	public async void OnCollisionHandle(object sender, CollisionEventArgs args)
	{
		var timeInMSec = (int)(1000 * secondsToWait);
		
		await Task.Delay(timeInMSec);
		panel.Show();
	}
}
