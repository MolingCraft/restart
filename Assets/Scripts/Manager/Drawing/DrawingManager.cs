using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class DrawingManager : Singleton<DrawingManager>
{
    public Shader newSurfaceShader;
    public GameObject dataCreatePanel;
    public Camera drawingCamera;
    public RenderTexture drawingTexture;
    public GameObject DrawArea;
    LineRenderer line;
    Material mat;
    public bool SuctionTubeIf;//吸管功能

    public List<GameObject> LineList=new List<GameObject>();

    [Header("颜色滑动条")]
    public Slider RedSlider;
    public Slider GreenSlider;
    public Slider BlueSlider;
    public Slider slider;

    [Header("读取显示图片")]
    public Image SelectedImage;
    public CharaData SelectedCharaData;



    public GameObject ShowContent;//生成按钮的父物体
    public GameObject ContentPrefab;//按钮预制体

    public List<Sprite> SpriteList=new List<Sprite>();
    public List<CharaData> CharaDataList=new List<CharaData>();
    int num = 0;//总共画画点数
    public Color color;

    private List<GameObject> buttonList=new List<GameObject>();


    private string PngDataPath;
	// Use this for initialization
	void Start () {
        PngDataPath=SelfMadeNamespaceTool.DataTool.GetPngDataPath()+GameManager.Instance.ArchiveName;

        slider.value = 0.1f;
        RedSlider.value=0f;
        GreenSlider.value=0f;
        BlueSlider.value=0f;
        LineList=new List<GameObject>();

        ContentPrefab.GetComponent<ShowtheSprite>().SpriteList=this.SpriteList;
        ContentPrefab.GetComponent<ShowtheSprite>().SelectedImage=this.SelectedImage;
        PngLoad();

	}
                // Update is called once per frame
    void Update () {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hit.collider != null)//当鼠标位于画框内时
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (SuctionTubeIf)//吸管功能如果开启
                {
                    StartCoroutine(SuctionTubeChangeColor());//吸色
                    return;
                }
                else if (color==null)//如果颜色为null，直接返回
                {
                    return;
                }
                else
                {
                    color=new Color32((byte)RedSlider.value,(byte)GreenSlider.value,(byte)BlueSlider.value,(byte)color.a);//通过拖动条获得当前颜色
                }

                GameObject obj = new GameObject();//线条object
                LineList.Add(obj);
                line= obj.AddComponent<LineRenderer>();
                line.material = new Material(newSurfaceShader);
                line.material.SetColor("_Color",color);
                line.widthMultiplier = slider.value;//宽度
                line.SetPosition(0,hit.point);
                line.SetPosition(1, hit.point);
                num = 0;
                line.sortingLayerName = "Draw";
                line.sortingOrder = LineList.Count;
                line.gameObject.layer=3;
            }
            if (Input.GetMouseButton(0))
            {
                num++;
                line.positionCount = num;
                line.SetPosition(num - 1, hit.point+Vector2.up*0.2f);

            }
        }
	}
    public void ClearAllLine()
    {
        while(LineList.Count!=0)
        {
            var obj=LineList[LineList.Count-1];
            LineList.Remove(obj);
            Destroy(obj);
        }
    }
    public void Revocation()
    {
        if(LineList.Count==0)return;
        var obj=LineList[LineList.Count-1];
            LineList.Remove(obj);
            Destroy(obj);
    }

    public void SuctionTube()
    {
        SuctionTubeIf=true;
    }
    IEnumerator SuctionTubeChangeColor()
    {
        yield return new WaitForEndOfFrame();
        if(SuctionTubeIf)
        {
            Texture2D texture2D = new Texture2D(Screen.width,Screen.height,TextureFormat.RGB24,true);
            texture2D.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            texture2D.Apply();
            color = texture2D.GetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y);
            RedSlider.value=color.r*255;
            GreenSlider.value=color.g*255;
            BlueSlider.value=color.b*255;
            SuctionTubeIf=false;
        }
    }

/// <summary>
/// 保存画作
/// </summary>
    public void SaveDraw()
{
    StartCoroutine(SaveDrawing());
}


IEnumerator SaveDrawing()//保存
{
    // 等待帧绘制完成
    yield return new WaitForEndOfFrame();

    /*
    获取名为DrawArea的gameobject的长和宽作为保存区域
    */
    var pos=DrawArea.transform.position;
    var boundsize=DrawArea.GetComponent<SpriteRenderer>().bounds.size;
    var pos2=Camera.main.WorldToScreenPoint(new Vector3(pos.x+boundsize.x/2,pos.y+boundsize.y/2,0));
    pos=Camera.main.WorldToScreenPoint(new Vector3(pos.x-boundsize.x/2,pos.y-boundsize.y/2,0));

    // 获取画布大小
    int canvasWidth =(int)(pos2.x-pos.x);
    int canvasHeight =(int)(pos2.y-pos.y);

    Texture2D texture = new Texture2D(canvasWidth,canvasHeight, TextureFormat.RGB24, false);
    //texture.ReadPixels(new Rect(530,320, canvasWidth, canvasHeight), 0, 0);
    texture.ReadPixels(new Rect(pos.x+1,pos.y, canvasWidth, canvasHeight), 0, 0);
    texture.Apply();


    byte[] bytes = texture.EncodeToPNG();

    // 保存PNG文件
    string filePath = Path.Combine(PngDataPath, "Drawing"+SpriteList.Count.ToString()+".png");
    File.WriteAllBytes(filePath, bytes);


    //加入spriteList
    Texture2D tex = new Texture2D(2, 2);
    tex.LoadImage(bytes);
    Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
    SpriteList.Add(sprite);

    var obj=Instantiate(ContentPrefab,new Vector3(0,0,0),Quaternion.identity,ShowContent.transform);
    obj.GetComponent<ShowtheSprite>().newSetSprite(SpriteList.Count);

    CharaManager.Instance.CharaSpriteList.Add(sprite);
    CharaManager.Instance.CharaDataList.Add(dataCreatePanel.GetComponent<DataCreatePanel>().DataCreate());
}

    public void PngLoad()
    {
        //获取指定路径下面的所有资源文件
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
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                SpriteList.Add(sprite);
            }

        }


        for(int i=0;i<SpriteList.Count;i++)
        {
            var obj=Instantiate(ContentPrefab,new Vector3(0,0,0),Quaternion.identity,ShowContent.transform);
            obj.GetComponent<ShowtheSprite>().newSetSprite(i);
        }
    }

}
