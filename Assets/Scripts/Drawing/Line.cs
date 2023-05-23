using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour, ILine
{
	[SerializeField]
	private LineRenderer lineRenderer;
	private Color color;
	public Color Color
	{
		set
		{
			Gradient gradient = new Gradient();
			
			SetGradient(value, gradient);
			lineRenderer.colorGradient = gradient;
		}
	}
	public Vector3[] Points //return Vector3[] 
	{
		get
		{
			int count = lineRenderer.positionCount;
			Vector3[] array = new Vector3[count];
			
			lineRenderer.GetPositions(array);
			return array;
		}
	}

	private static void SetGradient(Color value, Gradient gradient)
	{
		gradient.mode = GradientMode.Blend;
		var gradientColorKeys = new GradientColorKey[1]
		{
				new GradientColorKey(value, 1)
		};
		var alphaKeys = new GradientAlphaKey[1]
		{
				new GradientAlphaKey(1f, 1),
		};
		gradient.SetKeys(gradientColorKeys, alphaKeys);
	}

	private void Start()
	{
		if (!lineRenderer)
			SetInitialProperties();
	}

	public void SetInitialProperties()
	{
		lineRenderer = GetComponent<LineRenderer>();
	}

	public void Continue(Vector2 newPosition)
	{
		int count = ++lineRenderer.positionCount;
		lineRenderer.SetPosition(count - 1, newPosition);
	}

	public bool CanContinue(Vector2 newPosition, float threshold)
	{
		int count = lineRenderer.positionCount;
		if (count == 0) return true;

		Vector2 oldPosition = lineRenderer.GetPosition(count - 1);
		return Vector2.Distance(newPosition, oldPosition) > threshold;
	}

	public void SetPoints(Vector3[] array) => lineRenderer.SetPositions(array);
}
