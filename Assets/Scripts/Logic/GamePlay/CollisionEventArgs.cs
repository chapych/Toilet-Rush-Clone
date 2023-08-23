using System;
using UnityEngine;

namespace Logic.GamePlay
{
	public class CollisionEventArgs : EventArgs
	{
		public Vector2 Position { get; set; }
		public CollisionEventArgs(Vector2 position)
		{
			Position = position;
		}
	}
}