using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using de;
public class Item : MonoBehaviour
{

    public string itemName;
    public Sprite itemImage;
    public string itemExplanation;
    public de.Define.itemType itemtype;

    public float currentTime;
    public float coolTime;

    public float radius;
    public float applyRadius;
    public float power;
    public float applyPower;
    public int level;

    protected virtual void Awake()
    {
        level = 1;
        applyRadius = radius;
        applyPower = power;
    }
    public virtual void Update()
    {
        UseItem();
    }
    public virtual void UseItem()
    {

    }


    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, applyRadius);
    }

    public virtual void LevelUp()
    {
        level++;
    }
}
