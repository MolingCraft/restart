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

}
public enum tagname
{
    Player,
    Enemy,
}
public class CharaObject : MonoBehaviour
{
    public CharaData charaData;//角色数据
    public float curHP;//当前HP
    public States charaStates;//角色当前状态
    public Vector2 charaVector;//坐标

    public bool TraceIf;
    public delegate void VoidDelegate();

    public static event VoidDelegate Event_Move;

    public CharaObject(tagname tagn,CharaData data)
    {
        this.transform.tag=tagn.ToString();
        this.charaData=data;
        curHP=charaData.HP;
    }

    private void FixedUpdate()
    {
        if(TraceIf)Trace();
    }

    void Trace()
    {
        if(this.transform.tag=="Player")
        {

        }
        else// if(this.transform.tag=="Enemy")
        {

        }
        var FindObject=TraceTheNearestObject(this);

        Event_Move();
        Action_Moveto(FindObject.transform.position);

    }


    void Action_Moveto(Vector2 vec2)
    {
        float distance = (vec2 - (Vector2)this.transform.position).sqrMagnitude;
        float XDistance = vec2.x - this.transform.position.x;
        float YDistance = vec2.y - this.transform.position.y;
/*
        if (distance < Radius && distance > interval)
            {
                EnemyRigid.velocity = new Vector2(XDistance * EnemySpeed, YDistance * EnemySpeed);
                //Prefs.storynumber = 1000;
                
            }
            else if(BackStartIf&&distance>Radius)
            {
                transform.position =new Vector2(XStartDistance,YStartDistance);
                
            }*/
    }

    GameObject TraceTheNearestObject(CharaObject charaObj)
    {
        List<GameObject> objectList;
        string TraceTag;

        if(charaObj.tag==tagname.Player.ToString())
        {
            objectList=CharaManager.Instance.enemyObjectList;
            TraceTag=tagname.Enemy.ToString();
        }
        else //if(obj.tag==tagname.Enemy.ToString())
        {
            objectList=CharaManager.Instance.charaObjectList;
            TraceTag=tagname.Player.ToString();
        }


        //遍历寻找距离最近的object
        var FindObject=objectList[0];
        for(int i=1;i<objectList.Count;i++)
        {
            var obj=objectList[i];

            float dis1=Vector2.Distance(charaObj.transform.position,       obj.transform.position);
            float dis2=Vector2.Distance(charaObj.transform.position,FindObject.transform.position);

            if(dis1<dis2)
            {
                FindObject=obj;
            }

        }

        return FindObject;
    }
}

