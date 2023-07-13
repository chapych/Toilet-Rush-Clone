public interface ICharacterData : IComponent
{
	Line Line { get; set; }
	IFinishData Finish { get; set; }
	Kind Kind { get; set; }
}