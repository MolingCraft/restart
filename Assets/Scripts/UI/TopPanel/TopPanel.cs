using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPanel : MonoBehaviour
{
    public List<GameObject> charaObjectList;
    public GameObject buttomPrefab;
    public GameObject ButtomContent;
    public List<GameObject> ButtomList;
    void Start()
    {
        charaObjectList=CharaManager.Instance.charaObjectList;
        ButtomList=new List<GameObject>();
        LoadCharaImage();

    }


    void Update()
    {
        
    }

    void LoadCharaImage()
    {
        for(int i=0;i<charaObjectList.Count;i++)
        {
            GameObject obj=GameObject.Instantiate(
                        buttomPrefab,
                        ButtomContent.transform.position,
                        Quaternion.identity,
                        ButtomContent.transform);
            obj.GetComponent<TopPanelBottomSet>().BottomSet(charaObjectList[i]);
            charaObjectList.Add(obj);;
            ButtomList.Add(obj);
        }
    }
}
