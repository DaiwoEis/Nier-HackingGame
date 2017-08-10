public class PlatformUtility
{
    public static PlatformType currentPlatform
    {
        get
        {
#if Moblie_Platform
            return PlatformType.Moblie;
#else
            return PlatformType.PC;
#endif
        }
    }

    private void Awake() { }

    private void Start() { }

    private void Update() { }
}

public enum PlatformType
{
    Moblie,
    PC
}