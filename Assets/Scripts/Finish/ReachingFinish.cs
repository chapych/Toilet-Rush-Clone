using System;
using UnityEngine;

public class ReachingFinish : MonoBehaviour
{
	private IKindData finish;
	public event Action OnReachedFinish;
	
	private void Start()
	{
		finish = GetComponent<FinishData>();
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		ICharacterData character = other.GetComponent<ICharacterData>();
		if (character != null && character.Finish == finish)
		{
			other.enabled = false;
			OnReachedFinish?.Invoke();
		}
	}
}