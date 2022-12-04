using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DownStairsManager : MonoBehaviour
{
    [Header("平台生成位置")] public Transform generateLine;

    [Header("游戏面板")] public GameObject gamePanel;
    [Header("游戏分数")] public Text scoreText;
    [Header("玩家")] public GameObject player;
    [Header("地面")]public GameObject Gound;
    [Header("结束分数")] public int endScore = 30;
    [Header("下一个Scene")] public string GameScene;

    private static DownStairsManager _instance;
    public List<GameObject> platformList;
    public List<GameObject> trapList;
    public float offsetY = 3;

    private bool pause;
    private DownStairsPlayerController _playerController;

    public float
        maxPlayformCount,
        timeDuration,
        randomTime,
        minRandomTime,
        maxRandomTime,
        generatePlatformCount;
    int groundCount=0;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }

        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        randomTime = Random.Range(minRandomTime, maxRandomTime);
        _playerController = player.GetComponent<DownStairsPlayerController>();
        if (GameObject.Find("Data"))
        {
            GameObject.Find("Data").GetComponent<DataController>().Down_Record = true;
            GameObject.Find("Data").GetComponent<DataController>().Down_Score = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_instance._playerController.scorePoint < endScore)
        {
            GeneratePlatform();
            GenerateTrap();
        }
        else
        {
            if (groundCount==0)
            {
                GenerateGround();
                groundCount++;
            }
            if (_instance._playerController.scorePoint > endScore + 5f)
            {
                ShowGamePanel();
                if (GameObject.Find("Data"))
                {
                    GameObject.Find("Data").GetComponent<DataController>().Down_PE = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            ShowGamePanel();
    }

    private void GenerateTrap()
    {
        //生成一定平台数量就生成一个陷阱
        if (generatePlatformCount >= maxPlayformCount)
        {
            var randomPosition = new Vector3(Random.Range(-offsetY, offsetY), generateLine.position.y,
                transform.position.y);
            Instantiate(trapList[Random.Range(0, trapList.Count)], randomPosition, Quaternion.identity);
            generatePlatformCount = 0;
        }
    }

    /**
     * 生成平台
     */
    private void GeneratePlatform()
    {
        timeDuration += Time.deltaTime;
        if (timeDuration > randomTime)
        {
            timeDuration = 0;
            randomTime = Random.Range(minRandomTime, maxRandomTime);
            var randomPosition = new Vector3(Random.Range(-offsetY, offsetY), generateLine.position.y,
                transform.position.y);
            Instantiate(platformList[Random.Range(0, platformList.Count)], randomPosition, Quaternion.identity);
            generatePlatformCount++;
        }
    }
    /**
     * 生成地面，结束游戏
     */
    private void GenerateGround()
    {
        Instantiate(Gound);
    }

    /**
     * 暂停游戏
     */
    public static void PauseGame()
    {
        Time.timeScale = 0;
    }


    /**
     * 显示游戏面板
     */
    public static void ShowGamePanel()
    {
        _instance.scoreText.text = _instance._playerController.scorePoint.ToString(CultureInfo.InvariantCulture);
        _instance.gamePanel.SetActive(true);
        PauseGame();
    }

    /**
     * 继续游戏
     */
    public void ResumeGame()
    {
        Debug.Log("ResumeGame");
        Time.timeScale = 1;
        //如果玩家已dead 重新开始游戏
        if (_playerController.dead)
        {
            RestartGame();
        }
        _instance.gamePanel.SetActive(false);
    }

    /**
     * 重新开始游戏
     */
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /**
     * 退出游戏
     */
    public void QuitGame()
    {
        SceneManager.LoadScene(GameScene);
        Destroy(GameObject.Find("SoundManager"));
        Time.timeScale = 1;
    }
}