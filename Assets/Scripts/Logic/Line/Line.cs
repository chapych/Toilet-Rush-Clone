using UnityEngine;

namespace Drawing
{
	public class Line : MonoBehaviour, ILine
	{
		[SerializeField]
		private LineRenderer lineRenderer;
		private Color color;
		public Color Color
		{
			set
			{
				var gradient = new Gradient();
			
				SetGradient(value, gradient);
				lineRenderer.colorGradient = gradient;
			}
		}
		public Vector3[] Points
		{
			get
			{
				int count = lineRenderer.positionCount;
				var array = new Vector3[count];
			
				lineRenderer.GetPositions(array);
				return array;
			}
		}

		private static void SetGradient(Color value, Gradient gradient)
		{
			gradient.mode = GradientMode.Blend;
			var gradientColorKeys = new[]
			{
				new GradientColorKey(value, 1)
			};
			var alphaKeys = new[]
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

		private void SetInitialProperties()
		{
			lineRenderer = GetComponent<LineRenderer>();
		}

		public void AddPoint(Vector2 newPosition)
		{
			int count = ++lineRenderer.positionCount;
			lineRenderer.SetPosition(count - 1, newPosition);
		}

		public void DestroySelf()
		{
			Destroy(gameObject);
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
}
