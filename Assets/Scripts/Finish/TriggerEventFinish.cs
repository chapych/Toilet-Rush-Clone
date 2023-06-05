using UnityEngine;

public class TriggerEventFinish : MonoBehaviour 
{
	private void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.GetComponent<ICharacterData>() != null)
		{
			other.GetComponent<ICharacterData>().HasReachedFinish = true;
			other.GetComponent<Collider2D>().enabled = false;
		}
	}
}