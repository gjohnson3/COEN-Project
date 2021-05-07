using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int iLevelToLoad;
    public AudioSource noise;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            noise.Play();
            playerShoot.resetAmmo();
            SceneManager.LoadScene(iLevelToLoad);
        }
    }
}
