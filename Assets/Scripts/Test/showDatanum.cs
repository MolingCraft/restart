using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showDatanum : MonoBehaviour
{
    public Text text;
    public List<Text> textlist=new List<Text>();

    void FixedUpdate()
    {
        CharaData data=CharaManager.Instance.CharaDataList[CharaCreateManager.Instance.SelectedCharaData];
        text.text=data.charaName;

        textlist[0].text="HP:"+data.HP;
        textlist[1].text="速度:"+data.speed;
        textlist[2].text="防御"+data.defend;
        textlist[3].text="体型"+data.size;
        textlist[4].text="攻击力"+data.attackdamage;
        textlist[5].text="攻击范围"+data.attackRange;
        textlist[6].text="攻击CD"+data.attackCD;
    }
}
