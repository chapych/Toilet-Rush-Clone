using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions
{
	public static Queue<Vector2> ConvertToQueue(this Vector3[] array)
	{
		int count = array.Length;
		
		var queue = new Queue<Vector2>();
		for (int i = 0; i < count; i++)
		{
			queue.Enqueue((Vector2)array[i]);
		}

		return queue;
	}
}
