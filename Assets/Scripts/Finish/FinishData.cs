using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[Serializable]
public class FinishData : MonoBehaviour, IKindData
{
	[field : SerializeField] public bool IsGenderNeutral { get; set; }
	[field : SerializeField] public Kind Kind { get; set; }
}
