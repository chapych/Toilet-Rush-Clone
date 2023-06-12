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
		gender;
	 
	 void OnEnable () 
	 {
		 isGenderNeutral = serializedObject.FindProperty ("<IsGenderNeutral>k__BackingField");
		 gender = serializedObject.FindProperty("<Gender>k__BackingField");
	 }
	public override void OnInspectorGUI()
	{
		color = Color.white;
		 
		EditorGUILayout.PropertyField(isGenderNeutral);
		
		if(!isGenderNeutral.boolValue)
		{
			EditorGUILayout.PropertyField(gender);
			color = GetColor();
		}
		
		serializedObject.ApplyModifiedProperties();
		(target as FinishData).GetComponent<SpriteRenderer>().color = color;
	}

	private Color GetColor()
	{
		int genderIndex = gender.enumValueIndex;
		return GenderToColor.GetColor(genderIndex);
	}
}
