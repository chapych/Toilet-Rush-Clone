using System;
using System.Collections.Generic;
using System.Linq;
using Character;
using Infrastructure.Factories;
using Services.StaticDataService.StaticData;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private const string STATIC_DATA_PATH = "StaticData/";
        private Dictionary<string, LevelStaticData> levels;
        private Dictionary<Kind, FinishStaticData> finishData;
        private Dictionary<Kind, CharacterStaticData> characterData;

        public void Load()
        {
            levels = LoadFromResources<string, LevelStaticData>("Levels", x => x.levelName);
            finishData = LoadFromResources<FinishStaticData>("Finishes");
            characterData = LoadFromResources<CharacterStaticData>("Characters");
        }

        private Dictionary<TKey, TValue> LoadFromResources<TKey, TValue> (string name, Func<TValue, TKey> keyDelegate) 
            where TValue : Object
        {
            string path = STATIC_DATA_PATH + name;
            var dictionary = Resources
                .LoadAll<TValue>(path)
                .ToDictionary(keyDelegate, x => x);
            
            return dictionary;
        }
        private Dictionary<Kind, T> LoadFromResources<T>(string name) where T : Object, IKindData
        {
            var dictionary = LoadFromResources<Kind, T>(name, x => x.Kind);
            return dictionary;
        }

        public LevelStaticData ForLevel(string level) => levels[level];
        public FinishStaticData ForFinish(Kind finish) => finishData[finish];
        public CharacterStaticData ForCharacter(Kind character) => characterData[character];
    }
}