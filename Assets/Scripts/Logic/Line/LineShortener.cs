using System.Linq;
using UnityEngine;

namespace Drawing
{
	public class LineShortener
	{
		private readonly ILine line;
		private Vector3[] current;
	
		public LineShortener(ILine line)
		{
			this.line = line;
			current = line.Points;
		}
		public void ReducePointsByOne()
		{
			current = current.Skip(1)
				.ToArray();
						 
			line.SetPoints(current);
		}
	}
}
