using Drawing;
using Finish;
using Logic.BaseClasses;
using UnityEngine;
using UnityEngine.Serialization;

namespace Character
{
	public class CharacterData : MonoBehaviour, ILineHolder, ICharacterData
	{
		[field: SerializeField] public Kind Kind { get; set; }
		public ILine Line { get; set; }
		public bool IsFree => Line == null;
		public Color Color => KindToColor.GetColor(Kind);
		public IKindData Finish { get; set; }

		public bool CanBeFinishPoint(IFinishData finish) 
			=> finish != null && (finish.Kind == Kind.Universal || finish.Kind == Kind);
		public void Configure(IFinishData finish) => Finish = finish;
	}
}
