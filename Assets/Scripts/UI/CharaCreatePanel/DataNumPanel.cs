using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum Dnum
{
    HP,
    Defend,
    Speed,
    Size,
    Attackdamage,
    AttackRange,
    AttackCD,
}
public class DataNumPanel : MonoBehaviour
{
    public List<Sprite> SpriteList=new List<Sprite>();
    public Dnum dataEnum;
    public int dataNum;
    public Image imageTen;
    public Image imageOne;
    private void Start()
    {
        dataNum=1;
        ShowNum();
    }

    public void AddNum()
    {
        dataNum++;
        if(dataNum>99)dataNum=1;
        ShowNum();
    }
    public void DelNum()
    {
        dataNum--;
        if(dataNum<=0)dataNum=99;;
        ShowNum();
    }
    public void ShowNum()
    {
        int x=dataNum/10;
        int y=dataNum%10;
        imageTen.sprite=SpriteList[x];
        imageOne.sprite=SpriteList[y];
    }
}
