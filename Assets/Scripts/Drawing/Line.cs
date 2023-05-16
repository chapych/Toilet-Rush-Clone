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
    public Queue<Vector2> Points
    {
        get
        {
            Queue<Vector2> queue = GetAllPositions();
            return queue;
        }
    }

    private Queue<Vector2> GetAllPositions()
    {
        int count = lineRenderer.positionCount;
        Vector3[] array = new Vector3[count];
        lineRenderer.GetPositions(array);

        var queue = new Queue<Vector2>();
        for (int i = 0; i < count; i++)
        {
            queue.Enqueue((Vector2)array[i]);
        }

        return queue;
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
        if (lineRenderer)
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

}
