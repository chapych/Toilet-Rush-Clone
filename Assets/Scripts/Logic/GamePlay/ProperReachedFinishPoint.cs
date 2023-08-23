using Character;
using Logic.Interfaces;

namespace Logic.GamePlay
{
	public class ProperReachedFinishPoint : ProperNumberOfElementsBase
	{
		public ProperReachedFinishPoint(int maxTimeRaised, params IObservable[] observables) : base(maxTimeRaised, observables)
		{
		}
	}
}