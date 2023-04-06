using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData
{
    public Quaternion InitialRotation;//初始的旋转值
    public float AttackSwayAngle = 90f; // 摇晃角度
    public float AttackSwayTime = 0.2f; // 单次摇晃时间

    protected virtual void Start()
    {

    }
    public virtual void Action_Attack(WeaponObject weaponObject,CharaObject charaObject){}

}
