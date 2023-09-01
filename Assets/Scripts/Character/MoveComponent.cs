using System;
using System.Collections;
using System.Collections.Generic;
using Logic.BaseClasses;
using Logic.BaseClasses.CustomEventArgs;
using UnityEngine;

namespace Character
{
	public class MoveComponent : MonoBehaviour
	{
		private Coroutine coroutine;
		private Rigidbody2D rigidBody;
		[SerializeField] private CollisionObserver collisionObserver;
		[SerializeField] public float speed;
		[SerializeField] private float epsilon;

		private void Awake()
		{
			collisionObserver.OnRaised += StopMovement;
		}

		private void Start()
		{
			rigidBody = GetComponent<Rigidbody2D>();
		}

		public void StartMovement(Queue<Vector2> queue, Action onPointWalkedBy = null, Action onMovedStopped = null)
		{
			coroutine = StartCoroutine(Movement(queue, onPointWalkedBy, onMovedStopped));
		}

		private void StopMovement(object sender, CollisionEventArgs e)
		{
			GameObject other = e.Collision.gameObject;
			if(other != gameObject && other.TryGetComponent(out ICharacterData _))
			{
				StopMovement();
			}
		}

		public void StopMovement()
		{
			StopCoroutine(coroutine);
		}
	
		private IEnumerator Movement(Queue<Vector2> path, Action onPointWalkedBy, Action onMovementStopped)
		{
			Vector2 next = path.Dequeue();
			float step = speed * Time.fixedDeltaTime;
		
			while(true)
			{
				Vector2 newPosition = Vector2.MoveTowards(transform.position, next, step);
				rigidBody.MovePosition(newPosition);
			
				if(Vector2.Distance(transform.position, next) < epsilon)
				{
					if(path.Count == 0)
					{
						if (onMovementStopped != null) onMovementStopped();
						break;
					}
				
					next = path.Dequeue();
					if (onPointWalkedBy != null) onPointWalkedBy();
				}
				yield return null;
			}
		}

		private void OnDestroy()
		{
			collisionObserver.OnRaised -= StopMovement;
		}
	}
}
