using Drawing;

public interface ICharacterData : IComponent
{
	ILine Line { get; set; }
	IKindData Finish { get; set; }
	Kind Kind { get; set; }
}