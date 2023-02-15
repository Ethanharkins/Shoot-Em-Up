using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    Gun[] guns;

    

    float moveSpeed = 3;

    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;
    bool shoot;
    bool speedUp;

    void Start()
    {
        guns = transform.GetComponentsInChildren<Gun>();

    }


    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        speedUp = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        shoot = Input.GetKeyDown(KeyCode.LeftControl);
        if (shoot)
        {
            shoot = false;
            foreach(Gun gun in guns)
            {
                gun.Shoot();
            }
        }
    }
    private void FixedUpdate()
    {

        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;

        if (speedUp)
        {
            moveAmount *= 3;
        }

        Vector2 move = Vector2.zero;

        if (moveUp)
        {
            move.y += moveAmount;
        }

        if (moveDown)
        {
            move.y -= moveAmount;
        }

        if (moveLeft)
        {
            move.x -= moveAmount;
        }

        if (moveRight)
        {
            move.x += moveAmount;
        }

        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }
       // moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
      //  Debug.Log(moveMagnitude);

        pos += move;

        if (pos.x <= 1.5f)
        {
            pos.x = 1.5f;
        }

        if (pos.x >= 16f)
        {
            pos.x = 16f;
        }

        if (pos.y <= 1f)
        {
            pos.y = 1f;
        }

        if (pos.y >= 9f)
        {
            pos.y = 9f;
        }

        transform.position = pos;
    }
}

