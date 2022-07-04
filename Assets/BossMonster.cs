using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : Monster
{

    protected override void Start()
    {
        base.Start();
        MaxHp *= (Mathf.Pow(1.6f, (int)(IngameManager.Instance.gameTime / 180)) + 1);
    }
    public void SpawnBackpack()
    {
        Instantiate(IngameManager.Instance.backpackPrefab,transform.position,Quaternion.identity);
    }

}
