using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour{
    public float fireRate = 0.2f;
    public Transform GunPoint;
    public GameObject bulletPrefab;

    float timeUntilFire;
    PlayerMovement pm;

    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && timeUntilFire < Time.time)
        {
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        float angle = pm.isFacingRight ? 0f : 180f; 
        Instantiate(bulletPrefab, GunPoint.position, Quaternion.Euler(new Vector3(1f, 1f, angle)));
    }

}
