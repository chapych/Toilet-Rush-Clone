using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class TriggerEvent : MonoBehaviour //make a seperated script for finishPoint so it was triggerEnter
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
	private void OnCollisionEnter2D(Collision2D collision) 
	{
		var other = collision.gameObject;
		if(other.TryGetComponent(out ICharacterData component))
		{
			if (HasAnyoneFinished(component))
				return;
				
			HandleCollision(other);
		}
	}
	private bool HasAnyoneFinished(ICharacterData component) => GetComponent<ICharacterData>().HasReachedFinish || component.HasReachedFinish;
	
	private void HandleCollision(GameObject other)
	{
		Vector2 medianCollisionPoint = (transform.position + other.transform.position) / 2;
		
		OnCollision?.Invoke(medianCollisionPoint);
		foreach(var element in new GameObject[] {this.gameObject, other})
		{
			StopMovement(element);
		}
		
		StartCoroutine(WaitGameOver(seconds));
	}
	private IEnumerator WaitGameOver(int seconds)
	{
		yield return new WaitForSeconds(seconds);
		gameOver.GameOverExecute();	
	}
	
	private void StopMovement(GameObject movingObject)=>movingObject.GetComponent<MoveComponent>().StopMovement();
}
