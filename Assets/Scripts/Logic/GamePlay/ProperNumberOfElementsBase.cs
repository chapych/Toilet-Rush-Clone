using System;
using Base.Interfaces;
using Logic.BaseClasses;
using UnityEngine;

namespace Logic.GamePlay
{
	public abstract class ProperNumberOfElementsBase : IProperNumberOfElements
	{
		private readonly int maxTimeToBeRaised;
		private int current;
		public event Action OnAllElements;

		protected ProperNumberOfElementsBase(int maxTimeToBeRaised)
		{
			this.maxTimeToBeRaised = maxTimeToBeRaised;
		}

		public void OnOneElementHandler()
		{
			current++;
			if (current != maxTimeToBeRaised) return;
			OnAllElements?.Invoke();
		}
	}
}