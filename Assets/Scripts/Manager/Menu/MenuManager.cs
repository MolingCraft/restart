using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using System;

public class MenuManager : Singleton<MenuManager>
{
    public GameObject SettingsMenuPanel;//设置UI窗口
    public GameObject ArchiveMenuPanel;//存档UI窗口
    public GameObject PauseMenuPanel;//暂停UI窗口
    public GameObject DeathMenuPanel;//死亡UI窗口

    //存档部分
    private int _NowArchiveNum;//当前存档数量
    public int NowArchiveNum{
        get{return _NowArchiveNum;}
        set{_NowArchiveNum=value;}
    }

    public GameObject ArchivePrefab;//存档预制体
    public GameObject archiveContent;//生成存档预制体的位置

    protected override void Awake()
    {
        base.Awake();

    }
    void Start()
    {

        SettingsMenuPanel.SetActive(false);
        ArchiveMenuPanel.SetActive(false);

        ArchiveLoad();
    }
    void Update()
    {
        menuEscape();

    }

    #region 菜单部分
    void menuEscape(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //如果设定、存档菜单已打开，优先关闭。若无打开的菜单且不在主菜单场景，打开暂停菜单
            if (SettingsMenuPanel.activeInHierarchy) SettingsMenuPanel.SetActive(false);
            else if (ArchiveMenuPanel.activeInHierarchy) ArchiveMenuPanel.SetActive(false);
            else if(SceneManager.GetActiveScene().buildIndex!=0)//当不在主菜单场景时
            {
                if (PauseMenuPanel.activeInHierarchy) PauseMenuPanel.SetActive(false);
                else PauseMenuPanel.SetActive(true);
            }

        }
    }

    #endregion


    #region 存档部分
    public void ArchiveLoad()
    {
        //获取指定路径下面的所有资源文件  然后进行删除
        if (Directory.Exists(SelfMadeNamespaceTool.DataTool.GetArchiveDataPath()))
        {
            DirectoryInfo direction = new DirectoryInfo(SelfMadeNamespaceTool.DataTool.GetArchiveDataPath());
            FileInfo[] files = direction.GetFiles("*", SearchOption.AllDirectories);

            for (int i = 0; i < files.Length; i++)
            {
                if (!files[i].Name.EndsWith(".sav"))
                {
                    continue;
                }
                _NowArchiveNum++;
                GameObject archive = (GameObject)GameObject.Instantiate(ArchivePrefab, this.transform.position, Quaternion.identity, archiveContent.transform);
                archive.name = files[i].Name;


                archive.GetComponent<ArchiveButton>().ChangetheName();
            }

        }

    }

    public void ArchiveCreate()
    {
        _NowArchiveNum++;
        Debug.Log("正在创建新存档");
        string archivename = System.DateTime.Now.ToString();
        archivename = archivename.Replace("/", "");
        archivename = archivename.Replace(" ", "");
        archivename = archivename.Replace(":", "");
        string resultPath = SelfMadeNamespaceTool.DataTool.GetArchiveDataPath() + archivename + ".sav";
        var jsonData = JsonConvert.SerializeObject(Formatting.Indented);
        File.WriteAllText(resultPath, jsonData);//数据写入
        Debug.Log("创建成功,存档编号为：" + archivename);
        //ArchivePrefab.name = archivename + ".sav";
        GameObject archive = (GameObject)GameObject.Instantiate(ArchivePrefab, this.transform.position, Quaternion.identity, archiveContent.transform);
        archive.name = archivename + ".sav";
        archive.GetComponent<ArchiveButton>().ChangetheName();
    }
    #endregion
}
