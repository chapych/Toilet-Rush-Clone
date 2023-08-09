using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
	[SerializeField]
	private InputReaderSO input;
	
	private void Start()
	{
		input.TouchStartedEvent += DestroySelf;
	}

	private void DestroySelf()
	{
		input.TouchStartedEvent -= DestroySelf;
		if(gameObject) Destroy(gameObject);
	}
}
