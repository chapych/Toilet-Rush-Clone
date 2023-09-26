using Base.BaseClasses.Enums;
using Infrastructure.Factories;
using Logic.UI;
using UnityEngine;

namespace Services.OpenWindow
{
    public class WindowService : IWindowService
    {
        private readonly UIFactory factory;
        private GameObject lastOpened;

        public WindowService(UIFactory factory)
            => this.factory = factory;

        public void Open(WindowType windowType)
        {

            lastOpened = windowType switch
            {
                WindowType.GameOver => factory.CreateGameOverWindow(),
                WindowType.LevelCleared => factory.CreateLevelClearedWindow(),
                WindowType.Pause => factory.CreatePauseWindow(this),
                WindowType.Settings => factory.CreateSettingsWindow(this),
                _ => lastOpened
            };
        }

        public void CloseLastOpened()
        {
            if(lastOpened) Object.Destroy(lastOpened.gameObject);
        }
    }
}