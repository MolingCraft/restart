using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class DrawingManager : Singleton<DrawingManager>
{
    LineRenderer line;
    Material mat;
    public Slider slider;
    int num = 0;//总共画画点数
    Color c;
	// Use this for initialization
	void Start () {
        slider.value = 0.1f;
	}
                // Update is called once per frame
    void Update () {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hit.collider != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (c==null)
                {
                    return;
                }
                GameObject obj = new GameObject();
                line= obj.AddComponent<LineRenderer>();
                line.material.color= c;
                line.widthMultiplier = slider.value;//宽度
                line.SetPosition(0,hit.point);
                line.SetPosition(1, hit.point);
                num = 0;
                line.sortingLayerName = "Draw";
                line.sortingOrder = 0;
            }
            if (Input.GetMouseButton(0))
            {
                num++;
                line.positionCount = num;
                line.SetPosition(num - 1, hit.point+Vector2.up*0.2f);

            }
            if (Input.GetMouseButtonDown(1))
            {
                StartCoroutine(ChangeColor());
            }
        }
	}
    IEnumerator ChangeColor()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture2D = new Texture2D(Screen.width,Screen.height,TextureFormat.RGB24,true);
        texture2D.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture2D.Apply();
        c = texture2D.GetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y);
    }









    /*
    public static Color Pen_Colour = Color.red;
    public static int Pen_Width = 3;

    public LayerMask Drawing_Layers;

    private Sprite drawable_sprite;
    private Texture2D drawable_texture;

    private Vector2 previous_drag_position;
    private Color[] clean_colours_array;
    private Collider2D[] rayResult = new Collider2D[2];
    private Color32[] cur_colors;
      
    private bool no_drawing_on_current_drag = false;
    private bool mouse_was_previously_held_down = false;
      
    protected override void Awake()
    {
        base.Awake();
        drawable_sprite = this.GetComponent<SpriteRenderer>().sprite;
        drawable_texture = drawable_sprite.texture;
  
        clean_colours_array = new Color[(int)drawable_sprite.rect.width * (int)drawable_sprite.rect.height];
        clean_colours_array = drawable_texture.GetPixels();
    }
      
    void Update()
    {
        bool mouse_held_down = Input.GetMouseButton(0);
        if (mouse_held_down && !no_drawing_on_current_drag)
        {
            Vector2 mouse_world_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
  
            Collider2D hit = Physics2D.OverlapPoint(mouse_world_position, Drawing_Layers.value);
            if (hit != null && hit.transform != null)
            {
                PenBrush(mouse_world_position);
                //current_brush(mouse_world_position);
            }
            else
            {
                previous_drag_position = Vector2.zero;
                if (!mouse_was_previously_held_down)
                {
                    no_drawing_on_current_drag = true;
                }
            }
        }
        else if (!mouse_held_down)
        {
            previous_drag_position = Vector2.zero;
            no_drawing_on_current_drag = false;
        }
        mouse_was_previously_held_down = mouse_held_down;
    }
      
    protected void OnDestroy()
    {
        ResetCanvas();
    }
      
    /// <summary>
    ///  重置画布
    /// </summary>
    private void ResetCanvas()
    {
        drawable_texture.SetPixels(clean_colours_array);
        drawable_texture.Apply();
    }
      
    /// <summary>
    ///  笔刷
    /// </summary>
    public void PenBrush(Vector2 world_point)
    {
        Vector2 pixel_pos = WorldToPixelCoordinates(world_point);
          
        cur_colors = drawable_texture.GetPixels32();
          
        if (previous_drag_position == Vector2.zero)
        {
            MarkPixelsToColour(pixel_pos, Pen_Width, Pen_Colour);
        }
        else
        {
            ColourBetween(previous_drag_position, pixel_pos, Pen_Width, Pen_Colour);
        }
        ApplyMarkedPixelChanges();
         
        previous_drag_position = pixel_pos;
    }
      
    private Vector2 WorldToPixelCoordinates(Vector2 world_position)
    {
        Vector3 local_pos = transform.InverseTransformPoint(world_position);
  
        float pixelWidth = drawable_sprite.rect.width;
        float pixelHeight = drawable_sprite.rect.height;
        float unitsToPixels = pixelWidth / drawable_sprite.bounds.size.x * transform.localScale.x;
  
        float centered_x = local_pos.x * unitsToPixels + pixelWidth / 2;
        float centered_y = local_pos.y * unitsToPixels + pixelHeight / 2;
  
        Vector2 pixel_pos = new Vector2(Mathf.RoundToInt(centered_x), Mathf.RoundToInt(centered_y));
  
        return pixel_pos;
    }
      
    private void ColourBetween(Vector2 start_point, Vector2 end_point, int width, Color color)
    {
        float distance = Vector2.Distance(start_point, end_point);
        Vector2 direction = (start_point - end_point).normalized;
  
        Vector2 cur_position = start_point;
        float lerp_steps = 1 / distance;
  
        for (float lerp = 0; lerp <= 1; lerp += lerp_steps)
        {
            cur_position = Vector2.Lerp(start_point, end_point, lerp);
            MarkPixelsToColour(cur_position, width, color);
        }
    }
      
    private void MarkPixelsToColour(Vector2 center_pixel, int pen_thickness, Color color_of_pen)
    {
        int center_x = (int)center_pixel.x;
        int center_y = (int)center_pixel.y;
 
        for (int x = center_x - pen_thickness; x <= center_x + pen_thickness; x++)
        {
            if (x >= (int)drawable_sprite.rect.width || x < 0)
                continue;
  
            for (int y = center_y - pen_thickness; y <= center_y + pen_thickness; y++)
            {
                MarkPixelToChange(x, y, color_of_pen);
            }
        }
    }
    private void MarkPixelToChange(int x, int y, Color color)
    {
        int array_pos = y * (int)drawable_sprite.rect.width + x;
  
        if (array_pos > cur_colors.Length || array_pos < 0)
            return;
  
        cur_colors[array_pos] = color;
    }
      
    private void ApplyMarkedPixelChanges()
    {
        drawable_texture.SetPixels32(cur_colors);
        drawable_texture.Apply();
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
*/
}
