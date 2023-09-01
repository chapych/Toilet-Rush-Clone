using Infrastructure.Factories;
using Logic.BaseClasses;

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
            }
        }
    }
}