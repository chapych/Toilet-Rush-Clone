using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Drawing
{
	public class InputService : IInputService, Input.IDrawingActions
	{
		private Input controls;
		private Camera camera;
		public event Action TouchStartedEvent;
		public event Action TouchPerformedEvent;
		public Vector2 Position => GetTouchPosition();

		public void Initialise()
		{
			if (controls != null) return;
			controls = new Input();
			controls.Drawing.SetCallbacks(this);
			DrawingEnable();
		}
		private void DrawingEnable()
		{
			controls.Drawing.Enable();
		}

		private Vector2 GetTouchPosition()
		{
			if (!camera) camera = Camera.main;
			var position = controls.Drawing.Position.ReadValue<Vector2>();
			return camera.ScreenToWorldPoint(position);
		}

		public void OnTouch(InputAction.CallbackContext context)
		{
			if (context.started)
				TouchStartedEvent?.Invoke();
			if(context.performed)
			{
				TouchPerformedEvent?.Invoke();
			}
		}

		public void OnPosition(InputAction.CallbackContext context)
		{
		}
	}
}
