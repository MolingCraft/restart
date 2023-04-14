using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCharaList : MonoBehaviour
{
    // Start is called before the first frame update
    public void clearCharaList()
    {
        List<GameObject> objList=CharaManager.Instance.charaObjectList;
        while(objList.Count!=0)
        {
            GameManager.Instance.difficult=0;
            objList[0].GetComponent<CharaObject>().action_Death();
        }
    }
}
