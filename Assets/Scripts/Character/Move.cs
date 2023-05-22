using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	private Vector2 next;
	public Queue<Vector2> path;
	private Rigidbody2D rigidbody;
	[SerializeField] private float epsilon = float.Epsilon;
	public float Speed;
	
	public event Action<Vector2> OnLineStartChanged;
	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}
	public void StartMovement(Queue<Vector2> queue)
	{
		path = queue;
		next = path.Dequeue();
		
		StartCoroutine(Movement());
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
					OnLineStartChanged(next);
				}
				else break;
			}
			var step = Speed * Time.fixedDeltaTime;
			Vector2 newPosition = Vector2.MoveTowards(transform.position, next, step);
			rigidbody.MovePosition(newPosition);
			yield return null;
		}
	}
}
