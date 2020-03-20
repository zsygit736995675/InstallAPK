using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class 测试 : MonoBehaviour {
    string path;
    AndroidJavaClass javaClass;
    // Use this for initialization
    void Start () {
        path = Application.persistentDataPath + "/a.apk";
        print(Application.streamingAssetsPath);// jar:file:///data/app/com.Company.ProductName1-1.apk!/assets
        print(Application.persistentDataPath);// /storage/emulated/0/Android/data/com.Company.ProductName1/files

        javaClass = new AndroidJavaClass("example.administrator.myapplication.MainActivity");

        StartCoroutine(把安装包写入可读写路径());
    }

    IEnumerator 把安装包写入可读写路径()
    {
       
       // FileStream sw=null;
        FileInfo t = new FileInfo(path);
        if (!t.Exists)
        {
            WWW w = new WWW(Application.streamingAssetsPath + "/1.apk");
            yield return w;
            FileStream sw = t.Create();
            sw.Write(w.bytes, 0, w.bytes.Length);
            sw.Close();
            sw.Dispose();
        }
        else
        {
            print("已经存在，");
        }
    }

   public void 点击按钮()
    {
        print(javaClass);
        print(path);    
       bool b = javaClass.CallStatic<bool>("installAPK", path);
        print("是否安装成功：" + b);
    }


   


    // Update is called once per frame
    void Update () {
		
	}
}
