using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Sword : WeaponObject
{
    public override void Action_Attack()
    {
        base.Action_Attack();
    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
}
