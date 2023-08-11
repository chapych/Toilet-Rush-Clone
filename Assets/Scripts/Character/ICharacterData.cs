using Drawing;

public interface ICharacterData : IComponent
{
	ILine Line { set; }
	IKindData Finish { get; set; }
	Kind Kind { get; }
	bool IsFree { get; }
}

public interface ILineHolder : IComponent
{
	ILine Line { get; set; }
}