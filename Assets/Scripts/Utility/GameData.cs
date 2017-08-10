using FullInspector;
using UnityEngine;

public class GameData : BaseScriptableObject
{
    [SerializeField]
    private int _gameLevelCount;
    public int gameLevelCount { get { return _gameLevelCount; } }

    public int completeLevelNumber { get; set; }
}
