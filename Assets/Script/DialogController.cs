using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogController : MonoBehaviour
{

    public Button close;

    public GameObject Box;

    [Header("小游戏的Scene名称")]public string GameScene;

    [Header("下一个的dialog名称")] public GameObject Nextdialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickClose()
    {
        Box.SetActive(false);
    }

    public void OnclickGame()
    {
        Box.SetActive(false);
        SceneManager.LoadScene(GameScene);
    }
    public void Onclicknext()
    {
        Box.SetActive(false);
        Nextdialog.SetActive(true);
    }
}
