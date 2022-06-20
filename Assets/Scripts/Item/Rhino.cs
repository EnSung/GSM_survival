using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhino : Item
{

    public GameObject projectilePrefabs;

    public LayerMask monsterMask;

    void Start()
    {
        
    }

    public override void UseItem()
    {
        base.UseItem();
        if (Time.time >= currentTime)
        {
                Projectile obj = Instantiate(projectilePrefabs, transform.position, Quaternion.identity).GetComponent<Projectile>();
                obj.power = applyPower;
                obj.speed = 8;
                obj.dir = Vector2.right;

                Vector2 dir = (IngameManager.Instance.player.transform.position + (Vector3)IngameManager.Instance.player.dir - transform.position).normalized;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                obj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                currentTime = Time.time + coolTime;
        }
    }

}
