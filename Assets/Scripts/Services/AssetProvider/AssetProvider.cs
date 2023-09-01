using System;
using UnityEngine;

public class AssetProvider : IAssetProvider
{
    public GameObject Get(string path)
    {
        var prefab = Resources.Load<GameObject>(path);
        return prefab;
    }
}