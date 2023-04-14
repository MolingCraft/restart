using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OpenFolderButton : MonoBehaviour
{
    public GameObject panel;
    void Start()
    {

    }

    public void OpenFolder()
    {
        panel.SetActive(true);
    }


        //string path = EditorUtility.OpenFolderPanel("Load png Textures", SelfMadeNamespaceTool.DataTool.GetPngDataPath(), "");
}

/*
using System.Diagnostics;
System.Diagnostics.Process.Start这个方法可以用来启动一个进程，也就是运行一个程序或者打开一个文件或者文件夹。它有两个参数，第一个是要运行的程序的名称，第二个是要传递给程序的参数。例如，如果你想打开Windows的记事本程序，并且打开一个文本文件，你可以这样写：

using System.Diagnostics;
// ...
Process.Start("notepad.exe", @"C:\Users\你的用户名\Desktop\test.txt");
*/
