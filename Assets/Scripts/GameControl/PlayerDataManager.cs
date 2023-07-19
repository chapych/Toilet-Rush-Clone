using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerDataManager : MonoBehaviour
{
	private AudioPlayerSO player;
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
	
	[Inject]
	public void Construct(AudioPlayerSO player)
	{
		this.player = player;
	}
	private void Awake() 
	{
		maxAvailableLevel = new Level();
		currentLevel = new Level();
		SaveDataManager.LoadJsonData(maxAvailableLevel);
		SaveDataManager.LoadJsonData(player);
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
		Save();
	}
	
	private void OnDestroy()
	{
		Save();
	}

	private void Save()
	{
		SaveDataManager.SaveJsonData(maxAvailableLevel);
		SaveDataManager.SaveJsonData(player);
	}
}
