using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelMenu : MonoBehaviour
{
    private RectTransform mainMenu;
    private MenuTransition transition;
    [Inject]
    public void Construct([Inject(Id = (MenuInstaller.MAIN_MENU_ID))] RectTransform mainMenu,
                            MenuTransition transition)
    {
        this.mainMenu = mainMenu;
        this.transition = transition;
    }
    public void LoadLevel(GameObject button)
    {
        int index = Int32.Parse(button.name);
        transition.DelayAnimationTransition(index);
    }

    public void BackToMainMenu() => transition.DelayAnimationTransition(this, mainMenu);
}
