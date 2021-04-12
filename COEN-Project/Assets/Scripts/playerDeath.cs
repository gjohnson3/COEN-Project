using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //if (currency > 0)
           // {
             //   LevelManager.instance.IncreaseCurrency(-100);
            //}
            //else
            //{
                Destroy(gameObject);
                LevelManager.instance.Respawn();
            //}
        }
    }
}
