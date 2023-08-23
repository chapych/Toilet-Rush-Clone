using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

[Serializable]
public class FinishData : MonoBehaviour, IKindData
{
	[field : SerializeField] public Kind Kind { get; set; }
}
