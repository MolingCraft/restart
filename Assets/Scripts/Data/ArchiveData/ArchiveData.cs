using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArchiveData
{
    public bool introductionif;
    //public float mana;//魔力槽
    //public float coin;//金币
     public List<CharaData>CharaDataList;
    //public int CharaCreateMaxNum;//最大创建角色数量
    //public List<GameObject> Baglist=new List<GameObject>();//背包
    public ArchiveData()
    {
        introductionif=false;
    }
}
