namespace GameControl
{
    public class Progress : ISaveable
    {
        public Progress(int level)
        {
            Level = level;
        }

        public int Level { get; set; }
        
        public void PopulateSaveData(SaveData saveData)
        {
            saveData.currentLevel = Level;
        }

        public void LoadFromSaveData(SaveData saveData)
        {
            Level = saveData.currentLevel;
        }
    }
}