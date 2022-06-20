using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static de.Define;

public class ItemButton : MonoBehaviour
{

    public int idx;

    public void itemSpawn()
    {
        Debug.Log(IngameManager.Instance.player.activeItems.ContainsKey(IngameManager.Instance.itemList[idx].GetType()) || IngameManager.Instance.player.passiveItems.ContainsKey(IngameManager.Instance.itemList[idx].GetType()));
        if (IngameManager.Instance.player.activeItems.ContainsKey(IngameManager.Instance.itemList[idx].GetType()) || IngameManager.Instance.player.passiveItems.ContainsKey(IngameManager.Instance.itemList[idx].GetType()))
        {
            switch (IngameManager.Instance.itemList[idx].itemtype)
            {
                case itemType.active:
                    IngameManager.Instance.player.activeItems[IngameManager.Instance.itemList[idx].GetType()].LevelUp();
                    break;
                case itemType.passive:
                    IngameManager.Instance.player.passiveItems[IngameManager.Instance.itemList[idx].GetType()].LevelUp();
                    break;
                default:
                    break;
            }
        }
        else
        {
            var obj = Instantiate(IngameManager.Instance.itemList[idx]);
            obj.transform.parent = IngameManager.Instance.player.gameObject.transform;
            obj.transform.localPosition = Vector2.zero;
            obj.transform.localScale = new Vector3(1, 1, 1);
            Item item = obj.GetComponent<Item>();
            
            switch (item.itemtype)
            {
                case itemType.active:
                    IngameManager.Instance.player.activeItems.Add(item.GetType(),item);
                    break;
                case itemType.passive:
                    IngameManager.Instance.player.passiveItems.Add(item.GetType(),item);
                    break;
                default:
                    break;
            }
        }

        IngameUIManager.Instance.levelup_panel.SetActive(false);
        Time.timeScale = 1;
    }


}
