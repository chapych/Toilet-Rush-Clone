public interface ICharacterData : IComponent
{
	Line Line { get; set; }
	IKindData Finish { get; set; }
	Kind Kind { get; set; }
}