﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Item coinItem;
    private Player player;
    public Image healthMeter;
    public Image staminaMeter;
    public Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
          
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            healthMeter.fillAmount = player.healthPoints / player.maxHealthPoints;
            staminaMeter.fillAmount = player.staminaPoints / player.maxStaminaPoints;
            coinText.text = "" + coinItem.quantity+"/"+player.coinAllCount;
        }
        else {
            // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            healthMeter.fillAmount = 0;
        }
    }
}
