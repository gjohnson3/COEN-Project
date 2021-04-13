using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour{
    //vairabls to control the bullet's speed and damage
    public float bulletSpeed = 15f;
    public float bulletDamage = 10f;
    public Rigidbody2D rb;

    //When the bullet is spawned it will fly to the right by default
    private void FixedUpdate()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    //whenever the bullet hits something, destroy the bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
