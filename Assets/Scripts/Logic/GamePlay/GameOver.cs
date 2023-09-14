using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Logic.GamePlay
{
	public class GameOver
	{
		private IPanel panel;
		private IPanel gui;
		[SerializeField] private float secondsToWait = 1f;
	
		[Inject]
		public void Construct()
		{
		}
	
		public async void OnCollisionHandleAsync(object sender, CollisionEventArgs args)
		{
			var timeInMSec = (int)(1000 * secondsToWait);
		
			await Task.Delay(timeInMSec);
		
			gui.Hide();
			panel.Show();
		}
	}
}
