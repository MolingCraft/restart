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
    Action_Start
    ,//行动开始
    Action_End
    ,//行动结束
    Action_Attack
    ,//行动攻击
    Action_Move
    ,//行动移动



}

public class CharaObject : MonoBehaviour
{
    public bool Action_EndIf;
    public CharaData charaData;//角色数据

    public States charaStates;//角色当前状态

    public List<Buff> BuffList=new List<Buff>();//Buff列表
    public Vector2 objectVector2;//位置

    public delegate void VoidDelegate();

    public static event VoidDelegate Event_Action_Start;

    public static event VoidDelegate Event_Action_End;

    public static event VoidDelegate Event_Attack_Start;

    public static event VoidDelegate Event_Attack_End;

    public static event VoidDelegate Event_Move_Start;

    public static event VoidDelegate Event_Move_End;

    private int sortingorder111;//最开始的图层排序数字

    public CharaObject()
    {
        Event_Action_Start+=Buff_Effect;
        Event_Action_End  +=Buff_Effect;
    }
    public void AddInBattlefield()//加入战场事件
    {
        charaData.curHP=charaData.maxHP;
        charaData.curActionNum=charaData.maxActionNum;

    }

    public void Action_Start()
    {
        Action_EndIf=false;
        charaData.curActionNum=charaData.maxActionNum;
        Debug.Log(this.transform.gameObject.name+" 行动开始,行动点数回复");
        charaStates=States.Action_Start;
        if(Event_Action_Start != null)Event_Action_Start();
    }
    public void Action_End()
    {
        Debug.Log(this.transform.gameObject.name+" 行动结束");
        charaStates=States.Action_End;
        if(Event_Action_End != null)Event_Action_End();

        ActionOptionsUI.Instance.Action_End();
    }



    public void Action_Attack_Scope()
    {

    }
    public void Action_Attack()
    {
        charaStates=States.Action_Attack;

        if(Event_Attack_Start != null)Event_Attack_Start();

        charaData.curActionNum--;
        Debug.Log(this.transform.gameObject.name+" 发起了一次攻击,剩余行动点数"+charaData.curActionNum);


        //攻击内容



        if(Event_Attack_End != null)Event_Attack_End();

        if(charaData.curActionNum<=0)Action_EndIf=true;
    }

    public void Action_Move()
    {
        charaStates=States.Action_Move;

        if(Event_Move_Start != null)Event_Move_Start();

        if(Event_Move_End != null)Event_Move_End();

        if(charaData.curActionNum<=0)Action_End();
    }

    public void Action_Injury(float damage)//受伤事件
    {


        charaData.curHP-=damage;
        if(charaData.curHP<=0f)
        {
            Action_Death();
        }
    }

    public void Action_Death()//死亡事件
    {

        this.gameObject.SetActive(false);
        //CharaManager.Instance.charaObjectList.Remove(this.transform.gameObject);

    }




    public void Buff_Effect()
    {
        foreach(Buff buff in BuffList)
        {
            if(buff.Effective==false)Buff_Remove(buff);
            else buff.Effect(this,charaStates);
        }
    }
    public void Buff_Add(Buff buff)
    {
        BuffList.Add(buff);
    }
    public void Buff_Remove(Buff buff)
    {
        BuffList.Remove(buff);
    }


}

