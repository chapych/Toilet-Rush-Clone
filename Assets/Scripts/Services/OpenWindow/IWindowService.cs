using Base.BaseClasses.Enums;
using Logic.BaseClasses;

namespace Services.OpenWindow
{
    public interface IWindowService
    {
        void Open(WindowType windowType);
    }
}