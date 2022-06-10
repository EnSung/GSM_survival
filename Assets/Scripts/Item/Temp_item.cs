using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_item : Item
{
    public GameObject projectilePrefabs;
    void Start()
    {
        
    }


    public override void UseItem()
    {
        base.UseItem();
        if(Time.time >= currentTime)
        {
            Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, radius);
            if (col[0])
            {
                Projectile obj = Instantiate(projectilePrefabs, transform.position, Quaternion.identity).GetComponent<Projectile>();
                obj.power = power;
                obj.speed = 5;
                obj.dir = (col[0].transform.position - transform.position).normalized;


                currentTime = Time.time + coolTime;
            }
        }
    }
}
