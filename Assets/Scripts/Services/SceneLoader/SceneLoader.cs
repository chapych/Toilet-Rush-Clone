using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : ISceneLoader
{
	private readonly ICoroutineRunner coroutineRunner;
	public SceneLoader(ICoroutineRunner coroutineRunner) =>
		this.coroutineRunner = coroutineRunner;
	public void Load(string name, Action onLoaded = null) => 
		coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));

	public void Load(int index, Action onLoaded = null)
	{
		string name = SceneManager.GetSceneAt(index).name;
		coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
	}

	private IEnumerator LoadScene(string nextScene, Action onLoaded)
	{
		if (SceneManager.GetActiveScene().name == nextScene)
	  	{
			onLoaded?.Invoke();
			yield break;
	  	}
	  
	  	AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

	  	while (!waitNextScene.isDone)
		    yield return null;

	  	onLoaded?.Invoke();
	}
}
