using System;
using UnityEngine;

public interface IDrawingContext
{
	Vector2 TouchPosition { get; set; }
	event Action OnProperLineCreated;
	DrawingState GetStartState();
	bool CanCreateLine(CharacterData character);
	void ContinueLine(Vector2 position);
	void CreateLine(CharacterData character, Vector2 position);
	void DestroyLine();
	void TryRegisterLine(FinishData data);
	void TouchHandle();
	void Transition<T>() where T : DrawingState, new();
}
