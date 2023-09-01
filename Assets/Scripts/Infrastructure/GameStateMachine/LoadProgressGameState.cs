using GameControl;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.GameStateMachine
{
    public class LoadProgressGameState : IEnteringState
    {
        private readonly IGameStateMachine stateMachine;
        private readonly ISaveLoadService saveLoadService;
        private readonly IProgressService progressService;

        public LoadProgressGameState(IGameStateMachine stateMachine, ISaveLoadService saveLoadService, IProgressService progressService)
        {
            this.stateMachine = stateMachine;
            this.saveLoadService = saveLoadService;
            this.progressService = progressService;
        }

        public void Enter()
        {
            LoadOrInitProgress();
            string name = BuildIndexToString(progressService.Progress.Level);
            stateMachine.Enter<LoadLevelState, string>(name);
        }

        private string BuildIndexToString(int index)
        {
            string name = SceneManager.GetSceneAt(index).name;
            return name;
        }

        private void LoadOrInitProgress()
        {
            bool isLoadingSucceeded = saveLoadService.LoadJsonData(progressService.Progress);
            if (!isLoadingSucceeded) progressService.Progress = new Progress(1);
        }


        public void Exit()
        {
			
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadProgressGameState>
        {
            
        }
    }
}