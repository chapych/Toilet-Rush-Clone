using UnityEngine;

public interface IFactory<T1,T2>
{
	bool ContainsElementFor(T2 key);
	T1 Create(T2 key, Vector2 position = default);
}
