using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolderingIron : Item
{
    [SerializeField] SolderingIronObject useObject;
    public LayerMask monster;
    public float keepingTime;
    private void Start()
    {
        useObject.radius = applyRadius;
        useObject.power = applyPower;
    }
    public override void Update()
    {
        base.Update();
    }

    public override void UseItem()
    {
        base.UseItem();

        if (Time.time < currentTime) return;

        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, applyRadius,monster);

        if (col.Length <= 0) return;


            useObject.gameObject.SetActive(true);
            


    }

    public override void LevelUp()
    {
        base.LevelUp();
        coolTime *= 0.7f;

        applyPower *= 1.8f;
    }

    protected override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
    }
}
