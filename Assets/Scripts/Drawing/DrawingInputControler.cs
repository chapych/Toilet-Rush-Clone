using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawingInputControler : MonoBehaviour
{
	[SerializeField]
	private InputReaderSO inputReader;
	private DrawingContext context;
	public Camera main;
	public Vector2? TouchPosition{ get =>  GetTouchPosition(); }
	private void Start() 
	{
		context = GetComponent<DrawingContext>();
		inputReader.DrawingEnable();
		inputReader.TouchEvent+=context.TouchHandle;
	}
	
	private void Update()
	{
		//TouchPosition = GetTouchPosition();
		//Debug.Log(TouchPosition);
	}
	
	private Vector2? GetTouchPosition()
	{
		if(EventSystem.current.IsPointerOverGameObject()) return null;
		return main.ScreenToWorldPoint(inputReader.Position);
	}
	
	private void OnDisable()
	{
		inputReader.TouchEvent-=context.TouchHandle;
	}
}
