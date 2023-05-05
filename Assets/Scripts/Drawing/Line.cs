using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
	[SerializeField]
	private LineRenderer lineRenderer;
	
	private void Start()
	{
		if(lineRenderer)
			lineRenderer = GetComponent<LineRenderer>();
	}
	
	public void ContinueLine(Vector2 newPosition)
	{
		int count = ++lineRenderer.positionCount;
		lineRenderer.SetPosition(count-1, newPosition);
	}
	
	public bool CanContinue(Vector2 newPosition, float threshold)
	{
		int count = lineRenderer.positionCount;
		if(count == 0) return true;
		
		Vector2 oldPosition = lineRenderer.GetPosition(count - 1);
		return Vector2.Distance(newPosition, oldPosition) > threshold;
	}

}
