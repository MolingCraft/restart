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
}
