using System;
using Character;
using Logic.BaseClasses;
using Logic.Interfaces;
using UnityEngine;

namespace Finish
{
	public class ReachingFinish : ObservableBaseMonoBehaviour
	{
		private IKindData finish;
		
		private void OnTriggerEnter2D(Collider2D other)
		{
			Debug.Log("s:");
			var character = other.GetComponent<ICharacterData>();
			if (character != null && character.Finish == finish)
			{
				other.enabled = false;
				RaiseEvent();
			}
		}
	}
}