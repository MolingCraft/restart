using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
public class ArchiveButton : MonoBehaviour
{
    string jsonArchiveFolder;
    
    public string ArchiveName;
    public Text Archivetext;
    public void Start()
    {
        jsonArchiveFolder = Application.dataPath + "/SaveData/ArchiveData/";
        
        
    }

    public void ChangetheName()
    {
        string name2 = this.name.Replace("(Clone)", "");
        ArchiveName = name2;
        Archivetext.text = name2;
    }
    public void StartArchive()
    {

        Debug.Log("加载存档："+ArchiveName);
        //GameManager.Instance.archiveData;
        GameManager.Instance.ArchiveName = ArchiveName;
        GameManager.Instance.Load();
        //GameManager.Instance.TransitionTo("MainScene");
    }
    public void DeleteArchive()
    {
        Debug.Log("删除存档：" + ArchiveName);

        File.Delete(jsonArchiveFolder+ArchiveName);
        this.gameObject.SetActive(false);
    }
}
