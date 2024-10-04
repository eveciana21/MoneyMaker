using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Money Actions/Animations")]
public class AnimationsSO : ScriptableObject
{
    public Action Play100Anim;
    public Action Play200Anim;
    public Action PlayLOLAnim;
    public Action ResetLOLAnim;

    public void Play100Animation()
    {
        Play100Anim?.Invoke();
    }

    public void Play200Animation()
    {
        Play200Anim?.Invoke();
    }

    public void PlayLOLAnimation()
    {
        PlayLOLAnim?.Invoke();
    }

    public void ResetLOLAnimation()
    {
        ResetLOLAnim?.Invoke();
    }
}
