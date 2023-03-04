using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get { return instance; }
        //由于单例的特殊性，不需要进行更改，所以此处可以忽略set部分

    }

    protected virtual void Awake()//virtual这个虚函数可以在继承函数中进行overwrite（重写）
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = (T)this;
        }

        //DontDestroyOnLoad(this);
    }

    public static bool IsInitialized//如果instance不为空，返回true
    {
        get { return instance != null; }
    }


    protected virtual void OnDestory()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    /*
    using UnityEngine.SceneManagement;

    void GetAllSceneName()
    {
        int count = SceneManager.sceneCountInBuildSettings;
        Debug.Log("Scene Count = " + count);
        string[] scene_names = new string[count];
        string[] scene_paths = new string[count];
        for (int i = 0; i < count; i++)
        {
            scene_names[i] = SceneUtility.GetScenePathByBuildIndex(i);
            //从Assets路径下到此场景的路径
            Debug.Log("Assets路径开始到场景的路径为：" + scene_names[i]);
            scene_paths[i] = SceneUtility.GetScenePathByBuildIndex(i);
            //路径
            Debug.Log("路径为：" + scene_paths[i]);
            string[] strs = scene_names[i].Split('/');
            string str = strs[strs.Length - 1];
            strs = str.Split('.');
            str = strs[0];
            scene_names[i] = str;
            //场景的名字
            Debug.Log("场景的名字为：" + str);
        }
    }*/
}
