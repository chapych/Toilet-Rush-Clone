using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Menu : MonoBehaviour
{
	protected MenuTransition transition;
	private AudioPlayerSO player;
	private AudioHolder audioHolder;
	private PlayerDataManager playerDataManager;
	[SerializeField] private Animator animator; 
	
	[Inject]
	public void Construct(MenuTransition transition, AudioHolder audioHolder,
									 AudioPlayerSO player, PlayerDataManager playerDataManager)
	{
		this.audioHolder = audioHolder;
		this.transition = transition;
		this.player = player;
		this.playerDataManager = playerDataManager;
	}
	
	private void Start() => transition.IsInTransition = false;
	public void Exit() => Application.Quit();
	public void PlayCurrent() => SceneManager.LoadScene(playerDataManager.currentLevel.Value);
	public void Transition(int sceneIndex)
	{
		transition.DelayAnimationTransition(sceneIndex, animator);
	}
	public void Transition(Menu other) => transition.DelayAnimationTransition(this, other, animator);
	public void PlaySound()
	{
		player.PlayClickSound(audioHolder.ClickSound);
	}
}
