using Base.Interfaces;
using Logic.BaseClasses;
using UnityEditor;
using UnityEngine;

namespace Editor
{
	public class KindDataEditor<T>  : UnityEditor.Editor
		where T : class, IKindData
	{
		private bool isNeutral;
		private SerializedProperty kind;
		private T kindData;

		public override void OnInspectorGUI()
		{
			isNeutral = EditorGUILayout.Toggle("Is Universal Kind", isNeutral);
			if (isNeutral)
				kindData.Kind = Kind.Universal;
			else
				EditorGUILayout.PropertyField(kind);

			serializedObject.ApplyModifiedProperties();
		}

		private protected static void CircleGizmo(Transform instanceTransform, float radius, Color color)
		{
			Gizmos.color = color;
			Vector2 position = instanceTransform.position;
			Gizmos.DrawSphere(position, radius);
		}

		private void OnEnable()
		{
			kind = serializedObject.FindProperty("<Kind>k__BackingField");

			kindData = target as T;
		}
	}
}
