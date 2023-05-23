using UnityEngine;

public class CharacterObserver : MonoBehaviour
{
	private CharacterData characterData;
    private void Start() => characterData = GetComponent<CharacterData>();
    public void OnAllLinesCreatedHandle()
	{
		var line = characterData.Line;
		var lineShortener = new LineShortener(line);
		var moveComponent = GetComponent<Move>();
		
		moveComponent.OnLinePointWalkedBy+=lineShortener.OnLinePointWalkedByHandler;
		
		var points = line.Points;
		GetComponent<Move>().StartMovement(points.ConvertToQueue());
	}
}