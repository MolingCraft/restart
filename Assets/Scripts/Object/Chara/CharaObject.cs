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


    public bool TraceIf;
    /// <summary>
/// 追踪时停止的间距
/// </summary>
    public float traceDistance;

    public delegate void VoidDelegate();

    public static event VoidDelegate Event_Move;

    private Rigidbody2D thisRigid;

    private bool CouldAttackIf;

    [SerializeField]
    private GameObject _FindObject;
    public CharaObject(tagname tagn,CharaData data)
    {
        this.transform.tag=tagn.ToString();
        this.charaData=data;
        curHP=charaData.HP;
        CouldAttackIf=false;
    }
    private void Start() {
        thisRigid=this.transform.GetComponent<Rigidbody2D>();
        traceDistance=1.2f;
        StartCoroutine(AttackCD());
    }
    private void FixedUpdate()
    {
        if(TraceIf)Trace();
    }

    void Trace()//追踪
    {
        if(this.transform.tag=="Player")
        {

        }
        else// if(this.transform.tag=="Enemy")
        {

        }
        _FindObject=TraceTheNearestObject(this);
        if(_FindObject==null)return;
        //避免过近
        float dis2=Vector2.Distance(this.transform.position,_FindObject.transform.position);
        if(dis2<traceDistance)
        {
            //此间进行攻击
            CouldAttackIf=true;

            return;
        }
        CouldAttackIf=false;

        if(Event_Move!=null)Event_Move();
        Action_Moveto(_FindObject.transform.position);

    }

    IEnumerator AttackCD()
    {
        while(true)
        {
            if(_FindObject!=null && CouldAttackIf==true)
            {
                Action_Attack(_FindObject);
            }
            yield return new WaitForSeconds(charaData.attackCD);
        }
    }

    void Action_Attack(GameObject attackObject)
    {
        attackObject.GetComponent<CharaObject>().Action_Hit(charaData.damage);
    }


    void Action_Moveto(Vector2 vec2)
    {
        float distance = (vec2 - (Vector2)this.transform.position).sqrMagnitude;
        float XDistance = vec2.x - this.transform.position.x;
        float YDistance = vec2.y - this.transform.position.y;

        thisRigid.velocity =charaData.speed*new Vector2(XDistance, YDistance).normalized;
    }
/// <summary>
/// 寻找到距离最近的Object并返回
/// </summary>
/// <param name="charaObj">起始Object</param>
/// <returns></returns>
    GameObject TraceTheNearestObject(CharaObject charaObj)
    {
        List<GameObject> objectList;
        string TraceTag;

        if(charaObj.tag==tagname.Player.ToString())
        {
            objectList=CharaManager.Instance.enemyObjectList;
            TraceTag=tagname.Enemy.ToString();
        }
        else if(charaObj.tag==tagname.Enemy.ToString())
        {
            objectList=CharaManager.Instance.charaObjectList;
            TraceTag=tagname.Player.ToString();
        }
        else
        {
            return null;
        }


        //遍历寻找距离最近的object
        if(objectList.Count<=0)return null;
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



    public void Action_Hit(float attack)//受伤
    {
        curHP-=attack;
        if(curHP<=0)Invoke("action_Death",0.1f);
    }

    public void action_Death()//死亡
    {
        List<GameObject> ObjectList;

        this.transform.gameObject.SetActive(false);

        if(this.transform.tag==tagname.Player.ToString())
        {
            ObjectList=CharaManager.Instance.charaObjectList;
        }
        else if(this.transform.tag==tagname.Enemy.ToString())
        {
            ObjectList=CharaManager.Instance.enemyObjectList;
        }
        else
        {
            ObjectList=CharaManager.Instance.enemyObjectList;
        }

        ObjectList.Remove(this.transform.gameObject);
    }

}

