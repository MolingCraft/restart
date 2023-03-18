using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff
{
    /// <summary>
    /// 有效状态
    /// </summary>
    public bool Effective;
    public States NeedStates;
    /// <summary>
    /// Buff生效效果
    /// </summary>
    /// <param name="charaobject"></param>生效对象
    public virtual void Effect(CharaObject charaObject,States charaStates)
    {
        //所有继承了该class的子类都应该先判断自己是否仍然有效，修改Effective后return，或者执行
    }

}
