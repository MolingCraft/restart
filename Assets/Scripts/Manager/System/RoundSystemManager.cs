using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystemManager : Singleton<RoundSystemManager>
{
    public ActionOptionsUI actionOptionsUI;//行动选项UI，在行动者回合出现的可供操作的UI界面

    [SerializeField]
    public RoundSequence roundSequence;//回合顺序脚本
    private GameObject ActiveObject;//行动者
    protected override void Awake() 
    {
        base.Awake();
        roundSequence=new SurvivorSequence();
    }

    void Game_Start()//开始游戏
    {
        roundSequence.SequenceSet();
    }
    void Game_End()
    {

    }
    void Round_Start()//开始回合
    {
        actionOptionsUI.setActionObject(ActiveObject);
        actionOptionsUI.Action_InitialSet();

    }

    void Round_End()
    {
        roundSequence.SequenceChange();
    }
}
