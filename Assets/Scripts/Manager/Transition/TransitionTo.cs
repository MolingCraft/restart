using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTo : MonoBehaviour
{
    // Showing a list of loaded scenes
    [StringInList(typeof(PropertyDrawersHelper), "AllSceneNames")] 
    public string SceneToName;
    public void sceneTo(){
        TransitionManager.Instance.TransitionTo(SceneToName);
    }

    public void setdifficult()
    {
        if(GameManager.Instance.difficult==0)GameManager.Instance.difficult=CharaManager.Instance.charaObjectList.Count/2+1;
    }
}
