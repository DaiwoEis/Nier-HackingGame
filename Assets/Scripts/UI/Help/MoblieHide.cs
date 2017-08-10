using UnityEngine;

public class MoblieHide : MonoBehaviour
{
    private void Awake()
    {
#if Moblie_Platform
        gameObject.SetActive(true);
#else
        gameObject.SetActive(false);
#endif
    }
}
