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
            panel.SetActive(true);
            GameManager.Instance.archiveData.introductionif=true;
            GameManager.Instance.Save();
        }
        else{
            panel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
