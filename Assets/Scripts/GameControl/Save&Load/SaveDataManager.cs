using System.Collections.Generic;
using UnityEngine;

public static class SaveDataManager
{
	private const string FILE_NAME = "SaveData.dat";
	public static void SaveJsonData(ISaveable saveable)
	{
		SaveData sd = new SaveData();
		saveable.PopulateSaveData(sd);

		FileManager.WriteToFile(FILE_NAME, sd.ToJson());
	}
	
	public static void LoadJsonData(ISaveable saveable)
	{
		if (FileManager.LoadFromFile(FILE_NAME, out var json))
		{
			SaveData sd = new SaveData();
			sd.LoadFromJson(json);

			saveable.LoadFromSaveData(sd);
		}
	}
}