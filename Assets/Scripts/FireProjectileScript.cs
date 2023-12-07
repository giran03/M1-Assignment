using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileScript : MonoBehaviour
{
    [Header("Projectile Settings")]
    public float projectileSpeed = 15000f;
    public GameObject cannon_ball;
    bool hasFired = false;
    private float fireCooldown = .3f;
    private float lastFired = 0f;
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && Time.time > lastFired + fireCooldown )
        {
            hasFired = true;
            lastFired = Time.time;
        }
    }

    private void FixedUpdate() {

        if(!hasFired) { return; };

        GameObject cannonBall = Instantiate(cannon_ball, transform.position, transform.rotation);
        cannonBall.GetComponent<Rigidbody>().AddForce(transform.up * projectileSpeed);

        hasFired = false;
    }
}
