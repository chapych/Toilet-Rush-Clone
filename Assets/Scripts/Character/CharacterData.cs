using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour, ICharacterData
{
	private SpriteRenderer spriteRenderer;
	[SerializeField] private Kind kind;
	public Kind Kind 
	{
		get => kind;
		set
		{
			kind = value;
			//SetColor();
		}
	}

	private void SetColor()
	{
		if (!spriteRenderer)
			spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = KindToColor.GetColor(kind);
	}

	public Line Line { get; set; }
	public IFinishData Finish {get; set; }
	
	private void OnValidate() 
	{
		Kind = kind;
	}
}
