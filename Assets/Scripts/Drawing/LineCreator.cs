using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : ICreator<Line, ICharacterData>
{
	private Line prefab;
	private Line currentLine;
	private ICharacterData currentCharacter;
	private List<ICharacterData> createdLines = new List<ICharacterData>();

	public LineCreator(Line prefab) => this.prefab = prefab;
	public bool ContainsElementFor(ICharacterData character) => createdLines.Contains(character);
	public Line Create(ICharacterData character, Vector2 position)
	{
		currentLine = GameObject.Instantiate(prefab, position, Quaternion.identity);
		currentCharacter = character;
		return currentLine;
	}

	public void SetLineProperties(ICharacterData character)
	{
		currentLine.transform.parent = character.transform;
		currentLine.Color = KindToColor.GetColor(character.Kind);
	}

	public void ContinueLine(Vector2 position)
	{
		if (currentLine.CanContinue(position, Constants.THRESHOLD))
		{
			currentLine.Continue(position);
		}
	}

	public bool TryAddCurrentLineToList(IKindData finishData)
	{
		if (finishData.IsGenderNeutral || finishData.Kind == currentCharacter.Kind)
		{
			createdLines.Add(currentCharacter);
			currentCharacter.Line = currentLine;
			currentCharacter.Finish = finishData;
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
