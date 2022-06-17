using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumblerProjectile : Projectile
{
    float t;
    void Start()
    {
        t = Time.time + 3;
    }

    protected override void Update()
    {
        base.Update();
        if(Time.time >= t)
        {
            Destroy(gameObject);
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().onHit(power);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(collision.contacts[0].normal * -1 * 40);
        }
    }
}
