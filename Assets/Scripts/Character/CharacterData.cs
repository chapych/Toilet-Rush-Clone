using System;
using System.Collections;
using System.Collections.Generic;
using Drawing;
using UnityEngine;

public class CharacterData : MonoBehaviour, ICharacterData
{
	private SpriteRenderer spriteRenderer;
	[SerializeField] private Kind kind;
	public Kind Kind 
	{
		get => kind;
		set => kind = value;
	}

	private void SetColor()
	{
		if (!spriteRenderer)
			spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = KindToColor.GetColor(kind);
	}

	public ILine Line { get; set; }
	public IKindData Finish {get; set; }
	
	private void OnValidate() 
	{
		Kind = kind;
	}
}
