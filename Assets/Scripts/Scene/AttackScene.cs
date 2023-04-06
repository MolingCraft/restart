using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScene : MonoBehaviour
{
    public float StartGameTime;//开始游戏的间隔时间

    public GameObject CreateSpawn;//生成区域
    public int createNum;
    public List<GameObject> enemyObjectList=new List<GameObject>();
    private void Reset() {
        StartGameTime=3f;
    }
    void Start()
    {

        foreach(GameObject obj in enemyObjectList)
        {
            obj.tag=tagname.Enemy.ToString();
            CharaManager.Instance.enemyObjectList.Add(obj);
        }
        RandomCreateEnemy(createNum);
        StartCoroutine(StartGameCoroutine());
    }


    void Update()
    {

    }


    public void RandomCreateEnemy(int createNum)
    {
        Vector3 centerPosition=CreateSpawn.transform.position;
        float Xsize=CreateSpawn.transform.localScale.x/2;
        float Ysize=CreateSpawn.transform.localScale.y/2;

        for(int i=0;i<createNum;i++)
        {
            Vector3 pos = centerPosition + new Vector3(
                                        Random.Range(-Xsize, Xsize),
                                        Random.Range(-Ysize, Ysize),
                                        0);
            CharaManager.Instance.CreateObject(tagname.Enemy,pos);
        }
    }


    private IEnumerator StartGameCoroutine()// 战斗回合延迟开始时间
    {
        AttackManager.Instance.StartAttackGame();
        yield return new WaitForSeconds(StartGameTime);
        AttackManager.Instance.StartBattle();
    }
}
