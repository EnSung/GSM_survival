using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealObject : EXPObject
{
    void Start()
    {
        
    }

    protected override void Update()
    {
        base.Update();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IngameManager.Instance.player.HPUP(6);
            Destroy(gameObject);
        }
    }
}
