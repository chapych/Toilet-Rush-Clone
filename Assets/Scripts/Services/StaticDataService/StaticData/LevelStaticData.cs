using System.Collections.Generic;
using Services.StaticDataService.Points;
using UnityEngine;

namespace Services.StaticDataService.StaticData
{
    [CreateAssetMenu(fileName = "New Level Static Data", menuName = "Static Data/Level Static Data")]
    public class LevelStaticData : ScriptableObject
    {
        public string levelName;
        public List<Point> characterPoints;
        public List<Point> finishPoints;
    }
}