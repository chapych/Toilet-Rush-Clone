using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FinishData : MonoBehaviour, IFinishData
{
	[field : SerializeField] public bool IsGenderNeutral { get; set; }
	[field : SerializeField] public Kind Kind { get; set; }
}
