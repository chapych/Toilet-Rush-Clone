using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FinishData))]
public class FinishDataEditor : Editor 
{
	private Color color;
	public SerializedProperty 
		isGenderNeutral,
		kind;
	 
	 void OnEnable () 
	 {
		 isGenderNeutral = serializedObject.FindProperty ("<IsGenderNeutral>k__BackingField");
		 kind = serializedObject.FindProperty("<Kind>k__BackingField");
	 }
	public override void OnInspectorGUI()
	{
		color = Color.white;
		 
		EditorGUILayout.PropertyField(isGenderNeutral);
		
		if(!isGenderNeutral.boolValue)
		{
			EditorGUILayout.PropertyField(kind);
			color = GetColor();
		}
		
		serializedObject.ApplyModifiedProperties();
		(target as FinishData).GetComponent<SpriteRenderer>().color = color;
	}

	private Color GetColor()
	{
		int genderIndex = kind.enumValueIndex;
		return KindToColor.GetColor(genderIndex);
	}
}
