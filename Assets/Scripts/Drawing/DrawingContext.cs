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
	
	public Vector2 TouchPosition => input.TouchPosition;
	
	public event Action OnProperLineCreated;

	/*[Inject]
public void Constructor(InputReaderSO input) => this.input = input;*/

	private void Start()
	{
		input = GetComponent<DrawingInputControler>();
		lineCreator = new LineCreator(prefab);
		factory = new DrawingStateFactory();
		state = GetStartState();
	}

	private void Update()
	{
		state.UpdateHandler(this);
	}
	public DrawingState GetStartState()
	{
		return factory.GetOrCreate<DrawingStartState>();
	}

	public void TouchHandle()
	{
		state.TouchHandle(this);
	}

	public void Transition<T>() where T : DrawingState, new()
	{
		state = factory.GetOrCreate<T>();
	}

	public bool CanCreateLine(CharacterData character) => !lineCreator.ContainsLineFor(character);

	public void CreateLine(CharacterData character, Vector2 position)
	{
		Line line = lineCreator.Create(character, position);	
		lineCreator.SetLineProperties(character);
	}

	public void ContinueLine() => lineCreator.ContinueLine(TouchPosition);

	public void RegisterLine(FinishData data)
	{
		bool hasAdded = lineCreator.TryAddCurrentLine(data);
		if(hasAdded) OnProperLineCreated?.Invoke();
	}
	public void DestroyLine() => lineCreator.DestroyLine();
}
