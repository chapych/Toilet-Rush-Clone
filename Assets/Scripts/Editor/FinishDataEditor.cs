using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FinishData))]
public class FinishDataEditor : Editor 
{
	public SerializedProperty 
		isGenderNeutral,
		gender;
	 
	 void OnEnable () 
	 {
		 isGenderNeutral = serializedObject.FindProperty ("IsGenderNeutral");
		 gender = serializedObject.FindProperty("Gender");  
	 }
	public override void OnInspectorGUI() 
	{
		serializedObject.Update ();
		 
		EditorGUILayout.PropertyField(isGenderNeutral);
		
		if(!isGenderNeutral.boolValue)
		{
			EditorGUILayout.PropertyField(gender);
		}
		serializedObject.ApplyModifiedProperties();
	}
}
