using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorSequence : RoundSequence
{
    private bool PlayerRoundIf;//是否是玩家回合
    private List<GameObject> charaObjectList;
    private int charaActionNum;
    private List<GameObject> enemyObjectList;
    private int enemyActionNum;
    private GameObject actionObject;//正在行动的object
    public SurvivorSequence()
    {
        charaObjectList=CharaManager.Instance.charaObjectList;
        enemyObjectList=CharaManager.Instance.enemyObjectList;
        charaActionNum=0;
        enemyActionNum=0;
        PlayerRoundIf=true;

    }

    public override GameObject getActionObject()
    {
        return actionObject;
    }

    public override GameObject SequenceChange()//顺序改变
    {
        if(PlayerRoundIf)
        {
            actionObject=charaObjectList[charaActionNum];

            charaActionNum++;
            if(charaActionNum>=charaObjectList.Count)charaActionNum=0;
        }
        else
        {
            actionObject=enemyObjectList[enemyActionNum];

            enemyActionNum++;
            if(enemyActionNum>=enemyObjectList.Count)enemyActionNum=0;
        }
        PlayerRoundIf=!PlayerRoundIf;
        return actionObject;
    }

}
