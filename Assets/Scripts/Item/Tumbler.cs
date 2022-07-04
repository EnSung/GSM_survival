using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumbler : Item
{
    public GameObject projectilePrefabs;

    public LayerMask monsterMask;

    void Start()
    {
        
    }


    public override void UseItem()
    {
        base.UseItem();
        if(Time.time >= currentTime)
        {
            Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, applyRadius, monsterMask);
            if (col.Length > 0)
            {
                GameObject target = col[0].gameObject;
                Projectile obj = Instantiate(projectilePrefabs, transform.position, Quaternion.identity).GetComponent<Projectile>();
                obj.power = applyPower;
                obj.speed = 5;
                obj.dir = Vector2.right;

                Vector2 dir = (target.transform.position - transform.position).normalized;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                obj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                currentTime = Time.time + coolTime;
            }
        }
    }

    public override void LevelUp()
    {
        base.LevelUp();
        coolTime *= 0.9f;

        applyPower *= 1.5f;
    }

    protected override void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        base.OnDrawGizmosSelected();
    }
}
