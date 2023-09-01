using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{ 
	public int currentLevel;
	public float MusicVolume;
	public float SoundVolume;
	public string ToJson()
	{
		return JsonUtility.ToJson(this);
	}

	public void LoadFromJson(string json)
	{
		JsonUtility.FromJsonOverwrite(json, this);
	}
}