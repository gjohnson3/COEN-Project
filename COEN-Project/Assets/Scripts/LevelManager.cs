using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;

    public CinemachineVirtualCameraBase cam;

    [Header("Currency")]
    public int currency = 0;
    public Text CurrencyUI;

    [Header("Ammo")]
    public int ammunition = 0;
    public Text AmmoUI;

    private void Awake(){
        instance = this;
    }

    //method to repawn the player at the respawn point
    public void Respawn(){
        GameObject player=Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        cam.Follow = player.transform;
    }
    
    //method to increase the currency count of the UI
    public void IncreaseCurrency(int amount)
    {
        currency += amount;
        CurrencyUI.text = "$" + currency;
    }

    public void IncreaseAmmo(int amount)
    {
        ammunition += amount;
        AmmoUI.text = "Ammo: " + ammunition;
    }



}
