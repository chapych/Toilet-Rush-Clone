using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
	private Level maxAvailableLevel;
	public int MaxAvailableLevel 
	{ 
		get => maxAvailableLevel.Value;
	}
	private Level currentLevel;
	public int CurrentLevel 
	{ 
		get => currentLevel.Value;
		set
		{
			currentLevel = new Level(value);
		}
	}
	private void Awake() 
	{
		maxAvailableLevel = new Level();
		currentLevel = new Level();
	}
	private void Start()
	{
		SaveDataManager.LoadJsonData(maxAvailableLevel);
	}
	
	public void IncreaseLevel()
	{
		if(currentLevel == maxAvailableLevel) 
		{
			maxAvailableLevel.IncreaseLevel();
		}
		currentLevel.IncreaseLevel();
	}
	
	private void OnApplicationQuit() 
	{
		SaveDataManager.SaveJsonData(maxAvailableLevel);
	}
	
	private void OnDestroy()
	{
		SaveDataManager.SaveJsonData(maxAvailableLevel);
	}
}
