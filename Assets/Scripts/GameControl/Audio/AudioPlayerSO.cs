using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "AudioPlayer", menuName = "ScriptableObjects/Audio Player", order = 1)]
public class AudioPlayerSO : ScriptableObject
{
	private AudioSource backgroundMusicSource = null;
	public float MusicVolume { get; private set; }
	public float SoundVolume { get; private set; }
	
	public void PlayMusic(AudioSource source)
	{
		if(!backgroundMusicSource) backgroundMusicSource = source;
		if(backgroundMusicSource.isPlaying) return;
		
		source.volume = MusicVolume;
		source.Play();
	}
	
	public void PlayClickSound(AudioSource source)
	{
		source.volume = SoundVolume;
		source.Play();
	}
	
	public void SetMusicVolume(Slider slider) 
	{
		MusicVolume = slider.value;
		backgroundMusicSource.volume = MusicVolume;	
	}
	
	public void SetSoundVolume(Slider slider) => SoundVolume = slider.value;
}
