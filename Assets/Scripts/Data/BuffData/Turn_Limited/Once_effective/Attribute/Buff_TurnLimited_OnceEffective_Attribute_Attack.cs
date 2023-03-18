using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_TurnLimited_OnceEffective_Attribute_Attack : Buff_TurnLimited
{
    public float ChangeValue;
    /// <summary>
    ///
    /// </summary>
    /// <param name="states"></param>触发状态
    /// <param name="time"></param>持续回合
    /// <param name="num"></param>回复量
    public Buff_TurnLimited_OnceEffective_Attribute_Attack(States states,int time,int num)
    {
        NeedStates=states;
        Effective=true;
        sustainedNum=time;
        ChangeValue=num;
    }
     public override void Effect(CharaObject charaObject,States charaStates)
    {
        if(!Effective)return;
        if(charaStates!=NeedStates)return;//判断是否是可生效的状态                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          ;
        sustainedNum_Reduce();
        if(sustainedNum<=0)Effective=false;
    }

}
