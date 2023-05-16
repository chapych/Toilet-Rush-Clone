using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingInputControler : MonoBehaviour
{
	[SerializeField]
	private InputReaderSO inputReader;
	private DrawingContext context;
	public Camera main;//put in in injection
	public Vector2 TouchPosition {
		get => main.ScreenToWorldPoint(inputReader.Position);
		private set {}
	}
	private void Start() 
	{
		context = GetComponent<DrawingContext>();
		inputReader.DrawingEnable();
		inputReader.TouchEvent+=context.TouchHandle;
	}
	
	private void OnDisable()
	{
		inputReader.TouchEvent-=context.TouchHandle;
	}
}
