using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EndScreen endScreen;
    [SerializeField] private XPSystem xpSystem;
    [SerializeField] private GPU3080 gpu;
    [SerializeField] private Hammer hammer;
    [SerializeField] private int lastLevel = 25;
    [SerializeField] private int superSaiyanLevel = 15;
    private const int superSaiyanFirstPowerUpAtLevel = 23;
    private const int superSaiyanSecondPowerUpAtLevel = 27;

    [SerializeField] private Animator superSaiyanQuestionAnimator;
    private const string superSaiyanFadeInAnimation = "Appear";
    private const string superSaiyanFadeOutAnimation = "Disappear";
    private bool listenForSuperSaiyanAnswer = false;

    private void OnEnable()
    {
        xpSystem.OnLevelUpEvent += OnLevelUp;
    }

    private void OnDisable()
    {
        xpSystem.OnLevelUpEvent -= OnLevelUp;
    }

    private void Update()
    {
        if(listenForSuperSaiyanAnswer)
        {
            if(Input.GetKeyDown(KeyCode.Y))
            {
                ActivateSuperSaiyan(true);
            }
            else if(Input.GetKeyDown(KeyCode.N))
            {
                ActivateSuperSaiyan(false);
            }
        }
    }

    private void OnLevelUp(int newLevel)
    {
        if(newLevel >= lastLevel)
        {
            StartCoroutine(EndGame());
        }

        if(newLevel == superSaiyanLevel)
        {
            ShowSuperSaiyanQuestion();
            listenForSuperSaiyanAnswer = true;
        }

        if(newLevel == superSaiyanFirstPowerUpAtLevel)
        {
            hammer.ActivateSuperSaiyanLevel2();
        }

        if(newLevel == superSaiyanSecondPowerUpAtLevel)
        {
            hammer.ActivateSuperSaiyanLevel3();
        }
    }

    private void ShowSuperSaiyanQuestion()
    {
        superSaiyanQuestionAnimator.SetTrigger(superSaiyanFadeInAnimation);
    }

    private void ActivateSuperSaiyan(bool activate)
    {
        superSaiyanQuestionAnimator.SetTrigger(superSaiyanFadeOutAnimation);
        if(activate)
        {
            hammer.ActivateSuperSaiyan();
        }
    }

    private IEnumerator EndGame()
    {
        hammer.EnablePlayerInputs(false);
        gpu.BreakInHalf();
        yield return new WaitForSeconds(1.5f);
        endScreen.PlayEndScreen();
    }
}
