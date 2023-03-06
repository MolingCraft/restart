using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharaObject : MonoBehaviour
{
    public string charaName;//角色名
    public RaceData charaData;//角色种族
    public Sprite charaSprite;//种族图片
    public EquipmentData equipmentData;//角色装备
    public Sprite equipSprite;//装备图片
    public Vector2 objectVector2;//位置
    public int killNum;//杀敌数
    public float walkNum;//行走路程
    public int survivalRound;//存活回合

    public bool ActionInIf=false;//是否在行动中
    private int actionNum;

    private int sortingorder111;
    public void EventAddInBattlefield()//加入战场事件
    {
        charaData.curHP=charaData.maxHP;

    }

    public void EventActionStart()//行动事件前
    {
        sortingorder111=this.GetComponent<SpriteRenderer>().sortingOrder;
        this.GetComponent<SpriteRenderer>().sortingOrder=100;
        ActionInIf=true;
        actionNum=charaData.actionNum;
    }

    public void EventActionIn()//行动事件
    {
        if(actionNum<=0)
        {
            EventActionEnd();
            return;
        }

    }
    public void EventActionEnd()//行动事件后
    {
        ActionInIf=false;
        this.GetComponent<SpriteRenderer>().sortingOrder=sortingorder111;
    }

    public void EventAttackStart()//攻击事件前
    {

    }
    public void EventAttackIn()//攻击事件
    {

    }
    public void EventAttackEnd()//攻击事件后
    {

    }

    public void EventPlayerMove()
    {
        SurvivorAttackManager.Instance.changeActionOption();
    }
    public void EventEnemyMove()
    {

    }
    
    public void EventInjury(float damage)//受伤事件
    {

        /*调用受击动画*/
        charaData.curHP-=damage;
        if(charaData.curHP<=0f)
        {
            EventDeath();
        }
    }
    public void EventDeath()//死亡事件
    {
        /*调用死亡动画*/
        this.gameObject.SetActive(false);
        //CharaManager.Instance.charaObjectList.Remove(this.transform.gameObject);

    }

    public void EventInstantBuff()//即时性buff
    {

    }
    public void EventAddSustainedBuff()//添加持续性buff
    {

    }



}






 