using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CenterOfMassPlacing))]
class DecalMeshHelperEditor : Editor 
{
	CenterOfMassPlacing targetClass;
	
	private void OnEnable() 
	{
		targetClass = target as CenterOfMassPlacing;
	}
  public override void OnInspectorGUI() {
	if(GUILayout.Button("Transfer To Center"))
	  targetClass.ToCenter();
  }
}