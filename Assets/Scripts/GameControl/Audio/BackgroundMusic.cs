using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BackgroundMusic : MonoBehaviour
{
	private AudioPlayerSO player;
	[Inject]
	public void Construct(AudioPlayerSO player) => this.player = player; 
	void Awake()
	{
		DontDestroyOnLoad(this.transform.root);
		player.PlayMusic(GetComponent<AudioSource>());	
	} 
}
