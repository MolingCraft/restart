using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorAttackManager : Singleton<SurvivorAttackManager>
{
    public GameObject ObjectActionOption;//行动选项
    public GameObject CancelActionButton;//取消行动按钮
    public GameObject theCamera;//主摄像机

    public bool InRoundIf;//true为玩家回合，
    private int actionCharaNum;//行动玩家编号
    private GameObject actionObject;//玩家方正在行动的Object
    private bool actionInif;//是否在玩家回合


    protected override void Awake() 
    {
        base.Awake();
        InRoundIf=true;
        actionCharaNum=0;
    }
    void Start()
    {


        StartAttack();
    }


    void Update()
    {
        if(actionInif)
        {
            actionObject.GetComponent<CharaObject>().EventActionIn();
        }
        else
        {
            ObjectActionOption.SetActive(false);
            //Debug.Log("回合结束");
            RoundEnd();
        }

    }

    void StartAttack()
    {

    }
    void RoundStart()
    {

    }
    void RoundEnd()
    {
        
    }
    
    public void PlayerRound()
    {
        Debug.Log("开始玩家回合");
        if(actionCharaNum>=CharaManager.Instance.charaObjectList.Count)actionCharaNum=0;
        actionObject=CharaManager.Instance.charaObjectList[actionCharaNum];//获取当前行动棋子
        actionObject.GetComponent<CharaObject>().EventActionStart();
        actionInif=actionObject.GetComponent<CharaObject>().ActionInIf;


        Vector3 vec=actionObject.transform.position;
        
        //行动菜单对准行动者
        ObjectActionOption.SetActive(true);
        ObjectActionOption.transform.position=vec;
        //相机中心对准行动者
        theCamera.GetComponent<CameraControl>().restoreCamera();
        vec.z-=10;
        theCamera.transform.position=vec;

        //回合开始行动
        RoundStart();

        actionCharaNum++;
    }

    public void EnemyRound()
    {
        Debug.Log("开始敌方回合");
        int enemynum=actionCharaNum;
        if(enemynum>=CharaManager.Instance.enemyObjectList.Count)enemynum=0;
        actionObject=CharaManager.Instance.enemyObjectList[enemynum];//获取当前行动棋子
        actionObject.GetComponent<CharaObject>().EventActionStart();
        actionInif=actionObject.GetComponent<CharaObject>().ActionInIf;


        Vector3 vec=actionObject.transform.position;
        
        //行动菜单对准行动者
        ObjectActionOption.SetActive(true);
        ObjectActionOption.transform.position=vec;
        //相机中心对准行动者
        theCamera.GetComponent<CameraControl>().restoreCamera();
        vec.z-=10;
        theCamera.transform.position=vec;

        //回合开始行动
        RoundStart();
    }

    public void changeActionOption()
    {
        ObjectActionOption.SetActive(!ObjectActionOption.activeSelf);
        CancelActionButton.SetActive(!CancelActionButton.activeSelf);
    }


}




/*
public class Foo : MonoBehaviour
{
    //扇形角度
    [SerializeField] private float angle = 80f;
    //扇形半径
    [SerializeField] private float radius = 3.5f;
    //物体B
    [SerializeField] private Transform b;
 
    private bool flag;
 
    private void Update()
    {
        flag = IsInRange(angle, radius, transform, b);
    }


 /*
    /// <summary>
    /// 判断target是否在扇形区域内
    /// </summary>
    /// <param name="sectorAngle">扇形角度</param>
    /// <param name="sectorRadius">扇形半径</param>
    /// <param name="attacker">攻击者的transform信息</param>
    /// <param name="target">目标</param>
    /// <returns>目标target在扇形区域内返回true 否则返回false</returns>
    public bool IsInRange(float sectorAngle, float sectorRadius, Transform attacker, Transform target)
    {
        //攻击者位置指向目标位置的向量
        Vector3 direction = target.position - attacker.position;
        //点乘积结果
        float dot = Vector3.Dot(direction.normalized, transform.forward);
        //反余弦计算角度
        float offsetAngle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        return offsetAngle < sectorAngle * .5f && direction.magnitude < sectorRadius;
    }
 
    private void OnDrawGizmos()
    {
        Handles.color = flag ? Color.cyan : Color.red;
 
        float x = radius * Mathf.Sin(angle / 2f * Mathf.Deg2Rad);
        float y = Mathf.Sqrt(Mathf.Pow(radius, 2f) - Mathf.Pow(x, 2f));
        Vector3 a = new Vector3(transform.position.x - x, 0f, transform.position.z + y);
        Vector3 b = new Vector3(transform.position.x + x, 0f, transform.position.z + y);
 
        Handles.DrawLine(transform.position, a);
        Handles.DrawLine(transform.position, b);
 
        float half = angle / 2;
        for (int i = 0; i < half; i++)
        {
            x = radius * Mathf.Sin((half - i) * Mathf.Deg2Rad);
            y = Mathf.Sqrt(Mathf.Pow(radius, 2f) - Mathf.Pow(x, 2f));
            a = new Vector3(transform.position.x - x, 0f, transform.position.z + y);
            x = radius * Mathf.Sin((half - i - 1) * Mathf.Deg2Rad);
            y = Mathf.Sqrt(Mathf.Pow(radius, 2f) - Mathf.Pow(x, 2f));
            b = new Vector3(transform.position.x - x, 0f, transform.position.z + y);
 
            Handles.DrawLine(a, b);
        }
        for (int i = 0; i < half; i++)
        {
            x = radius * Mathf.Sin((half - i) * Mathf.Deg2Rad);
            y = Mathf.Sqrt(Mathf.Pow(radius, 2f) - Mathf.Pow(x, 2f));
            a = new Vector3(transform.position.x + x, 0f, transform.position.z + y);
            x = radius * Mathf.Sin((half - i - 1) * Mathf.Deg2Rad);
            y = Mathf.Sqrt(Mathf.Pow(radius, 2f) - Mathf.Pow(x, 2f));
            b = new Vector3(transform.position.x + x, 0f, transform.position.z + y);
 
            Handles.DrawLine(a, b);
        }
    }
}

*/
 