using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    bool canBeDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        Level.instance.AddEnemy();
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
        if (bullet != null)
        {
            if (!bullet.isEnemy) {
                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        Level.instance.RemoveEnemy();
    }
}
