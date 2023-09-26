using Infrastructure.GameStateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Logic.UI.Windows
{
    public class GameOverWindow : Window
    {
        private IGameStateMachine gameStateMachine;
        [SerializeField] private Button replayButton;

        public void Construct(IGameStateMachine stateMachine) =>
            gameStateMachine = stateMachine;

        private protected override void OnAwake()
        {
            base.OnAwake();

            string scene = SceneManager.GetActiveScene().name;
            replayButton.onClick.AddListener(() =>
            {
                Destroy(gameObject);
                gameStateMachine.Enter<InitGamePlayState, string>(scene);
            });
        }
    }
}