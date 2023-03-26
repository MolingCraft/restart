using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 时限类-属性类-生命值修改
/// </summary>
public class Buff_TurnLimited_Atttibute_HP_Alone : Buff_TurnLimited
{
    public float ChangeValue;
    /// <summary>
    ///
    /// </summary>
    /// <param name="states"></param>触发状态
    /// <param name="time"></param>持续回合
    /// <param name="num"></param>回复量
    public Buff_TurnLimited_Atttibute_HP_Alone(States states,int time,int num)
    {
        NeedStates=states;
        Effective=true;
        sustainedNum=time;
        ChangeValue=num;
    }
     public override void Effect(CharaObject charaObject,States charaStates)
    {
        if(!Effective)return;
        if(charaStates!=NeedStates)return;//判断是否是可生效的状态
        charaObject.curHP-=ChangeValue;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               ;
        sustainedNum_Reduce();
        if(sustainedNum<=0)Effective=false;
    }
}
