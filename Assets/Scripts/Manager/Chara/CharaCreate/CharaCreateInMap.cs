using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharaCreateInMap : MonoBehaviour
{
    public int charaNum;
    public GameObject selectedObj;
    bool ChooseNow;
    private void Update()
    {

            if(selectedObj!=null)
            {
                MoveTheObject();

                if(Input.GetMouseButtonDown(0))
                {
                    Vector3 vec3=selectedObj.transform.position;
                    selectedObj.GetComponent<CharaObject>().ResetPosition=vec3;
                    selectedObj=null;
                }
            }
    }

    public void CreateObjectInMap()
    {
        Vector3 vec3=Input.mousePosition;
        vec3.z=0;

        var Datanum=CharaCreateManager.Instance.SelectedCharaData;

        var obj=CharaManager.Instance.CreateObject(tagname.Player,vec3,Datanum);
        obj.SetActive(true);
        obj.GetComponent<SpriteRenderer>().sprite=CharaCreateManager.Instance.SelectedSprite;

//改成obj后再传递会导致出问题，血条没了

        selectedObj=obj;
    }

    public void MoveTheObject()
    {

        Vector3 vec3=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec3.z=0;
        selectedObj.transform.position=vec3;
    }
    public void difficultadd()
    {
        GameManager.Instance.difficult++;
    }
}
