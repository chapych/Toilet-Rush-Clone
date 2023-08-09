using Drawing;
using UnityEngine;

public class CharacterObserver : MonoBehaviour //:IObservable?
{
	private CharacterData characterData;
    private void Start() => characterData = GetComponent<CharacterData>();
    public void OnAllElementsHandle()
	{
		ILine line = characterData.Line;
		var lineShortener = new LineShortener(line);
		var moveComponent = GetComponent<MoveComponent>();
		
		moveComponent.OnLinePointWalkedBy+=lineShortener.OnLinePointWalkedByHandler;
		
		var points = line.Points;
		GetComponent<MoveComponent>().StartMovement(points.ConvertToQueue());
	}
}