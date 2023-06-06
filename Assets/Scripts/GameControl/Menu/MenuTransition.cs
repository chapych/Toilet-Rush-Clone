using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Menu Transition", menuName = "ScriptableObjects/Menu Transition", order = 1)]
public class MenuTransition : ScriptableObject
{
	private int sortingOrder = 10;
	[SerializeField] private Animator animatorPrefab;
	[SerializeField] private float time;
	private Animator animator;

	private Animator GetAnimatorFromPrefab() 
	{
		Canvas animatorHolder = new GameObject("Animator Holder").AddComponent<Canvas>();
		animatorHolder.renderMode = RenderMode.ScreenSpaceOverlay;
		animatorHolder.sortingOrder = sortingOrder;
		
		animator = Instantiate(animatorPrefab, animatorHolder.transform);
		DontDestroyOnLoad(animatorHolder);
		return animator;
	}

	public async void DelayAnimationTransition(Component from, Component to)
	{
		await AnimationTransitionStartAsync();
		from.gameObject.SetActive(false);
		to.gameObject.SetActive(true);
		AnimationTransitionEnd();
	}
	public async void DelayAnimationTransition(int sceneIndex)
	{
		await AnimationTransitionStartAsync();
		SceneManager.LoadScene(sceneIndex);
		AnimationTransitionEnd();
	}
	private async Task AnimationTransitionStartAsync()
	{
		if(!animator)
			animator = GetAnimatorFromPrefab();
		
		var timeInMSec = (int)(1000 * time);
		
		animator.SetTrigger("Start");
		await Task.Delay(timeInMSec);
	}

	private void AnimationTransitionEnd() => animator.SetTrigger("End");
}
