using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSequence
{
    //public List<GameObject> PlayerList;//玩家列表
    //public virtual void SequenceSet(){}//设置顺序

    /// <summary>
    /// 返回一个行动者
    /// </summary>
    /// <param name="GameObject("></param>
    /// <returns></returns>
    public virtual GameObject SequenceChange(){return new GameObject();}//顺序改变,引用赋值，方法内必须为obj赋值

/// <summary>
/// 获得当前行动的Object
/// </summary>
/// <param name="GameObject("></param>
/// <returns></returns>
    public virtual GameObject getActionObject(){return new GameObject();}
    //public virtual void SequenceNext(){}//按顺序下一个
    //public virtual void SequencePrevious(){}//按顺序上一个


}
