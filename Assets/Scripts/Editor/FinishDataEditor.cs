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
		 isGenderNeutral = serializedObject.FindProperty ("<IsGenderNeutral>k__BackingField");
		 gender = serializedObject.FindProperty("<Gender>k__BackingField");  
		 Debug.Log(isGenderNeutral.propertyType);
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
