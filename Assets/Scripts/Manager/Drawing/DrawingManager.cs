using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class DrawingManager : Singleton<DrawingManager>
{
    public Camera drawingCamera;
    public RenderTexture drawingTexture;
    public GameObject DrawArea;
    LineRenderer line;
    Material mat;
    public bool SuctionTubeIf;//吸管功能
    public Slider slider;

    [Header("颜色滑动条")]
    public Slider RedSlider;
    public Slider GreenSlider;
    public Slider BlueSlider;
    int num = 0;//总共画画点数
    public Color color;
	// Use this for initialization
	void Start () {
        slider.value = 0.1f;
        RedSlider.value=0f;
        GreenSlider.value=0f;
        BlueSlider.value=0f;
	}
                // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(Input.mousePosition);
            }
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hit.collider != null)
        {
            if (SuctionTubeIf && Input.GetMouseButtonDown(0))
            {
                StartCoroutine(SuctionTubeChangeColor());
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (color==null)
                {
                    return;
                }
                color=new Color32((byte)RedSlider.value,(byte)GreenSlider.value,(byte)BlueSlider.value,(byte)color.a);
                GameObject obj = new GameObject();
                line= obj.AddComponent<LineRenderer>();
                line.material.color= color;
                line.widthMultiplier = slider.value;//宽度
                line.SetPosition(0,hit.point);
                line.SetPosition(1, hit.point);
                num = 0;
                line.sortingLayerName = "Draw";
                line.sortingOrder = 0;
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
            SuctionTubeIf=false;
        }
    }

    public void SaveDraw()
{
    StartCoroutine(SaveDrawing());
}


IEnumerator SaveDrawing()
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
    texture.ReadPixels(new Rect(pos.x,pos.y, canvasWidth, canvasHeight), 0, 0);
    texture.Apply();


    byte[] bytes = texture.EncodeToPNG();

    // 保存PNG文件
    string filePath = Path.Combine(SelfMadeNamespaceTool.DataTool.GetPngDataPath(), "drawing.png");
    File.WriteAllBytes(filePath, bytes);
}
/*
IEnumerator SaveDrawing()
{
    // 等待帧绘制完成
    yield return new WaitForEndOfFrame();

    // 获取画布大小
    int canvasWidth = Screen.width;
    int canvasHeight = Screen.height;

    // 创建RenderTexture对象
    drawingTexture = new RenderTexture(canvasWidth, canvasHeight, 24);
    drawingCamera.targetTexture = drawingTexture;

    // 渲染线条
    drawingCamera.Render();

    // 激活RenderTexture
    RenderTexture.active = drawingTexture;

    // 创建Texture2D对象
    Texture2D texture = new Texture2D(canvasWidth, canvasHeight);

    // 读取画布像素数据
    texture.ReadPixels(new Rect(0, 0, canvasWidth, canvasHeight), 0, 0);
    texture.Apply();

    // 将Texture2D对象转换为PNG格式的字节数组
    byte[] pngData = texture.EncodeToPNG();

    // 保存PNG文件
    string filePath = Path.Combine(Application.dataPath, "drawing.png");
    File.WriteAllBytes(filePath, pngData);

    // 重置状态
    RenderTexture.active = null;
}*/

}








    /*
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
        }*//*
        ContentPrefab.GetComponent<ShowtheSprite>().SpriteList=this.SpriteList;
        ContentPrefab.GetComponent<ShowtheSprite>().SelectedImage=this.SelectedImage;

        PngLoad();
        //PngShow();
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
*/