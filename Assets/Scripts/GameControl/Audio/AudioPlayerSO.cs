using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioPlayer", menuName = "ScriptableObjects/Audio Player", order = 1)]
public class AudioPlayerSO : ScriptableObject
{
	private Vector3 audioSourcePosition = Vector3.zero;
//	[SerializeField] private AudioClip backgroundMusic;
	
	public void PlayClickSound(AudioSource source)
	{
		source.Play();
	}
}
