using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwayOverTime : MonoBehaviour
{
    public float swayAngle = 15f; // 摇晃角度
    public float swayTime = 1f; // 单次摇晃时间
    void Start()
    {
        StartSway(true);
    }


    void Update()
    {

    }


    public void StartSway(bool swayIf)
    {
        if(swayIf)StartCoroutine(Sway());
        else StopCoroutine(Sway());
    }


    private IEnumerator Sway()
    {
        while (true)
        {
            // 向右摇晃
            float elapsedTime = 0f;
            Quaternion startRotation = transform.rotation;
            Quaternion endRotation = Quaternion.Euler(0f, 0f, -swayAngle);
            while (elapsedTime < swayTime)
            {
                /*
                //非缓动效果
                transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / swayTime);
                */
                float t = Mathf.SmoothStep(0f, 1f, elapsedTime / swayTime);
                transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.rotation = endRotation;

            // 向左摇晃
            elapsedTime = 0f;
            startRotation = transform.rotation;
            endRotation = Quaternion.Euler(0f, 0f, swayAngle);
            while (elapsedTime < swayTime)
            {
                float t = Mathf.SmoothStep(0f, 1f, elapsedTime / swayTime);
                transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.rotation = endRotation;
        }
    }
}
