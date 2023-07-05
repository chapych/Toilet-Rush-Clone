using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSliderValue : SliderValue
{
	public override void Synchronise(Slider slider)
	{
		slider.value = player.MusicVolume;
	}
}
