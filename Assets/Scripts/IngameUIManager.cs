using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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


    [Header("Item UI")]
    public GameObject itemUIPrefab;
    public Dictionary<System.Type, Item_Image_Object> itemImageObject = new Dictionary<System.Type, Item_Image_Object>();

    public Transform itemUIParent;
    [Header("Gameover")]
    public GameObject gameoverPanel;

    [Header("Backpack")]
    public GameObject backpackPanel;
    public Image backpackItemImg;

    [Header("Time")]
    public TMP_Text time;
    void Start()
    {
        backpackPanel.GetComponentInChildren<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    void Update()
    {
        EXP_UI_Refresh();

        string minute = (((int)IngameManager.Instance.gameTime / 60) > 9) ? ((int)IngameManager.Instance.gameTime / 60).ToString() : "0" + ((int)IngameManager.Instance.gameTime / 60).ToString();
        string second = (((int)(IngameManager.Instance.gameTime) % 60) > 9) ? ((int)(IngameManager.Instance.gameTime) % 60).ToString() : ("0" + ((int)(IngameManager.Instance.gameTime) % 60)).ToString();

        time.text = minute + ":" + second;
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

    public void gamover()
    {
        Time.timeScale = 0;
        gameoverPanel.SetActive(true);
    }

    public void ClickRestartBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");

    }


    public void backpackOpen(Backpack backpack, Item item)
    {
        Time.timeScale = 0;
        
        backpackPanel.SetActive(true);
        backpack.gameObject.SetActive(false);
        backpack.gameObject.SetActive(true);
        backpackItemImg.sprite = item.itemImage;
    }

    public void backpackClose()
    {
        backpackPanel.SetActive(false);
        Time.timeScale = 1;
    }

}
