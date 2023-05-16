using UnityEngine;

public interface IDrawingContext
{
	Vector2 TouchPosition { get; }

	DrawingState GetStartState();
	bool CanCreateLine(CharacterData character);
	void ContinueLine();
	void CreateLine(CharacterData character, Vector2 position);
	void DestroyLine();
	void RegisterLine(FinishData data);
	void TouchHandle();
	void Transition<T>() where T : DrawingState, new();
}
