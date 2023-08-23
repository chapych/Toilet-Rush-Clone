using System;
using Character;
using UnityEngine;

namespace Services.StaticDataService.Points
{
    [Serializable]
    public class Point : IKindData
    {
        public Kind Kind { get; set; }
        public Vector2 position;


        public Point(Kind kind, Vector2 position)
        {
            Kind = kind;
            this.position = position;
        }
    }
}