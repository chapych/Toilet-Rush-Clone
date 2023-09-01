using GameControl;

public interface ISaveLoadService
{
    void SaveJsonData(ISaveable savable);
    bool LoadJsonData(ISaveable savable);
}