using CUI;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    private AudioSource _audioSource = null;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        if (sound == null) return;
        _audioSource.PlayOneShot(sound);
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
        FindObjectOfType<GameRoot>().LoadCurrentScene();
    }

    public void LoadNextScene()
    {
        FindObjectOfType<GameRoot>().LoadNextScene();
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
