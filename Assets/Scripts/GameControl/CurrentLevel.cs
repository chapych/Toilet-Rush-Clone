using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLevel : ISaveable
{
	public int Value { get; private set;}
	
	public CurrentLevel() => Value = 1;
	public void IncreaseLevel() => Value++;

	public void LoadFromSaveData(SaveData saveData)
	{
		Value = saveData.currentLevel;
	}

	public void PopulateSaveData(SaveData saveData)
	{
		saveData.currentLevel = Value;
	}
}
