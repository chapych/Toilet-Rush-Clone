using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Menu : MonoBehaviour
{
	protected MenuTransition transition;
	private AudioPlayerSO player;
	private AudioHolder audioHolder;
	[SerializeField] private Animator animator; 
	
	[Inject]
	public void Construct(MenuTransition transition, AudioHolder audioHolder, AudioPlayerSO player)
	{
		this.audioHolder = audioHolder;
		this.transition = transition;
		this.player = player;
	}
	public void Exit() => Application.Quit();
	public void Transition(int sceneIndex)
	{
		transition.DelayAnimationTransition(SceneManager.GetActiveScene().buildIndex + 1, animator);
	}
	public void Transition(Menu other) => transition.DelayAnimationTransition(this, other, animator);
	public void PlaySound()
	{
		player.PlayClickSound(audioHolder.ClickSound);
	}
}
