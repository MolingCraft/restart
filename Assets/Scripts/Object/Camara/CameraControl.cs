using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CameraControl : MonoBehaviour
{
    [Header("缩放范围限制")]
    public float ZoomMaxNum;//最大缩放限制
    public float ZoomMinNum;//最小缩放限制
    [Header("拖动范围限制")]
    public float xMaxNum;//x轴坐标限制范围
    public float yMaxNum;//y轴坐标限制范围
    [Header("参数设置")]
    public float MouseZoomSpeed;//缩放速度
    public float MouseMoveSpeed;//拖动速度

    private Camera camera1;

    private void OnEnable()
    {

        
    }

    private void OnDisable()
    {

    }

    private void Reset()
    {
        ZoomMaxNum = 12;
        ZoomMinNum = 2;
        xMaxNum = 0;
        yMaxNum = 0;
    }
    void Start()
    {
        gameObject.GetComponent<Camera>().orthographicSize = (ZoomMaxNum + ZoomMinNum)/2;
        camera1 = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseControl();
        
    }

    void MouseControl()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            //限制size大小    
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, ZoomMinNum, ZoomMaxNum);
            //滚轮改变    
            Camera.main.orthographicSize = Camera.main.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * MouseZoomSpeed;
        }

        if (EventSystem.current.IsPointerOverGameObject()) return;//如果鼠标在某个物体上则不执行以下操作

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float xnum = gameObject.transform.position.x - mouseX * MouseMoveSpeed * camera1.orthographicSize/10;
        if (xMaxNum!=0f &&(xnum > xMaxNum || xnum < -xMaxNum) ) xnum = gameObject.transform.position.x;

        float ynum = gameObject.transform.position.y - mouseY * MouseMoveSpeed * camera1.orthographicSize/10;
        if (yMaxNum!=0f &&(ynum > yMaxNum || ynum < -yMaxNum) ) ynum = gameObject.transform.position.y;

        if (Input.GetMouseButton(2))
        {
            
            
            gameObject.transform.position = new Vector3(
                xnum, 
                ynum, 
                gameObject.transform.position.z
                );
        }
        
    }

    public void WhentheSettingsChange()
    {
        //MouseZoomSpeed = SettingsManager.settingData.MouseZoomSpeed;
        //MouseMoveSpeed = SettingsManager.settingData.MouseMoveSpeed;
    }
}
