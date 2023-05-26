using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour, ICharacterData
{
	private SpriteRenderer spriteRenderer;
	[SerializeField] private Gender gender;
	public Gender Gender 
	{
		get => gender;
		set
        {
            gender = value;
            SetColor();
        }
    }

    private void SetColor()
    {
        if (!spriteRenderer)
            spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = GenderToColor.GetColor(gender);
    }

    public Line Line { get; set; }
	
	private void OnValidate() 
	{
		Gender = gender;
	}
}
