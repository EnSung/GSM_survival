using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : Unit
{
    public int level;

    public float currentMaxEXP = 20;
    public float currentEXP;
    public UnityEvent onLevelup;

    public Image HpUI;
    public float EXPRatio => currentEXP / currentMaxEXP;

    public Dictionary<System.Type, Item> activeItems = new Dictionary<System.Type, Item>();
    public Dictionary<System.Type, Item> passiveItems = new Dictionary<System.Type, Item>();
    Rigidbody2D rigid;

    public Vector2 dir;

    public SpriteRenderer sr;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(flipXCroutine());
    }

    private void Update()
    {
        move();
        rigid.velocity = Vector2.zero;
    }


    IEnumerator flipXCroutine()
    {
        while (true)
        {
            yield return null;
            sr.flipX = !sr.flipX;

            yield return new WaitForSeconds(.7f);
        }


    }

    public override void move()
    {
        dir = (new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) == Vector2.zero) ? dir : new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.deltaTime);
    }

    public override void onHit(float power)
    {
        base.onHit(power);
        hpUpdate();
    }

    void hpUpdate()
    {
        HpUI.fillAmount = hp / maxHp;
        HpUI.gameObject.transform.parent.gameObject.SetActive(!(hp >= maxHp));
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