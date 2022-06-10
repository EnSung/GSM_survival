using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngameUIManager : Singleton<IngameUIManager>
{
    [Header("EXP")]
    public Slider EXP_Slider;
    public TextMeshProUGUI levelText;
    void Start()
    {
        
    }

    void Update()
    {
        EXP_UI_Refresh();
    }

    public void EXP_UI_Refresh()
    {
        EXP_Slider.value = Mathf.Lerp(EXP_Slider.value, IngameManager.Instance.player.EXPRatio, 8 * Time.deltaTime);
        levelText.text = "LV " + IngameManager.Instance.player.level.ToString();
    }
}
