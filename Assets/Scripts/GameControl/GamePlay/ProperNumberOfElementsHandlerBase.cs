using System;
using UnityEngine;
using Zenject;

namespace GameControl.GamePlay
{
	public abstract class OnProperNumberOfElementsHandleBase<T> : MonoBehaviour, ISubscriber, 
		IProperNumberOfElementsHandler where T : MonoBehaviour
	{
		private int max;
		private int current;
		[SerializeField] private GameObject container;
	
		protected T[] Elements;

		public event Action OnAllElements;
	
		public void Initialise()
		{
			Elements = container.GetComponentsInChildren<T>();
			max = Elements.Length;
			Subscribe();
		}

		public void OnOneElementHandle()
		{
			current++;
			if (current == max)
			{
				OnAllElements?.Invoke();
				Unsubcribe();
			}
		}

		public abstract void Subscribe();

		public abstract void Unsubcribe();
		
		public abstract class Factory : IProperNumberOfElementsHandlerFactory
		{
			protected readonly DiContainer Container;
			public Factory(DiContainer container)
			{
				this.Container = container;
			}

			public abstract IProperNumberOfElementsHandler Create();
		}
	}
}