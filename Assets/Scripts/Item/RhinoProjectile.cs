using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoProjectile : Projectile
{
    float t;
    void Start()
    {
        t = Time.time + 1.5f;
        if (transform.rotation.z >= 0.7f && transform.rotation.z <= 1 || transform.rotation.z <= -0.7f)
        {
            GetComponent<SpriteRenderer>().flipY = true;
        }

    }

    protected override void Update()
    {
        base.Update();

       

        if (Time.time >= t)
        {
            Destroy(gameObject);
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().onHit(power);
        }
    }
}

