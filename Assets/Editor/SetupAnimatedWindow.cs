using System.Collections.Generic;
using System.Linq;
using CUI;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class SetupAnimatedWindow  
{
    [MenuItem("Help/Setup all animated window dic")]
    public static void SetupWindowsDic()
    {
        foreach (var window in Object.FindObjectsOfType<CAnimateWindow>())
        {
            var animator = window.GetComponent<Animator>();
            AnimatorController ac = (AnimatorController)animator.runtimeAnimatorController;
            List<AnimatorState> states = ac.layers[0].stateMachine.states.Select(cas => cas.state).ToList();
            window.stateLengthDic = new Dictionary<string, float>();
            foreach (var state in states)
            {
                AnimationClip clip = (AnimationClip)state.motion;
                window.stateLengthDic[state.name] = clip.length;
            }
        }
    }
}
