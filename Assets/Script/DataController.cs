using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    // Start is called before the first frame update


/*    public int healthInital = 0;
    public float health;*/
    [Header("��������")]public int Mole_Score;
    [Header("�Ƿ���������")]public bool Mole_Record = false;
    [Header("������Ƿ��������")] public bool Mole_PE = false;
    [Header("��һ�ٲ����")] public float Down_Score;
    [Header("�Ƿ������һ�ٲ�")] public bool Down_Record = false;
    [Header("��һ�ٲ��Ƿ��������")] public bool Down_PE = false;
    [Header("��ܳ������")] public float Dodge_Score;
    [Header("�Ƿ������ܳ���")] public bool Dodge_Record = false;
    [Header("��ܳ����Ƿ��������")] public bool Dodge_PE = false;


    void Awake()
    {
        //����ȫ�ֵļ�¼����,ɾ���ظ��ı���
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
        //������¼
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