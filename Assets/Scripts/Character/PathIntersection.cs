using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class PathIntersection : MonoBehaviour
{
	private float waitTillGameOverPanel = 1f;
	private GameOver gameOver;
	public event Action<Vector2> OnCollision;
	
	[Inject]
	public void Costruct(GameOver gameOver, DustControl dustControl)
	{
		this.gameOver = gameOver;
		
		OnCollision += dustControl.OnCollisionHandle;
	}
	
	private void OnCollisionEnter2D(Collision2D collision) 
	{
		var other = collision.gameObject;
		if(other.TryGetComponent(out ICharacterData component))
		{
			HandleCollision(other);
		}
	}
		
	private void HandleCollision(GameObject other)
	{
		Vector2 medianCollisionPoint = (transform.position + other.transform.position) / 2;
		
		OnCollision?.Invoke(medianCollisionPoint);
		foreach(var element in new GameObject[] {gameObject, other})
		{
			var movingObject = element.GetComponent<MoveComponent>();
			StopMovement(movingObject);
		}
		StartCoroutine(ShowGameOverPanel(waitTillGameOverPanel));
	}
	
	private IEnumerator ShowGameOverPanel(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		gameOver.GameOverExecute();
	}
	
	private void StopMovement(MoveComponent movingObject) => movingObject.StopMovement();
}
