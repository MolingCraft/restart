
public class SettingData 
{
    //
    public int targetFrameRate;//渲染帧率,如此调用，放任意一个位置 Application.targetFrameRate = 120;//最大帧率


    //鼠标设置

    public float MouseZoomSpeed;//缩放速度
    public float MouseMoveSpeed;//拖动速度
    public SettingData()
    {

        MouseZoomSpeed = 50;
        MouseMoveSpeed = 50;
        targetFrameRate = 60;
    }
}
