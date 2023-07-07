using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{ 
	public int currentLevel;
	public string ToJson()
	{
		return JsonUtility.ToJson(this);
	}

	public void LoadFromJson(string a_Json)
	{
		JsonUtility.FromJsonOverwrite(a_Json, this);
	}
}

public interface ISaveable
{
	void PopulateSaveData(SaveData saveData);
	void LoadFromSaveData(SaveData saveData);
}