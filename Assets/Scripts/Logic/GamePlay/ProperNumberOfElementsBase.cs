using System;
using Logic.BaseClasses;
using Logic.Interfaces;
using UnityEngine;

namespace Logic.GamePlay
{
	public abstract class ProperNumberOfElementsBase : ObservableBase, IProperNumberOfElements
	{
		private int maxTimeToBeRaised;
		private int current;

		public ProperNumberOfElementsBase(int maxTimeToBeRaised)
		{
			this.maxTimeToBeRaised = maxTimeToBeRaised;
		}

		public void OnOneElementHandle(object sender, EventArgs e)
		{
			current++;
			if (current == maxTimeToBeRaised)
			{
				RaiseEvent();
				UnSubscribe(sender as IObservable);
			}
		}

		public void Subscribe(IObservable observable)
		{
			observable.OnRaised += OnOneElementHandle;
		}

		public void UnSubscribe(IObservable observable)
		{
			observable.OnRaised -= OnOneElementHandle;
		}
	}
}