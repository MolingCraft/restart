using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttackScene : MonoBehaviour
{
    public List<Sprite> spritelist=new List<Sprite>();
    public float attacktime;
    public Image imageten;
    public Image imageone;
    public float StartGameTime;//开始游戏的间隔时间

    public GameObject CreateSpawn;//生成区域
    public int createNum;
    public List<GameObject> enemyObjectList=new List<GameObject>();

    private float timeLeft;
    private void Reset() {
        StartGameTime=3f;
    }
    void Start()
    {
        //GameManager.Instance.difficult=CharaManager.Instance.charaObjectList.Count/2+1;
        createNum=GameManager.Instance.difficult;
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
            var num=UnityEngine.Random.Range(0,CharaManager.Instance.CharaDataList.Count);
            var obj=CharaManager.Instance.CreateObject(tagname.Enemy,pos,num);
            obj.GetComponent<SpriteRenderer>().sprite=CharaManager.Instance.CharaSpriteList[num];
        }
    }


    private IEnumerator StartGameCoroutine()// 战斗回合延迟开始时间
    {
        AttackManager.Instance.StartAttackGame();
        yield return new WaitForSeconds(StartGameTime);
        AttackManager.Instance.StartBattle();
        timeLeft=attacktime;
        StartCoroutine(AttackTimeCoroutine());
    }
    private IEnumerator AttackTimeCoroutine()// 战斗回合延迟开始时间
    {
        while (timeLeft > 0) // while there is still time left
        {
            int x=(int)timeLeft/10;
            int y=(int)timeLeft%10;
            imageten.sprite=spritelist[x];
            imageone.sprite=spritelist[y];
            yield return new WaitForSeconds(1f); // wait for one second
            timeLeft -= 1f; // decrease the time left by one second
        }
        GameManager.Instance.difficult/=2;
        while(CharaManager.Instance.enemyObjectList.Count!=0)
        {
            CharaManager.Instance.enemyObjectList[CharaManager.Instance.enemyObjectList.Count-1].GetComponent<CharaObject>().action_Death();
        }
        AttackManager.Instance.EndBattle();
    }
}
