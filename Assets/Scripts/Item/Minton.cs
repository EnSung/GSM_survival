using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minton : Item
{

    public Animator anim;
    public Transform atkPos;
    public Vector2 atkSize;

    public LayerMask monsterLays;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public override void Update()
    {
        base.Update();
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public override void UseItem()
    {
        base.UseItem();
        if (Time.time >= currentTime)
        {
            anim.SetTrigger("Attack");
            currentTime = Time.time + 100;
        }
    }

    public void attack()
    {
        Collider2D[] col = Physics2D.OverlapBoxAll(atkPos.position, atkSize,monsterLays);
        if (col.Length > 0)
        {
            foreach (Collider2D c in col)
            {
                try
                {
                c.gameObject.GetComponent<Monster>().onHit(applyPower);
                }
                catch
                {

                }
            }

        }
        currentTime = Time.time + coolTime;

    }

    public override void LevelUp()
    {
        base.LevelUp();
        applyPower *= 1.65f;
    }

    protected override void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(atkPos.position, atkSize);
    }
}
