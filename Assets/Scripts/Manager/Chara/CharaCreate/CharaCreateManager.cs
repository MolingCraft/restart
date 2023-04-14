using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class CharaCreateManager : Singleton<CharaCreateManager>
{
    public Sprite SelectedSprite;
    public int SelectedCharaData;

    [Header("角色列表")]//初始模板
    public List<Sprite> SpriteList=new List<Sprite>();
    //public List<CharaData> CharaDataList=new List<CharaData>();

    [Header("按钮设置")]
    public GameObject ShowContent;//生成按钮的父物体
    public GameObject ButtonPrefab;//按钮预制体
    public Image ShowImage;//另一个显示图
    private string PngDataPath;

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
        PngDataPath=SelfMadeNamespaceTool.DataTool.GetPngDataPath()+GameManager.Instance.ArchiveName;
        if (!File.Exists(PngDataPath)) Directory.CreateDirectory(PngDataPath);//检测并创建存档文件夹
        ShowtheButton();
    }
    private void ShowtheButton()
    {

        //获取pngdata路径下面的所有资源文件
        if (Directory.Exists(PngDataPath))
        {
            DirectoryInfo direction = new DirectoryInfo(PngDataPath);
            FileInfo[] files = direction.GetFiles("*", SearchOption.AllDirectories);

            for (int i = 0; i < files.Length; i++)
            {
                if (!files[i].Name.EndsWith(".png"))
                {
                    continue;
                }
                //在此处将找到的png文件转换为Sprite并存储到List中
                byte[] bytes = File.ReadAllBytes(files[i].FullName);
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(bytes);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f),texture.width);
                SpriteList.Add(sprite);
            }
            CharaManager.Instance.CharaSpriteList=SpriteList;
        }

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
