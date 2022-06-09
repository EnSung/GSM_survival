using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    List<Item> items = new List<Item>();
    private void Start()
    {
        
    }

    private void Update()
    {
        move();
    }

    public override void move()
    {
        transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized *speed * Time.deltaTime);
    }

    public override void onHit(float power)
    {
        base.onHit(power);
    }

}