using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator
{
	private Line prefab;
	private Line currentLine;
	private CharacterData currentCharacter;
	private List<CharacterData> createdLines = new List<CharacterData>(); //make seperated class for created lines
	
	public LineCreator(Line prefab)
	{
		this.prefab = prefab;
	}
	public bool ContainsLineFor(CharacterData character) => createdLines.Contains(character);
	public void Create(CharacterData character, Vector2 position)
	{
		currentLine = GameObject.Instantiate(prefab, position, Quaternion.identity);///subcribe to this
		currentLine.transform.parent = character.transform;
		currentLine.Color = GenderToColor.GetColor(character.Gender);
		currentCharacter = character;
	}
	
	public void ContinueLine(Vector2 position)
	{
		if(currentLine.CanContinue(position, DrawingContext.THRESHOLD))
		{
			currentLine.Continue(position);
		}
	}
	
	public bool TryAddCurrentLine(FinishData finishData)
	{
		if(finishData.IsGenderNeutral || finishData.Gender == currentCharacter.Gender)
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
