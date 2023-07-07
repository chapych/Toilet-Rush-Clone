public interface ICharacterData : IComponent
{
	Line Line { get; set; }
	IFinishData Finish { get; set; }
	Gender Gender { get; set; }
}