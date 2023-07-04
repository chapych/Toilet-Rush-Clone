using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class PathIntersection : MonoBehaviour, ISubscriber
{
	static private bool hasCollisionHappened;
	private GameOver gameOver;
	private DustControl dustControl;
	public EventHandler<CollisionEventArgs> OnCollision;
	
	[Inject]
	public void Costruct(GameOver gameOver, DustControl dustControl)
	{
		this.gameOver = gameOver;
		this.dustControl = dustControl;
	}
	
	void Start()
	{
		hasCollisionHappened = false;
		Subscribe();
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
		var movingObject = GetComponent<MoveComponent>();
		
		InvokeEventOnce(other);
		Unsubcribe();
		StopMovement(movingObject);
	}

	private void InvokeEventOnce(GameObject other)
	{
		if (hasCollisionHappened) return;
		
		Vector2 medianCollisionPoint = (transform.position + other.transform.position) / 2;
		OnCollision?.Invoke(this, new CollisionEventArgs(medianCollisionPoint));
		hasCollisionHappened = true;
	}
	
	private void StopMovement(MoveComponent movingObject) => movingObject.StopMovement();

	public void Subscribe()
	{
		OnCollision += gameOver.OnCollisionHandle;
		OnCollision += dustControl.OnCollisionHandle;
	}

	public void Unsubcribe()
	{
		OnCollision -= gameOver.OnCollisionHandle;
		OnCollision -= dustControl.OnCollisionHandle;
	}
}
