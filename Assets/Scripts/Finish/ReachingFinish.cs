using System;
using Character;
using Logic.BaseClasses;
using Logic.BaseClasses.CustomEventArgs;
using Logic.Interfaces;
using UnityEngine;

namespace Finish
{
	public class ReachingFinish : ObservableBaseMonoBehaviour
	{
		[SerializeField] private TriggerObserver triggerObserver;
		private IKindData finish;

		private void Awake()
		{
			triggerObserver.OnRaised += OnRaisedHandler;
		}

		private void OnRaisedHandler(object sender, ColliderEventArgs args)
		{
			Collider2D other = args.Collider;
			var character = other.GetComponent<ICharacterData>();

			if (character != null && character.Finish == finish)
			{
				other.enabled = false;
				RaiseEvent();
			}
		}

		private void OnDestroy()
		{
			triggerObserver.OnRaised -= OnRaisedHandler;
		}
	}
}