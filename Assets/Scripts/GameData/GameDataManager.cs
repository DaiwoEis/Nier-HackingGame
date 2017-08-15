using UnityEngine;

public class GameDataManager
{
    private static LevelData[] _levelDatas = null;
    public static LevelData[] levelDatas { get { return _levelDatas; } }

    public static GameData gameData { get; private set; }

    public static int currentLevel { get { return CSceneManager.GetSceneNumberByName(CSceneManager.CurrentScene); } }

    static GameDataManager()
    {
        gameData = Resources.Load<GameData>("GameData/Data");
        _levelDatas = Resources.LoadAll<LevelData>("GameData/LevelData");
    }

    public static LevelData GetLevelData(int levelNumber)
    {
        if (levelNumber <= 0 || levelNumber > gameData.gameLevelCount)
        {
            Debug.LogError("The game dont has level " + levelNumber);
            return null;
        }

        return _levelDatas[levelNumber - 1];
    }

    public static string GetLevelName(int levelNumber)
    {
        return "Level " + NumberUtility.NormalizedNumber(levelNumber);
    }

    public static string GetNextLevelName()
    {
        var levelNumber = currentLevel;
        levelNumber += 1;
        if (levelNumber > gameData.gameLevelCount)
            levelNumber = 1;
        return GetLevelName(levelNumber);
    }
}