using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : MonoBehaviour
{

    //when the player collides with an enemy, destory the player and instantiate a respawn
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
                Destroy(gameObject);
                LevelManager.instance.Respawn();
        }
    }
}
