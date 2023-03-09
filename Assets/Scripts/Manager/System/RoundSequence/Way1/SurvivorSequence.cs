using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorSequence : RoundSequence
{
    private List<GameObject> charaObjectList;
    private int charaActionNum;
    private List<GameObject> enemyObjectList;
    private int enemyActionNum;

    public SurvivorSequence()
    {
        charaObjectList=CharaManager.Instance.charaObjectList;
        enemyObjectList=CharaManager.Instance.enemyObjectList;
        charaActionNum=0;
        enemyActionNum=0;

    }

    public override void SequenceChange()//顺序改变
    {


        
    }

}
