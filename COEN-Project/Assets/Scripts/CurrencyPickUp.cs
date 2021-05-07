using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyPickUp : MonoBehaviour
{
    //Int so that the value of each coin can be changed without making a different code for each one
    public int worth = 100;


    //When the player and coin collide, destory the coin the add its worth to the money count
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            LevelManager.instance.IncreaseCurrency(worth);
        }
    }
}
