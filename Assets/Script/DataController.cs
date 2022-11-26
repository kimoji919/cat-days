using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    // Start is called before the first frame update


    public int healthInital = 0;
    public int health;
    public int score;
    public int MoleRecord = 0;
    public int[] NpcFlag = new int[10];
    public GameObject molePrefab;


    void Awake()
    {
        //创建全局的记录变量,删除重复的变量
        if (GameObject.FindGameObjectsWithTag("Data").Length > 1)
            Destroy(this.gameObject);
        else
        {
            NpcFlag = new int[10];
            DontDestroyOnLoad(this.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //体力记录
        if (GameObject.Find("Player"))
        {
            health = GameObject.Find("Player").GetComponent<Playercontroller>().health;
        }
        else
        {
            health = healthInital;
        }
    }
}
