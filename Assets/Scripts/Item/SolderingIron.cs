using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolderingIron : Item
{
    [SerializeField] SolderingIronObject useObject;
    public LayerMask monster;
    private void Start()
    {
        useObject.radius = radius;
        useObject.power = power;
    }
    public override void Update()
    {
        base.Update();
    }

    public override void UseItem()
    {
        base.UseItem();

        if (Time.time < currentTime) return;

        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, radius,monster);

        if (col.Length <= 0) return;

        useObject.gameObject.SetActive(true);

        
    }

    protected override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
    }
}
