using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum States
{
    EventAddIn
    ,//事件加入战场
    None
    ,//无行动
    ActionStart
    ,//行动开始
    ActionIn
    ,//行动中
    ActionEnd
    ,//行动结束

}

public class CharaObject : MonoBehaviour
{
    public string charaName;//角色名
    public RaceData charaData;//角色种族
    [Header("Sprite设置")]
    public Sprite BodySprite;//种族图片
    public Sprite RightHandSprite;//右手图片
    public Sprite LeftHandSprite;//左手图片
    public Vector2 objectVector2;//位置

    public States states;

//一些在回合中需要重置的数据，读取出来进行更改
private int actionNum;//允许行动次数
private int sortingorder111;///最开始的图层排序数字

    public void EventAddInBattlefield()//加入战场事件
    {
        charaData.curHP=charaData.maxHP;
        states=States.None;

    }

    public void EventAction()//行动事件
    {
        switch(states)
        {
            case States.ActionStart:

                sortingorder111=this.GetComponent<SpriteRenderer>().sortingOrder;
                this.GetComponent<SpriteRenderer>().sortingOrder=100;
                actionNum=charaData.actionNum;
                break;

            case States.ActionIn:
                /*
                动画效果等在回合中持续性作用的函数
                */

                
                break;

            
            
            case States.ActionEnd:
                this.GetComponent<SpriteRenderer>().sortingOrder=sortingorder111;

                break;

            default:

                break;
        }

    }

    public void EventAttackStart()
    {

        //SurvivorAttackManager.Instance.ChangeAttackScope(this.transform);//展现攻击范围
        

    }
    public void EventAttackIn()
    {
        //攻击内容
        Debug.Log("发起了一次攻击,剩余攻击次数"+actionNum);
        EventAttackEnd();
    }
    public void EventAttackEnd()
    {



        actionNum--;
        if(actionNum==0)
        {
            states=States.ActionEnd;
            EventAction();
            return;
        }
        EventAttackStart();
    }
    public void EventMove()
    {

    }

    public void EventInjury(float damage)//受伤事件
    {

 
        charaData.curHP-=damage;
        if(charaData.curHP<=0f)
        {
            EventDeath();
        }
    }

    public void EventDeath()//死亡事件
    {

        this.gameObject.SetActive(false);
        //CharaManager.Instance.charaObjectList.Remove(this.transform.gameObject);

    }

    public void EventInstantBuff()//即时性buff
    {

    }
    public void EventAddSustainedBuff()//添加持续性buff
    {

    }
    
    /*
    public int killNum;//杀敌数
    public float walkNum;//行走路程
    public int survivalRound;//存活回合

    public bool ActionInIf=false;//是否在行动中
    

    
   

    public void EventPlayerMove()
    {
        SurvivorAttackManager.Instance.changeActionOption();
    }
    public void EventEnemyMove()
    {

    }
    

*/

}






 