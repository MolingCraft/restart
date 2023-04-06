using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharaCreateManager : Singleton<CharaCreateManager>
{
    public Sprite SelectedSprite;
    public CharaData SelectedCharaData;

    [Header("角色列表")]//初始模板
    public List<Sprite> SpriteList=new List<Sprite>();
    public List<CharaData> CharaDataList=new List<CharaData>();

    [Header("按钮设置")]
    public GameObject ShowContent;//生成按钮的父物体
    public GameObject ButtonPrefab;//按钮预制体
    public Image ShowImage;//另一个显示图


/*
    [Space(5)]//添加间距

    [Header("种族与武器文件")]

    public List<CharaData> RaceList=new List<CharaData>();
/*
    public TextAsset RacecsvFile;//种族csv文件
    public Dictionary<String, CharaData> RaceDict = new Dictionary<String, CharaData>();
*/

    protected override void Awake()
    {
        base.Awake();
/*
        if (RacecsvFile == null) return;
        RaceDict.Clear();

        string[] line = RacecsvFile.text.Split(separator: '\n');//以换行符进行拆分，将文本的内容拆成一行一行的存储

        string[] attributename = line[1].Split(separator: ',');//以逗号(csv格式以逗号进行数据分隔)进行拆分
        var attributearrayLength = attributename.Length;
        for (int i = 2; i < line.Length; i++)
        {
            string[] value = line[i].Split(separator: ',');//以逗号(csv格式以逗号进行数据分隔)进行拆分
            CharaData chara=new CharaData();
            //接下来开始具体数据读取

            RaceDict.Add(chara.charaName, chara);
        }
*/

    }

    private void Start()
    {
        ShowtheButton();
    }
    private void ShowtheButton()
    {
        for(int i=0;i<SpriteList.Count;i++)
        {
            var obj=Instantiate(ButtonPrefab,new Vector3(0,0,0),Quaternion.identity,ShowContent.transform);
            obj.GetComponent<ShowtheSpriteInImage>().ShowImage2=ShowImage;
            obj.GetComponent<ShowtheSpriteInImage>().SetSprite(i);
        }
    }
    public Sprite GetTheSprite(int num)
    {
        if(num<SpriteList.Count)
            return SpriteList[num];
        else if(num<0)
        {
            return SpriteList[0];
        }
        else
        {
            return SpriteList[SpriteList.Count];
        }
    }
    public int GetSpriteListCount()
    {
        return SpriteList.Count;
    }

}
