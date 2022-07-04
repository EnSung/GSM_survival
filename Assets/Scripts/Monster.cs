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
    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        if (IngameManager.Instance.player.level > 0)
            MaxHp *= Mathf.Pow(1.3f, IngameManager.Instance.player.level); 
        hp = MaxHp;
        
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
        float random = Random.Range(0,1000);
        if (random >= 1000)
            Instantiate(IngameManager.Instance.backpackPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public override void onHit(float power)
    {
        base.onHit(power);
        anim.SetTrigger("onhit");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;


        collision.gameObject.GetComponent<Player>().onHit(power);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        t += Time.deltaTime;

        if (t >= attackTime)
        {

            collision.gameObject.GetComponent<Player>().onHit(power);
            t = 0;
        }
    }
}
