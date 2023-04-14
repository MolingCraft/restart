using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using System;

public class GameManager : Singleton<GameManager>
{
    public int difficult;
    public static SettingData settingData;

    private string _ArchiveName;//当前加载存档的名字，编辑器中不应修改，所以用了private
    public string ArchiveName
    {
        get { return _ArchiveName; }
        set { _ArchiveName = value; }
    }

    public ArchiveData archiveData;

    public delegate void VoidDelegate(ArchiveData archiveData);
    public static event VoidDelegate Event_LoadArchive;

    protected override void Awake()
    {
        base.Awake();
        string folder = SelfMadeNamespaceTool.DataTool.GetArchiveDataPath();
        if (!File.Exists(folder)) Directory.CreateDirectory(folder);//检测并创建存档文件夹

        string pngfolder=SelfMadeNamespaceTool.DataTool.GetPngDataPath();
        if (!File.Exists(pngfolder)) Directory.CreateDirectory(pngfolder);//检测并创建存档文件夹

        OnStartSettingLoad();//加载游戏设置


    }

    /*
    public static event Action UnloadSceneBeforeEvent;
    public static void CallUnloadSceneBeforeEvent()
    {
        UnloadSceneBeforeEvent?.Invoke();
    }

    //加载场景时进行的事件，用于一些零散脚本
    public static event Action LoadSceneBeforeEvent;
    public static void CallLoadSceneBeforeEvent()
    {
        LoadSceneBeforeEvent?.Invoke();
    }*/


    void Start()
    {
        difficult=0;
        DontDestroyOnLoad(this);
    }




    #region Settings

    /// <summary>
    /// 载入游戏时的设置文件检测与读取
    /// </summary>
    public void OnStartSettingLoad()
    {
        var resultPath = SelfMadeNamespaceTool.DataTool.GetSaveDataPath() + "SettingData.sav";
        if (!File.Exists(resultPath))
        {//若不存在保存数据，创建一份
            Debug.Log("未检测到SettingData.sav，重新创建");
            settingData = new SettingData();
            var jsonData = JsonConvert.SerializeObject(settingData, Formatting.Indented);
            File.WriteAllText(resultPath, jsonData);//数据写入
            Debug.Log("创建成功");
        }
        else
        {
            Debug.Log("检测到SettingData.sav，开始读取");
            var stringData = File.ReadAllText(resultPath);
            var jsonData = JsonConvert.DeserializeObject<SettingData>(stringData);
            settingData = jsonData;

        }
    }


    /// <summary>
    /// 游戏设置文件初始化
    /// </summary>
    public void SettingsInitialization()
    {
        settingData = new SettingData();
        var resultPath = SelfMadeNamespaceTool.DataTool.GetSaveDataPath() + "SettingData.sav";
        var jsonData = JsonConvert.SerializeObject(settingData, Formatting.Indented);
        File.WriteAllText(resultPath, jsonData);//数据写入
        Debug.Log("初始化成功");
    }



    #endregion





    #region SaveLoad

    public void Save()//保存数据,我在TransitionManager的场景切换中调用了这个玩意
    {
        string resultPath = SelfMadeNamespaceTool.DataTool.GetArchiveDataPath() + ArchiveName;

        var jsonData = JsonConvert.SerializeObject(archiveData, Formatting.Indented);


        File.WriteAllText(resultPath, jsonData);//数据写入
    }

    public void LoadArchive()//加载读取数据
    {

        if (ArchiveName == null) {archiveData = new ArchiveData(); return; }
        string resultPath = SelfMadeNamespaceTool.DataTool.GetArchiveDataPath() +ArchiveName;
        var stringData = File.ReadAllText(resultPath);

        if (stringData == "1")
        {
            Debug.Log("检测为空存档,创建初始模板");
            archiveData = new ArchiveData();
            return;
        }// return;//如果不存在保存数据，直接return
        else
        {
            Debug.Log("开始加载存档数据");


        }
        var jsonData = JsonConvert.DeserializeObject<ArchiveData>(stringData);
        archiveData = jsonData;

        if(Event_LoadArchive!=null) Event_LoadArchive(archiveData);

        Debug.Log("存档读取完成");
    }

    #endregion
    public void ButtonExit()
    {
        Application.Quit(); // quit the game
    }

}
