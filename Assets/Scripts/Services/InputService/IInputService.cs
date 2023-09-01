using System;
using UnityEngine;

namespace Drawing
{
	public interface IInputService
	{
		public event Action TouchStartedEvent;
		public event Action TouchPerformedEvent;
		Vector2 Position { get; }
		void Initialise();
	}
}
