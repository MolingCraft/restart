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
    public GameObject CharaUIShowContent;//角色展示UI生成时的父物体

    [Space(5)]//添加间距

    [Header("种族与武器文件")]

    public List<CharaData> RaceList=new List<CharaData>();
    public List<CharaData> EquipmentList=new List<CharaData>();
    /*
    public TextAsset RacecsvFile;//种族csv文件
    public TextAsset WeaponcsvFile;//武器csv文件
    public Dictionary<int, RaceData> RaceDict = new Dictionary<int, RaceData>();
    public Dictionary<int, EquipmentData> weaponDict = new Dictionary<int, EquipmentData>();
*/
    [Space(20)]
    [Header("已生成对象")]
    public GameObject charaObjectfather;
    public List<GameObject> charaObjectList=new List<GameObject>();
    [Space(10)]
    public GameObject enemyObjectfather;
    public List<GameObject> enemyObjectList=new List<GameObject>();
    public Queue<GameObject> ObjectQuene;


    protected override void Awake()
    {
        base.Awake();

        /*
        if (RacecsvFile == null) return;
        RaceDict.Clear();



        if (WeaponcsvFile == null) return;
        weaponDict.Clear();*/
/*
        string[] line = RacecsvFile.text.Split(separator: '\n');//以换行符进行拆分，将文本的内容拆成一行一行的存储

        string[] attributename = line[1].Split(separator: ',');//以逗号(csv格式以逗号进行数据分隔)进行拆分
        attributearrayLength = attributename.Length;
        for (int i = 2; i < line.Length; i++)
        {
            string[] value = line[i].Split(separator: ',');//以逗号(csv格式以逗号进行数据分隔)进行拆分
            CharaRace charaRace = new CharaRace(value.Length);

            charaRace.attributeNameArray[0] = value[0];//种族名
            charaRace.attributeValueArray[0] = i - 1;//种族编号，虽然我也不知道有啥用

            for (int j = 1; j < value.Length; j++)//属性名
            {
                charaRace.attributeNameArray[j] = attributename[j];
            }

            for (int j = 1; j < value.Length; j++)
            {
                charaRace.attributeValueArray[j] = float.Parse(value[j]);
            }
            charaRaceDict.Add(i - 1, charaRace);
        }
*/

    }

      public void LoadArchiveChara()//读取存档内角色
    {

    }

    public void CreateCharaObject(GameObject prefab)
    {
        GameObject obj = (GameObject)GameObject.Instantiate(
                prefab, charaObjectfather.transform.position, Quaternion.identity, charaObjectfather.transform);
            charaObjectList.Add(obj);
    }
    public void DeleteCharaObject()
    {

    }
    public void CreateEnemyObject(GameObject prefab)
    {
        GameObject obj = (GameObject)GameObject.Instantiate(
                prefab, enemyObjectfather.transform.position, Quaternion.identity, enemyObjectfather.transform);
            enemyObjectList.Add(obj);
    }
    public void DeleteEnemyObject()
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
