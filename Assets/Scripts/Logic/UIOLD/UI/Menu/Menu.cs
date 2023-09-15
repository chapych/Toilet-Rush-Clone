using GameControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Menu : MonoBehaviour
{
	protected MenuTransition transition;
	private AudioPlayerSO player;
	private AudioHolder audioHolder;
	[SerializeField] private Animator animator;
	private IProgressService progressService;

	[Inject]
	public void Construct(MenuTransition transition, AudioHolder audioHolder,
									 AudioPlayerSO player, IProgressService progressService)
	{
		this.progressService = progressService;
		this.audioHolder = audioHolder;
		this.transition = transition;
		this.player = player;
	}
	
	private void Start() => transition.IsInTransition = false;
	public void Exit() => Application.Quit();
	public void PlayCurrent() => Transition(progressService.Progress.Level);
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
