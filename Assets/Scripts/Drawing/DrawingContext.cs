using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class DrawingContext : MonoBehaviour
{
	public const float THRESHOLD = 0.1f;
	private DrawingState state;
	private DrawingStateFactory factory;
	[SerializeField]
	private InputReaderSO inputReader;
	public Line LinePrefab;
	public Line Line;
	public Vector2 TouchPosition {get =>
	
		main.ScreenToWorldPoint(inputReader.Position)
	;private set{}}
	public Camera main;

	/*[Inject]
	public void Constructor(InputReaderSO input) => this.input = input;*/

	private void Awake() 
	{
		factory = new DrawingStateFactory();
		state = factory.GetOrCreate<DrawingStartState>();
	}
	
	private void Start() 
	{
		inputReader.DrawingEnable();
		inputReader.TouchEvent+=TouchHandle;
	}
	
	private void Update() 
	{
		state.UpdateHandler(this);
	}
	
	private void TouchHandle()
	{
		state.Handle(this);
	}
	
	private void OnDisable()
	{
		inputReader.TouchEvent-=TouchHandle;
	}
	
	public void Transition<T>() where T : DrawingState, new()
	{
		state = factory.GetOrCreate<T>();
	}
	
	
}
