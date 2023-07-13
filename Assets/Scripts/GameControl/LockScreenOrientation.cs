using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScreenOrientation : MonoBehaviour
{
	void Start()
	{
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
		Screen.autorotateToPortrait = false;
		
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
}