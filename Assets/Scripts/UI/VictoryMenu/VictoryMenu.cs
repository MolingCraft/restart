using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMenu : MonoBehaviour
{

    void Start()
    {
        //this.transform.gameObject.SetActive(false);
    }


    public void VictoryAction()
    {

    }
    public void Transition()
    {
        TransitionManager.Instance.TransitionTo("RestScene");
        List<GameObject> charaObjectList=CharaManager.Instance.charaObjectList;
        foreach(GameObject obj in charaObjectList)
        {
            obj.transform.position=new Vector3(0,0,-50);
        }
        this.transform.gameObject.SetActive(false);
    }
}
