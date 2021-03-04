using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpReceivedText : MonoBehaviour
{
    public enum ReceiveXpAnimation
    {
        SMALL = 0,
        BIG = 1,
        EXTREME = 2
    }

    [SerializeField] private Animator animator;
    private const string receiveSmallAnimation = "ReceiveSmall";
    private const string receiveBigAnimation = "ReceiveBig";

    public void Play(int xp, ReceiveXpAnimation animation)
    {
        Text text = GetComponent<Text>();
        text.text= "+" + xp + "xp";
        if(animation == ReceiveXpAnimation.SMALL)
        {
            animator.SetTrigger(receiveSmallAnimation);
        }
        else if(animation == ReceiveXpAnimation.BIG)
        {
            text.color = new Color(255f/255f, 168f/255f, 103f/255f);
            animator.SetTrigger(receiveBigAnimation);
        }
        else if (animation == ReceiveXpAnimation.EXTREME)
        {
            text.color = Color.white;
            animator.SetTrigger(receiveBigAnimation);
        }
    }
}
