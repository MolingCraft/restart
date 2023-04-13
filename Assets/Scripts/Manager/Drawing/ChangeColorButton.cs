using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeColorButton : MonoBehaviour
{
    private byte red,green,blue,alpha;
    public void setColorRed(int r)
    {
        red=(byte)r;
        this.transform.GetComponent<Image>().color=new Color32(red,green,blue,alpha);
    }
    public void setColorGreen(int g)
    {
        green=(byte)g;
        this.transform.GetComponent<Image>().color=new Color32(red,green,blue,alpha);
    }
    public void setColorBlue(int b)
    {
        blue=(byte)b;
        this.transform.GetComponent<Image>().color=new Color32(red,green,blue,alpha);
    }
    public void setColorAlpha(int a)
    {
        alpha=(byte)a;
        this.transform.GetComponent<Image>().color=new Color32(red,green,blue,alpha);
    }
    public void setColor()
    {
        this.transform.GetComponent<Image>().color=new Color32(red,green,blue,alpha);
    }
    public void setColor(int r,int g,int b,int a)
    {
        red=(byte)r;
        green=(byte)g;
        blue=(byte)b;
        alpha=(byte)a;
        this.transform.GetComponent<Image>().color=new Color32(red,green,blue,alpha);
    }
    public void ChangeColor()
    {
        DrawingManager.Instance.color=new Color32(red,green,blue,alpha);
    }
}
