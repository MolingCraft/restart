using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public CharaObject FromObject;
    public bool hasHit;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.TryGetComponent(out CharaObject charaObject))
        {
            if(FromObject.tag!=charaObject.tag)
            {
                charaObject.Action_Hit(FromObject.charaData.damage);
                hasHit=false;
            }
        }
    }
}
