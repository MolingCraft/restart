using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScope : MonoBehaviour
{
    [Header("行动范围划线参数")]
    public float DrawTime;//绘画完成时间
    public float CutNum;//切割数

    public Vector2 SkewingVector;
    public LineRenderer AttackLine;
    private Vector2 AttackLineFace;
    private float le;
    public GameObject ga;
    private void Reset() {
        DrawTime=1;
    }
    void Start()
    {
        AttackLine.positionCount=2;

    }


    void Update()
    {
        if(AttackLine.enabled==true)
        {
            Towardmouse(le,0);
        }
    }
    
    public void DrawAttackLine(float length )
    {
            le=length;
            AttackLine.enabled=true;
            AttackLine.SetPosition(0,SkewingVector);
            AttackLine.SetPosition(1,SkewingVector);
            StartCoroutine(DrawAttackLineCoroutine(length,1)); 
    }
    void Towardmouse(float length,float angle)
    {

        Vector2 worldPoint=Camera.main.ScreenToWorldPoint(ga.transform.position);
        Debug.Log(ga.transform.position+" "+worldPoint);
        Vector2 faceIn=(Vector2)Input.mousePosition-worldPoint; 
        faceIn.Normalize();//单位化
        faceIn=faceIn*length;
        AttackLine.SetPosition(1,faceIn);
    }
    public void DeleteAttackLine(float length ,float angle)
    {
        AttackLine.SetPosition(1,AttackLine.GetPosition(0));

    }

    IEnumerator DrawAttackLineCoroutine(float length,float angle)
    {
        Debug.Log("!");
        for(int i=1;i<=CutNum;i++)
        {
            Vector3 ne=AttackLine.GetPosition(1);
            ne.y+=length/CutNum;
            //ne.x+=drawLength/CutNum;
            AttackLine.SetPosition(1,ne);
            yield return new WaitForSeconds(DrawTime/CutNum);
        }
        Debug.Log("!");
        /*
        float drawLength=length/CutNum;
        while(Vector3.Distance(AttackLine.GetPosition(0),AttackLine.GetPosition(1))<length )
        {
            Vector3 ne=AttackLine.GetPosition(1);
            ne.y+=drawLength;
            //ne.x+=drawLength/CutNum;
            AttackLine.SetPosition(1,ne);
            //改变AttackLine.GetPosition(1)的位置
            //三条线都需改变
            Debug.Log("1");
            yield return new WaitForSeconds(DrawTime/CutNum);
        }*/
    }
}
