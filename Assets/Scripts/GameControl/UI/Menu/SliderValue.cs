using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SliderValue : MonoBehaviour //get player voluem data
{
	private AudioPlayerSO player;
	 
	[Inject]
	private void Construct(AudioPlayerSO player)
	{
		this.player = player;
	}
	private void Awake()
	{
		Slider slider = GetComponent<Slider>();
	}
}