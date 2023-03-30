using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textDrafts : MonoBehaviour
{
public GameObject prefab;
public GameObject charaobjFather;
public GameObject enemyobjFather;
List<GameObject> objlist;
List<GameObject> enemylist;
MyClass cl=new MyClass();
public int text1;
public int text2;
void Start()
{
    
    charaobjFather=CharaManager.Instance.charaObjectfather;
    enemyobjFather=CharaManager.Instance.enemyObjectfather;

    objlist=CharaManager.Instance.charaObjectList;
    enemylist=CharaManager.Instance.enemyObjectList;

}
   public void randomCreate(int num)
    {

        for(int i=1;i<=num;i++)
        {
             CharaManager.Instance.CreateObject(prefab,tagname.Player);
        }
        for(int i=1;i<=num;i++)
        {
             CharaManager.Instance.CreateObject(prefab,tagname.Enemy);
        }
    }
    public void me1()
    {
        cl.Method1(ref text1,ref text2);
    }
    public void me2()
    {
        cl.Method2();
        Debug.Log(text1+" "+text2);
    }
}

public class MyClass
{
    private int x;
    private int y;

    public void Method1(ref int a, ref int b)
    {
        x = a;
        y = b;
        b+=9;
        y+=10;
    }

    public void Method2()
    {
        y+=10;
        // 在这里可以使用x和y
        Debug.Log( x+" "+y);
    }
}
