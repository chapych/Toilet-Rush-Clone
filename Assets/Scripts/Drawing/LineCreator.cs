using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
	[SerializeField]
	private Line prefab;
	private Line currentLine;
	private CharacterData currentCharacter;
	private Dictionary<CharacterData, Line> createdLines = new Dictionary<CharacterData, Line>();
	public bool ContainsLineFor(CharacterData character) => createdLines.ContainsKey(character);
	public void Create(CharacterData character, Vector2 position)
	{
		currentLine = Instantiate(prefab, position, Quaternion.identity);
		currentLine.transform.parent = this.transform;
		currentLine.Color = GenderToColor.GetColor(character.Gender);
		
		currentCharacter = character;
	}
	
	public void ContinueLine(Vector2 position)
	{
		if(currentLine.CanContinue(position, DrawingContext.THRESHOLD))
		{
			currentLine.ContinueLine(position);
		}
	}
	
	public void AddCurrentLine(FinishData finishData)
	{
		if(finishData.IsGenderNeutral || finishData.Gender == currentCharacter.Gender)
			createdLines[currentCharacter] = currentLine;
		else DestroyLine();
	}
	public void DestroyLine()
	{
		Destroy(currentLine.gameObject);
		currentCharacter = null;
	}
}
