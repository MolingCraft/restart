using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Sword_1 : WeaponData
{

    private void Reset()
    {

    }

    protected override void Start()
    {
        base.Start();
    }

    public override void Action_Attack(WeaponObject weaponObject,CharaObject charaObject)
    {
        if(charaObject.tag!=weaponObject.owncharaObject.tag)
        charaObject.Action_Hit(weaponObject.owncharaObject.charaData.damage);
    }
}
