using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : ICreator<Line, ICharacterData>
{
	private Line prefab;
	private Line currentLine;
	private ICharacterData currentCharacter;
	private List<ICharacterData> createdLines = new List<ICharacterData>(); //make seperated class for created lines

	public LineCreator(Line prefab) => this.prefab = prefab;
	public bool ContainsElementFor(ICharacterData character) => createdLines.Contains(character);
	public Line Create(ICharacterData character, Vector2 position)
	{
		currentLine = GameObject.Instantiate(prefab, position, Quaternion.identity);///subcribe to this
		currentCharacter = character;
		return currentLine;
	}

	public void SetLineProperties(ICharacterData character)
	{
		currentLine.transform.parent = character.transform;
		currentLine.Color = GenderToColor.GetColor(character.Gender);
	}

	public void ContinueLine(Vector2 position)
	{
		if (currentLine.CanContinue(position, DrawingContext.THRESHOLD))
		{
			currentLine.Continue(position);
		}
	}

	public bool TryAddCurrentLineToList(IFinishData finishData)
	{
		if (finishData.IsGenderNeutral || finishData.Gender == currentCharacter.Gender)
		{
			createdLines.Add(currentCharacter);
			currentCharacter.Line = currentLine;
			return true;
		}
		DestroyLine();
		return false;
	}

	public void DestroyLine()
	{
		GameObject.Destroy(currentLine.gameObject);
		currentCharacter = null;
	}
}
