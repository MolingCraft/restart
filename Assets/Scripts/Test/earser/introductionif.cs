using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class introductionif : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        if(!GameManager.Instance.archiveData.introductionif)
        {
            Debug.Log("awa");
            panel.SetActive(true);
            GameManager.Instance.archiveData.introductionif=true;
            GameManager.Instance.Save();
        }
        else{
            Debug.Log("qwq");
            panel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
