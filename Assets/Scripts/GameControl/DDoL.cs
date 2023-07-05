using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDoL : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
