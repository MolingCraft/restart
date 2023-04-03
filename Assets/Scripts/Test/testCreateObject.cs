using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCreateObject : MonoBehaviour
{
    public GameObject CreateObjprefab;


    private List<GameObject> charaObjectList;
    private List<GameObject> enemyObjectList;
    void Start()
    {
        charaObjectList=CharaManager.Instance.charaObjectList;
        enemyObjectList=CharaManager.Instance.enemyObjectList;



    }


    public void wadfianfuihawf()
    {
        CharaManager.Instance.CreateObject(CreateObjprefab,tagname.Player,new Vector3(-1,2,0));
        CharaManager.Instance.CreateObject(CreateObjprefab,tagname.Player,new Vector3(-1,0,0));
        CharaManager.Instance.CreateObject(CreateObjprefab,tagname.Player,new Vector3(-1,-2,0));

        CharaManager.Instance.CreateObject(CreateObjprefab,tagname.Enemy,new Vector3(1,2,0));
        CharaManager.Instance.CreateObject(CreateObjprefab,tagname.Enemy,new Vector3(1,0,0));
        CharaManager.Instance.CreateObject(CreateObjprefab,tagname.Enemy,new Vector3(1,-2,0));
    }
}
