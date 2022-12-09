using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiaryController : MonoBehaviour
{
    [Header("下一个map名称")] public string nextMap;
    [Header("下一个diary名称")] public string nextDiary;
    [Header("上一个diary名称")] public string lastDiary;
    [Header("当前第几页")] public int page;
    [Header("下一页的箭头")] public GameObject nextJiantou;
    public GameObject text;
    public GameObject 提示;
    public GameObject pl;
    public GameObject head;
    public GameObject newtext;
    public GameObject newpicture;
    public GameObject newhead;
    // Start is called before the first frame update
    void Start()
    {
        if (page == 1)
        {
            if (GameObject.Find("Data").GetComponent<DataController>().Mole_Record)
            {
                nextJiantou.SetActive(true);
                提示.SetActive(false);
                if(GameObject.Find("Data").GetComponent<DataController>().Mole_PE)
                {
                    text.SetActive(false);
                    newtext.SetActive(true);
                    pl.SetActive(false);
                    newpicture.SetActive(true);
                    head.SetActive(false);
                    newhead.SetActive(true);
                }
                else
                {
                    text.SetActive(true);
                }

                if (GameObject.Find("Data").GetComponent<DataController>().Dodge_Record)
                {
                    text.GetComponent<CharForeach>().enabled = false;
                }

            }
        }
        if (page == 2)
        {
            if (GameObject.Find("Data").GetComponent<DataController>().Dodge_Record)
            {
                nextJiantou.SetActive(true);
                if (GameObject.Find("Data").GetComponent<DataController>().Dodge_PE)
                {
                    text.SetActive(false);
                    newtext.SetActive(true);
                    pl.SetActive(false);
                    newpicture.SetActive(true);
                    head.SetActive(false);
                    newhead.SetActive(true);
                }
                else
                {
                    text.SetActive(true);
                }
                if (GameObject.Find("Data").GetComponent<DataController>().Down_Record)
                {
                    text.GetComponent<CharForeach>().enabled = false;
                }
            }
        }
        if (page == 3)
        {
            Time.timeScale = 1.0f;
            if (GameObject.Find("Data").GetComponent<DataController>().Down_Record)
            {
                nextJiantou.SetActive(true);
                if (GameObject.Find("Data").GetComponent<DataController>().Down_PE)
                {
                    text.SetActive(false);
                    newtext.SetActive(true);
                    pl.SetActive(false);
                    newpicture.SetActive(true);
                    head.SetActive(false);
                    newhead.SetActive(true);
                }
                else
                {
                    text.SetActive(true);
                }
                if (GameObject.Find("Data").GetComponent<DataController>().Map4_Record)
                {
                    text.GetComponent<CharForeach>().enabled = false;
                }
            }
        }
        if (page == 4)
        {
            if (GameObject.Find("Data").GetComponent<DataController>().Map4_Record)
            {
                nextJiantou.SetActive(true);
                if (GameObject.Find("Data").GetComponent<DataController>().Map4_PE)
                {
                    text.SetActive(false);
                    newtext.SetActive(true);
                    pl.SetActive(false);
                    newpicture.SetActive(true);
                    head.SetActive(false);
                    newhead.SetActive(true);
                }
                else
                {
                    text.SetActive(true);
                }

                if (GameObject.Find("Data").GetComponent<DataController>().Map5_Record)
                {
                    text.GetComponent<CharForeach>().enabled = false;
                }
            }
        }
        if (page == 5)
        {
            if (GameObject.Find("Data").GetComponent<DataController>().Map5_Record)
            {
                nextJiantou.SetActive(true);
                if (GameObject.Find("Data").GetComponent<DataController>().Map5_Record)
                {
                    text.SetActive(false);
                    newtext.SetActive(true);
                    pl.SetActive(false);
                    newpicture.SetActive(true);
                    head.SetActive(false);
                    newhead.SetActive(true);
                }
                else
                {
                    text.SetActive(true);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(page == 4)
        {
            GameObject.Find("Data").GetComponent<DataController>().Map4_Record = true;
        }
        if (page == 5)
        {
            GameObject.Find("Data").GetComponent<DataController>().Map5_Record = true;
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
