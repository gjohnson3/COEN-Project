using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour{
    public float fireRate = 0.2f;
    public Transform GunPoint;
    public GameObject bulletPrefab;

    float timeUntilFire;
    PlayerMovement pm;
    //have the point in which the bullet will spawn follow the player's movement
    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        //shoot when the button is pressed but not the cooldown hasn't ended
        if (Input.GetMouseButtonDown(0) && timeUntilFire < Time.time)
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
    }

}
