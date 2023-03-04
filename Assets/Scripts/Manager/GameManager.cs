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
    public static SettingData settingData;

    private string _ArchiveName;//当前加载存档的名字，编辑器中不应修改，所以用了private
    public ArchiveData archiveData;

    private GameObject fadeCanvasPanel;
    

    //Transition
    public GameObject fadeCanvasPrefab;
    public float fadeDuration;
    private bool isFade;

    public string ArchiveName
    {
        get { return _ArchiveName; }
        set { _ArchiveName = value; }
    }

    private void Reset()
    {
        //自动生成过度panel
        fadeCanvasPanel = (GameObject)GameObject.Instantiate(fadeCanvasPrefab, this.transform.position, Quaternion.identity, this.transform);
        fadeCanvasPanel.transform.SetAsFirstSibling();
        isFade = false;
        fadeDuration = (float)0.17;
    }

    protected override void Awake()
    {
        base.Awake();
        string folder = SelfMadeNamespaceTool.DataTool.GetArchiveDataPath();
        if (!File.Exists(folder)) Directory.CreateDirectory(folder);//检测并创建存档文件夹
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
        DontDestroyOnLoad(this);
        fadeCanvasPanel = this.transform.GetChild(0).GetChild(0).gameObject;
        fadeCanvasPanel.SetActive(false);
        FadeWhenLoadinScene();

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






    #region Transition


    #region 场景淡入效果void FadeWhenLoadinScene()

    public void FadeWhenLoadinScene()
    {
        if (!isFade)
        {
            StartCoroutine(Fadein());
        }
    }
    private IEnumerator Fadein()
    {
        fadeCanvasPanel.SetActive(true);
        yield return Fade(0);
        //SaveLoadManager.Instance.GetComponent<SaveLoadManager>().Load();
        //GameObject.Find("SaveLoadManager").GetComponent<SaveLoadManager>().Load();
        fadeCanvasPanel.SetActive(false);
    }
    #endregion

    #region 变换场景与淡出void TransitionTo(string sceneto)
    public void TransitionTo(string sceneto)
    {
        if (!isFade)
        {
            StartCoroutine(TransitionToScene(sceneto));
        }

    }
    private IEnumerator TransitionToScene(string sceneto)
    {
        //黑幕缓入

        fadeCanvasPanel.SetActive(true);
        yield return Fade(1);//先执行此行，在执行后续
                             //StartCoroutine(Fade(1));//开始执行，同时开始执行后续

        SceneManager.LoadScene(sceneto);
        yield return Fade(0);
        fadeCanvasPanel.SetActive(false);

        //yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Single);
        //设置新场景为激活场景
        /*
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);
        */
    }
    #endregion


    /// <summary>
    /// 淡入淡出场景
    /// </summary>
    /// <param name="targetAlpha">1是黑，0是透明,超过范围黑屏速率会变慢，反之变快</param>
    /// <returns></returns>,
    private IEnumerator Fade(float targetAlpha)
    {
        CanvasGroup canvasGroup = fadeCanvasPanel.transform.GetComponent<CanvasGroup>();
        canvasGroup.alpha = -targetAlpha + 1;
        isFade = true;
        canvasGroup.blocksRaycasts = true;

        float speed = Mathf.Abs(canvasGroup.alpha - targetAlpha) / fadeDuration;

        while (!Mathf.Approximately(canvasGroup.alpha, targetAlpha))
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }
        isFade = false;
        canvasGroup.blocksRaycasts = false;
    }

    #endregion





    #region SaveLoad

    public void Save()//保存数据
    {
        string resultPath = SelfMadeNamespaceTool.DataTool.GetArchiveDataPath() + ArchiveName;

        var jsonData = JsonConvert.SerializeObject(archiveData, Formatting.Indented);


        File.WriteAllText(resultPath, jsonData);//数据写入
    }

    public void Load()//加载读取数据
    {

        if (ArchiveName == null) {archiveData = new ArchiveData(); return; }
        string resultPath = SelfMadeNamespaceTool.DataTool.GetArchiveDataPath() +ArchiveName;
        var stringData = File.ReadAllText(resultPath);

        if (stringData == "1")
        {
            Debug.Log("检测为空存档");
            archiveData = new ArchiveData();
            return;
        }// return;//如果不存在保存数据，直接return
        else
        {
            Debug.Log("开始加载存档数据");

        }
        var jsonData = JsonConvert.DeserializeObject<ArchiveData>(stringData);
        archiveData = jsonData;
    }

    #endregion


}
