using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyeongru : Item
{
    public Hyeongru_Object hO;


    private void Start()
    {
        hO.power = power;
        hO.radius = radius;
    }
    public override void Update()
    {
        base.Update();
        
    }

    public override void UseItem()
    {
        base.UseItem();
        
        if (Time.time < currentTime) return;

        hO.gameObject.SetActive(true);
        currentTime = Time.time + 100;




    }

    protected override void OnDrawGizmosSelected()
    {
    }
}
