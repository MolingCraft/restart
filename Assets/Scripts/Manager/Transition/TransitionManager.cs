using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using System;

public class TransitionManager : Singleton<TransitionManager>
{

    private GameObject fadeCanvasPanel;
    
    //Transition
    public GameObject fadeCanvasPrefab;
    public float fadeDuration;
    private bool isFade;

    private void Reset()
    {
        //自动生成过度panel
        fadeCanvasPanel = (GameObject)GameObject.Instantiate(fadeCanvasPrefab, this.transform.position, Quaternion.identity, this.transform);
        fadeCanvasPanel.transform.SetAsFirstSibling();
        isFade = false;
        fadeDuration = (float)0.17;
    }
    void Start()
    {
        DontDestroyOnLoad(this);
        fadeCanvasPanel = this.transform.GetChild(0).GetChild(0).gameObject;
        fadeCanvasPanel.SetActive(false);
        FadeWhenLoadinScene();
    }


    void Update()
    {
        
    }

    

 
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

        MenuManager.Instance.ArchiveMenuPanel.SetActive(false);
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



}
