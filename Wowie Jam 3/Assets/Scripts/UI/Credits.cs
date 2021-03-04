using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] private GameObject creditsGO;

    public void Show()
    {
        creditsGO.SetActive(true);
    }

    public void Close()
    {
        creditsGO.SetActive(false);
    }
}
