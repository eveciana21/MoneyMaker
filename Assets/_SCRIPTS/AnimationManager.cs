using System.Collections;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator _100anim;
    [SerializeField] private Animator _200anim;
    [SerializeField] private Animator _lolAnim;

    [SerializeField] private AnimationsSO _animationsSO;

    private void OnEnable()
    {
        if (_animationsSO != null)
        {
            _animationsSO.Play100Anim += Play100Animation;
            _animationsSO.Play200Anim += Play200Animation;
            _animationsSO.PlayLOLAnim += PlayLOLAnimation;
            _animationsSO.ResetLOLAnim += ResetLOLAnimation;
        }
    }

    private void OnDisable()
    {
        if (_animationsSO != null)
        {
            _animationsSO.Play100Anim -= Play100Animation;
            _animationsSO.Play200Anim -= Play200Animation;
            _animationsSO.PlayLOLAnim -= PlayLOLAnimation;
            _animationsSO.ResetLOLAnim -= ResetLOLAnimation;
        }
    }

    public void Play100Animation()
    {
        StartCoroutine(DisableAnimationObject(_100anim, "Play"));
    }

    public void Play200Animation()
    {
        StartCoroutine(DisableAnimationObject(_200anim, "Play"));
    }

    public void PlayLOLAnimation()
    {
        _lolAnim.gameObject.SetActive(true);
        _lolAnim.SetTrigger("Play");
    }

    public void ResetLOLAnimation()
    {
        _lolAnim.ResetTrigger("Play");
    }

    IEnumerator DisableAnimationObject(Animator animator, string value)
    {
        if (animator != null)
        {
            animator.gameObject.SetActive(true);
            animator.SetTrigger("Play");
            yield return new WaitForSeconds(2);
            animator.gameObject.SetActive(false);
        }
    }
}