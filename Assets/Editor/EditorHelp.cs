using System.Collections.Generic;
using System.Linq;
using CUI;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class EditorHelp 
{
    [MenuItem("Help/Setup/Setup animated window dics")]
    public static void SetupWindowsDics()
    {
        foreach (var window in Object.FindObjectsOfType<CAnimatorWindow>())
        {
            var animator = window.GetComponent<Animator>();
            AnimatorController ac = (AnimatorController)animator.runtimeAnimatorController;
            window.stateLengthDics = new Dictionary<string, float>[ac.layers.Length];
            for (int i = 0; i < window.stateLengthDics.Length; ++i)
            {
                List<AnimatorState> states = ac.layers[i].stateMachine.states.Select(cas => cas.state).ToList();
                window.stateLengthDics[i] = new Dictionary<string, float>();
                foreach (var state in states)
                {
                    AnimationClip clip = (AnimationClip)state.motion;                    
                    window.stateLengthDics[i][state.name] = clip.length;
                }
                if (i == 2)
                {
                    Debug.Log(states.Count);
                    foreach (var animatorState in states)
                    {
                        Debug.Log(animatorState.name);
                    }
                }
            }            
        }
        EditorSceneManager.MarkAllScenesDirty();
    }

    [MenuItem("Help/Setup/Setup game state window")]
    public static void SetupGameStateWindow()
    {
        foreach (var gameState in Object.FindObjectsOfType<GameState>())
            gameState.Setup();
        EditorSceneManager.MarkAllScenesDirty();
    }

    [MenuItem("Help/Setup/Setup all")]
    public static void SetupAll()
    {
        SetupWindowsDics();
        SetupGameStateWindow();
    }
}
