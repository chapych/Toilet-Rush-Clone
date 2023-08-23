namespace Character
{
	public interface ICharacterData : IComponent, IKindData
	{
		IKindData Finish { get; set; }
	}
}