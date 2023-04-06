using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowtheSpriteInImage : MonoBehaviour
{
    public Image ShowImage;
    public Image ShowImage2;
    public int ShowNum;

    private void Start()
    {
        //ShowNum=0;
        //ShowImage=this.transform.gameObject.GetComponent<Image>();
    }

    public void NextSprite()
    {
        ShowNum++;
        if(ShowNum>=CharaCreateManager.Instance.GetSpriteListCount())ShowNum=0;
        ShowImage.sprite=CharaCreateManager.Instance.GetTheSprite(ShowNum);
        if(ShowImage2!=null)ShowImage2.sprite=ShowImage.sprite;
        CharaCreateManager.Instance.SelectedSprite=ShowImage.sprite;
    }
    public void NextSprite(int num)
    {
        ShowNum+=num;
        if(ShowNum>=CharaCreateManager.Instance.GetSpriteListCount())ShowNum=0;
        ShowImage.sprite=CharaCreateManager.Instance.GetTheSprite(ShowNum);
        if(ShowImage2!=null)ShowImage2.sprite=ShowImage.sprite;
        CharaCreateManager.Instance.SelectedSprite=ShowImage.sprite;
    }

    public void PreviousSprite()
    {
        ShowNum--;
        if(ShowNum<0)ShowNum=CharaCreateManager.Instance.GetSpriteListCount()-1;
        ShowImage.sprite=CharaCreateManager.Instance.GetTheSprite(ShowNum);
        if(ShowImage2!=null)ShowImage2.sprite=ShowImage.sprite;
        CharaCreateManager.Instance.SelectedSprite=ShowImage.sprite;
    }
    public void PreviousSprite(int num)
    {
        ShowNum-=num;
        if(ShowNum<0)ShowNum=CharaCreateManager.Instance.GetSpriteListCount()-1;
        ShowImage.sprite=CharaCreateManager.Instance.GetTheSprite(ShowNum);
        if(ShowImage2!=null)ShowImage2.sprite=ShowImage.sprite;
        CharaCreateManager.Instance.SelectedSprite=ShowImage.sprite;
    }
    public void SetSprite()
    {
        if(ShowNum<0)ShowNum=CharaCreateManager.Instance.GetSpriteListCount()-1;
        if(ShowNum>=CharaCreateManager.Instance.GetSpriteListCount())ShowNum=0;
        ShowImage.sprite=CharaCreateManager.Instance.GetTheSprite(ShowNum);
        if(ShowImage2!=null)ShowImage2.sprite=ShowImage.sprite;
        CharaCreateManager.Instance.SelectedSprite=ShowImage.sprite;
    }
    public void SetSprite(int num)
    {
        ShowNum=num;
        if(ShowNum<0)ShowNum=CharaCreateManager.Instance.GetSpriteListCount()-1;
        if(ShowNum>=CharaCreateManager.Instance.GetSpriteListCount())ShowNum=0;
        ShowImage.sprite=CharaCreateManager.Instance.GetTheSprite(ShowNum);
        if(ShowImage2!=null)ShowImage2.sprite=ShowImage.sprite;
        CharaCreateManager.Instance.SelectedSprite=ShowImage.sprite;
    }
}
