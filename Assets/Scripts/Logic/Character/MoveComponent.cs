using System;
using System.Collections;
using System.Collections.Generic;
using Logic.BaseClasses;
using Logic.BaseClasses.CustomEventArgs;
using UnityEngine;

namespace Logic.Character
{
	public class MoveComponent : MonoBehaviour
	{
		private Coroutine coroutine;
		private Rigidbody2D rigidBody;
		private ILineHolder lineHolder;
		public float speed;
		[SerializeField] private CollisionObserver collisionObserver;
		[SerializeField] private float epsilon;

		private void Awake()
		{
			lineHolder = GetComponent<ILineHolder>();
			rigidBody = GetComponent<Rigidbody2D>();
		}

		private void Start()
		{
			collisionObserver.OnCollision += StopMovement;
		}

		public void StartMovement(Queue<Vector2> queue, Action onPointWalkedBy = null, Action onMovedStopped = null)
		{
			coroutine = StartCoroutine(Movement(queue, onPointWalkedBy, onMovedStopped));
		}

		private void StopMovement(object sender, CollisionEventArgs e)
		{
			GameObject other = e.Collision.gameObject;
			if(other != gameObject && other.TryGetComponent(out ILineHolder _))
				StopMovement();
		}

		private void StopMovement() => StopCoroutine(coroutine);

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
						onMovementStopped?.Invoke();
						break;
					}
					next = path.Dequeue();
					onPointWalkedBy?.Invoke();
				}
				yield return null;
			}
		}

		private void OnDestroy() =>
			collisionObserver.OnCollision -= StopMovement;
	}
}
