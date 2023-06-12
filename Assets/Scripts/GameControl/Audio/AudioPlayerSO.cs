using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "AudioPlayer", menuName = "ScriptableObjects/Audio Player", order = 1)]
public class AudioPlayerSO : ScriptableObject
{
	private AudioSource backgroundMusicSource;
	private float musicVolume; //make to public
	private float soundVolume;
	
	public void PlayMusic(AudioSource source)
	{
		backgroundMusicSource = source;
		source.volume = musicVolume;
		source.Play();
	}
	
	public void PlayClickSound(AudioSource source)
	{
		source.volume = soundVolume;
		source.Play();
	}
	
	public void SetMusicVolume(Slider slider) 
	{
		musicVolume = slider.value;
		backgroundMusicSource.volume = musicVolume;	
	}
	
	public void SetSoundVolume(Slider slider) => soundVolume = slider.value;
}
