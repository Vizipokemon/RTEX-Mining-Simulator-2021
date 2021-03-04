using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private const string appearAnimation = "Appear";
    private const string disappearAnimation = "Disappear";
    [SerializeField] private Text text;
    private const string secondEndScreenText = "Bitcoins mined: 0";
    private const string thirdEndScreenText = "Since you broke the last card in stock, it's kinda out of stock again :/";
    private const int menuSceneBuildIndex = 0;

    public void PlayEndScreen()
    {
        StartCoroutine(PlayEndScreenCoroutine());
    }

    private IEnumerator PlayEndScreenCoroutine()
    {
        animator.SetTrigger(appearAnimation);
        yield return new WaitForSeconds(3f);
        animator.SetTrigger(disappearAnimation);
        yield return new WaitForSeconds(1.5f);
        text.text = secondEndScreenText;
        animator.SetTrigger(appearAnimation);
        yield return new WaitForSeconds(3f);
        animator.SetTrigger(disappearAnimation);
        yield return new WaitForSeconds(1.5f);
        text.text = thirdEndScreenText;
        animator.SetTrigger(appearAnimation);
        yield return new WaitForSeconds(7f);
        animator.SetTrigger(disappearAnimation);
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<SceneLoader>().LoadScene(menuSceneBuildIndex);
    }
}
