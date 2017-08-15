using System.Collections;
using CUI;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    private AudioSource _audioSource = null;

    protected override void OnCreate()
    {
        base.OnCreate();

        _audioSource = GetComponent<AudioSource>();
    }

    protected override IEnumerator _OnRelease()
    {
        yield return base._OnRelease();

        while (true)
        {
            if (_audioSource.isPlaying)
                yield return null;
            else
                break;
        }
    }

    public void PlaySound(AudioClip sound)
    {
        if (sound == null) return;
        _audioSource.PlayOneShot(sound);
    }

    public void SetAnimationVersonZero(CWindow window)
    {
        window.SetAnimationVersion(0);
    }

    public void SetAnimationVersonOne(CWindow window)
    {
        window.SetAnimationVersion(1);
    }

    public void AddOpenCommend(CWindow nextView)
    {
        MonoSingleton<WindowController>.instance.AddCommond(new OpenCommond(nextView));
    }

    public void AddCloseCommend()
    {
        MonoSingleton<WindowController>.instance.AddCommond(new CloseCommond());
    }

    public void AddCloseAllCommend()
    {
        MonoSingleton<WindowController>.instance.AddCommond(new CloseAllCommond());
    }

    public void AddPausedCommend()
    {
        MonoSingleton<WindowController>.instance.AddCommond(new PauseCommond());
    }

    public void LoadScene(string sceneName)
    {        
        FindObjectOfType<GameRoot>().LoadScene(sceneName);
    }

    public void LoadCurrentScene()
    {
        FindObjectOfType<GameRoot>().LoadCurrentLevel();
    }

    public void LoadNextScene()
    {
        FindObjectOfType<GameRoot>().LoadNextLevel();
    }

    public void LoadMainMenuScene()
    {
        FindObjectOfType<GameRoot>().LoadMainMenuScene();
    }

    public void QuitGame()
    {
        FindObjectOfType<GameRoot>().QuitGame();
    }
}
