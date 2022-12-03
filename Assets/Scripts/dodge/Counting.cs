using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counting : MonoBehaviour
{
    public TextMeshProUGUI txt;
    [Header("完美结局的分数")]public float PE_Score;

    // Start is called before the first frame update
    void Start()
    {
        LocalValue.score = 0.0f;
        txt = GetComponent<TextMeshProUGUI>();
        if (GameObject.Find("Data"))
        {
            GameObject.Find("Data").GetComponent<DataController>().Dodge_Score = 0;
            GameObject.Find("Data").GetComponent<DataController>().Dodge_Record = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        LocalValue.score += Time.deltaTime;
        txt.text = LocalValue.score.ToString();
        if (GameObject.Find("Data"))
        {
            GameObject.Find("Data").GetComponent<DataController>().Dodge_Score += Time.deltaTime;
            if(GameObject.Find("Data").GetComponent<DataController>().Dodge_Score > PE_Score)
            {
                GameObject.Find("Data").GetComponent<DataController>().Dodge_PE = true;
            }

        }
    }
}
