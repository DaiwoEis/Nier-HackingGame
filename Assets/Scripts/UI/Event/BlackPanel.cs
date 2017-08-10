using System.Collections;
using UnityEngine;

public class BlackPanel : MonoBehaviour 
{
    private void Awake()
    {
        StartCoroutine(_DisableRender());
    }

    private IEnumerator _DisableRender()
    {
        yield return new WaitForEndOfFrame();
        gameObject.SetActive(false);
    }
}
