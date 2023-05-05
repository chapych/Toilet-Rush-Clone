using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "InputReader")]
public class InputReaderSO : ScriptableObject, DrawingInput.IDrawingActions
{
	private DrawingInput controls;
	public event Action TouchEvent;
	public event Action PositionEvent;
	public Vector2 Position 
	{
		get => controls.Drawing.Position.ReadValue<Vector2>();
	}
	
	private void OnEnable() 
	{
		if(controls == null)
			{
				controls = new DrawingInput();
				controls.Drawing.SetCallbacks(this); 
				DrawingEnable();
			}
	}
	
	public void DrawingEnable()
	{
		controls.Drawing.Enable();
	}
	
	public void OnTouch(InputAction.CallbackContext context)
	{
		if(context.started)
			TouchEvent?.Invoke();
	}

	public void OnPosition(InputAction.CallbackContext context)
	{
		PositionEvent?.Invoke();
	}
}
