using Logic.Spawners;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(FinishOnScenePoint))]
    public class FinishOnScenePointEditor : KindDataEditor<FinishOnScenePoint> 
    {
        private static Color color = Color.red;
        
        [DrawGizmo(GizmoType.NonSelected | GizmoType.Active | GizmoType.Pickable)]
        public static void RenderCustomGizmo(FinishOnScenePoint instance, GizmoType gizmoType) => 
            CircleGizmo(instance.transform,
                0.6f,
                color);
    }
}
