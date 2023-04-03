using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using System;


/*
[Tooltip("悬停内容")]//鼠标悬停在a时展示的东西
int a;
*/

public class CharaManager : Singleton<CharaManager>
{
    [Header("侧边角色UI")]//在Inspector中显示的文字
    public GameObject CharaUIPrefab;//角色UI预制体
    public GameObject CharaUIMenuPanel;
    //public GameObject CharaUIShowContent;//角色展示UI生成时的父物体


    [Space(20)]
    [Header("已生成对象")]

    public ObjectPool CharaObjectPool;
    //public GameObject charaObjectfather;
    public List<GameObject> charaObjectList=new List<GameObject>();
    [Space(10)]
    //public GameObject enemyObjectfather;
    public List<GameObject> enemyObjectList=new List<GameObject>();
    //public Queue<GameObject> ObjectQuene;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        GameManager.Event_LoadArchive+=LoadArchiveChara;
    }

    private void OnDisable()
    {
        GameManager.Event_LoadArchive-=LoadArchiveChara;
    }
      public void LoadArchiveChara(ArchiveData archiveData)//读取存档内角色
    {
        //RaceList=archiveData.
    }

    public void CreateObject(GameObject prefab,tagname tagname,Vector3 vec3)
    {
        Vector3 createPosition=new Vector3();

        List<GameObject> createObjList;
        if(tagname==tagname.Player)
        {
            createObjList=charaObjectList;
        }
        else if(tagname==tagname.Enemy)
        {
            createObjList=enemyObjectList;
        }
        else
        {
            createPosition=new Vector3(0,0,0);
            createObjList=charaObjectList;
        }

/*
        GameObject obj = (GameObject)GameObject.Instantiate(
                prefab,vec3, Quaternion.identity, createObjFather.transform);*/

        var obj=CharaObjectPool.GetPooledObject();
        obj.tag=tagname.ToString();
        createObjList.Add(obj);
        obj.SetActive(true);
    }
    public void DeleteObject()
    {

    }
    void Start()
    {

    }


    void Update()
    {

    }

    public void HideCharaMenu()
    {
        RectTransform pos = CharaUIMenuPanel.GetComponent<RectTransform>();
        pos.anchoredPosition = new Vector2(pos.anchoredPosition.x * (-1) - pos.rect.width, 0);
    }

}
