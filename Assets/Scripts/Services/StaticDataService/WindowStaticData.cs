using Infrastructure.Factories;
using Logic.BaseClasses;
using UnityEngine;

namespace Services.StaticDataService
{
    [CreateAssetMenu(fileName = "New Window Static Data", menuName = "Static Data/Window Static Data")]
    public class WindowStaticData : ScriptableObject
    {
        public WindowType Type;
        public GameObject Prefab;
    }
}