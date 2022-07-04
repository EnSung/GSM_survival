using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Item_Image_Object : MonoBehaviour
{

    public int idx;
    public Image itemImg;
    public TMP_Text level_text;
    public System.Type itemType;

    void Start()
    {
        itemImg.sprite = IngameManager.Instance.itemList[idx].itemImage;
    }

    void Update()
    {
    }

    public void level_up(int level)
    {
        level_text.text = "Level : " + level.ToString();
    }
}
