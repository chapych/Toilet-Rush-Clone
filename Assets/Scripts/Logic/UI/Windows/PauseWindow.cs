using System;
using Base.BaseClasses.Enums;
using Services.OpenWindow;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Logic.UI.Windows
{
    public class PauseWindow : Window
    {
        private IWindowService windowService;
        public void SetWindowService(IWindowService windowService) => this.windowService = windowService;
        public void InitialiseButtons()
        {
            foreach (OpenButton button in GetComponentsInChildren<OpenButton>())
                button.Construct(windowService);
        }

    }
}