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
            if(lastOpened) Close(lastOpened);

            lastOpened = windowType switch
            {
                WindowType.GameOver => factory.CreateGameOverWindow(),
                WindowType.LevelCleared => factory.CreateLevelClearedWindow(),
                WindowType.Pause => factory.CreatePauseWindow(),
                _ => lastOpened
            };
        }

        private void Close(GameObject window)
            => Object.Destroy(window.gameObject);
    }
}