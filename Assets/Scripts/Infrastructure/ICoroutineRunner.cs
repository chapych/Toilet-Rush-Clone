using System.Collections;
using UnityEngine;

public interface ICoroutineRunner
{
	Coroutine StartCoroutine(IEnumerator coroutine);
	void StopCoroutine(IEnumerator coroutine);
	void StopCoroutine(Coroutine coroutine);
	void StopAllCoroutines();
}