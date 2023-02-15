using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Bullet bullet;
    //Vector2 direction;
    public bool autoShoot = false;

    public float shootIntervalSeconds = 0.5f;
    public float shootDelaySeconds = 2.0f;

    float shootTimer = 0f;

    float delayTimer = 0f;
   
    void Start()
    {
        
    }

    
    void Update()
    {
       // direction = (transform.localRotation * Vector2.right).normalized;
       if (autoShoot)
        {
            if (shootTimer >= shootIntervalSeconds)
            {
                if (shootTimer >= shootIntervalSeconds)
                {
                    Shoot();
                    shootTimer = 0;

                }
                else
                {
                    shootTimer += Time.deltaTime;
                }
            }
            else
            {
                delayTimer += Time.deltaTime;
            }
        }
    }

    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
       // Bullet goBullet = go.GetComponent<Bullet>();
       //goBullet.direction = direction;
    }
}
