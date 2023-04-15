using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowtheHealthUI : MonoBehaviour
{
    public GameObject healthBarCanvas;

    public GameObject healthSliderPrefab;

    public GameObject healthBar;
public float yChange;
public Vector3 scale;
private Camera cam;
    private void Reset()
    {

    }
    public void createhealthbar()
    {
        if(healthBar!=null)return;
        cam=GameObject.Find("Main Camera").GetComponent<Camera>();
        healthBarCanvas = GameObject.Find("HealthBarCanvas");
        healthBar=Instantiate(healthSliderPrefab, healthBarCanvas.transform);//生成血条预制体
        healthBar.GetComponent<RectTransform>().localScale=scale;
    }
    private void Start()
    {
        healthBarCanvas = GameObject.Find("HealthBarCanvas");
        if(healthBarCanvas==null)this.enabled=false;
        createhealthbar();

    }
    private void Update()
    {

    }
    private void LateUpdate()
    {
        if(healthBar==null)return;
        if(healthBar.GetComponent<Slider>().value<=0)
        {
            healthBar.SetActive(false);
        }
        else healthBar.SetActive(true);
        Vector3 vec=gameObject.transform.position;

        //y轴偏移
        vec.y-=yChange;

        //使血条跟随移动
        healthBar.transform.position =vec;//cam.WorldToScreenPoint(vec);

        //根据CharaObject中curHP与maxHP的比值更改血条长度
        healthBar.GetComponent<Slider>().value =this.GetComponent<CharaObject>().curHP/this.GetComponent<CharaObject>().charaData.HP;
    }

}
