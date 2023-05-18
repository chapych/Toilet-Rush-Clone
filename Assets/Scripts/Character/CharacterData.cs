using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour, ICharacterData
{
	[field : SerializeField] public Gender Gender { get; set; }

	public Line Line { get; set; }

	public void OnAllLinesCreatedHandle()
	{
		var moveComponent = GetComponent<Move>();
		var points = Line.Points;
		GetComponent<Move>().StartMovement(points);
	}
}