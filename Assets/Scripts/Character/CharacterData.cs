using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using Drawing;
using UnityEngine;

public class CharacterData : MonoBehaviour, ICharacterData, ILineHolder
{
	private SpriteRenderer spriteRenderer;
	[SerializeField] private Kind kind;
	public Kind Kind 
	{
		get => kind;
		private set => kind = value;
	}

	public ILine Line { get; set; }
	public bool IsFree => Line == null;
	public Color Color => KindToColor.GetColor(kind);

	public bool CanBeFinishPoint(Vector2 point)
	{
		bool hasComponent = Physics2DExtension.TryOverlapCircle(point, Constants.DETECTING_RADIUS,
			out IKindData finish);
		
		return hasComponent && (finish.IsGenderNeutral || finish.Kind == Kind);
	}

	public IKindData Finish {get; set; }
	
	private void OnValidate() 
	{
		Kind = kind;
	}
}
