using Character;
using Logic.BaseClasses;
using Services.StaticDataService.StaticData;

namespace Services.StaticDataService
{
    public interface IStaticDataService
    {
        void Load();
        LevelStaticData ForLevel(string level);
        FinishStaticData ForFinish(Kind kind);
        CharacterStaticData ForCharacter(Kind kind);
    }
}