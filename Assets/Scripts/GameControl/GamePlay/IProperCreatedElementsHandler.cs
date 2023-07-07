using System;

public interface IProperNumberOfElementsHandler
{
	event Action OnAllElements;
	void OnProperNumberOfElementsHandle();
}
