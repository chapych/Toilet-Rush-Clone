using Base.BaseClasses.Enums;
using Infrastructure.Factories;

namespace Services.OpenWindow
{
    public class WindowService : IWindowService
    {
        private readonly UIFactory factory;

        public WindowService(UIFactory factory)
        {
            this.factory = factory;
        }
        public void Open(WindowType windowType)
        {
            switch (windowType)
            {
                case WindowType.GameOver:
                    factory.CreateGameOverWindow();
                    break;
                case WindowType.LevelCleared:
                    factory.CreateLevelClearedWindow();
                    break;
            }
        }
    }
}