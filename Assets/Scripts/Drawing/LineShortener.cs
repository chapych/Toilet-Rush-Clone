using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineShortener
{
	private Line line;
	private Vector3[] current;
	
	public LineShortener(Line line)
	{
		this.line = line;
		current = line.Points;
	}
	public void OnLinePointWalkedByHandler()
	{
		current = current.Skip(1).ToArray();
		line.SetPoints(current);
	}
}
