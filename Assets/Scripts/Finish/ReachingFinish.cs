using System;
using UnityEngine;

public class ReachingFinish : MonoBehaviour
{
	public event Action OnReachedFinish;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<ICharacterData>() != null)
		{
			other.enabled = false;
			OnReachedFinish?.Invoke();
		}
	}
}