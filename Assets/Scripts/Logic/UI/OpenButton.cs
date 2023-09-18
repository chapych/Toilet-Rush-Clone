using Base.BaseClasses.Enums;
using Services.OpenWindow;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Logic.UI
{
    public class OpenButton : MonoBehaviour
    {
        [SerializeField] private WindowType window;
        [SerializeField] private Button button;

        public void Construct(IWindowService service)
        {
            IWindowService windowService = service;

            if (!button)
                button = GetComponent<Button>();
            button.onClick.AddListener(() => windowService.Open(window));
        }
    }
}