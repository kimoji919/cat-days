using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    private Material background;

    public float xSpeed;

    public float ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<DownStairsPlayerController>().scorePoint < GameObject.Find("GameManager").GetComponent<DownStairsManager>().endScore)
        {
            background.mainTextureOffset = new Vector2(xSpeed * Time.time, ySpeed * Time.time);
        }
    }
}