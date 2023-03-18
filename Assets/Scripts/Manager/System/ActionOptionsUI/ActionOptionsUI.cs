using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOptionsUI : Singleton<ActionOptionsUI>
{
    public GameObject MainCamera;//相机
    private GameObject _ActionObject;//当前行动的Object

    private GameObject thisObj;

    int ScopeShow=0;//0为无，1为攻击范围，2为移动

    private void Update() {
        if(ScopeShow==0)
        {

        }
        else if (ScopeShow==1)
        {
            if(Input.GetMouseButtonUp(1))//未点击未展示攻击范围，点击后攻击
            {
                _ActionObject.GetComponent<CharaObject>().Action_Attack();
            }
            else
            {
                _ActionObject.GetComponent<CharaObject>().Action_Attack_Scope();
            }
        }
        else if (ScopeShow==2)
        {
            if(Input.GetMouseButtonUp(1))
            {
                _ActionObject.GetComponent<CharaObject>().Action_Move();
            }
        }
    }

    public void setActionObject(GameObject obj)
    {
        _ActionObject=obj;
    }


    public virtual void Action_InitialSet()
    {
        Debug.Log(" ui.行动菜单初始化设定 ");
        thisObj=this.transform.gameObject;
        thisObj.SetActive(true);

        ScopeShow=0;

        Vector3 vec=_ActionObject.transform.position;

        //行动菜单对准行动者
        thisObj.transform.position=vec;

        //相机中心对准行动者
        MainCamera.GetComponent<CameraControl>().restoreCamera();
        vec.z-=10;
        MainCamera.transform.position=vec;
        Action_Start();

    }
    public void Action_Start()//行动开始
    {
        ScopeShow=0;
        Debug.Log(" ui.行动开始 ");
        _ActionObject.GetComponent<CharaObject>().Action_Start();
    }


    public void Action_Attack()//行动攻击
    {
        ScopeShow=1;

        Debug.Log(" ui.开始攻击 ");

    }
    public void Action_Move()//行动移动
    {
        ScopeShow=2;

        Debug.Log(" ui.开始移动 ");
        _ActionObject.GetComponent<CharaObject>().Action_Move();
    }
    public void Action_End()//行动结束
    {
        Debug.Log(" ui.行动结束 ");
        thisObj.SetActive(false);
        //_ActionObject.GetComponent<CharaObject>().Action_End();
        RoundSystemManager.Instance.Round_End();
    }
}
