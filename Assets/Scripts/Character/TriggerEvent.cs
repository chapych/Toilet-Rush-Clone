
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TriggerEvent : MonoBehaviour
{
	public bool isTriger { get; private set; }
	public event Action OnCollision;
	
	[Inject]
	public void Costruct(GameOver gameOver) => OnCollision += gameOver.GameOverHandle;
	
	private void Start()
	{
		isTriger = true;
	}
	private void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.TryGetComponent(out TriggerEvent component))
		{
			if (IsAnyTriggerTurnedOff(component))
				return;
			OnCollision?.Invoke();
		}

		if (other.GetComponent<IFinishData>() != null)
			isTriger = false;
	}
    private bool IsAnyTriggerTurnedOff(TriggerEvent component) => !component.isTriger || !isTriger;
}
