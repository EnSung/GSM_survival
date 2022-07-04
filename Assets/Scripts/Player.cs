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

    public GameObject mintonPrefab;

    public float expAbsorptionRadius;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(flipXCroutine());


        var obj = Instantiate(mintonPrefab);
        obj.transform.parent = IngameManager.Instance.player.gameObject.transform;
        obj.transform.localPosition = Vector2.zero;
        obj.transform.localScale = new Vector3(1, 1, 1);
        Item item = obj.GetComponent<Item>();


        Item_Image_Object obj2 = Instantiate(IngameUIManager.Instance.itemUIPrefab).GetComponent<Item_Image_Object>();
        obj2.idx = 4;
        obj2.itemType = IngameManager.Instance.itemList[4].GetType();
        obj2.transform.parent = IngameUIManager.Instance.itemUIParent;

        IngameManager.Instance.player.activeItems.Add(item.GetType(), item);
        IngameUIManager.Instance.itemImageObject.Add(obj2.itemType, obj2);

        

    }

    private void Update()
    {
        move();
        rigid.velocity = Vector2.zero;

        Collider2D[] exps = Physics2D.OverlapCircleAll(transform.position, expAbsorptionRadius, LayerMask.GetMask("EXP"));

        if (exps.Length > 0)
        {

            foreach (Collider2D exp in exps)
            {
                exp.GetComponent<EXPObject>().isNearlyPlayer = true;
            }
        }
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
        HpUI.fillAmount = hp / MaxHp;
        HpUI.gameObject.transform.parent.gameObject.SetActive(!(hp >= MaxHp));
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

    public void HPUP(float amount)
    {
        hp += amount;
        if (hp > MaxHp)
            hp = MaxHp;

        hpUpdate();
    }

}