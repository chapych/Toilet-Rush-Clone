using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishData : MonoBehaviour, IFinishData
{
	public bool IsGenderNeutral { get; set; }
	public Gender Gender { get; set; }
}

public interface IFinishData
{
	public bool IsGenderNeutral { get; set; }
	public Gender Gender { get; set; }
}