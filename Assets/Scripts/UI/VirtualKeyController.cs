using UnityEngine;

public class VirtualKeyController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _gameObjects = null;

    private void Awake()
    {
#if !MOBILE_PLATFORM
        foreach (var go in _gameObjects)
        {
            go.SetActive(false);
        }
#endif
    }

    private void Start() { }

    private void Update() { }
}
