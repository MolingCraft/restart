using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowtheCharaUI : MonoBehaviour
{
    public GameObject CharaUIPrefab;
    private GameObject CharaUI;
    public GameObject CharaShowContent;

    // Start is called before the first frame update
    void Start()
    {
        CharaUI = (GameObject)GameObject.Instantiate(CharaUIPrefab, this.transform.position, Quaternion.identity, CharaShowContent.transform);
        CharaUI.transform.Rotate(0, -180, 0);
        CharaUI.transform.GetChild(0).GetComponent<RectTransform>().Rotate(0, -180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        
    }

    public void ChangeHealth(float HPnum)
    {
        CharaUI.transform.GetChild(1).GetComponent<Slider>().value = (float)HPnum / 100;
        deadDestory(HPnum);
    }
    public void ChangeHealth(float HPnum, float MaxNum)
    {
        CharaUI.transform.GetChild(1).GetComponent<Slider>().value = HPnum / MaxNum;
        deadDestory(HPnum);
    }

    void deadDestory(float HPnum)
    {
        if (HPnum <= 0)
        {
            Destroy(CharaUI);
        }
    }
}
