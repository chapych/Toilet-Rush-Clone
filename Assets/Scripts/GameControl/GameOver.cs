using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameOver
{
	private IPanel screen;
	[SerializeField] private float secondsToWait = 1f;
	
	[Inject]
	public void Construct(GameOverPanel panel)
	{
		this.screen = panel;
	}
	
	public async void OnCollisionHandle(object sender, CollisionEventArgs args)
	{
		var timeInMSec = (int)(1000 * secondsToWait);
		
		await Task.Delay(timeInMSec);
		screen.Show();
	}
}
