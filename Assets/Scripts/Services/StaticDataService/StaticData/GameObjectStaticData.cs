using Character;
using Logic.BaseClasses;
using UnityEngine;

namespace Services.StaticDataService.StaticData
{
    public abstract class GameObjectStaticData : ScriptableObject, IKindData
    {
        [field: SerializeField] public Kind Kind { get; set; }
        public GameObject prefab;
    }
}