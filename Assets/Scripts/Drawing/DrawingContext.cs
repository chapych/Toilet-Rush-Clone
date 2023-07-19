using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class DrawingContext : MonoBehaviour, IDrawingContext
{
	private LineCreator lineCreator;
	private DrawingStateMachine stateMachine;
	private DrawingInputControler input;
	[SerializeField] private Line prefab;
	public Vector2 TouchPosition { get => input.TouchPosition ?? default(Vector2);}
	public event Action OnProperLineCreated;

	private void Start()
	{
		lineCreator = new LineCreator(prefab);
		stateMachine = new DrawingStateMachine();
		stateMachine.Transition<DrawingStartState>();

		input = GetComponent<DrawingInputControler>();		
	}

	private void Update()
	{
		if(input.TouchPosition is null) return;
		
		stateMachine.UpdateHandler(this);
	}
	public void TouchHandle()
	{
		if(input.TouchPosition is null) return;
		
		stateMachine.TouchHandle(this);
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
