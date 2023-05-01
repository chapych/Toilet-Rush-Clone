using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DrawingContext : MonoBehaviour
{
	public Vector2 DrawingPosition {get; set;}
	private DrawingState state;
	private DrawingStateFactory factory;
	
	private void Awake() 
	{
		factory = new DrawingStateFactory();
		state = factory.GetOrCreate<DrawingStartState>();
	}
}
