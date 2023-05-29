public interface ICharacterData : IComponent
{
	Line Line { get; set; }
	Gender Gender { get; set; }
	bool HasReachedFinish { get; set; }
}