using System;
using Character;
using Logic.BaseClasses;
using UnityEngine;
using UnityEngine.Serialization;

namespace Services.StaticDataService.Points
{
    [Serializable]
    public class Point
    {
        [FormerlySerializedAs("Kind")] public Kind kind;
        public Vector2 position;


        public Point(Kind kind, Vector2 position)
        {
            this.kind = kind;
            this.position = position;
        }
    }
}