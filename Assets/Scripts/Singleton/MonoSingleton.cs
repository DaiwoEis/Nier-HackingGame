using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _instance;

    public static T instance { get { return _instance; } } 

    public static void Create()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<T>();

            if (_instance == null)
            {
                GameObject contaioner = new GameObject(typeof(T).ToString())
                {
                    tag = TagConfig.DontDestroyOnIntermediateScene
                };
                _instance = contaioner.AddComponent<T>();
            }

            _instance.Init();
        }
    }

    public static void Destroy()
    {
        _instance = null;
    }

    protected virtual void Init()
    {
        
    }
}
