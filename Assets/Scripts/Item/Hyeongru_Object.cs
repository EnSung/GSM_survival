using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hyeongru_Object : MonoBehaviour
{
    public Hyeongru h;
    public float radius;
    public LayerMask monsterMask;

    public TextMeshProUGUI h_text;

    public Animator anim;
    public float attackTime;
    public float t;

    public float power;

    public float spawnTime;

    private void OnEnable()
    {
        spawnTime = Time.time + 15;
        t = 0;

    }
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {

        if (spawnTime < Time.time)
        {
            gameObject.SetActive(false);
            h.currentTime = Time.time + h.coolTime;
        }

        
        t += Time.deltaTime;

        if (t < attackTime) return;

        transform.localScale = new((Random.Range(0, 2) == 0) ? 1 : -1, 1);

        int n = Random.Range(0, 5);
        switch (n)
        {
            case 0:
                h_text.text = "°³¹ßÇØ";
                break;
            case 1:
                h_text.text = "À¸ ¾Ã´ö";
                break;
            case 2:
                h_text.text = "¹º¼Ò¸®¾ß";
                break;
            case 3:
                h_text.text = "ÀÌ¾Ã´ö¾Æ";
                break;
            default:
                h_text.text = "À¹";
                break;
        }
        anim.SetTrigger("attack");


        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, radius, monsterMask);

        foreach (Collider2D c in col)
        {
            c.GetComponent<Monster>().onHit(power);
        }

        t = 0;
    }


    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
