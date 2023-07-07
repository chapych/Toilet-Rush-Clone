using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
	public CurrentLevel currentLevel;
	
	private void Awake() 
	{
		currentLevel = new CurrentLevel();
	}
	private void Start()
	{
		SaveDataManager.LoadJsonData(currentLevel);
		Debug.Log(currentLevel.Value);
	}
	
	private void OnApplicationQuit() 
	{
		SaveDataManager.SaveJsonData(currentLevel);
	}
	
	private void OnDestroy()
	{
		SaveDataManager.SaveJsonData(currentLevel);
	}
}
