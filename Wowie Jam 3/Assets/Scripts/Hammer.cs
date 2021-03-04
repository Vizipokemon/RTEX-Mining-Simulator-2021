using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] private GameObject superSaiyanVisuals;
    [SerializeField] private GPU3080 target;
    [SerializeField] private CameraUtil mainCamera;
    [SerializeField] private Animator hammerAnimator;
    [SerializeField] private AudioClip[] hitSounds;
    [SerializeField] private AudioSource audioSource;
    private const string smashTrigger = "Smash";
    private bool listenForPlayerInputs = true;

    private bool supersaiyan = false;
    private float supersaiyantimer = 0f;
    public float supersaiyanSmashEveryHowManySeconds = 0.1f;
    private const float supersaiyanLvl2Speed = 0.05f;
    private const float supersaiyanLvl3Speed = 0.01f;
    [SerializeField] private AudioSource over9000AudioSource;

    private void Update()
    {
        if(!listenForPlayerInputs)
        {
            return;
        }

        if(Input.GetMouseButtonDown(0) == true ||
            Input.GetKeyDown(KeyCode.Space) == true)
        {
            Smash();
        }

        if(supersaiyan)
        {
            if(supersaiyantimer <= 0f)
            {
                Smash();
                supersaiyantimer = supersaiyanSmashEveryHowManySeconds;
            }

            supersaiyantimer -= Time.deltaTime;
        }
    }

    public void ActivateSuperSaiyan()
    {
        supersaiyan = true;
        superSaiyanVisuals.SetActive(true);
    }

    public void ActivateSuperSaiyanLevel2()
    {
        supersaiyanSmashEveryHowManySeconds = supersaiyanLvl2Speed;
    }

    public void ActivateSuperSaiyanLevel3()
    {
        supersaiyanSmashEveryHowManySeconds = supersaiyanLvl3Speed;
        over9000AudioSource.Play();
    }

    public void EnablePlayerInputs(bool enable)
    {
        listenForPlayerInputs = enable;
    }

    private void Smash()
    {
        hammerAnimator.SetTrigger(smashTrigger);
        XPSystem.Instance.ReceiveRandomXP();
        PlayRandomHitSounds();
        mainCamera.ShakeCamera();
        target.PlayBreakAnimation();
    }

    private void PlayRandomHitSounds()
    {
        int randomHitSoundIndex = UnityEngine.Random.Range(0, hitSounds.Length);
        audioSource.clip = hitSounds[randomHitSoundIndex];
        audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.2f);
        audioSource.Play();
    }
}
