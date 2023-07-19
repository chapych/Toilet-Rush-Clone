using System;
using UnityEngine;

public interface IDrawingContext
{
	Vector2 TouchPosition { get;}
	event Action OnProperLineCreated;
	bool CanCreateLine(CharacterData character);
	void ContinueLine(Vector2 position);
	void CreateLine(CharacterData character, Vector2 position);
	void DestroyLine();
	void TryRegisterLine(FinishData data);
	void TouchHandle();
}
