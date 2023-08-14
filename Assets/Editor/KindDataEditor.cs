using Drawing;
using UnityEngine;
using UnityEditor;

public class KindDataEditor<T> : Editor
where T : MonoBehaviour, IKindData
{
	public SerializedProperty
		isGenderNeutral;
	public SerializedProperty
		kind;
	private Color color;
	public override void OnInspectorGUI()
	{
		color = Color.white;

		EditorGUILayout.PropertyField(isGenderNeutral);

		if (!isGenderNeutral.boolValue)
		{
			EditorGUILayout.PropertyField(kind);
			color = GetColor();
		}

		serializedObject.ApplyModifiedProperties();
		(target as T).GetComponent<SpriteRenderer>().color = color;
	}

	private Color GetColor()
	{
		int genderIndex = kind.enumValueIndex;
		return KindToColor.GetColor(genderIndex);
	}

	void OnEnable()
	{
		isGenderNeutral = serializedObject.FindProperty("<IsGenderNeutral>k__BackingField");
		kind = serializedObject.FindProperty("<Kind>k__BackingField");
	}
}
