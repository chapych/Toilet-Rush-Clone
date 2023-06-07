using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Menu : MonoBehaviour
{
	protected MenuTransition transition;
	private AudioPlayerSO player;
	[SerializeField] private AnimationTypeSO animationType; 
	
	[Inject]
	public void Construct(MenuTransition transition, AudioPlayerSO player)
	{
		this.transition = transition;
		this.player = player;
	}
	public void Transition(int sceneIndex)
	{
		transition.DelayAnimationTransition(SceneManager.GetActiveScene().buildIndex + 1, animationType);
	}
	public void Transition(Menu other) => transition.DelayAnimationTransition(this, other, animationType);
	public void PlaySound()
	{
		Debug.Log("working");
		player.PlayClickSound();
	}
}
