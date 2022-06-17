using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolderingIronObject : MonoBehaviour
{
    public float radius;
    float t;
    [SerializeField] float rotateSpeed;
    public float power;
    SolderingIron soldering;

    Collider2D[] col;
    Collider2D target;
    public LayerMask monsterMask;

    float currentDamageTime;
    public float damageTime;
    private void OnEnable()
    {
        t = Time.time + 2;
        try {
            col = Physics2D.OverlapCircleAll(transform.position, radius, monsterMask);
            target = col[0];
        }
        catch
        {

        }
    }
    void Start()
    {
        soldering = GetComponentInParent<SolderingIron>();
    }

    void Update()
    {
        if (Time.time >= t)
        {
            soldering.currentTime = Time.time + soldering.coolTime;
            gameObject.SetActive(false);
        }
        if (col.Length <= 0) return;

        if(target == null || Vector2.Distance(transform.position,target.transform.position) > radius)
        {
            try
            {
                col = Physics2D.OverlapCircleAll(transform.position, radius, monsterMask);
                target = col[0];
            }
            catch
            {

            }
        }

        try 
        { 
            Vector2 dir = (target.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        catch
        {

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().onHit(power);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        currentDamageTime += Time.deltaTime;

        if (currentDamageTime >= damageTime) 
        {
            if (collision.gameObject.CompareTag("Monster"))
            {
                collision.gameObject.GetComponent<Monster>().onHit(power);
            }

            currentDamageTime = 0;
        }
    }
}
