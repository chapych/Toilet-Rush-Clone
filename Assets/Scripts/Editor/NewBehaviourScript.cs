using UnityEngine;

public class CenterOfMassPlacing : MonoBehaviour
{	
	[ContextMenu("To Center Figure")]
	public void ToCenter()
	{
		Vector3 centerOfMass = Vector3.zero;
		foreach(Transform child in transform)
			centerOfMass+=child.localPosition;
			
		centerOfMass /= transform.childCount;
		foreach(Transform child in transform)
			child.localPosition-=centerOfMass;
	}
}