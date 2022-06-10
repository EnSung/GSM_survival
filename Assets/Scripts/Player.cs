using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Unit
{
    public int level;

    public float currentMaxEXP = 20;
    public float currentEXP;
    public UnityEvent onLevelup;

    public float EXPRatio => currentEXP / currentMaxEXP;

    List<Item> items = new List<Item>();
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
        transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.deltaTime);
    }

    public override void onHit(float power)
    {
        base.onHit(power);
    }

    public void UpEXP(float exp)
    {
        currentEXP += exp;

        if(currentEXP >= currentMaxEXP)
        {
            onLevelup.Invoke();
        }
    }

    public void LevelUP()
    {
        ++level;
        currentEXP = 0;
        currentMaxEXP *= 1.5f;
    }

}