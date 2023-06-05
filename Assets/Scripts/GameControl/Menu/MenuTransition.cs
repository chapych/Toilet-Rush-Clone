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
	private delegate void ParamsAction(params object[] arguments);

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
		await AnimationTransitionStart();
		from.gameObject.SetActive(false);
		to.gameObject.SetActive(true);
		AnimationTransitionEnd();
	}
	public async void DelayAnimationTransition(int sceneIndex)
	{
		await AnimationTransitionStart();
		SceneManager.LoadScene(sceneIndex);
		AnimationTransitionEnd();
	}
	// private async void AnimationTransition(Component from, Component to)
	// {	
	// 	var timeInMSec = (int)(1000 * time);
		
	// 	animator.SetTrigger("Start");
	// 	await Task.Delay(timeInMSec);
	// 	from.gameObject.SetActive(false);
	// 	to.gameObject.SetActive(true);
	// 	animator.SetTrigger("End");
	// }
	
	// private async void AnimationTransition(int sceneIndex)
	// {
	// 	var timeInMSec = (int)(1000 * time);
		
	// 	animator.SetTrigger("Start");
	// 	await Task.Delay(timeInMSec);
	// 	SceneManager.LoadScene(sceneIndex);
	// 	animator.SetTrigger("End");
	// }
	
	private async Task AnimationTransitionStart()
	{
		if(!animator)
			animator = GetAnimatorFromPrefab();
		
		var timeInMSec = (int)(1000 * time);
		
		animator.SetTrigger("Start");
		await Task.Delay(timeInMSec);
	}

	private void AnimationTransitionEnd() => animator.SetTrigger("End");
}
