using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(SpriteRenderer))]
public class GateCheck : MonoBehaviour, IKindData, ISubscriber
{
	[field : SerializeField] public bool IsGenderNeutral { get; set; }
	[field : SerializeField] public Kind Kind { get; set; }
	
	private GameOver gameOver;
	public EventHandler<CollisionEventArgs> OnCollision;
	
	[Inject]
	private void Construct(GameOver gameOver)
	{
		this.gameOver = gameOver;
	}

	private void Start()
	{
		Subscribe();
	}
	public void Subscribe()
	{
		OnCollision += gameOver.OnCollisionHandleAsync;
	}

	public void Unsubcribe()
	{
		OnCollision -= gameOver.OnCollisionHandleAsync;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		ICharacterData character = other.GetComponent<ICharacterData>();
		if (character != null && character.Kind != Kind)
		{
			other.GetComponent<MoveComponent>().StopMovement();
			OnCollision?.Invoke(this, new CollisionEventArgs(transform.position));
			Unsubcribe();
		}
	}
}
