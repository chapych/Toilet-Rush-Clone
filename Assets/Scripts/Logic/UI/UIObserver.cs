using System;
using Infrastructure.Factories;
using UnityEngine;
using UnityEngine.UI;

namespace Logic.UI
{
    public class UIObserver
    {
        private readonly UIFactory factory;

        private bool hasCalled = false;
        public UIObserver(UIFactory factory)
        {
            this.factory = factory;
        }

        public void CreateGameOver(object sender, EventArgs e)
        {
            if(!hasCalled)
            {
                var createdWindow = factory.CreateGameOverWindow().GetComponent<GameOverWindow>();
                createdWindow.RetryButton.onClick.AddListener(() => hasCalled = false);
                hasCalled = true;
            }
        }
    }

    public class GameOverWindow : MonoBehaviour
    {
        public Button RetryButton;

        private void Awake() =>
            RetryButton.onClick.AddListener(() =>
            {
                Destroy(gameObject);
                //reloadlevel
            });

    }
}