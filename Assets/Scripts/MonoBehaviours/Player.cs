using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float staminaPoints = 50.0f;
    public float maxStaminaPoints = 100.0f;
    public Inventory playerInventory;
    [HideInInspector]
    public bool bFinishGame;
    [HideInInspector]
    public int coinAllCount = 0;
    public AudioClip pickCoinAudio;
    public AudioClip pickOtherAudio;
    public Item coinItem;

    // Start is called before the first frame update

    void Start()
    {
        bFinishGame = false;
        GameObject[] coins = GameObject.FindGameObjectsWithTag("CoinPickupObject");
        coinAllCount = coins.Length;
        aSource = GetComponent<AudioSource>();
        coinItem.quantity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.X))
        // {
        //     RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
        //     if (hit.collider != null)
        //     {
        //         Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
        //     }
        // }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickupObject") || collision.gameObject.CompareTag("CoinPickupObject"))
        {

            Item hitObject = collision.gameObject.GetComponent<Pickup>().item;
            if (hitObject != null)
            {
                Debug.Log(hitObject.itemName);
                //hitObject.quantity += 1;
                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN:
                        if (pickCoinAudio != null)
                        {
                            aSource.clip = pickCoinAudio;
                            aSource.Play();
                        }
                        hitObject.quantity += 1;
                        if (hitObject.quantity >= coinAllCount)
                        {
                            bFinishGame = true;
                        }
                        break;
                    case Item.ItemType.HEALTH:
                        //if (pickOtherAudio != null)
                        //{
                            //aSource.clip = pickOtherAudio;
                            //aSource.Play();
                        //}
                        //hitObject.quantity += 1;
                        playerInventory.AddItem(hitObject);
                        //AdjustHealthPoints(hitObject.amount);
                        break;
                    case Item.ItemType.STAMINA:
                        //if (pickOtherAudio != null)
                        //{
                          //  aSource.clip = pickOtherAudio;
                           // aSource.Play();
                        //}
                        // hitObject.quantity += 1;
                        playerInventory.AddItem(hitObject);
                        //AdjustStaminaPoints(hitObject.amount);
                        break;
                    case Item.ItemType.COMMONBALL:
                        return;
                    case Item.ItemType.FIREBALL:
                        //if (pickOtherAudio != null)
                        //{
                          //  aSource.clip = pickOtherAudio;
                           // aSource.Play();
                        //}
                        playerInventory.AddItem(hitObject);
                        return;
                    case Item.ItemType.WATERBALL:
                        //if (pickOtherAudio != null)
                        //{
                          //  aSource.clip = pickOtherAudio;
                            //aSource.Play();
                        //}
                        playerInventory.AddItem(hitObject);
                        return;
                    default:
                        break;
                }
                    
            }
            collision.gameObject.SetActive(false);
        }
    }

    public void AdjustHealthPoints(float amount)
    {
        healthPoints += amount;
        Debug.Log("health : " + healthPoints.ToString());
    }

    public void AdjustStaminaPoints(float amount)
    {
        staminaPoints += amount;
        Debug.Log("Stamina : " + healthPoints.ToString());
    }

    override public void CharacterDie()
    {
        base.CharacterDie();
        RPGGameManager.sharedInstance.GameOver(false);
    }
}
