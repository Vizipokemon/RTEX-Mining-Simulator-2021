using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPSystem : MonoBehaviour
{
    [SerializeField] private GameObject independentAudioSourcePrefab;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip mediumPointsSound;
    [SerializeField] private AudioClip largePointsSound;
    private float pointsSoundVolume = 0.45f;
    [SerializeField] private AudioClip levelUpSound;
    [SerializeField] private ParticleSystem XPParticles;
    [SerializeField] private ParticleSystem ExtremeXPReceivedParticles;
    [SerializeField] private XPBarUI ui;
    private int currentXP = 0;
    private int currentMaxXP = 30;
    private int currentLevel = 1;
    private const int xpConstant = 30;

    public static XPSystem Instance { get { return instance; } }
    private static XPSystem instance;

    public delegate void LevelUpDelegate(int newLevel);
    public event LevelUpDelegate OnLevelUpEvent;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
    }

    public void ReceiveRandomXP()
    {
        int random1to100 = UnityEngine.Random.Range(1,101);
        if(random1to100 <= 70)
        {
            ReceiveXP(5, XpReceivedText.ReceiveXpAnimation.SMALL);
        }
        else if(random1to100 > 70 && random1to100 <= 90)
        {
            ReceiveXP(10, XpReceivedText.ReceiveXpAnimation.SMALL);
        }
        else if (random1to100 > 90 && random1to100 <= 99)
        {
            ReceiveXP(25, XpReceivedText.ReceiveXpAnimation.BIG);
            PlaySoundWithIndependentAudioSource(mediumPointsSound, pointsSoundVolume);
        }
        else if (random1to100 == 100)
        {
            ReceiveXP(150, XpReceivedText.ReceiveXpAnimation.EXTREME);
            PlaySoundWithIndependentAudioSource(largePointsSound, pointsSoundVolume);
            ExtremeXPReceivedParticles.Play();
        }
    }

    private void PlaySoundWithIndependentAudioSource(AudioClip clip, float volume = 1f, float pitch = 1f)
    {
        IndependentAudioSource independentAudioSource = Instantiate(independentAudioSourcePrefab)
            .GetComponent<IndependentAudioSource>();
        independentAudioSource.Play(clip, volume, pitch);
    }

    public void ReceiveXP(int xp, XpReceivedText.ReceiveXpAnimation animation)
    {
        SetCurrentXP(xp);
        ui.SpawnXpReceivedText(xp, animation);
        ui.SetXP(currentXP);
        if(XPIsMaxedOut())
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentLevel++;
        ui.SetLevelTo(currentLevel);
        ui.PlayLevelTextPopAnimation();
        currentXP = 0;
        ui.SetXP(0);
        currentMaxXP += xpConstant;
        ui.setMaxXP(currentMaxXP);
        XPParticles.Play();
        PlayLevelUpSound();
        OnLevelUpEvent?.Invoke(currentLevel);
    }

    private void PlayLevelUpSound()
    {
        audioSource.clip = levelUpSound;
        audioSource.pitch = UnityEngine.Random.Range(1f, 1.3f);
        audioSource.Play();
    }

    private void SetCurrentXP(int xp)
    {
        if (currentXP + xp > currentMaxXP)
        {
            currentXP = currentMaxXP;
        }
        else
        {
            currentXP += xp;
        }
    }

    private bool XPIsMaxedOut()
    {
        return currentXP >= currentMaxXP;
    }
}
