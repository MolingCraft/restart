using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOptionsUI : MonoBehaviour
{
    private GameObject _ActionObject;//当前行动的Object
    private GameObject _actionUI;

    public void setActionObject(GameObject obj)
    {
        _ActionObject=obj;
    }

    public virtual void Action_InitialSet()
    {
        _actionUI.SetActive(true);
        
    }
    protected virtual void Action_Start()//行动开始
    {

    }
    protected virtual void Action_In()//行动中
    {

    }
    protected virtual void Action_End()//行动结束
    {

    }
}
