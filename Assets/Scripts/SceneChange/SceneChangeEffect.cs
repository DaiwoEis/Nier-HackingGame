using System;
using System.Collections;
using UnityEngine;

public class SceneChangeEffect : MonoBehaviour
{
    [SerializeField]
    public Material _effectMaterial;

    private bool _start = false;

    [SerializeField]
    private float _effectTime = 2f;

    private void OnRenderImage(RenderTexture src, RenderTexture dst)
    {

        Graphics.Blit(src, dst, _effectMaterial);
        //if (_start)
        //{
        //    Graphics.Blit(src, dst, _effectMaterial);
        //}
        //else
        //{
        //    Graphics.Blit(src, dst);
        //}          
    }

    public void Run(Action onComplete = null)
    {
        StartCoroutine(_Run(onComplete));
    }

    public void RunReverse(Action onComplete = null)
    {
        StartCoroutine(_RunReverse(onComplete));
    }

    private IEnumerator _Run(Action onComplete = null)
    {
        _start = true;
        enabled = true;
        float timer = 0f;
        while (timer < _effectTime)
        {
            _effectMaterial.SetFloat("_Magnitude", timer/_effectTime*0.5f);
            yield return null;
            timer += Time.unscaledDeltaTime;
        }
        if (onComplete != null) onComplete();
        _start = false;
        enabled = false;
    }

    private IEnumerator _RunReverse(Action onComplete = null)
    {
        enabled = true;
        _start = true;
        float timer = 0f;
        while (timer < _effectTime)
        {
            _effectMaterial.SetFloat("_Magnitude", 1f - timer/_effectTime);
            yield return null;
            timer += Time.unscaledDeltaTime;
        }
        if (onComplete != null) onComplete();
        _start = false;
        enabled = false;
    }
}