using FullInspector;
using UnityEngine;

public class GameData : BaseScriptableObject
{
    [SerializeField]
    private int _gameLevelCount = 0;
    public int gameLevelCount { get { return _gameLevelCount; } }
}
