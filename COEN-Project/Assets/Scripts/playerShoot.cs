using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour{
    public float fireRate = 0.2f;
    public Transform GunPoint;
    public GameObject bulletPrefab;

    //change
    //public static playerShoot instance;

    float timeUntilFire;
    public static float ammo = 0;
    PlayerMovement pm;
    //have the point in which the bullet will spawn follow the player's movement
    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        //shoot when the button is pressed but not the cooldown hasn't ended
        if (Input.GetButtonDown("Fire1") && timeUntilFire < Time.time && ammo > 0)
        {
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }

    //spawn a bullet prefab
    void Shoot()
    {
        //spawn the default bullet if facing right. Flip the bullet to fly left if the character is facing left
        float angle = pm.isFacingRight ? 0f : 180f; 
        Instantiate(bulletPrefab, GunPoint.position, Quaternion.Euler(new Vector3(1f, 1f, angle)));
        LevelManager.instance.IncreaseAmmo(-1);
        ammo -= 1;
    }

    public static void AmmoIncrease(int Amount)
    {
        ammo += Amount;
    }
    public static void resetAmmo()
    {
        ammo = 0;
    }

}
