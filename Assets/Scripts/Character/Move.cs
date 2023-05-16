using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	private Vector2 next;
	public Queue<Vector2> path;
	private Rigidbody2D rigidbody;
	[SerializeField] private float epsilon = 0.1f;
	public float speed;
	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}
	/*void FixedUpdate()
	{
		if(path.Count == 0) return;
		if(Vector2.Distance(transform.position, next)<float.Epsilon)
			next = path.Dequeue();
		var step = speed * Time.fixedDeltaTime;
		Vector2 newPosition = Vector2.MoveTowards(transform.position, next, step);
		rigidbody.MovePosition(newPosition);
	}*/
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
					next = path.Dequeue();
				else break;
			}
			var step = speed * Time.fixedDeltaTime;
			Vector2 newPosition = Vector2.MoveTowards(transform.position, next, step);
			rigidbody.MovePosition(newPosition);
			yield return null;
		}
	}
}
