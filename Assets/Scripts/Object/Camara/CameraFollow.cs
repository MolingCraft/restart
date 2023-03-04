using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Object;
    public float Xoffset;//x轴偏移
    public float Yoffset;//y轴偏移
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Object.transform.position.x+ Xoffset, Object.transform.position.y+ Yoffset, gameObject.transform.position.z);
    }
}
