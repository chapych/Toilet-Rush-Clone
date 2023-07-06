using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BackgroundMusic : MonoBehaviour
{
	private static BackgroundMusic instance = null;
	private AudioPlayerSO player;
	[Inject]
	public void Construct(AudioPlayerSO player) => this.player = player; 
	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			// Allow audio to keep playing between scenes
			instance = this;
			DontDestroyOnLoad(gameObject);
			player.PlayMusic(GetComponent<AudioSource>());
		}
	}
}
