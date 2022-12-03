using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    // Start is called before the first frame update


/*    public int healthInital = 0;
    public float health;*/
    [Header("打地鼠分数")]public int Mole_Score;
    [Header("是否玩过打地鼠")]public bool Mole_Record = false;
    [Header("打地鼠是否完美结局")] public bool Mole_PE = false;
    [Header("下一百层分数")] public float Down_Score;
    [Header("是否玩过下一百层")] public bool Down_Record = false;
    [Header("下一百层是否完美结局")] public bool Down_PE = false;
    [Header("躲避车层分数")] public float Dodge_Score;
    [Header("是否玩过躲避车层")] public bool Dodge_Record = false;
    [Header("躲避车层是否完美结局")] public bool Dodge_PE = false;


    void Awake()
    {
        //创建全局的记录变量,删除重复的变量
        if (GameObject.FindGameObjectsWithTag("Data").Length > 1)
            Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //体力记录
/*        if (GameObject.Find("Player"))
        {
            health = GameObject.Find("Player").GetComponent<Playercontroller>().health;
        }
        else
        {
            health = healthInital;
        }*/
    }
}