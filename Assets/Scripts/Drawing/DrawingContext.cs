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
	public LineCreator lineCreator;
	[SerializeField]
	private InputReaderSO inputReader;
	[SerializeField]
	private Line LinePrefab;
	public Line Line;
	public event Action<Line> OnProperLine;
	public Vector2 TouchPosition {
		get => main.ScreenToWorldPoint(inputReader.Position);
		private set {}
	}
	public Camera main;//put in in injection
	public Dictionary<GameObject, Line> createdLines;

	/*[Inject]
	public void Constructor(InputReaderSO input) => this.input = input;*/

	private void Awake() 
	{
		factory = new DrawingStateFactory();
		lineCreator = new LineCreator(LinePrefab);
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
