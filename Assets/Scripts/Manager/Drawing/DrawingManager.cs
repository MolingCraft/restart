using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class DrawingManager : Singleton<DrawingManager>
{
    public Image SelectedImage;
    public CharaData SelectedCharaData;



    public GameObject ShowContent;//生成按钮的父物体
    public GameObject ContentPrefab;//按钮预制体

    public List<Sprite> SpriteList=new List<Sprite>();
    public List<CharaData> CharaDataList=new List<CharaData>();
    void Start()
    {
        /*
        foreach(Sprite sprite in CharaCreateManager.Instance.SpriteList)
        {
            SpriteList.Add(sprite);
        }
        foreach(CharaData charaData in CharaCreateManager.Instance.CharaDataList)
        {
            CharaDataList.Add(charaData);
        }*/
        ContentPrefab.GetComponent<ShowtheSprite>().SpriteList=this.SpriteList;
        ContentPrefab.GetComponent<ShowtheSprite>().SelectedImage=this.SelectedImage;

        PngLoad();
        PngShow();
    }

    void Update()
    {

    }


    public void PngLoad()
    {
        //获取指定路径下面的所有资源文件  然后进行删除
        if (Directory.Exists(SelfMadeNamespaceTool.DataTool.GetPngDataPath()))
        {
            DirectoryInfo direction = new DirectoryInfo(SelfMadeNamespaceTool.DataTool.GetPngDataPath());
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
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                SpriteList.Add(sprite);
            }

        }

    }


    public void PngShow()
    {
        for(int i=0;i<SpriteList.Count;i++)
        {
            var obj=Instantiate(ContentPrefab,new Vector3(0,0,0),Quaternion.identity,ShowContent.transform);
            obj.GetComponent<ShowtheSprite>().SetSprite(i);
        }
    }


}
