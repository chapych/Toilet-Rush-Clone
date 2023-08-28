using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
	public class MoveComponent : MonoBehaviour
	{
		private Coroutine coroutine;
		private Rigidbody2D rigidBody;
		[SerializeField] public float speed;
		[SerializeField] private float epsilon;
		public event Action OnLinePointWalkedBy;
		void Start()
		{
			rigidBody = GetComponent<Rigidbody2D>();
		}
		public void StartMovement(Queue<Vector2> queue, Action onMovedStopped)
		{
			coroutine = StartCoroutine(Movement(queue, onMovedStopped));
		}
	
		public void StopMovement()
		{
			StopCoroutine(coroutine);
		}
	
		private IEnumerator Movement(Queue<Vector2> path, Action onMovementStopped)
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
						onMovementStopped();
						break;
					}
				
					next = path.Dequeue();
					OnLinePointWalkedBy?.Invoke();
				}
				yield return null;
			}
		}
	}
}
