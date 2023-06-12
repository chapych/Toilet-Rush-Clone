using System;
using UnityEngine;

public class TriggerEventFinish : MonoBehaviour
{
	public event Action OnReachedFinish;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<ICharacterData>() != null)
		{
			other.GetComponent<ICharacterData>().HasReachedFinish = true;
			other.GetComponent<Collider2D>().enabled = false;
			OnReachedFinish?.Invoke();
		}
	}
}