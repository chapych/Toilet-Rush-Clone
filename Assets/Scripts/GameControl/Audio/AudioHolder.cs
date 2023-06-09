using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class AudioHolder : MonoBehaviour
{
	[SerializeField] private Audio clickSound;
	public AudioSource ClickSound => clickSound.Source;
	
	private void Awake()
	{
		var type =  typeof(Audio);
		foreach(var property in this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
		{
			if(property.FieldType != type) return;
			
			Audio audio = property.GetValue(this) as Audio;
			audio.Source = gameObject.AddComponent<AudioSource>();
			audio.Source.clip = audio.AudioClip;
			audio.Source.playOnAwake = false;
		}
	}
}
