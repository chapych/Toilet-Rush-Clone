using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Menu : MonoBehaviour
{
	protected MenuTransition transition;
	private AudioPlayerSO player;
	private AudioHolder holder;
	[SerializeField] private Animator animator; 
	
	[Inject]
	public void Construct(MenuTransition transition, AudioPlayerSO player)
	{
		this.transition = transition;
		this.player = player;
	}

	public void Awake() => holder = GetComponent<AudioHolder>();
	public void Transition(int sceneIndex)
	{
		transition.DelayAnimationTransition(SceneManager.GetActiveScene().buildIndex + 1, animator);
	}
	public void Transition(Menu other) => transition.DelayAnimationTransition(this, other, animator);
	public void PlaySound()
	{
		player.PlayClickSound(holder.ClickSound);
	}
}
