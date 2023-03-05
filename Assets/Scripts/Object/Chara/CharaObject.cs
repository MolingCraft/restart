using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharaObject : MonoBehaviour
{
    public string charaName;//角色名
    public CharaData charaData;//角色种族
    public Sprite charaSprite;//种族图片
    public EquipmentData equipmentData;//角色装备
    public Sprite equipSprite;//装备图片


    public int killNum;//杀敌数
    public float walkNum;//行走路程
    public int survivalRound;//存活回合

    public void EventAddInBattlefield()//加入战场事件
    {

    }

    public void EventAction()//行动事件
    {

    }
    public void EventAttack()//攻击事件
    {

    }
    public void EventInjury()//受伤事件
    {

    }
    public void EventDeath()//死亡事件
    {

    }

    public void EventInstantBuff()//即时性buff
    {

    }
    public void EventAddSustainedBuff()//添加持续性buff
    {

    }



}
