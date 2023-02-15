using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    bool canBeDestroyed = false;

    public int scoreValue = 100;

    // Start is called before the first frame update
    void Start()
    {
        Level.instance.AddDestructable();
        if (Level.instance != null)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 17.0f && !canBeDestroyed)
        {
            canBeDestroyed = true;
            
            Gun[] guns = transform.GetComponentsInChildren<Gun>();

            foreach (Gun gun in guns)
            {
                gun.isActive = true;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canBeDestroyed)
        {
            return;
        }

        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null) //&& Level.instance != null)
        {
           
            if (!bullet.isEnemy)
            {
               //Level.instance.AddScore(scoreValue);
                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }
        }
    }

    private void OnDestroy()
    {
       // (Level.instance != null)
       // {if 
            Level.instance.RemoveDestructable();
        //Level.instance.AddScore(scoreValue);
        // }
    }
}