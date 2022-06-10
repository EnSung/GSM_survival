using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPObject : MonoBehaviour
{
    public float radius;
    public LayerMask playerMask;
    public float speed = 6f;

    void Start()
    {
        
    }

    void Update()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, radius,playerMask);

        if (player)
        {
            transform.position = Vector2.MoveTowards(transform.position, IngameManager.Instance.player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IngameManager.Instance.player.UpEXP(2);
            Destroy(gameObject);
        }
    }
}
