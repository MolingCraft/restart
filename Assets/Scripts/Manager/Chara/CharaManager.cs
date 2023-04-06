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


/// <summary>
/// 随机生成charadata类型的object
/// </summary>
/// <param name="tagname"></param>
/// <param name="vec3"></param>
/// <returns></returns>
    public GameObject CreateObject(tagname tagname,Vector3 vec3)
    {
        var obj=CharaObjectPool.GetPooledObject();

        Vector3 createPosition=vec3;
        List<GameObject> createObjList;

        Vector3 objScale=new Vector3(1,1,1);

        if(tagname==tagname.Player)
        {
            createObjList=charaObjectList;
        }
        else if(tagname==tagname.Enemy)
        {
            createObjList=enemyObjectList;
            objScale=new Vector3(-objScale.x,objScale.y,objScale.z);
        }
        else
        {
            createPosition=new Vector3(0,0,0);
            createObjList=charaObjectList;
        }

/*
        GameObject obj = (GameObject)GameObject.Instantiate(
                prefab,vec3, Quaternion.identity, createObjFather.transform);*/


        obj.GetComponent<CharaObject>().charaData=CharaCreateManager.Instance.CharaDataList[UnityEngine.Random.Range(0,CharaCreateManager.Instance.CharaDataList.Count)];
        obj.tag=tagname.ToString();
        createObjList.Add(obj);
        obj.SetActive(true);
        obj.transform.position=createPosition;

        objScale=objScale*obj.GetComponent<CharaObject>().charaData.size;
        obj.transform.localScale=objScale;

        return obj;
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
