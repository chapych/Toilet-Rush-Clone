using System;
using UnityEngine;

public interface IDrawingContext
{
	Vector2 TouchPosition { get; }
	event Action OnProperLineCreated;
	DrawingState GetStartState();
	bool CanCreateLine(CharacterData character);
	void ContinueLine();
	void CreateLine(CharacterData character, Vector2 position);
	void DestroyLine();
	void TryRegisterLine(FinishData data);
	void TouchHandle();
	void Transition<T>() where T : DrawingState, new();
}
