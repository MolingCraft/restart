using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NewBehaviourScript : MonoBehaviour
{

    public void playanim()
    {
        Animation myAnimation = GetComponent<Animation>();
        myAnimation.Play("FadeIn");
    }
}
