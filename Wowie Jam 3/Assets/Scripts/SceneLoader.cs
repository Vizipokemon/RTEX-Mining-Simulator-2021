using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Animator blackScreenAnimator;
    private const string blackScreenFadeInAnimation = "FadeIn";
    private const string blackScreenFadeOutAnimation = "FadeOut";

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(int buildIndexOfScene)
    {
        StartCoroutine(LoadSceneCoroutine(buildIndexOfScene));
    }

    private IEnumerator LoadSceneCoroutine(int buildIndexOfScene)
    {
        blackScreenAnimator.SetTrigger(blackScreenFadeInAnimation);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(buildIndexOfScene);
        yield return new WaitForSeconds(1f);
        blackScreenAnimator.SetTrigger(blackScreenFadeOutAnimation);
    }
}
