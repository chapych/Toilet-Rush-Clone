using System.Collections.Generic;
using UnityEngine;

public class GenderToColor
{
	static private Dictionary<Gender, Color> dictionary = new Dictionary<Gender, Color>();
	
	static GenderToColor()
	{
		dictionary[Gender.Male] = Color.blue;
		dictionary[Gender.Female] = Color.red;
	}
	static public Color GetColor(Gender gender) => dictionary[gender];
}