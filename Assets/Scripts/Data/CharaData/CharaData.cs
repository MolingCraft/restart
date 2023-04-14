using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum Role//职业
{
    Warrior,//战士
    Mage,//法师
}

[System.Serializable]
public class CharaData
{
    //所有的Lock都代表该值是否锁定不变
    public string charaName;//角色名
    //public Role role;//职业
    //public string introduction;//介绍
    public float HP;//HP
    public float speed;//速度
    public float defend;//防御
    public float size;//体型大小
    public float attackdamage;//攻击力
    public float attackRange;//攻击距离
    public float attackCD;//攻击CD

}
