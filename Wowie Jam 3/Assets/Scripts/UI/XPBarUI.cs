using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBarUI : MonoBehaviour
{
    [SerializeField] private GameObject xpReceivedTextPrefab;
    [SerializeField] private Transform uiCanvas;

    [SerializeField] private Collider2D xpReceivedTextSpawnPositionBounds;

    [SerializeField] private Slider slider;
    [SerializeField] private Text levelText;
    [SerializeField] private Animator levelTextAnimator;
    private const string levelTextPopAnimation = "Pop";

    public void SpawnXpReceivedText(int xp, XpReceivedText.ReceiveXpAnimation animation)
    {
        GameObject go = Instantiate(xpReceivedTextPrefab, uiCanvas);
        RectTransform rectTransform = go.GetComponent<RectTransform>();
        Vector3 spawnPosition = GetRandomSpawnPositionWithinBounds(rectTransform);
        rectTransform.anchoredPosition = spawnPosition;
        go.GetComponentInChildren<XpReceivedText>().Play(xp, animation);
    }

    public void SetXP(int xp)
    {
        slider.value = xp;
    }

    public void setMaxXP(int maxXP)
    {
        slider.maxValue = maxXP;
    }

    private Vector3 GetRandomSpawnPositionWithinBounds(RectTransform bounds)
    {
        Vector3 position = new Vector3(0, 0, 0);

        float minX = bounds.anchoredPosition.x + bounds.rect.xMin;
        float maxX = bounds.anchoredPosition.x + bounds.rect.xMax;
        float minY = bounds.anchoredPosition.y + bounds.rect.yMin;
        float maxY = bounds.anchoredPosition.y + bounds.rect.yMax;

        position.x = Random.Range(minX, maxX);
        position.y = Random.Range(minY, maxY);

        return position;
    }

    public void SetLevelTo(int level)
    {
        levelText.text = "Lv " + level.ToString();
    }

    public void PlayLevelTextPopAnimation()
    {
        levelTextAnimator.SetTrigger(levelTextPopAnimation);
    }
}
