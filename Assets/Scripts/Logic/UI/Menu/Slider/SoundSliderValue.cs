using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSliderValue : SliderValue
{
    public override void Synchronise(Slider slider)
    {
        slider.value = player.SoundVolume;
    }
}
