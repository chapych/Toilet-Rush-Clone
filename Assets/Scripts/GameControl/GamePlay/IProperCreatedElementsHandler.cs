using System;
using GameControl.GamePlay;
using Zenject;

namespace GameControl.GamePlay
{
	public interface IProperNumberOfElementsHandler
	{
		event Action OnAllElements;
		void OnOneElementHandle();
	}
}

public interface IProperNumberOfElementsHandlerFactory : IFactory<IProperNumberOfElementsHandler>
{
}

