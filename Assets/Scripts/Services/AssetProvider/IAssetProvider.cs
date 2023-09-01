using UnityEngine;

public interface IAssetProvider
{
    GameObject Get(string path);
}
