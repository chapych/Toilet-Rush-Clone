using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public abstract class SliderValue : MonoBehaviour
{
	protected AudioPlayerSO player;
	 
	[Inject]
	private void Construct(AudioPlayerSO player)
	{
		this.player = player;
	}
	private void Awake()
	{
		Slider slider = GetComponent<Slider>();
		
		Synchronise(slider);
	}
	
	public abstract void Synchronise(Slider slider);
}