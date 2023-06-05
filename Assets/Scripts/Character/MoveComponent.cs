using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
	private Vector2 next;
	private Coroutine coroutine;
	public Queue<Vector2> path;
	private Rigidbody2D rigidbody;
	private float step;
	[SerializeField] public float speed;
	[SerializeField] private float epsilon = float.Epsilon;
	public event Action OnLinePointWalkedBy;
	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}
	public void StartMovement(Queue<Vector2> queue)
	{
		path = queue;
		next = path.Dequeue();
		step = speed * Time.fixedDeltaTime;
		
		coroutine = StartCoroutine(Movement());
	}
	
	public void StopMovement()
	{
		StopCoroutine(coroutine);
	}
	
	private IEnumerator Movement()
	{
		while(true)
		{
			if(Vector2.Distance(transform.position, next) < epsilon)
			{
				if(path.Count != 0)
				{
					next = path.Dequeue();
					OnLinePointWalkedBy?.Invoke();
				}
				else break;
			}
			Vector2 newPosition = Vector2.MoveTowards(transform.position, next, step);
			rigidbody.MovePosition(newPosition);
			yield return null;
		}
	}
}
