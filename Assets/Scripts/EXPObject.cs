using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPObject : MonoBehaviour
{
    public float speed = 6f;
    public bool isNearlyPlayer;
    void Start()
    {
        
    }

    protected virtual void Update()
    {

        if (isNearlyPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, IngameManager.Instance.player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IngameManager.Instance.player.UpEXP(5);
            Destroy(gameObject);
        }
    }
}
