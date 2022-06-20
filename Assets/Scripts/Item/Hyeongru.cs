using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyeongru : Item
{
    public Hyeongru_Object hO;


    private void Start()
    {
        hO.power = applyPower;
        hO.radius = applyRadius;
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

    public override void LevelUp()
    {
        base.LevelUp();
        applyRadius = radius + level * 0.4f;
        hO.radius = applyRadius;
        hO.power = applyPower;

    }

    protected override void OnDrawGizmosSelected()
    {
    }
}
