using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : Singleton<AttackManager>
{

    public bool AttackStartIf;
    //public float battleDuration;//回合持续时间
    //public float RestTime;//休息持续时间


    public List<GameObject> charaObjectList;
    [Space(10)]
    //public GameObject enemyObjectfather;
    public List<GameObject> enemyObjectList;

/*
    public delegate void VoidDelegate();


    public static event VoidDelegate Event_AttackGame_End;//战斗流程结束，回主界面
    public static event VoidDelegate Event_Battle_Start;
    public static event VoidDelegate Event_Battle_End;*/
    private void Reset() {
        AttackStartIf=false;
        //battleDuration=30f;
    }
    void Start()
    {
        charaObjectList=CharaManager.Instance.charaObjectList;
        enemyObjectList=CharaManager.Instance.enemyObjectList;
    }


    private void OnEnable()
    {
        //Event_Battle_Start+=;
    }
    private void OnDisable()
    {

    }
    private void FixedUpdate()
    {
        if(AttackStartIf && charaObjectList.Count==0)
        {
            EndAttackGame();
        }
        if(AttackStartIf && enemyObjectList.Count==0)
        {
            EndBattle();
        }
    }


    public void StartAttackGame()
    {
        foreach(GameObject obj in charaObjectList)
        {
            obj.GetComponent<CharaObject>().ResetWhenAttackStart();
            //obj.GetComponentInChildren<WeaponObject>().End_sway();
        }
    }

    public void StartBattle()
    {
        //StartCoroutine(BattleCoroutine());
        AttackStartIf=true;
        //if(Event_Battle_Start!=null)Event_Battle_Start();
        CharaTraceChange(true);
    }

    public void EndBattle()
    {
        //if(Event_Battle_End!=null)Event_Battle_End();

        CharaTraceChange(false);
        AttackStartIf=false;
        TransitionManager.Instance.TransitionTo("RestScene");
        foreach(GameObject obj in charaObjectList)
        {
            obj.transform.position=new Vector3(0,0,-50);
        }
    }
    public void EndAttackGame()
    {
        //if(Event_AttackGame_End!=null)Event_AttackGame_End();
        MenuManager.Instance.DeathMenuPanel.SetActive(true);
    }






/*
    private IEnumerator BattleCoroutine()// 战斗回合持续时间
    {
        yield return new WaitForSeconds(battleDuration);
        EndBattle();
    }
*/


    void CharaTraceChange(bool traceif)
    {
        foreach(GameObject obj in charaObjectList)
        {
            obj.GetComponent<CharaObject>().TraceIf=traceif;
            if(!traceif)obj.GetComponentInChildren<WeaponObject>().End_sway();
        }
        foreach(GameObject obj in enemyObjectList)
        {
            obj.GetComponent<CharaObject>().TraceIf=traceif;
        }
    }
}
