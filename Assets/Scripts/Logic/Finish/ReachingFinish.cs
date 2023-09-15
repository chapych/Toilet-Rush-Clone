using System;
using Base.Interfaces;
using Logic.BaseClasses;
using Logic.BaseClasses.CustomEventArgs;
using Logic.Character;
using Logic.Finish;
using UnityEngine;

namespace Finish
{
	public class ReachingFinish : MonoBehaviour, ITarget
	{
		private IKindData finish;
		[SerializeField] private TriggerObserver triggerObserver;
		public event Action OnTargetReached;

		private void Awake()
		{
			finish = GetComponent<IKindData>();
			triggerObserver ??= GetComponent<TriggerObserver>();
		}

		private void Start() => triggerObserver.OnTrigger += OnTriggerHandler;

		private void OnTriggerHandler(object sender, ColliderEventArgs args)
		{
			Collider2D other = args.Collider;
			var character = other.GetComponent<ILineHolder>();

			if (character == null || character.Finish != finish) return;
			other.enabled = false;
			OnTargetReached?.Invoke();
		}

		private void OnDestroy() => triggerObserver.OnTrigger -= OnTriggerHandler;
	}
}