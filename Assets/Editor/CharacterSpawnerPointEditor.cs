using Logic.Spawners;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(CharacterOnScenePoint))]
    public class CharacterSpawnerPointEditor : KindDataEditor<CharacterOnScenePoint>
    {
        private static Color color = Color.blue;
        
        [DrawGizmo(GizmoType.NonSelected | GizmoType.Active | GizmoType.Pickable)]
        public static void RenderCustomGizmo(CharacterOnScenePoint instance, GizmoType gizmoType) => 
            CircleGizmo(instance.transform,
                0.6f,
                color);
    }
}