using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystemManager : Singleton<RoundSystemManager>
{


    public RoundSequence roundSequence;//回合顺序脚本

    public delegate void VoidDelegate();

    //事件，游戏开始时
    public static event VoidDelegate Event_Game_Start;

    public static event VoidDelegate Event_Game_End;



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
    }

}


