using Drawing;

public interface ICharacterData : IComponent
{
	IKindData Finish { get; set; }
	Kind Kind { get; }
}