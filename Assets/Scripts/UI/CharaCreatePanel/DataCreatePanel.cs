using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
public class DataCreatePanel : MonoBehaviour
{
    public InputField nameInputField;
    public List<DataNumPanel> dataList=new List<DataNumPanel>();

    void Start()
    {
        nameInputField.text="随手的涂鸦";
    }

    // Update is called once per frame
    public CharaData DataCreate()
    {
        CharaData charaData=new CharaData();;
        charaData.charaName = nameInputField.text;
        nameInputField.text="随手的涂鸦";
        charaData.HP=dataList[0].dataNum;
        charaData.defend=dataList[1].dataNum;
        charaData.speed=dataList[2].dataNum;
        charaData.size=dataList[3].dataNum;
        charaData.attackdamage=dataList[4].dataNum;
        charaData.attackRange=dataList[5].dataNum;
        charaData.attackCD=dataList[6].dataNum;
        return charaData;
    }
}
