using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Audio", menuName = "ScriptableObjects/Audio", order = 1)]
public class Audio : ScriptableObject
{
	public string AudioName;
	public AudioClip AudioClip;
	[HideInInspector]
	public AudioSource Source;
}
