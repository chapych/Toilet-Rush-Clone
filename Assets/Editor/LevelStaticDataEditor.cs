using System.Linq;
using Infrastructure.Factories;
using Logic.Spawners;
using Services.StaticDataService.Points;
using Services.StaticDataService.StaticData;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var levelStaticData = (LevelStaticData) target;

            if (GUILayout.Button("Collect"))
            {
                levelStaticData.characterPoints = FindObjectsOfType<CharacterOnScenePoint>()
                    .Select(x=> new Point(x.Kind, x.transform.position))
                    .ToList();
                levelStaticData.finishPoints = FindObjectsOfType<FinishOnScenePoint>()
                    .Select(x => new Point(x.Kind, x.transform.position))
                    .ToList();

                levelStaticData.levelName = SceneManager.GetActiveScene().name;
            }
            EditorUtility.SetDirty(target);
        }
    }
}