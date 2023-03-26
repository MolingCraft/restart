using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystemManager : Singleton<RoundSystemManager>
{
    public ActionOptionsUI actionOptionsUI;//行动选项UI，在行动者回合出现的可供操作的UI界面

    public RoundSequence roundSequence;//回合顺序脚本

    public delegate void VoidDelegate();

    //事件，游戏开始时
    public static event VoidDelegate Event_Game_Start;

    public static event VoidDelegate Event_Game_End;

    //事件，行动开始时
    public static event VoidDelegate Event_Round_Start;
    public static event VoidDelegate Event_Round_End;



    protected override void Awake()
    {
        base.Awake();
    }

    private void Start() {
        roundSequence=new SurvivorSequence();

        Game_Start();





    }


    void Game_Start()//开始游戏
    {
        Debug.Log(" 游戏开始 ");
        if(Event_Game_Start != null)Event_Game_Start();
        Round_Start();
    }

    void Round_Start()//开始回合
    {
        Debug.Log(" 回合开始 ");
        if(Event_Round_Start != null)Event_Round_Start();

        actionOptionsUI.setActionObject(roundSequence.SequenceChange());
        actionOptionsUI.Action_InitialSet();

    }

    public void Round_End()
    {
        Debug.Log(" 回合结束 ");
        if(Event_Round_End != null)Event_Round_End();
        Round_Start();
    }

    public void Game_End()
    {
        Debug.Log(" 游戏结束 ");
        if(Event_Game_End != null)Event_Game_End();
    }
}


