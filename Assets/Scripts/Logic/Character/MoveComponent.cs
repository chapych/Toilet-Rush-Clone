using System;
using System.Collections;
using System.Collections.Generic;
using Logic.BaseClasses;
using Logic.BaseClasses.CustomEventArgs;
using UnityEngine;

namespace Logic.Character
{
	public class MoveComponent : MonoBehaviour, IMovable
	{
		private Coroutine coroutine;
		[SerializeField] private float speed;
		[SerializeField] private float epsilon;
		[SerializeField] private CollisionObserver collisionObserver;
		[SerializeField] private Rigidbody2D rigidBody;

		private void Awake()
		{
			rigidBody ??= GetComponent<Rigidbody2D>();
			collisionObserver ??= GetComponent<CollisionObserver>();
		}

		private void Start() => collisionObserver.OnCollision += StopMovement;

		public void StartMovement(Queue<Vector2> queue, Action onPointWalkedBy = null, Action onMovementFinished = null)
		{
			coroutine = StartCoroutine(Movement(queue, onPointWalkedBy, onMovementFinished));
		}

		private void StopMovement(object sender, CollisionEventArgs e)
		{
			GameObject other = e.Collision.gameObject;
			if (other != gameObject && other.TryGetComponent(out ILineHolder _))
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
