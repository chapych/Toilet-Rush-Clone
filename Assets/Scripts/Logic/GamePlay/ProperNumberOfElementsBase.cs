using System;
using Logic.Interfaces;

namespace Logic.GamePlay
{
	public abstract class ProperNumberOfElementsBase : IObservable, IProperNumberOfElements
	{
		private int max;
		private int current;
	
		public event EventHandler<EventArgs> OnRaised;
		
		public ProperNumberOfElementsBase(int maxTimeRaised, params IObservable[] observables)
		{
			max = maxTimeRaised;
			
			foreach (IObservable observable in observables)
			{
				Subscribe(observable);
			}
		}
		
		public void OnOneElementHandle(object sender, EventArgs e)
		{
			current++;
			if (current == max)
			{
				OnRaised?.Invoke(this, EventArgs.Empty);
				UnSubscribe(sender as IObservable);
			}
		}

		private void Subscribe(IObservable observable)
		{
			observable.OnRaised += OnOneElementHandle;
		}

		private void UnSubscribe(IObservable observable)
		{
			observable.OnRaised -= OnOneElementHandle;
		}
	}
}