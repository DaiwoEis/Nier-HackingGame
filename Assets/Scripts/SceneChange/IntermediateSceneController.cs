using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntermediateSceneController : MonoBehaviour
{
    [SerializeField]
    private Slider _slider = null;

	private void Start ()
	{
	    StartCoroutine(_LoadScene(CSceneManager.NextScene));
	}

    private IEnumerator _LoadScene(string scene)
    {
        int displayProgress = 0;
        int toProgress;
        AsyncOperation op = SceneManager.LoadSceneAsync(scene);
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            toProgress = (int)op.progress * 100;
            while (displayProgress < toProgress)
            {
                ++displayProgress;
                SetLoadingPercentage(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }

        toProgress = 100;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            SetLoadingPercentage(displayProgress);
            yield return new WaitForEndOfFrame();
        }

        op.allowSceneActivation = true;
        CSceneManager.NextScene = "";
    }

    private void SetLoadingPercentage(int displayProgress)
    {
        _slider.value = displayProgress;
    }

}
