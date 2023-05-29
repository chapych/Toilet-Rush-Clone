using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTransition : MonoBehaviour
{
	[SerializeField] private Animator animation;
	[SerializeField] private float time;
	
	
	public void RunAnimationTransition(Component from, Component to) => StartCoroutine(AnimationTransition(from, to));
	public void RunAnimationTransition(int sceneIndex) => StartCoroutine(AnimationTransition(sceneIndex));
	private IEnumerator AnimationTransition(Component from, Component to)
	{		
		animation.SetTrigger("Start");
		yield return new WaitForSeconds(time);
		from.gameObject.SetActive(false);
		to.gameObject.SetActive(true);
		animation.SetTrigger("End");
	}
	
	private IEnumerator AnimationTransition(int sceneIndex)
	{
		animation.SetTrigger("Start");
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene(sceneIndex);
		animation.SetTrigger("End");
	}
}
