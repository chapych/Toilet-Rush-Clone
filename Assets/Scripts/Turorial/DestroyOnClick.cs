using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
	[SerializeField]
	private InputReaderSO input;
	
	private void Start()
	{
		input.TouchEvent += DestroySelf;
	}

	private void DestroySelf()
	{
		input.TouchEvent -= DestroySelf;
		if(gameObject) Destroy(gameObject);
	}
}
