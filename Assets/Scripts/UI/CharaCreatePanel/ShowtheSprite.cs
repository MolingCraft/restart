using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowtheSprite : MonoBehaviour
{
    public Image ShowImage;
    public int ShowNum;

    public Image SelectedImage;
    public List<Sprite> SpriteList=new List<Sprite>();
    void Start()
    {

    }

    public void NextSprite()
    {
        ShowNum++;
        if(ShowNum>=SpriteList.Count)ShowNum=0;

        ShowSprite();
    }


    public void PreviousSprite()
    {
        ShowNum--;
        if(ShowNum<0)ShowNum=SpriteList.Count-1;

        ShowSprite();
    }

    public void SetSprite()
    {
        if(ShowNum<0)ShowNum=SpriteList.Count-1;
        if(ShowNum>=SpriteList.Count)ShowNum=0;

        ShowSprite();
    }
    public void SetSprite(int num)
    {
        ShowNum=num;
        if(ShowNum<0)ShowNum=0;
        if(ShowNum>=SpriteList.Count)ShowNum=SpriteList.Count-1;

        ShowSprite();
    }
    public void newSetSprite(int num)
    {
        ShowNum=num;
        if(ShowNum<0)ShowNum=0;
        if(ShowNum>=SpriteList.Count)ShowNum=SpriteList.Count-1;
        ShowImage.sprite=SpriteList[ShowNum];
    }
    private void ShowSprite()
    {
        ShowImage.sprite=SpriteList[ShowNum];
        SelectedImage.sprite=ShowImage.sprite;
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
