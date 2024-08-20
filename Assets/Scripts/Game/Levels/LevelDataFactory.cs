

using Game.Levels;

public static class LevelDataFactory
{
    public static LevelData Create(LevelName levelName)
    {
        LevelData levelData = levelName switch
        {
            LevelName.Level1 => new Level_1(),
            LevelName.Level2 => new Level_2(),
            LevelName.Level_CrateTest=>new Level_CrateTest(),
            _ => new Level_1()
        };

        levelData.Initialize();
        return levelData;
    }

}
