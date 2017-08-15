using FullInspector;

public class LevelData : BaseScriptableObject
{
    public bool complete = false;

    public float consumeTime;

    public int consumeLife;

    [InspectorButton]
    public void Clear()
    {
        complete = false;
        consumeTime = 0f;
        consumeLife = 0;
    }
}
