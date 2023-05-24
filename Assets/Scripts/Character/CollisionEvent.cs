
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CollisionEvent : MonoBehaviour
{
	public event Action OnCollision;
	[Inject]
	public void Costructor(GameOver gameOver)
	{
		OnCollision+=gameOver.GameOverHandle;
	}
	private void OnCollisionEnter2D(Collision2D other) 
	{
		if(other.gameObject.GetComponent<ICharacterData>() != null)
		{
			Debug.Log("smth");
			OnCollision?.Invoke();
		}
	}
}
