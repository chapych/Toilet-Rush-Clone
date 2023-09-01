using System.Collections.Generic;
using GameControl;
using UnityEngine;

public class SaveLoadService : ISaveLoadService
{
	private const string FILE_NAME = "SaveData.dat";
	public void SaveJsonData(ISaveable savable)
	{
		var sd = new SaveData();
		savable.PopulateSaveData(sd);

		FileManager.WriteToFile(FILE_NAME, sd.ToJson());
	}
	
	public bool LoadJsonData(ISaveable savable)
	{
		if (!FileManager.LoadFromFile(FILE_NAME, out var json)) return false;
		var sd = new SaveData();
		sd.LoadFromJson(json);

		savable.LoadFromSaveData(sd);
		return true;
	}
}