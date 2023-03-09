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
             CharaManager.Instance.CreateCharaObject(prefab);
        }
        for(int i=1;i<=num;i++)
        {
             CharaManager.Instance.CreateEnemyObject(prefab);
        }
    }
}
