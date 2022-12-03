using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCManager : MonoBehaviour
{
    public GameObject dialogImage;
    //public GameObject tipImage;
    //public Text text;
    public float showTime = 4;
    private float showTimer;
    // Start is called before the first frame update
    void Start()
    {
        //tipImage.SetActive(true);
        dialogImage.SetActive(false);
        showTimer = -1;
    }
 
    // Update is called once per frame
    void Update()
    {
        showTimer -= Time.deltaTime;
        if(showTimer<0)
        {
            //tipImage.SetActive(true);
            dialogImage.SetActive(false);
        }
    }
 
    public void ShowDialog()
    {

        print("触发NPC1对话");
        //text.text= "青蛙先生:\n任务已完成，你现在可以进入城堡了!";
        showTimer = showTime;
        dialogImage.SetActive(true);
        //tipImage.SetActive(false);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShowDialog();
    }

}