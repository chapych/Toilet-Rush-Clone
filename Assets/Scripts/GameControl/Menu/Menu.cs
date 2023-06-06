using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Menu : MonoBehaviour
{
	protected MenuTransition transition;
    [Inject]
    public void Construct(MenuTransition transition) => this.transition = transition;
    public void Transition(int sceneIndex) => transition.DelayAnimationTransition(SceneManager.GetActiveScene().buildIndex + 1);
    public void Transition(Menu other) => transition.DelayAnimationTransition(this, other);
}
