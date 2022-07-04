using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static de.Define;

public class Backpack : MonoBehaviour
{
    public UnityEvent<Backpack,Item> openEvent;
    public Item item;

    void Start()
    {
        openEvent.AddListener(IngameUIManager.Instance.backpackOpen);
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int ran = Random.Range(0, 2);

            if (IngameManager.Instance.player.activeItems.Count > 0 && IngameManager.Instance.player.passiveItems.Count > 0)
            {
                if (ran == 0)
                {
                    int randomItemidx;
                    randomItemidx = Random.Range(0, IngameManager.Instance.player.activeItems.Count);
                    int cnt = 0;
                    foreach (Item item in IngameManager.Instance.player.activeItems.Values)
                    {
                        cnt++;

                        if (cnt == randomItemidx)
                            this.item = item;
                    }
                }
                else
                {
                    int randomItemidx;
                    randomItemidx = Random.Range(0, IngameManager.Instance.player.passiveItems.Count);
                    int cnt = 0;
                    foreach (Item item in IngameManager.Instance.player.passiveItems.Values)
                    {
                        cnt++;

                        if (cnt == randomItemidx)
                            this.item = item;
                    }
                }
            }
            else if (IngameManager.Instance.player.activeItems.Count > 0)
            {
                int randomItemidx;
                randomItemidx = Random.Range(0, IngameManager.Instance.player.activeItems.Count);
                int cnt = 0;
                foreach (Item item in IngameManager.Instance.player.activeItems.Values)
                {

                    if (cnt == randomItemidx)
                        this.item = item;
                    cnt++;

                }
            }
            else if (IngameManager.Instance.player.passiveItems.Count > 0)
            {

                int randomItemidx;
                randomItemidx = Random.Range(0, IngameManager.Instance.player.passiveItems.Count);
                int cnt = 0;
                foreach (Item item in IngameManager.Instance.player.passiveItems.Values)
                {
                    cnt++;

                    if (cnt == randomItemidx)
                        this.item = item;
                }
            }
                switch (item.itemtype)
                {
                    case itemType.active:
                    IngameManager.Instance.player.activeItems[item.GetType()].LevelUp();
                    
                        IngameUIManager.Instance.itemImageObject[item.GetType()].level_up(IngameManager.Instance.player.activeItems[item.GetType()].level);

                        break;
                    case itemType.passive:
                        IngameManager.Instance.player.passiveItems[item.GetType()].LevelUp();
                        break;
                    default:
                        break;
                }
            openEvent.Invoke(this, item);
            Destroy(gameObject);

        }
    }
}

