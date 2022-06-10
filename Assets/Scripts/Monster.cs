using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        move();
    }
    public override void move()
    {
        transform.Translate((IngameManager.Instance.player.transform.position - transform.position).normalized * speed * Time.deltaTime);
    }

    public void SpawnEXP()
    {
        Instantiate(IngameManager.Instance.expPrefab, transform.position, Quaternion.identity);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
