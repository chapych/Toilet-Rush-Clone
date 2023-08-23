using Drawing;
using UnityEngine;

namespace Character
{
	public class CharacterData : MonoBehaviour, ILineHolder//, ICharacterData
	{
		[SerializeField] private Kind kind;// { get; set; }
		public ILine Line { get; set; }
		public bool IsFree => Line == null;
		public Color Color => KindToColor.GetColor(kind);
		public IKindData Finish {get; set; }

		public bool CanBeFinishPoint(Vector2 point)
		{
			bool hasComponent = Physics2DExtension.TryOverlapCircle(point, Constants.DETECTING_RADIUS,
				out IKindData finish);
		
			return hasComponent && (finish.Kind == Kind.Universal || finish.Kind == kind);
		}
	}
}
