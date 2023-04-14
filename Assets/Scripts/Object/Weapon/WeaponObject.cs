using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour
{
    public CharaObject owncharaObject;//记得提前赋个值，指向装备了这个武器的charaobject
    public WeaponData weaponData;


    private Vector3 startPostion;
    void Start()
    {
        owncharaObject=this.transform.GetComponentInParent<CharaObject>();
        owncharaObject.charaData.attackRange=owncharaObject.traceStartDistance+owncharaObject.charaData.size;
        startPostion=new Vector3(0.5f,-0.2f,0f)*owncharaObject.charaData.size;
        if(owncharaObject.tag==tagname.Enemy.ToString())startPostion=new Vector3(-0.5f,-0.2f,0f)*owncharaObject.charaData.size;
        //weaponData.InitialRotation=Quaternion.identity;
        //weaponData.InitialRotation=this.transform.rotation;
    }


    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 vec3=startPostion+owncharaObject.transform.position;
        this.transform.position=vec3;
    }

    public virtual void Action_Attack()
    {
        Attack_Rotate();
        this.GetComponent<Collider2D>().enabled=true;
    }


    public virtual void Attack_Rotate()
    {
        transform.rotation = weaponData.InitialRotation;
        if (TryGetComponent(out ObjectSwayOverTime component))
        {
            component.enabled = false;
        }
        StartCoroutine(AttackSway());
    }


    public virtual void End_sway()
    {
        StopCoroutine(AttackSway());
    }

    public virtual IEnumerator AttackSway()
    {
            float elapsedTime = 0f;
            Quaternion startRotation = transform.rotation;
            Quaternion endRotation = Quaternion.Euler(0f, 0f, -weaponData.AttackSwayAngle);
            while (elapsedTime < weaponData.AttackSwayTime)
            {
                /*
                //非缓动效果
                transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / swayTime);
                */
                float t = Mathf.SmoothStep(0f, 1f, elapsedTime / weaponData.AttackSwayTime);
                transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.rotation = endRotation;


            this.GetComponent<Collider2D>().enabled=false;


            // 向左摇晃
            elapsedTime = 0f;
            startRotation = transform.rotation;
            endRotation = Quaternion.Euler(0f, 0f, weaponData.AttackSwayAngle);
            while (elapsedTime < weaponData.AttackSwayTime)
            {
                float t = Mathf.SmoothStep(0f, 1f, elapsedTime / weaponData.AttackSwayTime);
                transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.rotation = endRotation;


        if (TryGetComponent(out ObjectSwayOverTime component))
        {
            component.enabled = true;
        }
    }


    public virtual void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.TryGetComponent(out CharaObject charaObject))
        {
            weaponData.Action_Attack(this,charaObject);
            //charaObject.Action_Hit(1);
        }
    }
}
