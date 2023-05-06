using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator
{
	private Line prefab;
	private Dictionary<CharacterData, Line> createdLines;
	
	public LineCreator(Line prefab) 
	{
		createdLines = new Dictionary<CharacterData, Line>();
		this.prefab = prefab;
	}

	public bool ContainsLineFor(CharacterData character) => createdLines.ContainsKey(character);
	
	public Line Create(CharacterData character, Vector2 position)
	{
		return GameObject.Instantiate(prefab, position, Quaternion.identity);
	}
}
