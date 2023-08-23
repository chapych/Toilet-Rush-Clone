using System;
using Character;
using Logic.Interfaces;

namespace Logic.GamePlay
{
	public class ProperDrawnLines : ProperNumberOfElementsBase
	{
		public ProperDrawnLines(int maxTimeRaised, params IObservable[] observables) : base(maxTimeRaised, observables)
		{
		}
	}
}
