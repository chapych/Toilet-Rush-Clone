using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelMenu : Menu
{
    public void LoadLevel(GameObject button)
    {
        int index = Int32.Parse(button.name);
        base.Transition(index);
    }
}
