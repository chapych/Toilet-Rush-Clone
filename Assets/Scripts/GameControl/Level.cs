using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : ISaveable
{
	public int Value { get; private set;}
	public Level() => Value = 1;
	public Level(int index) => Value = index;
	
	public static bool operator == (Level first, Level second)
	{
		return first.Value == second.Value;
	}
	
	public static bool operator != (Level first, Level second) => !(first == second);
	public void IncreaseLevel() => Value++;

	public void LoadFromSaveData(SaveData saveData)
	{
		Value = saveData.currentLevel;
	}

	public void PopulateSaveData(SaveData saveData)
	{
		saveData.currentLevel = Value;
	}

    public override bool Equals(object obj)
    {
        return obj is Level level &&
               Value == level.Value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }
}
