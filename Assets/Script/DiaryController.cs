using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiaryController : MonoBehaviour
{
    [Header("��һ��map����")] public string nextMap;
    [Header("��һ��diary����")] public string nextDiary;
    [Header("��һ��diary����")] public string lastDiary;
    [Header("��ǰ�ڼ�ҳ")] public int page;
    [Header("��һҳ�ļ�ͷ")] public GameObject nextJiantou;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (page == 1)
        {
            if (GameObject.Find("Data").GetComponent<DataController>().Mole_Record)
            {
                nextJiantou.SetActive(true);
            }
        }
        if (page == 2)
        {
            if (GameObject.Find("Data").GetComponent<DataController>().Dodge_Record)
            {
                nextJiantou.SetActive(true);
            }
        }
        if (page == 3)
        {
            Time.timeScale = 1.0f;
            if (GameObject.Find("Data").GetComponent<DataController>().Down_Record)
            {
                nextJiantou.SetActive(true);
            }
        }
        if (page == 4)
        {
            if (GameObject.Find("Data").GetComponent<DataController>().Down_Record)
            {
                nextJiantou.SetActive(true);
            }
        }
        if (page == 5)
        {
            if (GameObject.Find("Data").GetComponent<DataController>().Down_Record)
            {
                nextJiantou.SetActive(true);
            }
        }
    }
    public void PictureBotton()
    {
        SceneManager.LoadScene(nextMap);
    }
    public void NextBotton()
    {
        SceneManager.LoadScene(nextDiary);
    }
    public void LastBotton()
    {
        SceneManager.LoadScene(lastDiary);
    }
}
