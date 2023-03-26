using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TopPanelBottomSet : MonoBehaviour
{
    public Sprite i1;
    public Sprite i2;
    public void BottomSet(GameObject obj)
    {
        this.transform.GetComponent<Image>().sprite=i1;
    }
    public void ButtomClick()
    {

    }
}
