using System;
using Logic.BaseClasses;
using UnityEngine;

namespace Finish
{
	[Serializable]
	public class FinishData : MonoBehaviour, IFinishData
	{
		public Kind Kind { get; set; }
	}
}
