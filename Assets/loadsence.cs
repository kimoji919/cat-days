using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadsence : MonoBehaviour
{
    public string nextDiary;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("NextBotton", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextBotton()
    {
        SceneManager.LoadScene(nextDiary);
    }
}
