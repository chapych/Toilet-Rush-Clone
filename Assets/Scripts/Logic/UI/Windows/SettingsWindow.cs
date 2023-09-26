using Services.OpenWindow;
using UnityEngine;

namespace Logic.UI.Windows
{
    public class SettingsWindow : Window
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