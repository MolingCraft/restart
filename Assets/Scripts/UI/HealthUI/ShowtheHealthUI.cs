using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowtheHealthUI : MonoBehaviour
{
    public GameObject healthBarCanvas;

    public GameObject healthSliderPrefab;

    GameObject healthBar;
    GameObject healthBarPoint;

    private void Reset()
    {
        healthBarCanvas = GameObject.Find("HealthBarCanvas");

        //生成用于定位血条位置的对象，并设置为子物体的第一个
        GameObject bar = new GameObject("HealthBarPoint");//Instantiate(new GameObject("HealthBarPoint") , gameObject.transform);
        bar.transform.SetParent(this.transform);
        bar.transform.SetAsFirstSibling();
        bar.transform.position = this.transform.position;
        bar.transform.position = new Vector3(bar.transform.position.x, bar.transform.position.y+(float)0.8, bar.transform.position.z);
    }
    private void Start()
    {
        healthBar=Instantiate(healthSliderPrefab, healthBarCanvas.transform);//生成血条预制体
        
    }
    private void Update()
    {
        
    }
    private void LateUpdate()
    {
        healthBar.transform.position = gameObject.transform.GetChild(0).GetComponent<Transform>().position;
    }

    public void Attack()
    {
        
    }
    public void ChangeHealth(float HPnum)
    {
        healthBar.GetComponent<Slider>().value = (float)HPnum /100;
        deadDestory(HPnum);
    }
    public void ChangeHealth(float HPnum, float MaxNum)
    {
        healthBar.GetComponent<Slider>().value = HPnum / MaxNum;
        deadDestory(HPnum);
    }

    void deadDestory(float HPnum)
    {
        if (HPnum <= 0)
        {
            Destroy(healthBar);
        }
    }

}
