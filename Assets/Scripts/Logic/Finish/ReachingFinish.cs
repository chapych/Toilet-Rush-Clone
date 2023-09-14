using System;
using Base.Interfaces;
using Logic.BaseClasses;
using Logic.BaseClasses.CustomEventArgs;
using Logic.Character;
using UnityEngine;

namespace Finish
{
	public class ReachingFinish : MonoBehaviour
	{
		[SerializeField] private TriggerObserver triggerObserver;
		private IKindData finish;
		private event Action OnReachFinish;

		private void Awake()
		{
			triggerObserver.OnTrigger += OnRaisedHandler;
		}

		private void OnRaisedHandler(object sender, ColliderEventArgs args)
		{
			Collider2D other = args.Collider;
			var character = other.GetComponent<ILineHolder>();

			if (character != null && character.Finish == finish)
			{
				other.enabled = false;
				OnReachFinish?.Invoke();
			}
		}

		private void OnDestroy()
		{
			triggerObserver.OnTrigger -= OnRaisedHandler;
		}
	}
}