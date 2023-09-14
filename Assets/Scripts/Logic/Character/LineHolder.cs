using System.Linq;
using Drawing;
using Finish;
using Logic.BaseClasses;
using UnityEngine;

namespace Logic.Character
{
	public class LineHolder : MonoBehaviour, ILineHolder
	{
		public ILine Line { get; set; }
		public Kind Kind { get; set; }
		public IFinishData Finish { get; set; }
		public void ShortenLineByPoint()
		{
			var linePoints = Line.Points;
			linePoints = linePoints.Skip(1)
				.ToArray();

			Line.SetPoints(linePoints);
		}
	}
}
