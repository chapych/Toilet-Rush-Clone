
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TriggerEvent : MonoBehaviour
{
	private int seconds = 1;
	public bool isTriger { get; private set; }
	private GameOver gameOver;
	public event Action<Vector2> OnCollision;
	
	[Inject]
	public void Costruct(GameOver gameOver, DustControl dustControl)
	{
		this.gameOver = gameOver;
		OnCollision+=dustControl.OnCollisionHandle;
	}
	
	private void Start()
	{
		isTriger = true;
	}
	private void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.TryGetComponent(out ICharacterData component))
		{
			if (IsAnyTriggerTurnedOff(component))
				return;
				
			HandleTrigger(other);
		}

		if (other.GetComponent<IFinishData>() != null)
			GetComponent<ICharacterData>().HasReachedFinish = true;
	}
	private bool IsAnyTriggerTurnedOff(ICharacterData component) => component.HasReachedFinish || GetComponent<ICharacterData>().HasReachedFinish;
	
	private void HandleTrigger(Collider2D other)
	{
		Vector2 medianPosition = (transform.position + other.transform.position) / 2;
		OnCollision?.Invoke(medianPosition);
		GetComponent<MoveComponent>().StopMovement();
		other.GetComponent<MoveComponent>().StopMovement();
		StartCoroutine(WaitFor(seconds));
	}
	private IEnumerator WaitFor(int seconds)
	{
		yield return new WaitForSeconds(seconds);
		gameOver.GameOverExecute();	
	}
}
