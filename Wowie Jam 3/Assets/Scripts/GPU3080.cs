using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPU3080 : MonoBehaviour
{
    [SerializeField] private Animator breakAnimator;
    private const string breakAnimation = "Break";
    [SerializeField] private Transform breakAnimationTransform;
    [SerializeField] private Animator gpuAnimator;
    private const string breakInHalfAnimation = "BreakInHalf";

    public void PlayBreakAnimation()
    {
        breakAnimationTransform.Rotate(new Vector3(0, 0, 90));
        breakAnimator.SetTrigger(breakAnimation);
    }

    public void BreakInHalf()
    {
        gpuAnimator.SetTrigger(breakInHalfAnimation);
    }
}
