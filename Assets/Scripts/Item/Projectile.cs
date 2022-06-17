using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 dir;
    public float power;
    public float speed;


    protected virtual void Update()
    {
        if(dir == Vector2.zero)
        {
            dir = Vector2.up;
        }
        transform.Translate(dir * speed * Time.deltaTime);    
    }


    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().onHit(power);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(collision.contacts[0].normal*-1 * 40);
            Destroy(gameObject);
        }
    }
}
