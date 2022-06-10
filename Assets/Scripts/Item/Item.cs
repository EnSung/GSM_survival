using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public float currentTime;
    public float coolTime;

    public float radius;
    public float power;

    public virtual void Update()
    {
        UseItem();
    }
    public virtual void UseItem() { 

    }
}
