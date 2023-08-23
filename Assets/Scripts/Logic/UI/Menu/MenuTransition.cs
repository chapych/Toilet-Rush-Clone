using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Menu Transition", menuName = "ScriptableObjects/Menu Transition", order = 1)]
public class MenuTransition : ScriptableObject
{
	private Animator current = default;
	public bool IsInTransition;
	[SerializeField] private float time;
	public async void DelayAnimationTransition(Component from, Component to, Animator animation)
	{
		if(IsInTransition) return;
		IsInTransition = true;
		
		current = animation;
		await AnimationTransitionStartAsync();
		
		from.gameObject.SetActive(false);
		to.gameObject.SetActive(true);
		
		AnimationTransitionEnd();
	}
	public async void DelayAnimationTransition(int sceneIndex, Animator animation)
	{
		if(IsInTransition) return;
		IsInTransition = true;
		
		current = animation;
		
		await AnimationTransitionStartAsync();
		
		SceneManager.LoadScene(sceneIndex);
		
		AnimationTransitionEnd();
	}
	private async Task AnimationTransitionStartAsync()
	{
		var timeInMSec = (int)(1000 * time);
		
		current.SetTrigger("Start");
		await Task.Delay(timeInMSec);
	}

	private void AnimationTransitionEnd()
	{
		current.SetTrigger("End");
		
		current = default;
		IsInTransition = false;
	}
}
