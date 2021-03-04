using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public delegate void CamShakeEnabledChangedDelegate(bool newValue);
    public event CamShakeEnabledChangedDelegate CamShakeEnabledChangedEvent;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private GameObject optionsGO;
    private bool isOptionsActive = false;

    public bool CameraShake { get; set; } = true;
    public float Volume { get; set; }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Show(!isOptionsActive);
        }
    }

    public void OnVolumeChanged(float newValue)
    {
        Volume = newValue;
        audioMixer.SetFloat("masterVol", newValue);
    }

    public void OnCameraShakeValueChanged(bool newValue)
    {
        CameraShake = newValue;
        CamShakeEnabledChangedEvent?.Invoke(newValue);
    }

    public void Show(bool enable)
    {
        optionsGO.SetActive(enable);
        isOptionsActive = enable;
    }
}
