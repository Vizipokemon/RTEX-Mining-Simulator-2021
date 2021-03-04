using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtil : MonoBehaviour
{
    private Options options;
    [SerializeField] private Animator cameraAnimator;
    private const string cameraShake = "Shake";

    public bool ShakeEnabled { get; set; } = true;

    private void Start()
    {
        options = FindObjectOfType<Options>();
        options.CamShakeEnabledChangedEvent += OnCamShakeEnabledChanged;
    }

    private void OnDestroy()
    {
        options.CamShakeEnabledChangedEvent -= OnCamShakeEnabledChanged;
    }

    private void OnCamShakeEnabledChanged(bool newValue)
    {
        ShakeEnabled = newValue;
    }

    public void ShakeCamera()
    {
        if(!ShakeEnabled)
        {
            return;
        }

        cameraAnimator.SetTrigger(cameraShake);
    }
}
