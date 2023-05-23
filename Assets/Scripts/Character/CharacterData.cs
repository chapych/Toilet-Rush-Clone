using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour, ICharacterData
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private Gender gender;
	public Gender Gender 
	{
		get => gender;
		set
		{
			gender = value;
			spriteRenderer.color = GenderToColor.GetColor(gender);
		}
	}

	public Line Line { get; set; }
	
	private void OnValidate() 
	{
		Gender = gender;
	}
}
