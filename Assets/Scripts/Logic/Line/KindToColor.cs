using System.Collections.Generic;
using Logic.BaseClasses;
using UnityEngine;

namespace Drawing
{
	public class KindToColor
	{
		private static Dictionary<Kind, Color> dictionary = new Dictionary<Kind, Color>();
	
		static KindToColor()
		{
			dictionary[Kind.Chicken] = Color.white;
			dictionary[Kind.BlueBird] = Color.blue;
		}
		static public Color GetColor(Kind gender) => dictionary[gender];
	
		static public Color GetColor(int index) => GetColor((Kind)index);
	}
}