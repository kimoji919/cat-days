using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class 对话控制器 : MonoBehaviour
{
    public Button close;

    public GameObject Box;
    [Header("开局dialog")] public GameObject firstdialog;
    [Header("下一个的dialog名称")] public GameObject Nextdialog;
    public bool isfirstdialog;
   
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Show", 2);
    }
    void Show()
    {
        if (isfirstdialog)
        {
            firstdialog.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void OnclickClose()
    {
        Box.SetActive(false);
    }
    public void Onclicknext()
    {
        Box.SetActive(false);
        Nextdialog.SetActive(true);
    }
}
