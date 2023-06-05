using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Menu : MonoBehaviour
{
	private RectTransform[] others;
    private MenuTransition transition;
	[Inject]
	virtual public void Construct([Inject(Id = "Main Menu")] RectTransform menu, MenuTransition transition)
	{
		//this.menu = menu;
		this.transition = transition;
	}
	public void Transition(int sceneIndex) => transition.DelayAnimationTransition(SceneManager.GetActiveScene().buildIndex + 1);
    public void Transition(Component from, Component to) => transition.DelayAnimationTransition(this, to);
}
