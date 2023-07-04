using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEventArgs : EventArgs
{
	public Vector2 Position { get; set; }
	public CollisionEventArgs(Vector2 position)
	{
		Position = position;
	}
}