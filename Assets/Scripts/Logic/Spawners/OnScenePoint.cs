using Base.Interfaces;
using Logic.BaseClasses;
using UnityEngine;

namespace Logic.Spawners
{
    public abstract class OnScenePoint : MonoBehaviour, IKindData
    {
        [field: SerializeField] public Kind Kind { get; set; }
    }
}