using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Monster : Unit
{
    Rigidbody2D rigid;
    SpriteRenderer SR;

    Animator anim;

    public float attackTime;
    float t;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        move();
    }
    public override void move()
    {
        transform.Translate((IngameManager.Instance.player.transform.position - transform.position).normalized * speed * Time.deltaTime);
        SR.flipX = (IngameManager.Instance.player.transform.position.x > transform.position.x);
    }

    public void SpawnEXP()
    {
        Instantiate(IngameManager.Instance.expPrefab, transform.position, Quaternion.identity);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public override void onHit(float power)
    {
        base.onHit(power);
        anim.SetTrigger("onhit");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.CompareTag("Player")) return;


        collision.GetComponent<Player>().onHit(power);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        t += Time.deltaTime;

        if (t >= attackTime)
        {

            collision.GetComponent<Player>().onHit(power);
            t = 0;
        }
    }
}
