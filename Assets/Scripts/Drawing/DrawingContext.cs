using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class DrawingContext : MonoBehaviour, IDrawingContext
{
	public const float THRESHOLD = 0.1f;
	private DrawingState state;
	private DrawingStateFactory factory;
	private LineCreator lineCreator;
	private DrawingInputControler input;
	[SerializeField] private Line prefab;
	
	public Vector2 TouchPosition { get; set; }
	
	public event Action OnProperLineCreated;

	private void Start()
	{
		input = GetComponent<DrawingInputControler>();
		lineCreator = new LineCreator(prefab);
		factory = new DrawingStateFactory();
		state = GetStartState();
	}

	private void Update()
	{
		if(input.TouchPosition is null) return;
		TouchPosition = input.TouchPosition ?? default(Vector2);
		
		state.UpdateHandler(this);
	}
	public DrawingState GetStartState()
	{
		return factory.GetOrCreate<DrawingStartState>();
	}

	public void TouchHandle()
	{
		if(input.TouchPosition is null) return;
		state.TouchHandle(this);
	}

	public void Transition<T>() where T : DrawingState, new()
	{
		state = factory.GetOrCreate<T>();
	}

	public bool CanCreateLine(CharacterData character) => !lineCreator.ContainsElementFor(character);

	public void CreateLine(CharacterData character, Vector2 position)
	{
		Line line = lineCreator.Create(character, position);	
		lineCreator.SetLineProperties(character);
	}

	public void ContinueLine(Vector2 position) => lineCreator.ContinueLine(position);

	public void TryRegisterLine(FinishData data)
	{
		bool hasAdded = lineCreator.TryAddCurrentLineToList(data);
		if(hasAdded) OnProperLineCreated?.Invoke();
	}
	public void DestroyLine() => lineCreator.DestroyLine();
}
