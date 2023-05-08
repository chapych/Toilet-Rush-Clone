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
	private LineCreator lineCreator;
	private DrawingInputControler input;
	public Vector2 TouchPosition => input.TouchPosition;
	//public Line Line => lineCreator.CurrentLine; 

	/*[Inject]
public void Constructor(InputReaderSO input) => this.input = input;*/

	private void Awake() 
	{
		input = GetComponent<DrawingInputControler>();
		lineCreator = GetComponent<LineCreator>();
		factory = new DrawingStateFactory();
		state = factory.GetOrCreate<DrawingStartState>();
	}
	
	private void Update() 
	{
		state.UpdateHandler(this);
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

	public void CreateLine(CharacterData character, Vector2 position) => lineCreator.Create(character, position);
	
	public void ContinueLine() => lineCreator.ContinueLine(TouchPosition);
	
	public void RegisterLine(FinishData data) => lineCreator.AddCurrentLine(data);
	public void DestroyLine() => lineCreator.DestroyLine();
}
