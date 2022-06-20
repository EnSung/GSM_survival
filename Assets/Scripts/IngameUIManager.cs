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

    [Header("LevelUp")]
    public GameObject levelup_panel;

    public ItemButton[] levelup_button;
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

    public void levelUp()
    {
        Time.timeScale = 0;
        levelup_panel.SetActive(true);
        
        List<int> idxList = new List<int>();

        foreach (ItemButton btn in levelup_button)
        {

            int idx;
            while (true)
            {
                idx = Random.Range(0, IngameManager.Instance.itemList.Count);

                if (!idxList.Contains(idx))
                {
                    idxList.Add(idx);
                    btn.idx = idx;
                    break;
                }
            }

            Image img = btn.GetComponentsInChildren<Image>()[2];
            img.sprite = IngameManager.Instance.itemList[idx].itemImage;
            TextMeshProUGUI[] itemText = btn.GetComponentsInChildren<TextMeshProUGUI>();
            itemText[0].text = IngameManager.Instance.itemList[idx].itemName;
            itemText[1].text = IngameManager.Instance.itemList[idx].itemExplanation;
        }

    }

}
