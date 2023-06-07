using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFactory : IFactory<Animator, AnimationTypeSO>
{
	private int sortingOrder = 10;
	private Dictionary<string, Animator> createdAnimators = new Dictionary<string, Animator>();
	private Canvas animatorHolder;
	public bool ContainsElementFor(AnimationTypeSO animation)
	{
		return createdAnimators.ContainsKey(animation.typeName);
	}

	public Animator Create(AnimationTypeSO animation, Vector2 position = default)
	{
		Animator animator = default;
		if (!animatorHolder)
			animatorHolder = CreateHolder();
		if(ContainsElementFor(animation)) 
		{
			Debug.Log(createdAnimators[animation.typeName]);
			animator = createdAnimators[animation.typeName];
		}
		else 
		{
			animator = GetAnimatorFromPrefab(animation.prefab);
			createdAnimators[animation.typeName] = animator;
		}
		return animator;
	}

	private Animator GetAnimatorFromPrefab(Animator animatorPrefab)
	{
		Animator animator = Object.Instantiate(animatorPrefab, animatorHolder.transform);
		animator.transform.parent = animatorHolder.transform;//
		return animator;
	}

	private Canvas CreateHolder()
	{
		Canvas animatorHolder = new GameObject("Animator Holder").AddComponent<Canvas>();
		Object.DontDestroyOnLoad(animatorHolder);
		
		animatorHolder.renderMode = RenderMode.ScreenSpaceOverlay;
		animatorHolder.sortingOrder = sortingOrder;
		return animatorHolder;
	}
}