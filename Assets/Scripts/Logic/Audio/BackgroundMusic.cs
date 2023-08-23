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
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	
	private void Start()
	{
		player.PlayMusic(GetComponent<AudioSource>());
	}
}
