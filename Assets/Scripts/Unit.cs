using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{

    public float hp;
    public float maxHp;
    public float speed;
    public float power;

    public UnityEvent onDie;
    public virtual void move()
    {

    }


    public virtual void onHit(float power)
    {
        hp-=power;

        if(hp <= 0)
        {
            onDie.Invoke();
        }
    }

}
